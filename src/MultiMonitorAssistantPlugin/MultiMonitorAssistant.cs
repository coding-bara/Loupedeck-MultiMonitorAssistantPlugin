namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.IO;

  public class MultiMonitorAssistant : Plugin {
    public override Boolean UsesApplicationApiOnly => true;
    public override Boolean HasNoApplication => true;

    public static String ResourcesPath;

    public static State State;

    public static LayoutsAvailable LayoutsAvailable;
    public static LayoutManager LayoutManager;

    public static MonitorsAvailable MonitorsAvailable;
    public static MonitorManager MonitorManager;

    public MultiMonitorAssistant() {
      Logger.Init(Log);
      Resources.Init(Assembly);

      var resourcesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nameof(Loupedeck), "Plugins", nameof(MultiMonitorAssistant), "win", "Resources");
      var pluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".loupedeck", nameof(MultiMonitorAssistant));

      if (!Directory.Exists(pluginPath))
        Directory.CreateDirectory(pluginPath);

      var config = new ConfigLoader(pluginPath, resourcesPath).Load();
      var api = new ToolAPI(config.ExePath);

      ResourcesPath = resourcesPath;
      State = new State();

      MonitorsAvailable = new MonitorsAvailable(config);
      MonitorManager = new MonitorManager(api, State);

      LayoutsAvailable = new LayoutsAvailable(MonitorsAvailable);
      LayoutManager = new LayoutManager(api, State);
    }
  }
}
