namespace blackjack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            button3 = new Button();
            listBox2 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(456, 524);
            button1.Name = "button1";
            button1.Size = new Size(160, 95);
            button1.TabIndex = 0;
            button1.Text = "Húz";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 0, 0);
            button2.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(622, 524);
            button2.Name = "button2";
            button2.Size = new Size(149, 95);
            button2.TabIndex = 1;
            button2.Text = "Megáll";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(192, 0, 0);
            listBox1.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 45;
            listBox1.Location = new Point(777, 524);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(189, 319);
            listBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(192, 0, 0);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 25F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(456, 625);
            label1.Name = "label1";
            label1.Size = new Size(315, 95);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 0, 0);
            button3.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(290, 358);
            button3.Name = "button3";
            button3.Size = new Size(160, 95);
            button3.TabIndex = 4;
            button3.Text = "Újra";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.FromArgb(192, 0, 0);
            listBox2.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox2.ForeColor = Color.White;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 45;
            listBox2.Location = new Point(777, 32);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(189, 319);
            listBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(192, 0, 0);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 25F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(456, 143);
            label2.Name = "label2";
            label2.Size = new Size(315, 95);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.BackColor = Color.FromArgb(192, 0, 0);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI", 35F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(456, 32);
            label3.Name = "label3";
            label3.Size = new Size(315, 95);
            label3.TabIndex = 7;
            label3.Text = "BANK";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(192, 0, 0);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 25F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(456, 358);
            label4.Name = "label4";
            label4.Size = new Size(315, 95);
            label4.TabIndex = 8;
            label4.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(1477, 896);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private Label label1;
        private Button button3;
        private ListBox listBox2;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
