namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  using System;

  public class SleepMonitorButtonTop : ASleepMonitorButton {
    public SleepMonitorButtonTop() : base(
      "Sleep Monitor",
      "Top",
      "Sleep top monitor."
    ) { }

    protected override Monitor Monitor => MultiMonitorAssistant.MonitorsAvailable.Top;
    protected override String Icon => "Top.png";
  }
}
