namespace EasyBrowserAutomation
{
    partial class MouseTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseTools));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbCurXY = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbxEditor = new ScintillaNET.Scintilla();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbCurXY
            // 
            this.lbCurXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurXY.ForeColor = System.Drawing.Color.Gray;
            this.lbCurXY.Location = new System.Drawing.Point(258, 11);
            this.lbCurXY.Name = "lbCurXY";
            this.lbCurXY.Size = new System.Drawing.Size(113, 30);
            this.lbCurXY.TabIndex = 3;
            this.lbCurXY.Text = "0  x  0";
            this.lbCurXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 43);
            this.panel2.TabIndex = 41;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbCurXY);
            this.groupBox3.Controls.Add(this.lbMsg);
            this.groupBox3.Controls.Add(this.lbStatus);
            this.groupBox3.Location = new System.Drawing.Point(2, -5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 46);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // lbMsg
            // 
            this.lbMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbMsg.Location = new System.Drawing.Point(36, 11);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(216, 30);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "Press F2 to capture current position:";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStatus
            // 
            this.lbStatus.Image = global::EasyBrowserAutomation.Properties.Resources.keyboard;
            this.lbStatus.Location = new System.Drawing.Point(5, 11);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(30, 30);
            this.lbStatus.TabIndex = 0;
            // 
            // tbxEditor
            // 
            this.tbxEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxEditor.Caret.CurrentLineBackgroundColor = System.Drawing.Color.Gainsboro;
            this.tbxEditor.Caret.HighlightCurrentLine = true;
            this.tbxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEditor.Indentation.TabWidth = 3;
            this.tbxEditor.Location = new System.Drawing.Point(0, 43);
            this.tbxEditor.Name = "tbxEditor";
            this.tbxEditor.Size = new System.Drawing.Size(584, 519);
            this.tbxEditor.Styles.BraceBad.FontName = "";
            this.tbxEditor.Styles.BraceBad.Size = 9F;
            this.tbxEditor.Styles.BraceLight.FontName = "";
            this.tbxEditor.Styles.BraceLight.Size = 9F;
            this.tbxEditor.Styles.ControlChar.FontName = "";
            this.tbxEditor.Styles.ControlChar.Size = 9F;
            this.tbxEditor.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.tbxEditor.Styles.Default.Size = 9F;
            this.tbxEditor.Styles.IndentGuide.FontName = "";
            this.tbxEditor.Styles.IndentGuide.Size = 9F;
            this.tbxEditor.Styles.LastPredefined.FontName = "";
            this.tbxEditor.Styles.LastPredefined.Size = 9F;
            this.tbxEditor.Styles.LineNumber.FontName = "";
            this.tbxEditor.Styles.LineNumber.Size = 9F;
            this.tbxEditor.Styles.Max.Size = 9F;
            this.tbxEditor.TabIndex = 35;
            // 
            // MouseTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.tbxEditor);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MouseTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse Tools - EasyBrowserAutomation";
            this.Load += new System.EventHandler(this.MouseTools_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbCurXY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbStatus;
        private ScintillaNET.Scintilla tbxEditor;
    }
}