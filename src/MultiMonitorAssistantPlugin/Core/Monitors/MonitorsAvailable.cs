namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class MonitorsAvailable {
    public readonly Monitor Top;
    public readonly Monitor Left;
    public readonly Monitor Right;
    public readonly Monitor Center;

    public MonitorsAvailable(Config config) {
      Top = config.Monitors.Top.ShortName != "-"
        ? new Monitor {
          ShortName = config.Monitors.Top.ShortName,
          Index = config.Monitors.Top.Index,
          Config = config.Monitors.Top.Config
        }
        : default;
      Left = config.Monitors.Left.ShortName != "-"
        ? new Monitor {
          ShortName = config.Monitors.Left.ShortName,
          Index = config.Monitors.Left.Index,
          Config = config.Monitors.Left.Config
        }
        : default;
      Right = config.Monitors.Right.ShortName != "-"
        ? new Monitor {
          ShortName = config.Monitors.Right.ShortName,
          Index = config.Monitors.Right.Index,
          Config = config.Monitors.Right.Config
        }
        : default;
      Center = config.Monitors.Center.ShortName != "-"
        ? new Monitor {
          ShortName = config.Monitors.Center.ShortName,
          Index = config.Monitors.Center.Index,
          Config = config.Monitors.Center.Config
        }
        : default;
    }
  }
}
