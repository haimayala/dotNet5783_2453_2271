using System.Runtime.CompilerServices;
using BO;
namespace simulator;

public static class Simulator
{
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
    private static readonly Random s_rund = new();
    private static volatile bool Activate;

    public  delegate void Reaport1(int id, DateTime? d, DateTime? l, BO.Enums.OrderStatus s);
   public static Reaport1 reaport1;
    public  delegate void Reaport2();
    public static Reaport2 reaport2;
    public  delegate void Reaport3(string msg);
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