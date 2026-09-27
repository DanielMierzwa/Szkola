namespace OopPaint.Forms
{
    partial class FigureSettingsForm
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            squareEdge = new NumericUpDown();
            groupBox2 = new GroupBox();
            rectangleWidth = new NumericUpDown();
            label5 = new Label();
            label2 = new Label();
            rectangleHeight = new NumericUpDown();
            groupBox3 = new GroupBox();
            label3 = new Label();
            circleRadius = new NumericUpDown();
            groupBox4 = new GroupBox();
            triangleWidth = new NumericUpDown();
            label6 = new Label();
            label4 = new Label();
            triangleHeight = new NumericUpDown();
            saveChangesBtn = new Button();
            secretLabel = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)squareEdge).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rectangleWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rectangleHeight).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)circleRadius).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)triangleWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triangleHeight).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(squareEdge);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 58);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kwadrat";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 24);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "Długość boku:";
            // 
            // squareEdge
            // 
            squareEdge.Location = new Point(98, 22);
            squareEdge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            squareEdge.Name = "squareEdge";
            squareEdge.Size = new Size(120, 23);
            squareEdge.TabIndex = 0;
            squareEdge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            squareEdge.ValueChanged += SettingChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rectangleWidth);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(rectangleHeight);
            groupBox2.Location = new Point(12, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(429, 58);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Prostokąt";
            // 
            // rectangleWidth
            // 
            rectangleWidth.Location = new Point(298, 22);
            rectangleWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rectangleWidth.Name = "rectangleWidth";
            rectangleWidth.Size = new Size(120, 23);
            rectangleWidth.TabIndex = 3;
            rectangleWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            rectangleWidth.ValueChanged += SettingChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(230, 24);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 2;
            label5.Text = "Szerokość:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 24);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Wysokość:";
            // 
            // rectangleHeight
            // 
            rectangleHeight.Location = new Point(98, 22);
            rectangleHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rectangleHeight.Name = "rectangleHeight";
            rectangleHeight.Size = new Size(120, 23);
            rectangleHeight.TabIndex = 0;
            rectangleHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            rectangleHeight.ValueChanged += SettingChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(circleRadius);
            groupBox3.Location = new Point(12, 140);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(429, 58);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Koło";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 24);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 1;
            label3.Text = "Promień:";
            // 
            // circleRadius
            // 
            circleRadius.Location = new Point(98, 22);
            circleRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            circleRadius.Name = "circleRadius";
            circleRadius.Size = new Size(120, 23);
            circleRadius.TabIndex = 0;
            circleRadius.Value = new decimal(new int[] { 1, 0, 0, 0 });
            circleRadius.ValueChanged += SettingChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(triangleWidth);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(triangleHeight);
            groupBox4.Location = new Point(12, 204);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(429, 58);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Trójkąt";
            // 
            // triangleWidth
            // 
            triangleWidth.Location = new Point(298, 22);
            triangleWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            triangleWidth.Name = "triangleWidth";
            triangleWidth.Size = new Size(120, 23);
            triangleWidth.TabIndex = 5;
            triangleWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            triangleWidth.ValueChanged += SettingChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(230, 24);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 4;
            label6.Text = "Szerokość:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 24);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 1;
            label4.Text = "Wysokość:";
            // 
            // triangleHeight
            // 
            triangleHeight.Location = new Point(98, 22);
            triangleHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            triangleHeight.Name = "triangleHeight";
            triangleHeight.Size = new Size(120, 23);
            triangleHeight.TabIndex = 0;
            triangleHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            triangleHeight.ValueChanged += SettingChanged;
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 287);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(150, 39);
            saveChangesBtn.TabIndex = 3;
            saveChangesBtn.Text = "Zapisz zmiany";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // secretLabel
            // 
            secretLabel.AutoSize = true;
            secretLabel.Location = new Point(356, 314);
            secretLabel.Name = "secretLabel";
            secretLabel.Size = new Size(85, 15);
            secretLabel.TabIndex = 4;
            secretLabel.TabStop = true;
            secretLabel.Text = "Nie klikaj tego!";
            secretLabel.LinkClicked += secretLabel_LinkClicked;
            // 
            // FigureSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 338);
            Controls.Add(secretLabel);
            Controls.Add(saveChangesBtn);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FigureSettingsForm";
            Text = "Ustawienia figur";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)squareEdge).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rectangleWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)rectangleHeight).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)circleRadius).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)triangleWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)triangleHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown squareEdge;
        private Label label1;
        private GroupBox groupBox2;
        private NumericUpDown rectangleWidth;
        private Label label5;
        private Label label2;
        private NumericUpDown rectangleHeight;
        private GroupBox groupBox3;
        private Label label3;
        private NumericUpDown circleRadius;
        private GroupBox groupBox4;
        private Label label4;
        private NumericUpDown triangleHeight;
        private Button saveChangesBtn;
        private LinkLabel secretLabel;
        private NumericUpDown triangleWidth;
        private Label label6;
    }
}