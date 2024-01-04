namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class ActivateLayoutButtonVertical : AActivateLayoutButton {
    public ActivateLayoutButtonVertical() : base(
      "Activate Layout",
      "Vertical",
      "Activate vertical layout."
    ) { }

    protected override Layout Layout => MultiMonitorAssistant.LayoutsAvailable.Vertical;
    protected override String Icon => "Vertical.png";
  }
}
