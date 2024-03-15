namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class ActivateLayoutButtonCenterOnly : AActivateLayoutButton {
    public ActivateLayoutButtonCenterOnly() : base(
      "Activate Layout",
      "Center Only",
      "Activate center only layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.CenterOnly;
    protected override string Icon => "CenterOnly.png";
  }
}
