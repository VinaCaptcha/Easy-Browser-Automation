using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Runtime.InteropServices;

// Mouse Hook supported
// Hotkey supported
// Window supported
using ManagedWinapi.Windows;
using ManagedWinapi.Accessibility;

namespace EasyBrowserAutomation
{
    public partial class MouseTools : Form
    {
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar);

        public MouseTools()
        {
            InitializeComponent();
        }

        #region Main Form Close
        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Stop();
            hk.Enabled = false;

            //ExitAnything();
        }
        private void ExitAnything()
        {
            ////MyGlobalSettings.Stop();
            
            //// Kill this Process
            //Process p = null;
            //try
            //{
            //    p = Process.GetCurrentProcess();
            //}
            //catch { }
            //while (p != null)
            //{
            //    try
            //    {
            //        p.Kill();
            //    }
            //    catch { }
            //    try
            //    {
            //        p = Process.GetCurrentProcess();
            //    }
            //    catch { }
            //}

            //Application.ExitThread();
            //Application.Exit();
            //Environment.Exit(-1);
        }
        #endregion

        ManagedWinapi.Hotkey hk = new ManagedWinapi.Hotkey();
        private void MouseTools_Load(object sender, EventArgs e)
        {
            this.Text = "Mouse Tools - " + Application.ProductName + " " + Application.ProductVersion;

            // Set Font Style Size
            tbxEditor.Styles.ResetDefault();
            tbxEditor.Styles.Default.FontName = "Courier New";// "Consolas";
            tbxEditor.Styles.Default.Size = 10;
            tbxEditor.Styles.Default.ForeColor = Color.Black;
            tbxEditor.Styles.ClearAll();

            // Show Line Number
            tbxEditor.Margins[0].Width = 30;
            tbxEditor.Styles.LineNumber.ForeColor = Color.Gray;
            tbxEditor.Caret.HighlightCurrentLine = true;
            tbxEditor.Caret.CurrentLineBackgroundColor = Color.WhiteSmoke;
            tbxEditor.Indentation.TabWidth = 3;

            // Set custom syntax highlighting
            tbxEditor.Lexing.Lexer = ScintillaNET.Lexer.Cpp;
            tbxEditor.Lexing.Keywords[0] = "WINDOW_TITLE PROCESS CONTROL_NAME WINDOW_LOCATION WINDOW_SIZE CONTROL_VALUE CONTROL_DESCRIPTION CONTROL_TITLE ";
            tbxEditor.Lexing.Keywords[1] = "SCREEN_CLICK CONTROL_CLICK ";
            //tbxEditor.Lexing.LineCommentPrefix = "//";
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["DOCUMENT_DEFAULT"]].ForeColor = Color.Silver;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["NUMBER"]].ForeColor = Color.SteelBlue;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["WORD"]].ForeColor = Color.Blue;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["WORD2"]].ForeColor = Color.DeepSkyBlue;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["STRING"]].ForeColor = Color.DarkRed;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["CHARACTER"]].ForeColor = Color.DarkRed;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["VERBATIM"]].ForeColor = Color.DarkRed;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["STRINGEOL"]].ForeColor = Color.DarkRed;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["PREPROCESSOR"]].ForeColor = Color.Maroon;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["OPERATOR"]].ForeColor = Color.Purple;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["IDENTIFIER"]].ForeColor = Color.Black;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["COMMENT"]].ForeColor = Color.Green;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["COMMENTLINE"]].ForeColor = Color.Green;
            tbxEditor.Styles[tbxEditor.Lexing.StyleNameMap["COMMENTLINEDOC"]].ForeColor = Color.Gray;

            // Capture Mouse Position
            timer1.Interval = 100;
            timer1.Start();

            // Set Hot Key = F2
            hk.HotkeyPressed += hk_HotkeyPressed;
            hk.KeyCode = Keys.F2;
            hk.Enabled = true;

        }

        void hk_HotkeyPressed(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            SystemAccessibleObject ctr = null;
            SystemWindow wp = null;
            //SystemWindow sw = SystemWindow.FromPoint(Cursor.Position.X, Cursor.Position.Y);
            try
            {
                ctr = SystemAccessibleObject.FromPoint(Cursor.Position.X, Cursor.Position.Y);
            }
            catch { }

            try
            {
                wp = ctr.Window;
                while (wp.Parent != null && wp.Parent.HWnd != IntPtr.Zero)
                {
                    wp = wp.Parent;
                    Application.DoEvents(); Thread.Sleep(100);
                }
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("WINDOW_TITLE: " + wp.Title);
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("WINDOW_LOCATION: " + wp.Location.X + " x " + wp.Location.Y);
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("WINDOW_SIZE: " + wp.Position.Width + " x " + wp.Position.Height);
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("PROCESS: " + wp.Process.ProcessName + ".exe");
                sb.AppendLine("------------------------------------------------------------------");
                //sb.AppendLine("SCROLLBAR: " + GetScrollPos((IntPtr)0x13004e6, Orientation.Horizontal) + " x " + GetScrollPos((IntPtr)0x13004e6, Orientation.Vertical));
                //sb.AppendLine("SCROLLBAR: " + GetScrollPos(ctr.Window.HWnd, Orientation.Horizontal) + " x " + GetScrollPos(ctr.Window.HWnd, Orientation.Vertical));
                //sb.AppendLine("------------------------------------------------------------------");
                
            }
            catch { }

            try
            {
                sb.AppendLine("CONTROL_NAME: " + ctr.Name);
                sb.AppendLine("------------------------------------------------------------------");
            }
            catch { }

            try
            {
                sb.AppendLine("CONTROL_TITLE: " + ctr.Window.Title);
                sb.AppendLine("------------------------------------------------------------------");
            }
            catch { }

            try
            {
                sb.AppendLine("CONTROL_VALUE: " + ctr.Value);
                sb.AppendLine("------------------------------------------------------------------");
            }
            catch { }

            try
            {
                sb.AppendLine("CONTROL_CLICK: " + (Cursor.Position.X - wp.Location.X) + " x " + (Cursor.Position.Y - wp.Location.Y));
                sb.AppendLine("------------------------------------------------------------------");
            }
            catch { }

            sb.AppendLine("SCREEN_CLICK: " + Cursor.Position.X + " x " + Cursor.Position.Y);
            sb.AppendLine("------------------------------------------------------------------");

            // Draw target control
            try
            {
                WindowDeviceContext hdc = SystemWindow.DesktopWindow.GetDeviceContext(false);
                Graphics g = Graphics.FromHdc(hdc.HDC);
                Rectangle r = ctr.Location;
                g.DrawRectangle(Pens.Red, r.X, r.Y, r.Width, r.Height);
                g.Dispose();
                hdc.Dispose();
            }
            catch { }

            

            tbxEditor.Text = sb.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbCurXY.Text = Cursor.Position.X + "  x  " + Cursor.Position.Y;
        }

        
    }
}
