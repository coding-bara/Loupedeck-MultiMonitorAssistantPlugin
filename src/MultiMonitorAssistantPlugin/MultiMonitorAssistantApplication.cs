namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class MultiMonitorAssistantApplication : ClientApplication {
    protected override string GetProcessName() => "";

    protected override string GetBundleName() => "";

    public override ClientApplicationStatus GetApplicationStatus() => ClientApplicationStatus.Unknown;
  }
}
