using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom;

public class SpinningCircles : Control
{
    private readonly int circleRadiusIncrement = 1;
    private readonly int circleRadius = 4;
    private readonly int circleCount = 8;
    private int next = 0;
    private readonly Timer animationTimer;
    public SpinningCircles()
    {
        animationTimer = new Timer() { Interval = 64 };
        this.Size = new Size(100, 100);
        animationTimer.Tick += (s, e) => this.Invalidate();
        if (!DesignMode) animationTimer.Enabled = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        if (Parent != null && this.BackColor == Color.Transparent)
        {
            using var bmp = new Bitmap(Parent.Width, Parent.Height);
            Parent.Controls.Cast<Control>()
                  .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                  .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                  .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                  .ToList()
                  .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

            e.Graphics.DrawImage(bmp, -Left, -Top);
        }
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        int length = Math.Min(Width, Height);
        PointF center = new(length / 2, length / 2);
        int bigRadius = length / 2 - circleRadius - (circleCount - 1) * circleRadiusIncrement;
        float unitAngle = 360 / circleCount;
        if (!DesignMode) next++;
        next = next >= circleCount ? 0 : next;
        int different = 0;
        for (int index = next; index < next + circleCount; index++)
        {
            int factor = index % circleCount;
            float c1X = center.X + (float)(bigRadius * Math.Cos(unitAngle * factor * Math.PI / 180));
            float c1Y = center.Y + (float)(bigRadius * Math.Sin(unitAngle * factor * Math.PI / 180));
            int curruntRadius = circleRadius + different * circleRadiusIncrement;
            PointF c1 = new(c1X - curruntRadius, c1Y - curruntRadius);
            e.Graphics.FillEllipse(new SolidBrush(Main.BaseColor), c1.X, c1.Y, 2 * curruntRadius, 2 * curruntRadius);
            using (Pen pen = new(Color.White, 2)) e.Graphics.DrawEllipse(pen, c1.X, c1.Y, 2 * curruntRadius, 2 * curruntRadius);
            different++;
        }
    }
    protected override void OnVisibleChanged(EventArgs e)
    {
        animationTimer.Enabled = Visible;
        base.OnVisibleChanged(e);
    }
}
