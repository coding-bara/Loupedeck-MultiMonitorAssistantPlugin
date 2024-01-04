namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  using System;

  public class SleepMonitorButtonRight : ASleepMonitorButton {
    public SleepMonitorButtonRight() : base(
      "Sleep Monitor",
      "Right",
      "Sleep right monitor."
    ) { }

    protected override Monitor Monitor => MultiMonitorAssistant.MonitorsAvailable.Right;
    protected override String Icon => "Right.png";
  }
}
