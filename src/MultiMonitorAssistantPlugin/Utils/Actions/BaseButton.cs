using System.IO;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public abstract class BaseButton : PluginDynamicCommand, IButton {
    protected BaseButton(string actionGroup, string actionName, string actionDescription) : base(actionName, actionDescription, actionGroup) { }

    protected override bool OnLoad() {
      if (OnButtonSetup()) {
        UpdateButtonIcon();

        return base.OnLoad();
      }

      return false;
    }

    protected override bool OnUnload() {
      OnButtonTeardown();

      return base.OnLoad();
    }

    protected override void RunCommand(string _) {
      if (OnButtonPress())
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon() => ActionImageChanged();

    public void UpdateButton() => UpdateButtonIcon();

    protected override BitmapImage GetCommandImage(string _, PluginImageSize imageSize) => GetButtonIcon(imageSize);

    protected override string GetCommandDisplayName(string _, PluginImageSize __) => GetButtonValue();

    public virtual bool OnButtonPress() => false;

    public virtual string GetButtonValue() => default;

    public virtual BitmapImage GetButtonIcon(PluginImageSize imageSize) => default;

    public virtual bool OnButtonSetup() => true;

    public virtual void OnButtonTeardown() { }

    protected string GetIconBasePath(int size) => Path.Combine(MultiMonitorAssistant.ResourcesPath, "Icons", $"Size{size}x{size}");
  }
}
