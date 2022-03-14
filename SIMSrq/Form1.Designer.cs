
namespace SIMSrq
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
            this.label1 = new System.Windows.Forms.Label();
            this.lambdaTB = new System.Windows.Forms.TextBox();
            this.mu1TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mu2TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NTB = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.callsTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sigmaTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.kvar1Label = new System.Windows.Forms.Label();
            this.kvar2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Интенсивность входящего потока:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lambdaTB
            // 
            this.lambdaTB.Location = new System.Drawing.Point(232, 30);
            this.lambdaTB.Name = "lambdaTB";
            this.lambdaTB.Size = new System.Drawing.Size(100, 23);
            this.lambdaTB.TabIndex = 2;
            this.lambdaTB.Text = "2";
            // 
            // mu1TB
            // 
            this.mu1TB.Location = new System.Drawing.Point(232, 79);
            this.mu1TB.Name = "mu1TB";
            this.mu1TB.Size = new System.Drawing.Size(100, 23);
            this.mu1TB.TabIndex = 4;
            this.mu1TB.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Интенсивность обслуживания\r\nна первой фазе:";
            // 
            // mu2TB
            // 
            this.mu2TB.Location = new System.Drawing.Point(232, 126);
            this.mu2TB.Name = "mu2TB";
            this.mu2TB.Size = new System.Drawing.Size(100, 23);
            this.mu2TB.TabIndex = 6;
            this.mu2TB.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Интенсивность обслуживания\r\nна второй фазе:";
            // 
            // NTB
            // 
            this.NTB.Location = new System.Drawing.Point(232, 218);
            this.NTB.Name = "NTB";
            this.NTB.Size = new System.Drawing.Size(100, 23);
            this.NTB.TabIndex = 8;
            this.NTB.Text = "10";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(28, 221);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(125, 15);
            this.label123.TabIndex = 7;
            this.label123.Text = "Размерность буфера:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Запуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // callsTB
            // 
            this.callsTB.Location = new System.Drawing.Point(232, 405);
            this.callsTB.Name = "callsTB";
            this.callsTB.Size = new System.Drawing.Size(100, 23);
            this.callsTB.TabIndex = 11;
            this.callsTB.Text = "5";
            this.callsTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Число событий в \r\nвыходящем потоке:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // sigmaTB
            // 
            this.sigmaTB.Location = new System.Drawing.Point(232, 173);
            this.sigmaTB.Name = "sigmaTB";
            this.sigmaTB.Size = new System.Drawing.Size(100, 23);
            this.sigmaTB.TabIndex = 23;
            this.sigmaTB.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 30);
            this.label7.TabIndex = 22;
            this.label7.Text = "Параметр времени \r\nзадержки на орбите:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 36);
            this.button2.TabIndex = 24;
            this.button2.Text = "Открыть Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Кvar выходящего потока 2 фазы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Кvar выходящего потока 1 фазы";
            // 
            // kvar1Label
            // 
            this.kvar1Label.AutoSize = true;
            this.kvar1Label.Location = new System.Drawing.Point(692, 108);
            this.kvar1Label.Name = "kvar1Label";
            this.kvar1Label.Size = new System.Drawing.Size(12, 15);
            this.kvar1Label.TabIndex = 27;
            this.kvar1Label.Text = "-";
            // 
            // kvar2Label
            // 
            this.kvar2Label.AutoSize = true;
            this.kvar2Label.Location = new System.Drawing.Point(692, 134);
            this.kvar2Label.Name = "kvar2Label";
            this.kvar2Label.Size = new System.Drawing.Size(12, 15);
            this.kvar2Label.TabIndex = 28;
            this.kvar2Label.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kvar2Label);
            this.Controls.Add(this.kvar1Label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sigmaTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.callsTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NTB);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.mu2TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mu1TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lambdaTB);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lambdaTB;
        private System.Windows.Forms.TextBox mu1TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mu2TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NTB;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox callsTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sigmaTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label kvar1Label;
        private System.Windows.Forms.Label kvar2Label;
    }
}

