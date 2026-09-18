namespace Second_Hand_Item_Ex_
{
    partial class BrowseListingForm
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
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(307, 456);
            button1.Name = "button1";
            button1.Size = new Size(215, 52);
            button1.TabIndex = 1;
            button1.Text = "Request this item";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GrayText;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Lucida Sans", 13.8F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(539, 456);
            button2.Name = "button2";
            button2.Size = new Size(117, 52);
            button2.TabIndex = 2;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.LightSlateGray;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(48, 33);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(618, 407);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // BrowseListingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(695, 521);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "BrowseListingForm";
            Text = "BrowseListingForm";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
