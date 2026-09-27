using OopPaint.Data;
using OopPaint.Data.Enums;
using OopPaint.Forms;
using OopPaint.Services;

namespace OopPaint
{
    public partial class MainForm : Form
    {
        private readonly PaintEngine _engine;

        public MainForm()
        {
            InitializeComponent();

            var textControls = new TextControls
            {
                AreaLabel = areaLabel,
                PerimeterLabel = perimeterLabel,
                ClassLabel = classLabel,
                StatementBox = statementBox
            };
            _engine = new(canvasPanel, textControls);
        }

        private void PickColor_Click(object? sender, EventArgs e)
        {
            using var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var senderBtn = sender as Button;

                senderBtn!.BackColor = colorDialog.Color;
                var tag = (senderBtn!.Tag as string)!;

                _engine.UpdateCurrentColors(Enum.Parse<FigureColorTarget>(tag), colorDialog.Color);
            }
        }

        private void AddFigureBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            var figureType = Enum.Parse<FigureType>(btn!.Tag as string);
            _engine.AddFigure(figureType);
        }

        private void figureSettingsBtn_Click(object sender, EventArgs e)
        {
            using var settingsForm = new FigureSettingsForm(_engine);
            if (settingsForm.ShowDialog() == DialogResult.OK && settingsForm.FigureSettings is not null)
            {
                _engine.UpdateFigureSettings(settingsForm.FigureSettings);
            }
        }
    }
}
