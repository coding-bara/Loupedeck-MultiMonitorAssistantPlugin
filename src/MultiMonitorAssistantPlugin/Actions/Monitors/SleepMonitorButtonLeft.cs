namespace Loupedeck.MultiMonitorAssistantPlugin.Displays {
  public class SleepMonitorButtonLeft : ASleepMonitorButton {
    public SleepMonitorButtonLeft() : base(
      "Sleep Monitor",
      "Left",
      "Sleep left monitor."
    ) { }

    protected override Monitor Monitor => MultiMonitorAssistant.MonitorsAvailable.Left;
    protected override string Icon => "Left.png";
  }
}
