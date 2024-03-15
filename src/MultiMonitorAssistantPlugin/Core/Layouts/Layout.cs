using System.Collections.Generic;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class Layout {
    public string ID { get; set; }
    public List<Monitor> Enable { get; set; }
    public List<Monitor> Disable { get; set; }
  }
}
