namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class MultiMonitorAssistantApplication : ClientApplication {
    protected override String GetProcessName() => "";

    protected override String GetBundleName() => "";

    public override ClientApplicationStatus GetApplicationStatus() => ClientApplicationStatus.Unknown;
  }
}
