namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  public class SleepMonitorButtonRight : ASleepMonitorButton {
    public SleepMonitorButtonRight() : base(
      "Sleep Monitor",
      "Right",
      "Sleep right monitor."
    ) { }

    protected override Monitor Monitor => MultiMonitorAssistant.MonitorsAvailable.Right;
    protected override string Icon => "Right.png";
  }
}
