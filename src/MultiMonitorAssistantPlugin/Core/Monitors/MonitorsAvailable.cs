namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class MonitorsAvailable {
    public readonly Monitor Center;
    public readonly Monitor Left;
    public readonly Monitor Right;

    public MonitorsAvailable(Config config) {
      Center = IsValid(config.Monitors.Center)
        ? CreateMonitor(config.Monitors.Center)
        : default;
      Left = IsValid(config.Monitors.Left)
        ? CreateMonitor(config.Monitors.Left)
        : default;
      Right = IsValid(config.Monitors.Right)
        ? CreateMonitor(config.Monitors.Right)
        : default;
    }

    private Monitor CreateMonitor(MonitorConfig monitor) => new Monitor {
      WindowsIndex = monitor.WindowsIndex,
      Name = monitor.Name,
      Config = monitor.Config
    };

    private bool IsValid(MonitorConfig monitor) => monitor.WindowsIndex != -1 && monitor.Name != "-" && monitor.Config != "-";
  }
}
