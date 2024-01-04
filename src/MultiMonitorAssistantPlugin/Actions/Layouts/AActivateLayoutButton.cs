namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.IO;

  public abstract class AActivateLayoutButton : BaseButton {
    protected AActivateLayoutButton(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract Layout Layout { get; }
    protected abstract String Icon { get; }

    private Int32 Progress { get; set; } = -1;

    public override Boolean OnButtonSetup() {
      if (Layout != default) {
        MultiMonitorAssistant.State.IsBusyChanged += UpdateButtonIcon;
        MultiMonitorAssistant.LayoutManager.ActivationProgress += LayoutManagerOnActivationProgress;
        return true;
      }

      return false;
    }

    public override void OnButtonTeardown() {
      MultiMonitorAssistant.State.IsBusyChanged -= UpdateButtonIcon;
      MultiMonitorAssistant.LayoutManager.ActivationProgress -= LayoutManagerOnActivationProgress;
    }

    private void LayoutManagerOnActivationProgress(String layoutID, Int32 progress) {
      if (layoutID == Layout.ID)
        Progress = progress;

      UpdateButtonIcon();
    }

    public override Boolean OnButtonPress() {
      if (MultiMonitorAssistant.State.IsBusy)
        return false;

      MultiMonitorAssistant.LayoutManager.Activate(Layout);

      return true;
    }

    public override BitmapImage GetButtonIcon(PluginImageSize imageSize) {
      if (MultiMonitorAssistant.State.IsBusy) {
        if (Progress != -1)
          using (var bitmapBuilder = new BitmapBuilder(imageSize)) {
            bitmapBuilder.SetBackgroundImage(BitmapImage.FromFile(Path.Combine(GetIconBasePath(80), "Layouts", "Busy.Progress.png")));
            bitmapBuilder.DrawText($"{$"{Progress}",3} %");

            return bitmapBuilder.ToImage();
          }

        return BitmapImage.FromFile(Path.Combine(GetIconBasePath(80), "Layouts", "Busy.png"));
      }

      return BitmapImage.FromFile(Path.Combine(GetIconBasePath(80), "Layouts", Icon));
    }
  }
}
