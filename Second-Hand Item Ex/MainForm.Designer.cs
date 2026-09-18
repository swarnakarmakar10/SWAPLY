namespace Second_Hand_Item_Ex_
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Stencil", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(12, 138);
            label1.Name = "label1";
            label1.Size = new Size(300, 47);
            label1.TabIndex = 0;
            label1.Text = "Welcome In !";
            // 
            // button1
            // 
            button1.BackColor = Color.CadetBlue;
            button1.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(70, 215);
            button1.Name = "button1";
            button1.Size = new Size(188, 45);
            button1.TabIndex = 1;
            button1.Text = "Browse Listings";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.CadetBlue;
            button2.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(330, 215);
            button2.Name = "button2";
            button2.Size = new Size(199, 45);
            button2.TabIndex = 2;
            button2.Text = "Post New Listing";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.CadetBlue;
            button3.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(70, 283);
            button3.Name = "button3";
            button3.Size = new Size(188, 44);
            button3.TabIndex = 3;
            button3.Text = "My Listings";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.CadetBlue;
            button4.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(330, 283);
            button4.Name = "button4";
            button4.Size = new Size(199, 44);
            button4.TabIndex = 4;
            button4.Text = "My Requests";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.BackColor = Color.CadetBlue;
            button5.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(70, 349);
            button5.Name = "button5";
            button5.Size = new Size(188, 44);
            button5.TabIndex = 5;
            button5.Text = "Admin Panel";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.MenuHighlight;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(228, 419);
            button6.Name = "button6";
            button6.Size = new Size(133, 40);
            button6.TabIndex = 6;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.CadetBlue;
            button7.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(330, 349);
            button7.Name = "button7";
            button7.Size = new Size(199, 44);
            button7.TabIndex = 7;
            button7.Text = "Create Admin";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.PeachPuff;
            label2.Location = new Point(198, 63);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 9;
            label2.Text = "Sign in to your Account";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(177, 9);
            label3.Name = "label3";
            label3.Size = new Size(203, 54);
            label3.TabIndex = 8;
            label3.Text = "SWAPLY";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(588, 117);
            panel1.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(588, 485);
            Controls.Add(panel1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label2;
        private Label label3;
        private Panel panel1;
    }
}
