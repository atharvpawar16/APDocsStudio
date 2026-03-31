using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APDocsStudio;

/// <summary>
/// Glassmorphism-style toolbar renderer for APDocs Studio.
/// Frosted glass panels, rounded buttons, soft shadows, mesh gradient background.
/// </summary>
public class GlassToolStripRenderer : ToolStripRenderer
{
    // Glass palette
    private static readonly Color GlassBg1     = Color.FromArgb(255, 240, 245, 255); // soft blue-white
    private static readonly Color GlassBg2     = Color.FromArgb(255, 225, 235, 255); // slightly deeper
    private static readonly Color ButtonNormal  = Color.FromArgb(30,  255, 255, 255); // near-transparent white
    private static readonly Color ButtonHover   = Color.FromArgb(90,  100, 160, 255); // blue tint
    private static readonly Color ButtonPressed = Color.FromArgb(140, 60,  120, 220); // deeper blue
    private static readonly Color BorderGlass   = Color.FromArgb(80,  255, 255, 255); // white border
    private static readonly Color TextDark      = Color.FromArgb(30,  30,  60);       // deep navy text
    private static readonly Color TextDisabled  = Color.FromArgb(160, 160, 180);
    private static readonly Color SepColor      = Color.FromArgb(60,  180, 200, 255);

    // Toolbar background — mesh gradient, clipped to exact bounds
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        var r = e.AffectedBounds;
        e.Graphics.SetClip(r);
        using var brush = new LinearGradientBrush(r.IsEmpty ? new Rectangle(0,0,1,1) : r,
            GlassBg1, GlassBg2, LinearGradientMode.Horizontal);
        var blend = new ColorBlend(4)
        {
            Colors = new[]
            {
                Color.FromArgb(255, 235, 245, 255),
                Color.FromArgb(255, 220, 235, 255),
                Color.FromArgb(255, 230, 240, 255),
                Color.FromArgb(255, 215, 230, 255),
            },
            Positions = new[] { 0f, 0.33f, 0.66f, 1f }
        };
        brush.InterpolationColors = blend;
        e.Graphics.FillRectangle(brush, r);
        e.Graphics.ResetClip();

        // Bottom border line
        using var pen = new Pen(Color.FromArgb(120, 180, 200, 255));
        e.Graphics.DrawLine(pen, r.Left, r.Bottom - 1, r.Right, r.Bottom - 1);
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

    // Rounded button background — clipped to item bounds
    protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    {
        e.Graphics.SetClip(new Rectangle(0, 0, e.Item.Width, e.Item.Height));
        DrawGlassButton(e.Graphics, e.Item);
        e.Graphics.ResetClip();
    }

    protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
    {
        e.Graphics.SetClip(new Rectangle(0, 0, e.Item.Width, e.Item.Height));
        DrawGlassButton(e.Graphics, e.Item);
        e.Graphics.ResetClip();
    }

    protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
    {
        e.Graphics.SetClip(new Rectangle(0, 0, e.Item.Width, e.Item.Height));
        DrawGlassButton(e.Graphics, e.Item);
        if (e.Item is ToolStripSplitButton btn)
        {
            using var pen = new Pen(SepColor);
            int x = btn.ButtonBounds.Right;
            e.Graphics.DrawLine(pen, x, 5, x, btn.Height - 5);
        }
        e.Graphics.ResetClip();
    }

    private void DrawGlassButton(Graphics g, ToolStripItem item)
    {
        if (!item.Selected && !item.Pressed) return;

        // Fill the entire button — no inset
        var rect = new Rectangle(0, 0, item.Width, item.Height);
        if (rect.Width <= 0 || rect.Height <= 0) return;

        var color = item.Pressed ? ButtonPressed : ButtonHover;

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.SetClip(new Rectangle(0, 0, item.Width, item.Height));

        // Glass fill — covers the full button
        using (var fillBrush = new SolidBrush(color))
            FillRoundRect(g, fillBrush, rect, 8);

        // Shine on top half
        var shineRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height / 2 - 2);
        if (shineRect.Width > 0 && shineRect.Height > 0)
        {
            using var shineBrush = new LinearGradientBrush(
                new Point(shineRect.X, shineRect.Y),
                new Point(shineRect.X, shineRect.Bottom),
                Color.FromArgb(50, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255));
            FillRoundRect(g, shineBrush, shineRect, 6);
        }

        // Border
        using (var borderPen = new Pen(BorderGlass, 1f))
            DrawRoundRect(g, borderPen, rect, 8);

        g.ResetClip();
        g.SmoothingMode = SmoothingMode.Default;
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.TextColor = e.Item.Enabled ? TextDark : TextDisabled;
        e.TextFont = new Font("Segoe UI", 8.25f, FontStyle.Regular);
        base.OnRenderItemText(e);
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        int x = e.Item.Width / 2;
        using var pen = new Pen(SepColor, 1f);
        e.Graphics.DrawLine(pen, x, 6, x, e.Item.Height - 6);
    }

    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        e.ArrowColor = Color.FromArgb(80, 80, 140);
        base.OnRenderArrow(e);
    }

    protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
    {
        DrawGlassButton(e.Graphics, e.Item);
    }

    // Helper: fill rounded rectangle
    private static void FillRoundRect(Graphics g, Brush brush, Rectangle r, int radius)
    {
        using var path = RoundedRect(r, radius);
        g.FillPath(brush, path);
    }

    private static void DrawRoundRect(Graphics g, Pen pen, Rectangle r, int radius)
    {
        using var path = RoundedRect(r, radius);
        g.DrawPath(pen, path);
    }

    private static GraphicsPath RoundedRect(Rectangle r, int radius)
    {
        int d = radius * 2;
        var path = new GraphicsPath();
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}

/// <summary>
/// Mesh gradient background panel for the main content area.
/// </summary>
public class GlassBackgroundPanel : Panel
{
    private static readonly Color[] MeshColors =
    {
        Color.FromArgb(255, 235, 245, 255),
        Color.FromArgb(255, 220, 235, 250),
        Color.FromArgb(255, 230, 240, 255),
        Color.FromArgb(255, 210, 228, 248),
    };

    public GlassBackgroundPanel()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var r = ClientRectangle;
        using var brush = new LinearGradientBrush(r,
            MeshColors[0], MeshColors[3], 45f);
        var blend = new ColorBlend(4)
        {
            Colors = MeshColors,
            Positions = new[] { 0f, 0.35f, 0.65f, 1f }
        };
        brush.InterpolationColors = blend;
        e.Graphics.FillRectangle(brush, r);
    }
}
