using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using EBASetting;

namespace EasyBrowserAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion + " © 2018 VinaCaptcha@gmail.com";



            // Set Font Style Size
            tbxEditor.Styles.ResetDefault();
            tbxEditor.Styles.Default.FontName = "Courier New";// "Consolas";
            tbxEditor.Styles.Default.Size = 10;
            tbxEditor.Styles.Default.ForeColor = Color.Silver;
            tbxEditor.Styles.ClearAll();

            // Show Line Number
            tbxEditor.Margins[0].Width = 40;
            tbxEditor.Styles.LineNumber.ForeColor = Color.Gray;
            tbxEditor.Caret.HighlightCurrentLine = true;
            tbxEditor.Caret.CurrentLineBackgroundColor = Color.WhiteSmoke;
            tbxEditor.Indentation.TabWidth = 3;

            // Set custom syntax highlighting
            tbxEditor.Lexing.Lexer = ScintillaNET.Lexer.Cpp;
            tbxEditor.Lexing.Keywords[0] = "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void var";
            tbxEditor.Lexing.Keywords[1] = "ShowMessage UpdateStatus Wait Delay";
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




            // Set default value for controls
            tvMain.Nodes[0].Expand();
            //tvMain.Nodes[1].Collapse();
            //tvMain.Nodes[2].Expand();

            tbxEditor.Text = "ShowMessage(\"Hello World\");\r";
            tbxEditor.Text += "Delay(2);\r";
            tbxEditor.Text += "ShowMessage(\"Bye World\");\r";
            tbxEditor.Text += "Delay(2);\r";
            tbxEditor.Text += "UpdateStatus(\"OK\",\"Completed\");\r";

            // Test add 1000 node
            for (int i = 1; i <= 100; i++)
            {
                TreeNode nd = new TreeNode("Web Browser " + i.ToString("0000"));
                nd.ImageKey = nd.SelectedImageKey = "Firefox.png";
                nd.Nodes.Add("Settings");
                nd.Nodes.Add("Script");
                nd.Nodes.Add("SSH");
                nd.Nodes.Add("ABC");
                nd.Nodes.Add("XYZ");
                nd.Nodes.Add("ZZZ");

                TreeNode ndtemp = nd.Nodes[1];
                nd.Nodes[1] = nd.Nodes[2];
                nd.Nodes[2] = ndtemp;

                tvMain.Nodes.Add(nd);
                //Application.DoEvents(); Thread.Sleep(10);
            }


            // Load YoutubeSettingsTest
            YoutubeReuploadFromFolder ytb1 = new YoutubeReuploadFromFolder();
            pgGeneralSettings.SelectedObject = ytb1;
        }


        Thread ThreadPlayMacro;
        private void btnPlayMacro_Click(object sender, EventArgs e)
        {
            if (PlayMacroObject.IsPlaying == false)
            {
                btnPlayMacro.Text = "Stop Macro";
                btnPlayMacro.Image = Properties.Resources.Stop_Red;
                lbStatus.Image = Properties.Resources.info;
                lbMsg.Text = "Ready to work!";

                PlayMacroObject.MacroScript = tbxEditor.Text;
                ThreadPlayMacro = new Thread(new ThreadStart(PlayMacroObject.Play));
                ThreadPlayMacro.TrySetApartmentState(ApartmentState.STA); //for using Clipboard in Threading
                ThreadPlayMacro.Start();
            }
            else 
            {
                btnPlayMacro.Text = "Play Macro";
                btnPlayMacro.Image = Properties.Resources.Play_Blue;

                ThreadPlayMacro.Abort();
                PlayMacroObject.IsPlaying = false;
            }
        }

        public void StopMacro()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                PlayMacroObject.IsPlaying = true;
                btnPlayMacro_Click(null, null);
            }));
        }

        public void UpdateStatus(string status, string message)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                switch (status.ToLower())
                {
                    case "error": lbStatus.Image = Properties.Resources.error; break;
                    case "waiting":
                    case "working":
                    case "loading": lbStatus.Image = Properties.Resources.loading; break;
                    case "warning": lbStatus.Image = Properties.Resources.warning; break;
                    case "complete":
                    case "yes":
                    case "ok": lbStatus.Image = Properties.Resources.check; break;
                    default: lbStatus.Image = Properties.Resources.info; break;
                }

                lbMsg.Text = message;
            }));
        }

        private void btnPanels_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                btnPanels.Image = Properties.Resources.PanelFull;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                btnPanels.Image = Properties.Resources.PanelOne;
            }
        }

        private void mnOpenTools_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null) return;
            switch (tvMain.SelectedNode.Text)
            { 
                case "Mouse":
                    MouseTools fmt = new MouseTools();
                    fmt.Show();

                    break;

                default: break;
            }
        }

    }
}
