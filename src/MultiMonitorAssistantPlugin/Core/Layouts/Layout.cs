namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.Collections.Generic;

  public class Layout {
    public String ID { get; set; }
    public List<Monitor> Enable { get; set; }
    public List<Monitor> Disable { get; set; }
  }
}
