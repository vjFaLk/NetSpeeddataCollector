using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace NetSpeedDataCollector
{
    public partial class Form1 : Form
    {            
        private NetworkInterface[] nicArr;
        private const double TimerUpdate = 1000;
        private const double DataUpdate = 600000;
        private Timer NetSpeedTimer;
        private double bytesRecieved = 0;
        private int maxSpeed = 0;
        private int avgSpeed = 0;
        
    

        public Form1()
        {
            InitializeComponent();
            InitializeNetworkInterface();
            InitializeTimer();
            
        }


        private void InitializeTimer()
        {
            NetSpeedTimer = new Timer();
            NetSpeedTimer.Interval = (int)TimerUpdate;
            NetSpeedTimer.Tick += new EventHandler(timer_Tick);
            NetSpeedTimer.Start();

            NetDataInputTimer = new Timer();
            NetDataInputTimer.Interval = (int)DataUpdate;
            NetDataInputTimer.Tick += new EventHandler(data_tick);
            NetDataInputTimer.Start();
        }

        private void data_tick(object sender, EventArgs e)
        {
            DatabaseHelper data = new DatabaseHelper();
            data.Insert(maxSpeed, avgSpeed);
            
        }

       


        private void InitializeNetworkInterface()
        {
            nicArr = NetworkInterface.GetAllNetworkInterfaces();

            // Add each interface name to the combo box
            for (int i = 0; i < nicArr.Length; i++)
                InterfacePickerCB.Items.Add(nicArr[i].Name);

            // Change the initial selection to the first interface
            InterfacePickerCB.SelectedIndex = 4;
       
        }

        private void UpdateNetworkInterface()
        {
            // Grab NetworkInterface object that describes the current interface
            NetworkInterface NetInterface = nicArr[InterfacePickerCB.SelectedIndex];

            // Grab the stats for that interface
            IPv4InterfaceStatistics interfaceStats = NetInterface.GetIPv4Statistics();
        
         
            int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - bytesRecieved) / 1024;
            bytesRecieved = interfaceStats.BytesReceived;

            // Update the labels              
            downLabel.Text = bytesReceivedSpeed.ToString() + " KB/s";

            if (bytesReceivedSpeed < 1000)
            {

                avgSpeed += bytesReceivedSpeed;
                avgSpeed /= 2;

                if (bytesReceivedSpeed > maxSpeed)
                {
                    maxSpeed = bytesReceivedSpeed;
                }
            }
        }




        void timer_Tick(object sender, EventArgs e)
        {
            UpdateNetworkInterface();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.notifyIcon.BalloonTipText = "Monitoring";
                this.notifyIcon.BalloonTipTitle = "Dynamic Synchronous Internet Speed Data Collector Ultimate 3000™ ©";
             
                notifyIcon.ShowBalloonTip(500);            
                this.Hide();
            }
          
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }



    }
}
