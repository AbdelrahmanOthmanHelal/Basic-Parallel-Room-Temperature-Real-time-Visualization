namespace Room_Temprature_Visualization
{
    public partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numberOfTicks = new System.Windows.Forms.TextBox();
            this.CPlusRadio = new System.Windows.Forms.RadioButton();
            this.CSharpRadio = new System.Windows.Forms.RadioButton();
            this.SequentialRadio = new System.Windows.Forms.RadioButton();
            this.StopVisualizationButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numberOfThreads = new System.Windows.Forms.TextBox();
            this.StartVisualizationButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.updateColorMap = new System.Windows.Forms.Button();
            this.updateCellSizeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CellSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxColorMap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DiscreteColorCheck = new System.Windows.Forms.RadioButton();
            this.ContinuousColorCheck = new System.Windows.Forms.RadioButton();
            this.MinColorMap = new System.Windows.Forms.TextBox();
            this.ColorKeyPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cellLabel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cellValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cellName = new System.Windows.Forms.TextBox();
            this.addNewCellButton = new System.Windows.Forms.Button();
            this.cellTypesCombo = new System.Windows.Forms.ComboBox();
            this.cellTypesLabels = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 436);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphical Output";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numberOfTicks);
            this.groupBox2.Controls.Add(this.CPlusRadio);
            this.groupBox2.Controls.Add(this.CSharpRadio);
            this.groupBox2.Controls.Add(this.SequentialRadio);
            this.groupBox2.Controls.Add(this.StopVisualizationButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numberOfThreads);
            this.groupBox2.Controls.Add(this.StartVisualizationButton);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cellLabel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cellValue);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cellName);
            this.groupBox2.Controls.Add(this.addNewCellButton);
            this.groupBox2.Controls.Add(this.cellTypesCombo);
            this.groupBox2.Controls.Add(this.cellTypesLabels);
            this.groupBox2.Location = new System.Drawing.Point(649, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 436);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Ticks:";
            // 
            // numberOfTicks
            // 
            this.numberOfTicks.Location = new System.Drawing.Point(160, 400);
            this.numberOfTicks.Name = "numberOfTicks";
            this.numberOfTicks.Size = new System.Drawing.Size(23, 20);
            this.numberOfTicks.TabIndex = 34;
            this.numberOfTicks.Text = "0";
            // 
            // CPlusRadio
            // 
            this.CPlusRadio.AutoSize = true;
            this.CPlusRadio.Location = new System.Drawing.Point(98, 369);
            this.CPlusRadio.Name = "CPlusRadio";
            this.CPlusRadio.Size = new System.Drawing.Size(81, 17);
            this.CPlusRadio.TabIndex = 33;
            this.CPlusRadio.TabStop = true;
            this.CPlusRadio.Text = "Parallel C++";
            this.CPlusRadio.UseVisualStyleBackColor = true;
            this.CPlusRadio.CheckedChanged += new System.EventHandler(this.CPlusRadio_CheckedChanged);
            // 
            // CSharpRadio
            // 
            this.CSharpRadio.AutoSize = true;
            this.CSharpRadio.Checked = true;
            this.CSharpRadio.Location = new System.Drawing.Point(11, 369);
            this.CSharpRadio.Name = "CSharpRadio";
            this.CSharpRadio.Size = new System.Drawing.Size(76, 17);
            this.CSharpRadio.TabIndex = 32;
            this.CSharpRadio.TabStop = true;
            this.CSharpRadio.Text = "Parallel C#";
            this.CSharpRadio.UseVisualStyleBackColor = true;
            this.CSharpRadio.CheckedChanged += new System.EventHandler(this.CSharpRadio_CheckedChanged);
            // 
            // SequentialRadio
            // 
            this.SequentialRadio.AutoSize = true;
            this.SequentialRadio.Location = new System.Drawing.Point(188, 369);
            this.SequentialRadio.Name = "SequentialRadio";
            this.SequentialRadio.Size = new System.Drawing.Size(75, 17);
            this.SequentialRadio.TabIndex = 31;
            this.SequentialRadio.TabStop = true;
            this.SequentialRadio.Text = "Sequential";
            this.SequentialRadio.UseVisualStyleBackColor = true;
            this.SequentialRadio.CheckedChanged += new System.EventHandler(this.SequentialRadio_CheckedChanged);
            // 
            // StopVisualizationButton
            // 
            this.StopVisualizationButton.Enabled = false;
            this.StopVisualizationButton.Location = new System.Drawing.Point(71, 398);
            this.StopVisualizationButton.Name = "StopVisualizationButton";
            this.StopVisualizationButton.Size = new System.Drawing.Size(47, 23);
            this.StopVisualizationButton.TabIndex = 30;
            this.StopVisualizationButton.Text = "Stop";
            this.StopVisualizationButton.UseVisualStyleBackColor = true;
            this.StopVisualizationButton.Click += new System.EventHandler(this.stopVisualization_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Threads:";
            // 
            // numberOfThreads
            // 
            this.numberOfThreads.Location = new System.Drawing.Point(240, 400);
            this.numberOfThreads.Name = "numberOfThreads";
            this.numberOfThreads.Size = new System.Drawing.Size(23, 20);
            this.numberOfThreads.TabIndex = 28;
            this.numberOfThreads.Text = "4";
            // 
            // StartVisualizationButton
            // 
            this.StartVisualizationButton.Location = new System.Drawing.Point(11, 398);
            this.StartVisualizationButton.Name = "StartVisualizationButton";
            this.StartVisualizationButton.Size = new System.Drawing.Size(56, 23);
            this.StartVisualizationButton.TabIndex = 27;
            this.StartVisualizationButton.Text = "Start";
            this.StartVisualizationButton.UseVisualStyleBackColor = true;
            this.StartVisualizationButton.Click += new System.EventHandler(this.StartVisualization_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.updateColorMap);
            this.groupBox3.Controls.Add(this.updateCellSizeButton);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.CellSizeUpDown);
            this.groupBox3.Controls.Add(this.MaxColorMap);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.DiscreteColorCheck);
            this.groupBox3.Controls.Add(this.ContinuousColorCheck);
            this.groupBox3.Controls.Add(this.MinColorMap);
            this.groupBox3.Controls.Add(this.ColorKeyPanel);
            this.groupBox3.Location = new System.Drawing.Point(0, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 142);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // updateColorMap
            // 
            this.updateColorMap.Location = new System.Drawing.Point(190, 107);
            this.updateColorMap.Name = "updateColorMap";
            this.updateColorMap.Size = new System.Drawing.Size(75, 23);
            this.updateColorMap.TabIndex = 26;
            this.updateColorMap.Text = "Update";
            this.updateColorMap.UseVisualStyleBackColor = true;
            this.updateColorMap.Click += new System.EventHandler(this.UpdateColorMappingLimits_Click);
            // 
            // updateCellSizeButton
            // 
            this.updateCellSizeButton.Location = new System.Drawing.Point(120, 16);
            this.updateCellSizeButton.Name = "updateCellSizeButton";
            this.updateCellSizeButton.Size = new System.Drawing.Size(145, 20);
            this.updateCellSizeButton.TabIndex = 25;
            this.updateCellSizeButton.Text = "Update";
            this.updateCellSizeButton.UseVisualStyleBackColor = true;
            this.updateCellSizeButton.Click += new System.EventHandler(this.CellSizeUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cell Size:";
            // 
            // CellSizeUpDown
            // 
            this.CellSizeUpDown.Location = new System.Drawing.Point(62, 16);
            this.CellSizeUpDown.Name = "CellSizeUpDown";
            this.CellSizeUpDown.Size = new System.Drawing.Size(52, 20);
            this.CellSizeUpDown.TabIndex = 23;
            this.CellSizeUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // MaxColorMap
            // 
            this.MaxColorMap.Location = new System.Drawing.Point(33, 113);
            this.MaxColorMap.Name = "MaxColorMap";
            this.MaxColorMap.Size = new System.Drawing.Size(37, 20);
            this.MaxColorMap.TabIndex = 21;
            this.MaxColorMap.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Min";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DiscreteColorCheck
            // 
            this.DiscreteColorCheck.AutoSize = true;
            this.DiscreteColorCheck.Location = new System.Drawing.Point(87, 91);
            this.DiscreteColorCheck.Name = "DiscreteColorCheck";
            this.DiscreteColorCheck.Size = new System.Drawing.Size(64, 17);
            this.DiscreteColorCheck.TabIndex = 18;
            this.DiscreteColorCheck.Text = "Discrete";
            this.DiscreteColorCheck.UseVisualStyleBackColor = true;
            this.DiscreteColorCheck.CheckedChanged += new System.EventHandler(this.DiscreteColorCheck_CheckedChanged);
            // 
            // ContinuousColorCheck
            // 
            this.ContinuousColorCheck.AutoSize = true;
            this.ContinuousColorCheck.Checked = true;
            this.ContinuousColorCheck.Location = new System.Drawing.Point(87, 113);
            this.ContinuousColorCheck.Name = "ContinuousColorCheck";
            this.ContinuousColorCheck.Size = new System.Drawing.Size(78, 17);
            this.ContinuousColorCheck.TabIndex = 17;
            this.ContinuousColorCheck.TabStop = true;
            this.ContinuousColorCheck.Text = "Continuous";
            this.ContinuousColorCheck.UseVisualStyleBackColor = true;
            this.ContinuousColorCheck.CheckedChanged += new System.EventHandler(this.ContinuousColorCheck_CheckedChanged);
            // 
            // MinColorMap
            // 
            this.MinColorMap.Location = new System.Drawing.Point(33, 87);
            this.MinColorMap.Name = "MinColorMap";
            this.MinColorMap.Size = new System.Drawing.Size(37, 20);
            this.MinColorMap.TabIndex = 16;
            this.MinColorMap.Text = "0";
            // 
            // ColorKeyPanel
            // 
            this.ColorKeyPanel.Location = new System.Drawing.Point(14, 42);
            this.ColorKeyPanel.Name = "ColorKeyPanel";
            this.ColorKeyPanel.Size = new System.Drawing.Size(256, 40);
            this.ColorKeyPanel.TabIndex = 15;
            this.ColorKeyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorKeyPanel_Paint_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Cell Label:";
            // 
            // cellLabel
            // 
            this.cellLabel.Location = new System.Drawing.Point(204, 170);
            this.cellLabel.Name = "cellLabel";
            this.cellLabel.Size = new System.Drawing.Size(59, 20);
            this.cellLabel.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Cell Value:";
            // 
            // cellValue
            // 
            this.cellValue.Location = new System.Drawing.Point(69, 197);
            this.cellValue.Name = "cellValue";
            this.cellValue.Size = new System.Drawing.Size(59, 20);
            this.cellValue.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cell Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Adding a new Cell Type:";
            // 
            // cellName
            // 
            this.cellName.Location = new System.Drawing.Point(69, 170);
            this.cellName.Name = "cellName";
            this.cellName.Size = new System.Drawing.Size(59, 20);
            this.cellName.TabIndex = 17;
            // 
            // addNewCellButton
            // 
            this.addNewCellButton.Location = new System.Drawing.Point(147, 197);
            this.addNewCellButton.Name = "addNewCellButton";
            this.addNewCellButton.Size = new System.Drawing.Size(116, 20);
            this.addNewCellButton.TabIndex = 16;
            this.addNewCellButton.Text = "Add Cell Type";
            this.addNewCellButton.UseVisualStyleBackColor = true;
            this.addNewCellButton.Click += new System.EventHandler(this.AddCell_Click);
            // 
            // cellTypesCombo
            // 
            this.cellTypesCombo.FormattingEnabled = true;
            this.cellTypesCombo.Location = new System.Drawing.Point(11, 124);
            this.cellTypesCombo.Name = "cellTypesCombo";
            this.cellTypesCombo.Size = new System.Drawing.Size(254, 21);
            this.cellTypesCombo.TabIndex = 15;
            // 
            // cellTypesLabels
            // 
            this.cellTypesLabels.Enabled = false;
            this.cellTypesLabels.Location = new System.Drawing.Point(11, 19);
            this.cellTypesLabels.Name = "cellTypesLabels";
            this.cellTypesLabels.Size = new System.Drawing.Size(254, 96);
            this.cellTypesLabels.TabIndex = 11;
            this.cellTypesLabels.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 460);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Temprature Visualization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RichTextBox cellTypesLabels;
        private System.Windows.Forms.Button addNewCellButton;
        public System.Windows.Forms.ComboBox cellTypesCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cellName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cellLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cellValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button updateCellSizeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CellSizeUpDown;
        private System.Windows.Forms.TextBox MaxColorMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DiscreteColorCheck;
        private System.Windows.Forms.RadioButton ContinuousColorCheck;
        private System.Windows.Forms.TextBox MinColorMap;
        private System.Windows.Forms.Panel ColorKeyPanel;
        private System.Windows.Forms.Button updateColorMap;
        private System.Windows.Forms.Button StartVisualizationButton;
        private System.Windows.Forms.TextBox numberOfThreads;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button StopVisualizationButton;
        private System.Windows.Forms.RadioButton SequentialRadio;
        private System.Windows.Forms.RadioButton CPlusRadio;
        private System.Windows.Forms.RadioButton CSharpRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberOfTicks;
    }
}

