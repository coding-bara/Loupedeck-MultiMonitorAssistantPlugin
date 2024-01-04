namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class ActivateLayoutButtonDefault : AActivateLayoutButton {
    public ActivateLayoutButtonDefault() : base(
      "Activate Layout",
      "Default",
      "Activate default layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.Default;
    protected override String Icon => "Default.png";
  }
}
