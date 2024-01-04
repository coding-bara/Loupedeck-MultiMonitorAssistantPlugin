namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class ToolAPI : GenericAPI {
    public ToolAPI(String exePath) : base(exePath) { }

    public void LoadConfig(String configPath) => RunCommand($"/LoadConfig {configPath}");

    public void SetMonitors(String config) => RunCommand($"/SetMonitors \"{config}\"");

    public void Disable(String monitorID) => RunCommand($"/Disable {monitorID}");

    public void Enable(String monitorID) => RunCommand($"/Enable {monitorID}");

    public void Switch(String monitorID) => RunCommand($"/Switch {monitorID}");
  }
}
