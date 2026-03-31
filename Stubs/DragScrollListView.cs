using System.Drawing;
using System.Windows.Forms;
using NAPS2.Platform.Windows;

// Fixed copy - explicit WinForms Timer to avoid ambiguity with System.Threading.Timer
namespace NAPS2.WinForms;

public class DragScrollListView : ListView
{
    private System.Windows.Forms.Timer _tmrLvScroll;
    private System.ComponentModel.IContainer components;
    private int _mintScrollDirection;

    const int WM_VSCROLL = 277;
    const int SB_LINEUP = 0;
    const int SB_LINEDOWN = 1;

    public DragScrollListView()
    {
        components = new System.ComponentModel.Container();
        _tmrLvScroll = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        _tmrLvScroll.Tick += tmrLVScroll_Tick;
        HandleDestroyed += (_, _) => _tmrLvScroll.Dispose();
        DragOver += ListViewBase_DragOver;
        ResumeLayout(false);
    }

    private int EdgeSize => Font.Height;

    private void ListViewBase_DragOver(object? sender, DragEventArgs e)
    {
        Point position = PointToClient(new Point(e.X, e.Y));
        if (position.Y <= EdgeSize)
        {
            _mintScrollDirection = SB_LINEUP;
            _tmrLvScroll.Enabled = true;
        }
        else if (position.Y >= ClientSize.Height - EdgeSize)
        {
            _mintScrollDirection = SB_LINEDOWN;
            _tmrLvScroll.Enabled = true;
        }
        else
        {
            _tmrLvScroll.Enabled = false;
        }
    }

    private void tmrLVScroll_Tick(object? sender, EventArgs e)
    {
        Win32.SendMessage(Handle, WM_VSCROLL, (IntPtr)_mintScrollDirection, IntPtr.Zero);
    }
}
