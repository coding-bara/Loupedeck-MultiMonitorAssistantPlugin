namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  using System;

  public class SleepMonitorButtonLeft : ASleepMonitorButton {
    public SleepMonitorButtonLeft() : base(
      "Sleep Monitor",
      "Left",
      "Sleep left monitor."
    ) { }

    protected override Monitor Monitor => MultiMonitorAssistant.MonitorsAvailable.Left;
    protected override String Icon => "Left.png";
  }
}
