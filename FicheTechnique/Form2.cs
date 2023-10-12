using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.CodeDom;

namespace FicheTechnique
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       
        //fetch the battery informations
        public static ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");

        //file path for the battery test result text file. this is the active user directory
        public static string filename = @"C:\Users\" + Environment.GetEnvironmentVariable("Username") + "\\Battery_Test_Result.txt";
        public static string graphPath = @"C:\Users\" + Environment.GetEnvironmentVariable("Username") + "\\Graph.png";
        public static double[] y;
        public static double[] x;
        public static int timerTicCount = 0;
        public static int i = 0;
        public static int j = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("This test will register the device's battery percentage every 30 min in a text file until the computer shuts down. Try running multiple tasks so the test is more accurate. Do you want to proceed", "Battery Test", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                //gets the estimated charge remaining in the battery to display it into a label
                foreach (ManagementObject mo in mos.Get())
                {


                    lbInitialCharge.Text += mo["EstimatedChargeRemaining"].ToString();
                }

                try
                {
                    //deletes file if it already exists
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }

                    //creates the text file and writes the title
                    using (StreamWriter sw = new StreamWriter(filename, true))
                    {
                        
                        sw.WriteLine(lbInitialCharge.Text);
                        sw.Close();
                    }



                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
                //disables the start button so the user doesn't start the test twice
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                //timer start
                timerBattery.Enabled = true;
                timerBattery.Start();

            }



        }

        private void timerBattery_Tick(object sender, EventArgs e)
        {
        
            
           

            foreach (ManagementObject mo in mos.Get())
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(filename, true))
                    {
                        sw.WriteLine(mo["EstimatedChargeRemaining"].ToString());
                        sw.Close();
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
            if (testStop())
            {
                createGraph();
            }
            timerTicCount++;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerBattery.Stop();
            timerBattery.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
           
        }

        public bool testStop()
        {
            bool stopped = false;
            foreach(ManagementObject mo in mos.Get())
            {
                if ((long)mo["EstimatedChargeRemaining"] <= 20)
                {
                    timerBattery.Stop();
                    timerBattery.Enabled = false;
                    stopped = true;
                }
            }
            return stopped;
        }
        public void createGraph()
        {
            y = new double[timerTicCount];
            x = new double[timerTicCount];
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    var lines = File.ReadLines(filename);

                    foreach (var line in lines)
                    {
                        y[i] = double.Parse(line.Trim());
                        x[i] = j;
                        i++;
                        j += 30;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            fpBatteryDecay.Plot.XLabel("time");
            fpBatteryDecay.Plot.YLabel("charge");
            fpBatteryDecay.Plot.AddScatter(x, y);
            fpBatteryDecay.Plot.XAxis.ManualTickSpacing(30);
            fpBatteryDecay.Refresh();
            fpBatteryDecay.Visible = true;
            fpBatteryDecay.Plot.SaveFig(graphPath);
            System.Diagnostics.Process.Start(graphPath);
        }
    }
}
