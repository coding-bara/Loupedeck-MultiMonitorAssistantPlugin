namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class ActivateLayoutButtonCenterOnly : AActivateLayoutButton {
    public ActivateLayoutButtonCenterOnly() : base(
      "Activate Layout",
      "Center Only",
      "Activate center only layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.CenterOnly;
    protected override String Icon => "CenterOnly.png";
  }
}
