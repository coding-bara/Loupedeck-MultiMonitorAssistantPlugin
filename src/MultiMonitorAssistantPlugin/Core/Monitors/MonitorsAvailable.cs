namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class MonitorsAvailable {
    public readonly Monitor Center;
    public readonly Monitor Left;
    public readonly Monitor Right;
    public readonly Monitor Top;

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
      Top = IsValid(config.Monitors.Top)
        ? CreateMonitor(config.Monitors.Top)
        : default;
    }

    private Monitor CreateMonitor(MonitorConfig monitor) => new Monitor {
      ShortName = monitor.ShortName,
      Index = monitor.Index,
      Config = monitor.Config
    };

    private Boolean IsValid(MonitorConfig monitor) => monitor.ShortName != "-" && monitor.Index != -1 && monitor.Config != "-";
  }
}
