namespace Second_Hand_Item_Ex_
{
    partial class MyListingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            label1 = new Label();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 0;
            label1.Text = "My Listings";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GrayText;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Lucida Sans", 13.8F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(550, 402);
            button1.Name = "button1";
            button1.Size = new Size(104, 40);
            button1.TabIndex = 2;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.LightSlateGray;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(23, 62);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(631, 334);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // MyListingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(676, 454);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MyListingsForm";
            Text = "My Listings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
