using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace PL;

/// <summary>
/// Interaction logic for Simulator.xaml
/// </summary>
public partial class Simulator : Window
{

    BackgroundWorker bw = new BackgroundWorker();
    Stopwatch sw = new();
    private bool isRunTime = true;

    public int orderId
    {
        get { return (int)GetValue(orderIdProperty); }
        set { SetValue(orderIdProperty, value); }
    }

    // Using a DependencyProperty as the backing store for orderId.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty orderIdProperty =
        DependencyProperty.Register("orderId", typeof(int), typeof(Window), new PropertyMetadata(null));


    public DateTime? timeNow
    {
        get { return (DateTime?)GetValue(timeNowProperty); }
        set { SetValue(timeNowProperty, value); }
    }

    // Using a DependencyProperty as the backing store for timeNow.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty timeNowProperty =
        DependencyProperty.Register("timeNow", typeof(DateTime?), typeof(Window), new PropertyMetadata(null));

    public DateTime? timeAfter
    {
        get { return (DateTime?)GetValue(timeAfterProperty); }
        set { SetValue(timeAfterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for timeAfter.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty timeAfterProperty =
        DependencyProperty.Register("timeAfter", typeof(DateTime?), typeof(Window), new PropertyMetadata(null));



    public BO.Enums.OrderStatus oStatus
    {
        get { return (BO.Enums.OrderStatus)GetValue(oStatusProperty); }
        set { SetValue(oStatusProperty, value); }
    }

    // Using a DependencyProperty as the backing store for oStatus.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty oStatusProperty =
        DependencyProperty.Register("oStatus", typeof(BO.Enums.OrderStatus), typeof(Window), new PropertyMetadata(null));

    public bool treated
    {
        get { return (bool)GetValue(treatedProperty); }
        set { SetValue(treatedProperty, value); }
    }

    // Using a DependencyProperty as the backing store for treated.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty treatedProperty =
        DependencyProperty.Register("treated", typeof(bool), typeof(Window), new PropertyMetadata(false));




    public string timetxt
    {
        get { return (string)GetValue(timetxtProperty); }
        set { SetValue(timetxtProperty, value); }
    }

    // Using a DependencyProperty as the backing store for timetxt.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty timetxtProperty =
        DependencyProperty.Register("timetxt", typeof(string), typeof(Window), new PropertyMetadata(null));



    public string statusAfter
    {
        get { return (string)GetValue(statusAfterProperty); }
        set { SetValue(statusAfterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for statusAfter.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty statusAfterProperty =
        DependencyProperty.Register("statusAfter", typeof(string), typeof(Window), new PropertyMetadata(null));



    public string statusBefore
    {
        get { return (string)GetValue(statusBeforeProperty); }
        set { SetValue(statusBeforeProperty, value); }
    }

    // Using a DependencyProperty as the backing store for statusBefore.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty statusBeforeProperty =
        DependencyProperty.Register("statusBefore", typeof(string), typeof(Window), new PropertyMetadata(null));




    public string progResult
    {
        get { return (string)GetValue(progResultProperty); }
        set { SetValue(progResultProperty, value); }
    }

    // Using a DependencyProperty as the backing store for progResult.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty progResultProperty =
        DependencyProperty.Register("progResult", typeof(string), typeof(Window), new PropertyMetadata(null));



    public int progbar
    {
        get { return (int)GetValue(progbarProperty); }
        set { SetValue(progbarProperty, value); }
    }

    // Using a DependencyProperty as the backing store for progbar.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty progbarProperty =
        DependencyProperty.Register("progbar", typeof(int), typeof(Window), new PropertyMetadata(null));



    private void updateStatus(BO.Enums.OrderStatus s)
    {
        if (s == BO.Enums.OrderStatus.Ordered)
        {
            statusBefore = "Ordered";
            statusAfter = "shiped";
        }
        if (s == BO.Enums.OrderStatus.Shipped)
        {
            statusBefore = "shiped";
            statusAfter = "deliverd";
        }
    }



    public Simulator()
    {
        InitializeComponent();
        sw.Start();
        treated = false;
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
        bw.RunWorkerCompleted += bw_runWorker;
        bw.WorkerSupportsCancellation = true;
        bw.WorkerReportsProgress = true;
        bw.RunWorkerAsync();
        timetxt = "00:00";
        orderId = 0;
        timeAfter = DateTime.Now;
        timeNow = DateTime.Now;
        treated = false;
        oStatus = BO.Enums.OrderStatus.Ordered;
    }

    private void bw_runWorker(object? sender, RunWorkerCompletedEventArgs e)
    {

        simulator.Simulator.unRegisterReaport1(doReaport1);
        simulator.Simulator.unRegisterReaport2(doReaport2);
        simulator.Simulator.unRegisterReaport3(doReaport3);
    }

    private void bw_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        switch (e.ProgressPercentage)
        {
            case 0:
                string txtTimer = sw.Elapsed.ToString();
                timetxt = txtTimer.Substring(0, 8);
                break;
            case 1:
                orderId = currId;
                timeNow = cuurTimeNow;
                timeAfter = cuurTimeAfter;
                oStatus = status;
                break;
            case 2:
                treated = currTreated;
                break;
            case 3:
                break;
            case 4:
                int progress = int.Parse(e.UserState.ToString());
                progResult = (progress + "%");
                progbar = progress;
                break;
        }
    }

    private void bw_DoWork(object? sender, DoWorkEventArgs e)
    {

        simulator.Simulator.registerReaport1(doReaport1);
        simulator.Simulator.registerReaport2(doReaport2);
        simulator.Simulator.registerReaport3(doReaport3);
        simulator.Simulator.activate();
        while (isRunTime)
        {
            e.Cancel = true;
            break;
        }

        while (bw.CancellationPending == false)
        {

            bw.ReportProgress(0);
            Thread.Sleep(1000);
        }
        int length = 10;
        for (int i = 1; i <= length; i++)
        {
            if (bw.CancellationPending == true)
            {
                e.Cancel = true;
                e.Result = sw.ElapsedMilliseconds; // Unnecessary
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                bw.ReportProgress(4, i * 100 / length);
            }
        }
        e.Result = sw.ElapsedMilliseconds;

    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        sw.Stop();
        isRunTime = false;
        Closing -= Window_Closing;

    }

    int currId;
    DateTime? cuurTimeNow;
    DateTime? cuurTimeAfter;
    BO.Enums.OrderStatus status;
    private void doReaport1(int id, DateTime? d, DateTime? l, BO.Enums.OrderStatus s)
    {
        currId = id;
        cuurTimeNow = d;
        cuurTimeAfter = l;
        status = s;
        bw.ReportProgress(1);



    }
    bool currTreated;
    private void doReaport2()
    {
        currTreated = true;
        bw.ReportProgress(2);
    }
    private void doReaport3(string str)
    {
        MessageBox.Show(str);
        bw.ReportProgress(3);
    }


}





