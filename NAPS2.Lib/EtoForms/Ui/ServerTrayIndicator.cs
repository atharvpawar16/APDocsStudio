using Eto.Forms;

namespace NAPS2.EtoForms.Ui;

public class ServerTrayIndicator : TrayIndicator
{
    public ServerTrayIndicator()
    {
        Image = Icons.favicon.ToEtoImage();
        Title = string.Format(UiStrings.Naps2TitleFormat, UiStrings.ScannerSharing);
        Menu = new ContextMenu(
            new ButtonMenuItem
            {
                Text = UiStrings.StopScannerSharing,
                Command = new ActionCommand(() => StopClicked?.Invoke(this, EventArgs.Empty))
            }
        );
    }

    public event EventHandler? StopClicked;
}