namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class ActivateLayoutButtonHorizontal : AActivateLayoutButton {
    public ActivateLayoutButtonHorizontal() : base(
      "Activate Layout",
      "Horizontal",
      "Activate horizontal layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.Horizontal;
    protected override String Icon => "Horizontal.png";
  }
}
