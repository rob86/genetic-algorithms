namespace GAgui
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.executionGroupBox = new System.Windows.Forms.GroupBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.showAllCheckbox = new System.Windows.Forms.CheckBox();
            this.startProcessingButton = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.stopLabel = new System.Windows.Forms.Label();
            this.populationLabel = new System.Windows.Forms.Label();
            this.crossoverComboBox = new System.Windows.Forms.ComboBox();
            this.mutationComboBox = new System.Windows.Forms.ComboBox();
            this.crossoverLabel = new System.Windows.Forms.Label();
            this.selectionComboBox = new System.Windows.Forms.ComboBox();
            this.mutationLabel = new System.Windows.Forms.Label();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.stopSpinner = new System.Windows.Forms.NumericUpDown();
            this.populationSpinner = new System.Windows.Forms.NumericUpDown();
            this.dataInputGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schemaA1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliteSelectionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.survivorSpinner = new System.Windows.Forms.NumericUpDown();
            this.eliteSpinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.executionGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSpinner)).BeginInit();
            this.dataInputGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.survivorSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 462;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(789, 575);
            this.splitContainer1.SplitterDistance = 493;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.executionGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.settingsGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataInputGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 575);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // executionGroupBox
            // 
            this.executionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executionGroupBox.Controls.Add(this.progressLabel);
            this.executionGroupBox.Controls.Add(this.showAllCheckbox);
            this.executionGroupBox.Controls.Add(this.startProcessingButton);
            this.executionGroupBox.Location = new System.Drawing.Point(4, 514);
            this.executionGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.executionGroupBox.Name = "executionGroupBox";
            this.executionGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.executionGroupBox.Size = new System.Drawing.Size(485, 57);
            this.executionGroupBox.TabIndex = 0;
            this.executionGroupBox.TabStop = false;
            this.executionGroupBox.Text = "Wykonywanie";
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(337, 25);
            this.progressLabel.MinimumSize = new System.Drawing.Size(140, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(140, 17);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // showAllCheckbox
            // 
            this.showAllCheckbox.Location = new System.Drawing.Point(97, 25);
            this.showAllCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showAllCheckbox.Name = "showAllCheckbox";
            this.showAllCheckbox.Size = new System.Drawing.Size(179, 21);
            this.showAllCheckbox.TabIndex = 1;
            this.showAllCheckbox.Text = "Pokaż wyniki pośrednie";
            this.showAllCheckbox.UseVisualStyleBackColor = true;
            // 
            // startProcessingButton
            // 
            this.startProcessingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startProcessingButton.Location = new System.Drawing.Point(9, 21);
            this.startProcessingButton.Margin = new System.Windows.Forms.Padding(4);
            this.startProcessingButton.Name = "startProcessingButton";
            this.startProcessingButton.Size = new System.Drawing.Size(80, 25);
            this.startProcessingButton.TabIndex = 0;
            this.startProcessingButton.Text = "Start";
            this.startProcessingButton.UseVisualStyleBackColor = true;
            this.startProcessingButton.Click += new System.EventHandler(this.startProcessingButton_Click);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.settingsGroupBox.Location = new System.Drawing.Point(4, 4);
            this.settingsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.settingsGroupBox.Size = new System.Drawing.Size(485, 231);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Ustawienia";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.stopLabel, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.populationLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.crossoverComboBox, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.mutationComboBox, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.crossoverLabel, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.selectionComboBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.mutationLabel, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.selectionLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.stopSpinner, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.populationSpinner, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.eliteSelectionLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.survivorSpinner, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.eliteSpinner, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(477, 208);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.stopLabel.Location = new System.Drawing.Point(4, 180);
            this.stopLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(192, 20);
            this.stopLabel.TabIndex = 9;
            this.stopLabel.Text = "Stop - powtórzenia lidera:";
            this.stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.populationLabel.Location = new System.Drawing.Point(4, 0);
            this.populationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(192, 20);
            this.populationLabel.TabIndex = 1;
            this.populationLabel.Text = "Rozmiar populacji:";
            this.populationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // crossoverComboBox
            // 
            this.crossoverComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crossoverComboBox.FormattingEnabled = true;
            this.crossoverComboBox.Location = new System.Drawing.Point(204, 154);
            this.crossoverComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.crossoverComboBox.Name = "crossoverComboBox";
            this.crossoverComboBox.Size = new System.Drawing.Size(269, 24);
            this.crossoverComboBox.TabIndex = 4;
            // 
            // mutationComboBox
            // 
            this.mutationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mutationComboBox.FormattingEnabled = true;
            this.mutationComboBox.Location = new System.Drawing.Point(204, 124);
            this.mutationComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.mutationComboBox.Name = "mutationComboBox";
            this.mutationComboBox.Size = new System.Drawing.Size(269, 24);
            this.mutationComboBox.TabIndex = 6;
            // 
            // crossoverLabel
            // 
            this.crossoverLabel.AutoSize = true;
            this.crossoverLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crossoverLabel.Location = new System.Drawing.Point(4, 150);
            this.crossoverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.crossoverLabel.Name = "crossoverLabel";
            this.crossoverLabel.Size = new System.Drawing.Size(192, 30);
            this.crossoverLabel.TabIndex = 3;
            this.crossoverLabel.Text = "Krzyżowania:";
            this.crossoverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectionComboBox
            // 
            this.selectionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionComboBox.FormattingEnabled = true;
            this.selectionComboBox.Location = new System.Drawing.Point(204, 34);
            this.selectionComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectionComboBox.Name = "selectionComboBox";
            this.selectionComboBox.Size = new System.Drawing.Size(269, 24);
            this.selectionComboBox.TabIndex = 8;
            // 
            // mutationLabel
            // 
            this.mutationLabel.AutoSize = true;
            this.mutationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mutationLabel.Location = new System.Drawing.Point(4, 120);
            this.mutationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mutationLabel.Name = "mutationLabel";
            this.mutationLabel.Size = new System.Drawing.Size(192, 30);
            this.mutationLabel.TabIndex = 5;
            this.mutationLabel.Text = "Rodzaj Mutacji:";
            this.mutationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectionLabel
            // 
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionLabel.Location = new System.Drawing.Point(4, 30);
            this.selectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(192, 30);
            this.selectionLabel.TabIndex = 7;
            this.selectionLabel.Text = "Selekcja:";
            this.selectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stopSpinner
            // 
            this.stopSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopSpinner.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.stopSpinner.Location = new System.Drawing.Point(203, 182);
            this.stopSpinner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopSpinner.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stopSpinner.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.stopSpinner.Name = "stopSpinner";
            this.stopSpinner.Size = new System.Drawing.Size(271, 22);
            this.stopSpinner.TabIndex = 10;
            this.stopSpinner.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // populationSpinner
            // 
            this.populationSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.populationSpinner.Location = new System.Drawing.Point(203, 2);
            this.populationSpinner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.populationSpinner.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.populationSpinner.Name = "populationSpinner";
            this.populationSpinner.Size = new System.Drawing.Size(271, 22);
            this.populationSpinner.TabIndex = 11;
            this.populationSpinner.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dataInputGroupBox
            // 
            this.dataInputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataInputGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.dataInputGroupBox.Location = new System.Drawing.Point(4, 243);
            this.dataInputGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataInputGroupBox.Name = "dataInputGroupBox";
            this.dataInputGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.dataInputGroupBox.Size = new System.Drawing.Size(485, 263);
            this.dataInputGroupBox.TabIndex = 3;
            this.dataInputGroupBox.TabStop = false;
            this.dataInputGroupBox.Text = "Wprowadzanie danych";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataListBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(477, 240);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // dataListBox
            // 
            this.dataListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListBox.FormattingEnabled = true;
            this.dataListBox.ItemHeight = 16;
            this.dataListBox.Location = new System.Drawing.Point(4, 43);
            this.dataListBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataListBox.Name = "dataListBox";
            this.dataListBox.Size = new System.Drawing.Size(469, 193);
            this.dataListBox.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.loadDataButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(471, 35);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // loadDataButton
            // 
            this.loadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadDataButton.Location = new System.Drawing.Point(4, 4);
            this.loadDataButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(80, 25);
            this.loadDataButton.TabIndex = 5;
            this.loadDataButton.Text = "Wczytaj";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MinimumSize = new System.Drawing.Size(100, 100);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(291, 575);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(789, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // schemaToolStripMenuItem
            // 
            this.schemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schemaA1ToolStripMenuItem});
            this.schemaToolStripMenuItem.Name = "schemaToolStripMenuItem";
            this.schemaToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.schemaToolStripMenuItem.Text = "Schematy";
            // 
            // schemaA1ToolStripMenuItem
            // 
            this.schemaA1ToolStripMenuItem.Name = "schemaA1ToolStripMenuItem";
            this.schemaA1ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.schemaA1ToolStripMenuItem.Text = "A1";
            // 
            // eliteSelectionLabel
            // 
            this.eliteSelectionLabel.AutoSize = true;
            this.eliteSelectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eliteSelectionLabel.Location = new System.Drawing.Point(3, 90);
            this.eliteSelectionLabel.Name = "eliteSelectionLabel";
            this.eliteSelectionLabel.Size = new System.Drawing.Size(194, 30);
            this.eliteSelectionLabel.TabIndex = 13;
            this.eliteSelectionLabel.Text = "Rozmiar \"elite\":";
            this.eliteSelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rozmiar \"survivor\":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // survivorSpinner
            // 
            this.survivorSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.survivorSpinner.Location = new System.Drawing.Point(203, 63);
            this.survivorSpinner.Name = "survivorSpinner";
            this.survivorSpinner.Size = new System.Drawing.Size(271, 22);
            this.survivorSpinner.TabIndex = 15;
            // 
            // eliteSpinner
            // 
            this.eliteSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eliteSpinner.Location = new System.Drawing.Point(203, 93);
            this.eliteSpinner.Name = "eliteSpinner";
            this.eliteSpinner.Size = new System.Drawing.Size(271, 22);
            this.eliteSpinner.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 603);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "Algorytmów genetycznych";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.executionGroupBox.ResumeLayout(false);
            this.executionGroupBox.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSpinner)).EndInit();
            this.dataInputGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.survivorSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox executionGroupBox;
        private System.Windows.Forms.CheckBox showAllCheckbox;
        private System.Windows.Forms.Button startProcessingButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem schemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schemaA1ToolStripMenuItem;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.ComboBox crossoverComboBox;
        private System.Windows.Forms.Label crossoverLabel;
        private System.Windows.Forms.ComboBox mutationComboBox;
        private System.Windows.Forms.Label mutationLabel;
        private System.Windows.Forms.ComboBox selectionComboBox;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.GroupBox dataInputGroupBox;
        private System.Windows.Forms.ListBox dataListBox;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.NumericUpDown stopSpinner;
        private System.Windows.Forms.NumericUpDown populationSpinner;
        private System.Windows.Forms.Label eliteSelectionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown survivorSpinner;
        private System.Windows.Forms.NumericUpDown eliteSpinner;
    }
}

