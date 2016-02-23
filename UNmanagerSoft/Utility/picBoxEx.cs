using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace UNmanagerSoft
{
    public partial class picBoxEx : PictureBox
    {
        private ToolStripStatusLabelBorderSides borderSide;
        [DefaultValue(ToolStripStatusLabelBorderSides.All), Description("选择框体为那几边")]
        public ToolStripStatusLabelBorderSides BorderSide
        {
            get { return borderSide; }
            set 
            {
                borderSide = value;
                this.Invalidate();
            }
        }
        private Border3DStyle border3DStyle;
        [DefaultValue(Border3DStyle.Etched), Description("边框三维样式。仅当边框为三维模式时有效")]
        public Border3DStyle Border3DStyle
        {
            get { return border3DStyle; }
            set
            {
                if (border3DStyle == value) { return; }
                border3DStyle = value;
                this.Invalidate();
            }
        }

        public picBoxEx()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            this.border3DStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.borderSide = ToolStripStatusLabelBorderSides.All;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using(Graphics g = pe.Graphics)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle,Border3DStyle.Etched
                    , (Border3DSide)borderSide);
            }
        }
    }
}
