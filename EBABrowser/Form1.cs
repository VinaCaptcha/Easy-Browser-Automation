using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Diagnostics;
using System.Runtime.InteropServices;


namespace EBABrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        [DllImport("EBACore.dll")]
        public static extern void DisplayHelloFromDLL([MarshalAs(UnmanagedType.LPWStr)] string wchar_t);

        [DllImport("EBACore.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string ReturnTextUnicode([MarshalAs(UnmanagedType.LPStr)] string BStr, int InputNumber);

        [DllImport("EBACore.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string ReturnTextUnicode2([MarshalAs(UnmanagedType.LPWStr)] string wchar_t);



        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        /// <summary>
        /// Returns volume from 0 to 10
        /// </summary>
        /// <returns>Volume from 0 to 10</returns>
        public static int GetVolume()
        {
            uint CurrVol = 0;
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            int volume = CalcVol / (ushort.MaxValue / 10);
            return volume;
        }

        /// <summary>
        /// Sets volume from 0 to 10
        /// </summary>
        /// <param name="volume">Volume from 0 to 10</param>
        public static void SetVolume(int volume)
        {
            int NewVolume = ((ushort.MaxValue / 10) * volume);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //C++ Testing
            DisplayHelloFromDLL("Phưỡng");

            string s1 = ReturnTextUnicode("ABC000 - ", 88);
            Console.WriteLine(s1);

            s1 = ReturnTextUnicode("Phưỡng - ", 99);
            Console.WriteLine(s1);

            string s2 = ReturnTextUnicode2("Phưỡng");
            Console.WriteLine(s2);


            
            //SetVolume(0);



            
        }

   

    }
}
