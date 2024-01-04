namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  using System;
  using System.IO;

  public abstract class ASleepMonitorButton : BaseButton {
    protected ASleepMonitorButton(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract Monitor Monitor { get; }
    protected abstract String Icon { get; }

    public override Boolean OnButtonSetup() {
      if (Monitor != default) {
        MultiMonitorAssistant.State.IsBusyChanged += UpdateButtonIcon;
        return true;
      }

      return false;
    }

    public override void OnButtonTeardown() => MultiMonitorAssistant.State.IsBusyChanged -= UpdateButtonIcon;

    public override Boolean OnButtonPress() {
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
