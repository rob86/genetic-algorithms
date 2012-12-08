namespace GAgui
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Selekcja = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_mutacja = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_krzyzowanie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_RozmiarPopulacji = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_show_all_result = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schematyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_wezly = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_oneList = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 476);
            this.splitContainer1.SplitterDistance = 423;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Selekcja);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_mutacja);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_krzyzowanie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_RozmiarPopulacji);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 239);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ustawienia algorytmu genetycznego";
            // 
            // comboBox_Selekcja
            // 
            this.comboBox_Selekcja.FormattingEnabled = true;
            this.comboBox_Selekcja.Location = new System.Drawing.Point(166, 77);
            this.comboBox_Selekcja.Name = "comboBox_Selekcja";
            this.comboBox_Selekcja.Size = new System.Drawing.Size(205, 21);
            this.comboBox_Selekcja.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selekcja:";
            // 
            // comboBox_mutacja
            // 
            this.comboBox_mutacja.FormattingEnabled = true;
            this.comboBox_mutacja.Location = new System.Drawing.Point(166, 108);
            this.comboBox_mutacja.Name = "comboBox_mutacja";
            this.comboBox_mutacja.Size = new System.Drawing.Size(205, 21);
            this.comboBox_mutacja.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rodzaj Mutacji:";
            // 
            // comboBox_krzyzowanie
            // 
            this.comboBox_krzyzowanie.FormattingEnabled = true;
            this.comboBox_krzyzowanie.Location = new System.Drawing.Point(166, 135);
            this.comboBox_krzyzowanie.Name = "comboBox_krzyzowanie";
            this.comboBox_krzyzowanie.Size = new System.Drawing.Size(205, 21);
            this.comboBox_krzyzowanie.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Krzyzowania:";
            // 
            // textBox_RozmiarPopulacji
            // 
            this.textBox_RozmiarPopulacji.Location = new System.Drawing.Point(159, 42);
            this.textBox_RozmiarPopulacji.Name = "textBox_RozmiarPopulacji";
            this.textBox_RozmiarPopulacji.Size = new System.Drawing.Size(212, 20);
            this.textBox_RozmiarPopulacji.TabIndex = 2;
            this.textBox_RozmiarPopulacji.Text = "40";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "rozmiar populacji:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_show_all_result);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 41);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Run";
            // 
            // checkBox_show_all_result
            // 
            this.checkBox_show_all_result.AutoSize = true;
            this.checkBox_show_all_result.Location = new System.Drawing.Point(89, 17);
            this.checkBox_show_all_result.Name = "checkBox_show_all_result";
            this.checkBox_show_all_result.Size = new System.Drawing.Size(101, 17);
            this.checkBox_show_all_result.TabIndex = 1;
            this.checkBox_show_all_result.Text = "pokaz wszystko";
            this.checkBox_show_all_result.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(725, 476);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schematyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // schematyToolStripMenuItem
            // 
            this.schematyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.a1ToolStripMenuItem});
            this.schematyToolStripMenuItem.Name = "schematyToolStripMenuItem";
            this.schematyToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.schematyToolStripMenuItem.Text = "Schematy";
            // 
            // a1ToolStripMenuItem
            // 
            this.a1ToolStripMenuItem.Name = "a1ToolStripMenuItem";
            this.a1ToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.a1ToolStripMenuItem.Text = "A1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox_oneList);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Controls.Add(this.listBox_wezly);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 234);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wprowadzanie danych:";
            // 
            // listBox_wezly
            // 
            this.listBox_wezly.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox_wezly.FormattingEnabled = true;
            this.listBox_wezly.Location = new System.Drawing.Point(3, 97);
            this.listBox_wezly.Name = "listBox_wezly";
            this.listBox_wezly.Size = new System.Drawing.Size(417, 134);
            this.listBox_wezly.TabIndex = 0;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(10, 68);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Dodaj";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Usun";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_oneList
            // 
            this.textBox_oneList.Location = new System.Drawing.Point(10, 20);
            this.textBox_oneList.Name = "textBox_oneList";
            this.textBox_oneList.Size = new System.Drawing.Size(392, 20);
            this.textBox_oneList.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Usun wszy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(256, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "wczytaj z pliku";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(338, 68);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "zapisz";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 500);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "algorytmów genetycznych";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_show_all_result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem schematyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem a1ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_RozmiarPopulacji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_krzyzowanie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_mutacja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Selekcja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_oneList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ListBox listBox_wezly;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}

