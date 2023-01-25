using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PL
{
    /// <summary>
    /// Interaction logic for Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {

        BackgroundWorker bw = new BackgroundWorker();
        Stopwatch sw = new();     
        private bool isRunTime=true;

        public int  orderId
        {
            get { return (int )GetValue(orderIdProperty); }
            set { SetValue(orderIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for orderId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty orderIdProperty =
            DependencyProperty.Register("orderId", typeof(int ), typeof(Window), new PropertyMetadata(null));


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

        public Simulator()
        {
            InitializeComponent();
            sw.Start();
            treated = false;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_runWorker;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }

        private void bw_runWorker(object? sender, RunWorkerCompletedEventArgs e)
        {

            simulator.Simulator.unRegisterReaport1(doReaport1);
            simulator.Simulator.unRegisterReaport2(doReaport2);
            simulator.Simulator.unRegisterReaport3(doReaport3);
        }

        private void bw_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage==0)
            {
                string txtTimer = sw.Elapsed.ToString();
                txtTimer = txtTimer.Substring(0, 8);
                txtSimulation.Text = txtTimer;
            }                   
        }

        private void bw_DoWork(object? sender, DoWorkEventArgs e)
        {
           
            simulator.Simulator.registerReaport1(doReaport1);
            simulator.Simulator.registerReaport2(doReaport2);
            simulator.Simulator.registerReaport3(doReaport3);
            while (isRunTime)
            {
                bw.ReportProgress(1);
                Thread.Sleep(1000);
            }
            simulator.Simulator.activate();
            while (bw.CancellationPending == false)
            {
                Thread.Sleep(1000);
                bw.ReportProgress(0);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            sw.Stop();  
            isRunTime = false;
            Close();
        }

        private void doReaport1(int id, DateTime? d, DateTime? l, BO.Enums.OrderStatus s)
        {
            orderId = id;
            timeNow = d;
            timeAfter = l;
            oStatus = s;
        }
        private void doReaport2()
        {
            treated = true;
        }
        private void doReaport3(string str)
        {
            MessageBox.Show(str);
        }



    }
}
