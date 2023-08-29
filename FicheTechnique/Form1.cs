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
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace FicheTechnique
{
    public partial class Form1 : Form
    {
        public static ulong Ram;

        Form2 form2 = new Form2();
        
        public Form1()
        {
            InitializeComponent();
        }

        public void getCpuName()
        {
            ManagementObjectSearcher mos =
           new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                lbCPU.Text = (string)mo["Name"];

            }

        }
        public void getAvailableRAM()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject mo in mos.Get())
            {
                ulong speed = ulong.Parse(mo["Speed"].ToString());
                lbMemorySpeed.Text = speed.ToString() + " MHz";
            }

            ComputerInfo CI = new ComputerInfo();
            ulong mem = ulong.Parse(CI.TotalPhysicalMemory.ToString());
            lbMemorySize.Text = (mem / (1024 * 1024) + " MB").ToString();
            
        }
        public void getStorage()
        {
             int i = 0;
             ulong[] storage = new ulong[10];
             string[] DiskNames = new string[10];
        ManagementObjectSearcher mos1 =
           new ManagementObjectSearcher("root\\CIMV2", @"SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject mo in mos1.Get())
            {
                DiskNames[i] = (string)mo["Model"];
                storage[i] = ulong.Parse(mo["Size"].ToString());
                
                i++;
            }
            lbDiskName.Text = DiskNames[0];
            lbDiskName1.Text = DiskNames[1];
            lbDiskSize.Text = (storage[0] / (1000 * 1000 * 1000) + " GB").ToString();
            lbDiskSize1.Text = (storage[1] / (1000 * 1000 * 1000) + " GB").ToString();
        }
        public void getGpuName()
        {
            int i = 0;
            string[] gpu = new string[10];
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            foreach(ManagementObject mo in mos.Get())
            {
              gpu[i] = mo["Name"].ToString();
              i++;
            }
            lbGPUName.Text = gpu[0];
            lbGPUName1.Text = gpu[1];
        }
        public void getCurrentResolution()
        {
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            lbRes.Text = ("Resolution: " + screenWidth + " x" + screenHeight);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
           

            getCpuName();
            getStorage();
            getAvailableRAM();
            getGpuName();
            getCurrentResolution();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure", "Exiting software", MessageBoxButtons.OKCancel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
    }
}
