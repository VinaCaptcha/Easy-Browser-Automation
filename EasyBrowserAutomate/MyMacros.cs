using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

// Mouse Hook supported
// Hotkey supported
// Window supported
using ManagedWinapi.Windows;

// Mouse Hook and Keyboard Hook - Not Work for .NET 4.0
// Simulator Mouse and Keyboard - Worked but don't press a text.
// Scroll Supported
using InputManager;

// Simulator Keyboard only - Worked have press a text.
//InputSimulator.0.1.0.0-bin
using WindowsInput;

namespace EasyBrowserAutomation
{
    public class MyMacros
    {
        #region Status
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, "EasyBrowserAutomation");
        }

        public static void UpdateStatus(string status, string message)
        {
            Program.fmain.UpdateStatus(status, message);
        }
        #endregion

        #region Timer
        public static void Delay(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        #endregion

        #region Mouse
        public static void Click(int x, int y)
        { 
            
        }

        #endregion

    }
}
