using System.Drawing;
using System.Windows.Forms;

namespace OopPaint
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;
        private Panel canvasPanel = null!;
        private Button btnAddSquare = null!;
        private Button btnAddRectangle = null!;
        private Button btnAddCircle = null!;
        private Button btnAddTriangle = null!;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            canvasPanel = new Panel();
            btnAddSquare = new Button();
            btnAddRectangle = new Button();
            btnAddCircle = new Button();
            btnAddTriangle = new Button();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            backgroundColorPickBtn = new Button();
            borderColorPickBtn = new Button();
            textColorPickBtn = new Button();
            groupBox2 = new GroupBox();
            figureSettingsBtn = new Button();
            groupBox3 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblAreaCaption = new Label();
            areaLabel = new Label();
            lblPerimeterCaption = new Label();
            perimeterLabel = new Label();
            label4 = new Label();
            classLabel = new Label();
            lblInstructions = new Label();
            statementBox = new Label();
            groupBox4 = new GroupBox();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // canvasPanel
            // 
            canvasPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            canvasPanel.BackColor = Color.WhiteSmoke;
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.Location = new Point(6, 22);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(587, 600);
            canvasPanel.TabIndex = 0;
            // 
            // btnAddSquare
            // 
            btnAddSquare.Location = new Point(9, 22);
            btnAddSquare.Name = "btnAddSquare";
            btnAddSquare.Size = new Size(259, 30);
            btnAddSquare.TabIndex = 1;
            btnAddSquare.Tag = "Square";
            btnAddSquare.Text = "Dodaj Kwadrat";
            btnAddSquare.UseVisualStyleBackColor = true;
            btnAddSquare.Click += AddFigureBtn_Click;
            // 
            // btnAddRectangle
            // 
            btnAddRectangle.Location = new Point(9, 62);
            btnAddRectangle.Name = "btnAddRectangle";
            btnAddRectangle.Size = new Size(259, 30);
            btnAddRectangle.TabIndex = 2;
            btnAddRectangle.Tag = "Rectangle";
            btnAddRectangle.Text = "Dodaj Prostokąt";
            btnAddRectangle.UseVisualStyleBackColor = true;
            btnAddRectangle.Click += AddFigureBtn_Click;
            // 
            // btnAddCircle
            // 
            btnAddCircle.Location = new Point(9, 102);
            btnAddCircle.Name = "btnAddCircle";
            btnAddCircle.Size = new Size(259, 30);
            btnAddCircle.TabIndex = 3;
            btnAddCircle.Tag = "Circle";
            btnAddCircle.Text = "Dodaj Koło";
            btnAddCircle.UseVisualStyleBackColor = true;
            btnAddCircle.Click += AddFigureBtn_Click;
            // 
            // btnAddTriangle
            // 
            btnAddTriangle.Location = new Point(9, 142);
            btnAddTriangle.Name = "btnAddTriangle";
            btnAddTriangle.Size = new Size(259, 30);
            btnAddTriangle.TabIndex = 4;
            btnAddTriangle.Tag = "Triangle";
            btnAddTriangle.Text = "Dodaj Trójkąt";
            btnAddTriangle.UseVisualStyleBackColor = true;
            btnAddTriangle.Click += AddFigureBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(617, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(274, 121);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Właściwości";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.6848259F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.31518F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(backgroundColorPickBtn, 1, 0);
            tableLayoutPanel1.Controls.Add(borderColorPickBtn, 1, 1);
            tableLayoutPanel1.Controls.Add(textColorPickBtn, 1, 2);
            tableLayoutPanel1.Location = new Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(262, 93);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Kolor tła:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "Kolor obrysu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Kolor tekstu:";
            // 
            // backgroundColorPickBtn
            // 
            backgroundColorPickBtn.BackColor = Color.White;
            backgroundColorPickBtn.Location = new Point(88, 3);
            backgroundColorPickBtn.Name = "backgroundColorPickBtn";
            backgroundColorPickBtn.Size = new Size(23, 23);
            backgroundColorPickBtn.TabIndex = 3;
            backgroundColorPickBtn.Tag = "Background";
            backgroundColorPickBtn.UseVisualStyleBackColor = false;
            backgroundColorPickBtn.Click += PickColor_Click;
            // 
            // borderColorPickBtn
            // 
            borderColorPickBtn.BackColor = Color.Red;
            borderColorPickBtn.Location = new Point(88, 33);
            borderColorPickBtn.Name = "borderColorPickBtn";
            borderColorPickBtn.Size = new Size(23, 23);
            borderColorPickBtn.TabIndex = 4;
            borderColorPickBtn.Tag = "Border";
            borderColorPickBtn.UseVisualStyleBackColor = false;
            borderColorPickBtn.Click += PickColor_Click;
            // 
            // textColorPickBtn
            // 
            textColorPickBtn.BackColor = Color.Red;
            textColorPickBtn.Location = new Point(88, 63);
            textColorPickBtn.Name = "textColorPickBtn";
            textColorPickBtn.Size = new Size(23, 23);
            textColorPickBtn.TabIndex = 5;
            textColorPickBtn.Tag = "Text";
            textColorPickBtn.UseVisualStyleBackColor = false;
            textColorPickBtn.Click += PickColor_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(figureSettingsBtn);
            groupBox2.Controls.Add(btnAddSquare);
            groupBox2.Controls.Add(btnAddRectangle);
            groupBox2.Controls.Add(btnAddCircle);
            groupBox2.Controls.Add(btnAddTriangle);
            groupBox2.Location = new Point(617, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(274, 238);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Akcje";
            // 
            // figureSettingsBtn
            // 
            figureSettingsBtn.Location = new Point(6, 202);
            figureSettingsBtn.Name = "figureSettingsBtn";
            figureSettingsBtn.Size = new Size(259, 30);
            figureSettingsBtn.TabIndex = 5;
            figureSettingsBtn.Text = "Ustawienia";
            figureSettingsBtn.UseVisualStyleBackColor = true;
            figureSettingsBtn.Click += figureSettingsBtn_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel2);
            groupBox3.Controls.Add(lblInstructions);
            groupBox3.Controls.Add(statementBox);
            groupBox3.Location = new Point(617, 383);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(274, 257);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Szczegóły";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.1044178F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.8955841F));
            tableLayoutPanel2.Controls.Add(lblAreaCaption, 0, 0);
            tableLayoutPanel2.Controls.Add(areaLabel, 1, 0);
            tableLayoutPanel2.Controls.Add(lblPerimeterCaption, 0, 1);
            tableLayoutPanel2.Controls.Add(perimeterLabel, 1, 1);
            tableLayoutPanel2.Controls.Add(label4, 0, 2);
            tableLayoutPanel2.Controls.Add(classLabel, 1, 2);
            tableLayoutPanel2.Location = new Point(9, 22);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(256, 75);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // lblAreaCaption
            // 
            lblAreaCaption.AutoSize = true;
            lblAreaCaption.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblAreaCaption.Location = new Point(3, 0);
            lblAreaCaption.Name = "lblAreaCaption";
            lblAreaCaption.Size = new Size(33, 15);
            lblAreaCaption.TabIndex = 11;
            lblAreaCaption.Text = "Pole:";
            // 
            // areaLabel
            // 
            areaLabel.AutoSize = true;
            areaLabel.Font = new Font("Segoe UI", 9F);
            areaLabel.Location = new Point(69, 0);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new Size(12, 15);
            areaLabel.TabIndex = 13;
            areaLabel.Text = "-";
            // 
            // lblPerimeterCaption
            // 
            lblPerimeterCaption.AutoSize = true;
            lblPerimeterCaption.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblPerimeterCaption.Location = new Point(3, 20);
            lblPerimeterCaption.Name = "lblPerimeterCaption";
            lblPerimeterCaption.Size = new Size(49, 15);
            lblPerimeterCaption.TabIndex = 12;
            lblPerimeterCaption.Text = "Obwód:";
            // 
            // perimeterLabel
            // 
            perimeterLabel.AutoSize = true;
            perimeterLabel.Font = new Font("Segoe UI", 9F);
            perimeterLabel.Location = new Point(69, 20);
            perimeterLabel.Name = "perimeterLabel";
            perimeterLabel.Size = new Size(12, 15);
            perimeterLabel.TabIndex = 14;
            perimeterLabel.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(3, 40);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 15;
            label4.Text = "Klasa:";
            // 
            // classLabel
            // 
            classLabel.AutoSize = true;
            classLabel.Location = new Point(69, 40);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(12, 15);
            classLabel.TabIndex = 16;
            classLabel.Text = "-";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblInstructions.Location = new Point(6, 127);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(68, 15);
            lblInstructions.TabIndex = 16;
            lblInstructions.Text = "Opis figury:";
            // 
            // statementBox
            // 
            statementBox.BorderStyle = BorderStyle.FixedSingle;
            statementBox.Location = new Point(6, 151);
            statementBox.Name = "statementBox";
            statementBox.Size = new Size(259, 100);
            statementBox.TabIndex = 15;
            statementBox.Text = "Kliknij na figurę, żeby sprawdzić";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(canvasPanel);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(599, 628);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Obszar rysowania";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 652);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Object-Oriented Paint";
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button backgroundColorPickBtn;
        private Button borderColorPickBtn;
        private Button textColorPickBtn;
        private GroupBox groupBox2;
        private Button figureSettingsBtn;
        private GroupBox groupBox3;
        private Label lblInstructions;
        private Label statementBox;
        private Label perimeterLabel;
        private Label areaLabel;
        private Label lblPerimeterCaption;
        private Label lblAreaCaption;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Label classLabel;
    }
}
