namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.IO;

  public abstract class BaseButton : PluginDynamicCommand, IButton {
    protected BaseButton(String actionGroup, String actionName, String actionDescription) : base(actionName, actionDescription, actionGroup) { }

    protected override Boolean OnLoad() {
      if (OnButtonSetup()) {
        UpdateButtonIcon();

        return base.OnLoad();
      }

      return false;
    }

    protected override Boolean OnUnload() {
      OnButtonTeardown();

      return base.OnLoad();
    }

    protected override void RunCommand(String _) {
      if (OnButtonPress())
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon() => ActionImageChanged();

    public void UpdateButton() => UpdateButtonIcon();

    protected override BitmapImage GetCommandImage(String _, PluginImageSize imageSize) => GetButtonIcon(imageSize);

    protected override String GetCommandDisplayName(String _, PluginImageSize __) => GetButtonValue();

    public virtual Boolean OnButtonPress() => false;

    public virtual String GetButtonValue() => default;

    public virtual BitmapImage GetButtonIcon(PluginImageSize imageSize) => default;

    public virtual Boolean OnButtonSetup() => true;

    public virtual void OnButtonTeardown() { }

    protected String GetIconBasePath(Int32 size) => Path.Combine(MultiMonitorAssistant.ResourcesPath, "Icons", $"Size{size}x{size}");
  }
}
