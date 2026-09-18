namespace Second_Hand_Item_Ex_
{
    partial class AdminPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelRequests = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button6 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelRequests
            // 
            labelRequests.AutoSize = true;
            labelRequests.BackColor = Color.LightCyan;
            labelRequests.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRequests.Location = new Point(12, 368);
            labelRequests.Name = "labelRequests";
            labelRequests.Size = new Size(191, 23);
            labelRequests.TabIndex = 0;
            labelRequests.Text = "Pending Requests";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Lucida Fax", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(513, 474);
            button1.Name = "button1";
            button1.Size = new Size(114, 49);
            button1.TabIndex = 1;
            button1.Text = "Approve";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Lucida Fax", 13.8F);
            button2.Location = new Point(513, 404);
            button2.Name = "button2";
            button2.Size = new Size(109, 45);
            button2.TabIndex = 2;
            button2.Text = "Reject";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Lucida Fax", 13.8F);
            button3.Location = new Point(641, 222);
            button3.Name = "button3";
            button3.Size = new Size(137, 48);
            button3.TabIndex = 4;
            button3.Text = "Delete Listing";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.MenuHighlight;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Lucida Fax", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(641, 42);
            button4.Name = "button4";
            button4.Size = new Size(137, 71);
            button4.TabIndex = 5;
            button4.Text = "Add New Listing";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.GrayText;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Lucida Sans", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(657, 549);
            button5.Name = "button5";
            button5.Size = new Size(97, 43);
            button5.TabIndex = 6;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.LightSteelBlue;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 404);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(495, 188);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.LightSteelBlue;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(12, 42);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(610, 315);
            flowLayoutPanel2.TabIndex = 8;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.MenuHighlight;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Lucida Fax", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(641, 135);
            button6.Name = "button6";
            button6.Size = new Size(137, 61);
            button6.TabIndex = 9;
            button6.Text = "Update Listing";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(154, 30);
            label1.TabIndex = 10;
            label1.Text = "All Listing";
            label1.Click += label1_Click;
            // 
            // AdminPanelForm
            // 
            BackColor = Color.LightCyan;
            ClientSize = new Size(790, 604);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(labelRequests);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Name = "AdminPanelForm";
            Text = "Admin Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelRequests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button6;
        private Label label1;
    }
}