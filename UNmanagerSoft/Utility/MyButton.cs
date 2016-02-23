using System;
using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Data;

namespace UNmanagerSoft
{
    public class MyButton : UserControl
    {
        private State mButtonState = State.None;
        private bool calledbykey = false;
        private int mGlowAlpha = 0;
        private void InitializeComponent()
        {
            this.Name = "MySystemButton";
            this.Size = new System.Drawing.Size(100, 32);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VistaButton_Paint);
            this.GotFocus += new EventHandler(VistaButton_MouseEnter);
            this.LostFocus += new EventHandler(VistaButton_MouseLeave);
            this.Resize += new EventHandler(VistaButton_Resize);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyDown);
            this.MouseEnter += new System.EventHandler(this.VistaButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VistaButton_MouseLeave);
            this.MouseUp += new MouseEventHandler(VistaButton_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VistaButton_MouseDown);
        }

        enum State { None, Hover, Pressed };
        /// <summary>
        /// 按钮的样式
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Draw the button as normal
            /// </summary>
            Default,
            /// <summary>
            /// Only draw the background on mouse over.
            /// </summary>
            Flat
        };

        private string mText;
        /// <summary>
        /// 按钮上显示的文本
        /// </summary>
        [Category("Text"),
         Description("按钮上显示的文本.")]
        public string ButtonText
        {
            get { return mText; }
            set { mText = value; this.Invalidate(); }
        }

        private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        [Category("Text"),
         DefaultValue(typeof(ContentAlignment), "MiddleCenter"),
         Description("The alignment of the button text " +
                     "that is displayed on the control.")]
        public ContentAlignment TextAlign
        {
            get { return mTextAlign; }
            set { mTextAlign = value; this.Invalidate(); }
        }

        private Style mButtonStyle = Style.Default;
        /// <summary>
        /// Sets whether the button background is drawn 
        /// while the mouse is outside of the client area.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Style), "Default"),
         Description("Sets whether the button background is drawn " +
                     "while the mouse is outside of the client area.")]
        public Style ButtonStyle
        {
            get { return mButtonStyle; }
            set { mButtonStyle = value; this.Invalidate(); }
        }

        private int mCornerRadius = 3;
        /// <summary>
        /// The radius for the button corners. The 
        /// greater this value is, the more 'smooth' 
        /// the corners are. This property should
        ///  not be greater than half of the 
        ///  controls height.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(8),
         Description("The radius for the button corners. The " +
                     "greater this value is, the more 'smooth' " +
                     "the corners are. This property should " +
                     "not be greater than half of the " +
                     "controls height.")]
        public int CornerRadius
        {
            get { return mCornerRadius; }
            set { mCornerRadius = value; this.Invalidate(); }
        }


        private static Color mBaseColor = Color.FromArgb(70, 139, 194);
        /// <summary>
        /// The backing color that the rest of 
        /// the button is drawn. For a glassier 
        /// effect set this property to Transparent.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The backing color that the rest of" +
                     "the button is drawn. For a glassier " +
                     "effect set this property to Transparent.")]
        public Color BaseColor
        {
            get { return mBaseColor; }
            set { mBaseColor = value; this.Invalidate(); }
        }
        private Image mBackImage;
        /// <summary>
        /// The background image for the button, 
        /// this image is drawn over the base 
        /// color of the button.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(null),
         Description("The background image for the button, " +
                     "this image is drawn over the base " +
                     "color of the button.")]
        public Image BackImage
        {
            get { return mBackImage; }
            set { mBackImage = value; this.Invalidate(); }
        }

        private Color mButtonColor = Color.Black;
        /// <summary>
        /// The bottom color of the button that 
        /// will be drawn over the base color.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The bottom color of the button that " +
                     "will be drawn over the base color.")]
        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        private Color mHighlightColor = Color.Gray;
        /// <summary>
        /// The colour of the highlight on the top of the button.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "White"),
         Description("The colour of the highlight on the top of the button.")]
        public Color HighlightColor
        {
            get { return mHighlightColor; }
            set { mHighlightColor = value; this.Invalidate(); }
        }
        private Color mGlowColor = Color.FromArgb(141, 189, 255);
        /// <summary>
        /// 鼠标移上去之后显示的颜色
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof(Color), "141,189,255"),
         Description("The colour that the button glows when " +
                     "the mouse is inside the client area.")]
        public Color GlowColor
        {
            get { return mGlowColor; }
            set { mGlowColor = value; this.Invalidate(); }
        }
        /// <summary>
        /// 按钮的形状
        /// </summary>
        /// <param name="r"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        /// <returns></returns>
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }
        /// <summary>
        /// 对齐方式
        /// </summary>
        /// <param name="textalign"></param>
        /// <returns></returns>
        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }
        /// <summary>
        /// 画出按钮的外框线条
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawOuterStroke(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            Rectangle r = this.ClientRectangle;
            r.Width -= 1; r.Height -= 1;
            using (GraphicsPath rr = RoundRect(
                r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))  //圆角矩形
            {
                using (Pen p = new Pen(this.ButtonColor))
                {
                    g.DrawPath(p, rr);     //画出外框
                }
            }
        }

        /// <summary>
        /// 画出按钮的内框线条
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawInnerStroke(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            Rectangle r = this.ClientRectangle;
            r.X++; r.Y++;
            r.Width -= 3; r.Height -= 3;
            using (GraphicsPath rr = RoundRect(
                r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (Pen p = new Pen(this.HighlightColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }
        /// <summary>
        /// 画出按钮的背景
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawBackground(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            int alpha = (mButtonState == State.Pressed) ? 204 : 127;
            Rectangle r = this.ClientRectangle;
            r.Width--; r.Height--;
            using (GraphicsPath rr = RoundRect(
                r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (SolidBrush sb = new SolidBrush(this.BaseColor))
                {
                    g.FillPath(sb, rr);
                }
                if (this.BackImage != null) { g.DrawImage(this.BackImage, this.ClientRectangle); }
                g.ResetClip();
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(alpha, this.ButtonColor)))
                {
                    g.FillPath(sb, rr);
                }
            }
        }
        /// <summary>
        /// 画出按钮的上半部分高光颜色
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawHighlight(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            int alpha = (mButtonState == State.Pressed) ? 60 : 150;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height / 2);
            using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
            {
                using (LinearGradientBrush lg = new LinearGradientBrush(r.GetBounds(),
                                            Color.FromArgb(alpha, this.HighlightColor),
                                            Color.FromArgb(alpha / 3, this.HighlightColor),
                                            LinearGradientMode.Vertical))
                {
                    g.FillPath(lg, r);
                }
            }
        }
        /// <summary>
        /// 当鼠标移上去的时候的炫光
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawGlow(Graphics g)
        {
            if (this.mButtonState == State.Pressed) { return; }
            using (GraphicsPath glow = new GraphicsPath())
            {
                Rectangle r = this.ClientRectangle;
                //r.Width -= 3; r.Height -= 3;
                glow.AddPath(RoundRect(
                    new Rectangle(r.Left + 1, r.Top + 1, r.Width - 3, r.Height - 3)
                    , CornerRadius, CornerRadius, CornerRadius, CornerRadius), true);
                using (GraphicsPath gp = RoundRect(
                    new Rectangle(r.Left + 1, r.Top + 1, r.Width - 3, r.Height / 2 - 2)
                    , CornerRadius, CornerRadius, CornerRadius, CornerRadius))
                {
                    Color c = Color.FromArgb(mGlowAlpha, this.GlowColor);
                    Color c1 = Color.FromArgb(mGlowAlpha / 2 + 50, Color.White);
                    using (SolidBrush sb = new SolidBrush(c))
                    {
                        using (SolidBrush sb1 = new SolidBrush(c1))
                        {
                            g.FillPath(sb, glow);
                            g.FillPath(sb1, gp);
                        }
                    }
                }
            }
            g.ResetClip();
        }
        /// <summary>
        /// 显示按钮的文本
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment(this.TextAlign);
            Rectangle r = new Rectangle(8, 8, this.Width - 17, this.Height - 17);
            g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
        }

        private void VistaButton_Resize(object sender, EventArgs e)
        {
            Rectangle r = this.ClientRectangle;
            r.X -= 1; r.Y -= 1;
            r.Width += 2; r.Height += 2;
            using (GraphicsPath rr = RoundRect(
                r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                this.Region = new Region(rr);
            }
        }
        private void VistaButton_MouseEnter(object sender, EventArgs e)
        {
            mButtonState = State.Hover;
        }

        private void VistaButton_MouseLeave(object sender, EventArgs e)
        {
            mButtonState = State.None;
            if (this.mButtonStyle == Style.Flat) { mGlowAlpha = 0; }
        }

        public MyButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void VistaButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(g);
            DrawHighlight(g);
            DrawGlow(g);
            //DrawIcon(g);
            DrawText(g);
            DrawInnerStroke(g);
        }

        private void VistaButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mButtonState = State.Pressed;
                if (this.mButtonStyle != Style.Flat) { mGlowAlpha = 255; }
                //mFadeIn.Stop();
                //mFadeOut.Stop();
                this.Invalidate();
            }
        }

        private void VistaButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mButtonState = State.Hover;
                //mFadeIn.Stop();
                //mFadeOut.Stop();
                this.Invalidate();
                if (calledbykey == true) 
                { 
                    this.OnClick(EventArgs.Empty); calledbykey = false; 
                }
            }
        }

        private void VistaButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                VistaButton_MouseDown(sender, m);
            }
        }

        private void VistaButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                calledbykey = true;
                VistaButton_MouseUp(sender, m);
            }
        }
    }
}
