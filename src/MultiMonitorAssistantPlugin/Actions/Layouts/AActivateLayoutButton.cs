using System.IO;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public abstract class AActivateLayoutButton : BaseButton {
    protected AActivateLayoutButton(string actionGroup, string actionName, string actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract Layout Layout { get; }
    protected abstract string Icon { get; }

    private int Progress { get; set; } = -1;

    public override bool OnButtonSetup() {
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

    private void LayoutManagerOnActivationProgress(string layoutID, int progress) {
      if (layoutID == Layout.ID)
        Progress = progress;

      UpdateButtonIcon();
    }

    public override bool OnButtonPress() {
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
