using Microsoft.PointOfService;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDrawerCash
{
    public partial class Form1 : Form
    {
        //NET USE LPT1: \\DESKTOP-OC73CUF\XP-58 /PERSISTENT:YES

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);


        public Form1()
        {
            InitializeComponent(); 
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Print();
        }


       
        public static bool Print()
        {
            bool IsConnected = false;
            try
            {
                byte[] buffer = new byte[5]
                {
                  (byte) 27,
                  (byte) 112,
                  (byte) 0,
                  (byte) 25,
                  (byte) 250
                 };

                SafeFileHandle fh = CreateFile("LPT1:XP-58", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                if (!fh.IsInvalid)
                {
                    IsConnected = true;
                    FileStream lpt1 = new FileStream(fh, FileAccess.ReadWrite);
                    lpt1.Write(buffer, 0, buffer.Length);
                    lpt1.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return IsConnected;
        }
    }
}
