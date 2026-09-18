namespace Second_Hand_Item_Ex_
{
    partial class PostListingForm
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
            labelItemType = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            labelItemName = new Label();
            textBox1 = new TextBox();
            labelDescription = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelItemType
            // 
            labelItemType.AutoSize = true;
            labelItemType.Location = new Point(34, 33);
            labelItemType.Name = "labelItemType";
            labelItemType.Size = new Size(77, 20);
            labelItemType.TabIndex = 0;
            labelItemType.Text = "Item Type:";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ScrollBar;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "BOOK", "EQUIPMENT", "NOTE" });
            comboBox1.Location = new Point(183, 29);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(228, 28);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(34, 73);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 2;
            label2.Text = "instructions";
            // 
            // labelItemName
            // 
            labelItemName.AutoSize = true;
            labelItemName.Location = new Point(34, 120);
            labelItemName.Name = "labelItemName";
            labelItemName.Size = new Size(86, 20);
            labelItemName.TabIndex = 3;
            labelItemName.Text = "Item Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(183, 116);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 27);
            textBox1.TabIndex = 4;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(34, 167);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 20);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(183, 167);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(228, 27);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 239);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 7;
            label3.Text = "Detail 1:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.InactiveBorder;
            textBox3.ForeColor = SystemColors.MenuText;
            textBox3.Location = new Point(102, 263);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(170, 27);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 239);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 9;
            label4.Text = "Detail 2:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.InactiveBorder;
            textBox4.ForeColor = SystemColors.MenuText;
            textBox4.Location = new Point(330, 263);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(190, 27);
            textBox4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 320);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 11;
            label5.Text = "Detail 3:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(102, 344);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(170, 27);
            textBox5.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(330, 320);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 13;
            label6.Text = "Detail 4:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(330, 344);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(190, 27);
            textBox6.TabIndex = 14;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Lucida Bright", 13.8F, FontStyle.Bold);
            button1.Location = new Point(156, 404);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(116, 45);
            button1.TabIndex = 15;
            button1.Text = "Post";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.MenuHighlight;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Lucida Bright", 13.8F, FontStyle.Bold);
            button2.Location = new Point(330, 404);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(119, 45);
            button2.TabIndex = 16;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.InactiveCaption;
            pictureBox1.Location = new Point(483, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Lucida Bright", 9F);
            button3.Location = new Point(497, 188);
            button3.Name = "button3";
            button3.Size = new Size(136, 33);
            button3.TabIndex = 18;
            button3.Text = "Choose Photo";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.InactiveBorder;
            label1.Location = new Point(531, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 19;
            label1.Text = "Size : 150x150";
            // 
            // PostListingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(659, 476);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(labelItemType);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(labelItemName);
            Controls.Add(textBox1);
            Controls.Add(labelDescription);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(button1);
            Controls.Add(button2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PostListingForm";
            Text = "Post New Listing";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelItemType;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PictureBox pictureBox1;
        private Button button3;
        private Label label1;
    }
}
