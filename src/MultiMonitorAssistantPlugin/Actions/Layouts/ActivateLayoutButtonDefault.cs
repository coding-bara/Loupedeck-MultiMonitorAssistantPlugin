namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class ActivateLayoutButtonDefault : AActivateLayoutButton {
    public ActivateLayoutButtonDefault() : base(
      "Activate Layout",
      "Default",
      "Activate default layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.Default;
    protected override string Icon => "Default.png";
  }
}
