namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  [Serializable]
  public class MonitorConfig {
    public String ShortName { get; set; }
    public Int32 Index { get; set; }
    public String Config { get; set; }
  }

  [Serializable]
  public class MonitorsConfig {
    public MonitorConfig Top { get; set; }
    public MonitorConfig Left { get; set; }
    public MonitorConfig Center { get; set; }
    public MonitorConfig Right { get; set; }
  }

  [Serializable]
  public class Config {
    public MonitorsConfig Monitors { get; set; }

    public String ExePath { get; set; }
  }
}
