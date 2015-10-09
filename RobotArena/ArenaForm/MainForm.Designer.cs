namespace ArenaForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGridRobot = new System.Windows.Forms.PropertyGrid();
            this.scalingPanelArena = new Guidance.Windows.Forms.ScalingPanel();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGridRobot);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scalingPanelArena);
            this.splitContainer1.Size = new System.Drawing.Size(723, 644);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 0;
            // 
            // propertyGridRobot
            // 
            this.propertyGridRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridRobot.Location = new System.Drawing.Point(0, 0);
            this.propertyGridRobot.Name = "propertyGridRobot";
            this.propertyGridRobot.Size = new System.Drawing.Size(241, 644);
            this.propertyGridRobot.TabIndex = 0;
            // 
            // scalingPanelArena
            // 
            this.scalingPanelArena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalingPanelArena.DrawLimits = ((System.Drawing.RectangleF)(resources.GetObject("scalingPanelArena.DrawLimits")));
            this.scalingPanelArena.Location = new System.Drawing.Point(0, 0);
            this.scalingPanelArena.Name = "scalingPanelArena";
            this.scalingPanelArena.Offset = ((System.Drawing.PointF)(resources.GetObject("scalingPanelArena.Offset")));
            this.scalingPanelArena.Size = new System.Drawing.Size(478, 644);
            this.scalingPanelArena.TabIndex = 0;
            this.scalingPanelArena.TabStop = true;
            this.scalingPanelArena.Paint += new System.Windows.Forms.PaintEventHandler(this.scalingPanelArena_Paint);
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 644);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Arena Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGridRobot;
        private System.Windows.Forms.Timer timerTick;
        private Guidance.Windows.Forms.ScalingPanel scalingPanelArena;
    }
}

