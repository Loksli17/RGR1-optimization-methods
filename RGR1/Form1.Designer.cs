
namespace RGR1
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
            this.graphicView = new System.Windows.Forms.PictureBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itersView = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.x1View = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.x2View = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.y1View = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.y2View = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.predictItersView = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphicView)).BeginInit();
            this.SuspendLayout();
            // 
            // graphicView
            // 
            this.graphicView.BackColor = System.Drawing.SystemColors.Window;
            this.graphicView.Location = new System.Drawing.Point(12, 12);
            this.graphicView.Name = "graphicView";
            this.graphicView.Size = new System.Drawing.Size(791, 533);
            this.graphicView.TabIndex = 0;
            this.graphicView.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(827, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(186, 148);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во итераций";
            // 
            // itersView
            // 
            this.itersView.AutoSize = true;
            this.itersView.Location = new System.Drawing.Point(1030, 256);
            this.itersView.Name = "itersView";
            this.itersView.Size = new System.Drawing.Size(38, 15);
            this.itersView.TabIndex = 4;
            this.itersView.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(826, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "x1";
            // 
            // x1View
            // 
            this.x1View.AutoSize = true;
            this.x1View.Location = new System.Drawing.Point(973, 405);
            this.x1View.Name = "x1View";
            this.x1View.Size = new System.Drawing.Size(38, 15);
            this.x1View.TabIndex = 6;
            this.x1View.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(826, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "x2";
            // 
            // x2View
            // 
            this.x2View.AutoSize = true;
            this.x2View.Location = new System.Drawing.Point(973, 444);
            this.x2View.Name = "x2View";
            this.x2View.Size = new System.Drawing.Size(38, 15);
            this.x2View.TabIndex = 8;
            this.x2View.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(827, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Точность";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(892, 186);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(826, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "f(x1) = ";
            // 
            // y1View
            // 
            this.y1View.AutoSize = true;
            this.y1View.Location = new System.Drawing.Point(973, 481);
            this.y1View.Name = "y1View";
            this.y1View.Size = new System.Drawing.Size(38, 15);
            this.y1View.TabIndex = 12;
            this.y1View.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(827, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "f(x2) = ";
            // 
            // y2View
            // 
            this.y2View.AutoSize = true;
            this.y2View.Location = new System.Drawing.Point(973, 526);
            this.y2View.Name = "y2View";
            this.y2View.Size = new System.Drawing.Size(38, 15);
            this.y2View.TabIndex = 14;
            this.y2View.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(826, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Предполагаемое кол-во итераций";
            // 
            // predictItersView
            // 
            this.predictItersView.AutoSize = true;
            this.predictItersView.Location = new System.Drawing.Point(1030, 288);
            this.predictItersView.Name = "predictItersView";
            this.predictItersView.Size = new System.Drawing.Size(38, 15);
            this.predictItersView.TabIndex = 16;
            this.predictItersView.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 558);
            this.Controls.Add(this.predictItersView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.y2View);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.y1View);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.x2View);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.x1View);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itersView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.graphicView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphicView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphicView;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label itersView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label x1View;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label x2View;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label y1View;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label y2View;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label predictItersView;
    }
}

