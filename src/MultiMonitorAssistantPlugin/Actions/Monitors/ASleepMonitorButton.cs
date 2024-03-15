using System.IO;

namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  public abstract class ASleepMonitorButton : BaseButton {
    protected ASleepMonitorButton(string actionGroup, string actionName, string actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract Monitor Monitor { get; }
    protected abstract string Icon { get; }

    public override bool OnButtonSetup() {
      if (Monitor != default) {
        MultiMonitorAssistant.State.IsBusyChanged += UpdateButtonIcon;
        return true;
      }

      return false;
    }

    public override void OnButtonTeardown() => MultiMonitorAssistant.State.IsBusyChanged -= UpdateButtonIcon;

    public override bool OnButtonPress() {
      if (MultiMonitorAssistant.State.IsBusy)
        return false;

      MultiMonitorAssistant.MonitorManager.Sleep(Monitor);

      return true;
    }

    public override BitmapImage GetButtonIcon(PluginImageSize imageSize) {
      if (MultiMonitorAssistant.State.IsBusy)
        return BitmapImage.FromFile(Path.Combine(GetIconBasePath(80), "Monitors", "Busy.png"));

      return BitmapImage.FromFile(Path.Combine(GetIconBasePath(80), "Monitors", Icon));
    }
  }
}
