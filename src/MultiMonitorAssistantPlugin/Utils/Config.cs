using System;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  [Serializable]
  public class MonitorConfig {
    public int WindowsIndex { get; set; }
    public string Name { get; set; }
    public string Config { get; set; }
  }

  [Serializable]
  public class MonitorsConfig {
    public MonitorConfig Left { get; set; }
    public MonitorConfig Center { get; set; }
    public MonitorConfig Right { get; set; }
  }

  [Serializable]
  public class Config {
    public MonitorsConfig Monitors { get; set; }

    public string ExePath { get; set; }
  }
}
