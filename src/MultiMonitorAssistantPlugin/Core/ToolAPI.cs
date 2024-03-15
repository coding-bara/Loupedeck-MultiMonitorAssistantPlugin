namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class ToolAPI : GenericAPI {
    public ToolAPI(string exePath) : base(exePath) { }

    public void SetMonitors(string config) => RunCommand($"/SetMonitors \"{config}\"");

    public void Disable(string monitorName) => RunCommand($"/Disable {monitorName}");
  }
}
