using System.Runtime.CompilerServices;
using BO;
namespace simulator;

public static class Simulator
{
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
    private static readonly Random s_rund = new();
    private static volatile bool Activate;

    public delegate void Reaport1(int id, DateTime? d, DateTime? l, BO.Enums.OrderStatus s);
    public static Reaport1 reaport1;
    public delegate void Reaport2();
    public static Reaport2 reaport2;
    public delegate void Reaport3(string msg);
    private static Reaport3 reaport3;

    public static void activate()
    {
        Activate = true;
        new Thread(() =>
        {

            while (Activate)
            {
                try
                {
                    int orderId = bl.Order.OrderOldest();
                    if(orderId ==-1)
                    {
                        reaport3("finish simulation");
                        return;
                    }
                       
                    var order = bl.Order.GetOrderDetails(orderId);
                    int dilay = s_rund.Next(3, 11);
                    DateTime? time = DateTime.Now + TimeSpan.FromSeconds(dilay) * 1000;
                    if (order.ShipDate == null)
                    {
                        reaport1(orderId, DateTime.Now, time, (Enums.OrderStatus)order.Status);
                        Thread.Sleep(dilay * 1000);
                        bl.Order.UppdateShipDate(orderId);
                        reaport2();
                    }

                    else
                    {
                        reaport1(orderId, DateTime.Now, time, (Enums.OrderStatus)order.Status);
                        Thread.Sleep(dilay * 1000);
                        bl.Order.UppdateDeliveryDate(orderId);
                        reaport2();
                    }

                }
                catch (BO.BlNotExsistExeption ex)
                {
                    throw new simulator.SimNotExsisExeption(ex.Message);

                }
                Thread.Sleep(1000);
            }

            reaport3("finish simulation");
        }).Start();

    }

    public static void stopActivate()
    {
        Activate = false;
    }
    public static void registerReaport1(Reaport1 func)
    {
        reaport1 += func;
    }
    public static void registerReaport2(Reaport2 func)
    {
        reaport2 += func;
    }
    public static void registerReaport3(Reaport3 func)
    {
        reaport3 += func;
    }
    public static void unRegisterReaport1(Reaport1 func)
    {
        reaport1 -= func;
    }
    public static void unRegisterReaport2(Reaport2 func)
    {
        reaport2 -= func;
    }
    public static void unRegisterReaport3(Reaport3 func)
    {
        reaport3 -= func;
    }
}
//    private static readonly BlApi.IBl? bl = BlApi.Factory.Get();
//    private static volatile bool _shouldStop = false;
//    private static readonly Random random = new Random();
//    private const int SEC = 1000;
//    private static int delay = 0;
//    private static bool finishAll = false;

//    private static event Action s_stopSimulator;

//    public static event Action s_StopSimulator
//    {
//        add => s_stopSimulator += value;
//        remove => s_stopSimulator -= value;
//    }

//    private static event EventHandler? s_report;

//    public static event EventHandler? s_Report
//    {
//        add => s_report += value;
//        remove => s_report -= value;
//    }

//    public static void stopSim()
//    {
//        _shouldStop = true;
//        s_stopSimulator();
//    }

//    public static void simulatorActivate()
//    {
//        new Thread(() =>
//        {
//            try
//            {
//                while (!_shouldStop)
//                {
//                    int? orderId = bl?.Order.OrderOldest();
//                    if (orderId != null)
//                    {
//                        BO.Order order = bl?.Order.GetOrderDetails((int)orderId)!;
//                        delay = random.Next(3, 11);
//                        s_report!(Thread.CurrentThread, new ReportArgs(delay, order));
//                        Thread.Sleep(delay * 1000);

//                        if (order.ShipDate == null)
//                            bl?.Order.UppdateShipDate((int)orderId);
//                        else
//                            bl?.Order.UppdateDeliveryDate((int)orderId);
//                        if (!_shouldStop)
//                            s_report(Thread.CurrentThread, new ReportArgs("Finish order progress"));
//                    }
//                    else
//                    {
//                        _shouldStop = true;
//                        finishAll = true;
//                    }
//                    Thread.Sleep(SEC);
//                }
//                if (_shouldStop && finishAll)
//                    s_report!(Thread.CurrentThread, new ReportArgs("Finish simulation"));
//                _shouldStop = false;

//            }
//            catch (Exception)
//            {
//                throw new Exception();
//            }
//        }).Start();

//    }
//}




 