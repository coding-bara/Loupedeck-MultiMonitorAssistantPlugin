using System.IO;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class ConfigLoader {
    private readonly string _configPath;
    private readonly string _resourcesPath;

    public ConfigLoader(string pluginPath, string resourcesPath) {
      _configPath = Path.Combine(pluginPath, "config.json");
      _resourcesPath = resourcesPath;
    }

    public Config Load() => File.Exists(_configPath)
      ? UseExistingConfig(_configPath)
      : UseDefaultConfig(_configPath);

    private Config UseDefaultConfig(string configPath) {
      var defaultConfig = new Config {
        Monitors = new MonitorsConfig {
          Left = new MonitorConfig {
            WindowsIndex = -1,
            Name = "-",
            Config = "-"
          },
          Right = new MonitorConfig {
            WindowsIndex = -1,
            Name = "-",
            Config = "-"
          },
          Center = new MonitorConfig {
            WindowsIndex = -1,
            Name = "-",
            Config = "-"
          }
        }
      };
      JsonHelpers.SerializeAnyObjectToFile(defaultConfig, configPath);

      EnrichConfigWithDefaults(defaultConfig);

      #if LOGGING
      Logger.Verbose($"Default config loaded: {JsonHelpers.SerializeAnyObject(defaultConfig)}");
      #endif

      return defaultConfig;
    }

    private Config UseExistingConfig(string configPath) {
      var existingConfig = JsonHelpers.DeserializeAnyObjectFromFile<Config>(configPath);

      EnrichConfigWithDefaults(existingConfig);

      #if LOGGING
      Logger.Verbose($"Existing config loaded: {JsonHelpers.SerializeAnyObject(existingConfig)}");
      #endif

      return existingConfig;
    }

    private void EnrichConfigWithDefaults(Config config) {
      if (string.IsNullOrWhiteSpace(config.ExePath))
        config.ExePath = Path.Combine(_resourcesPath, "MultiMonitorTool", "MultiMonitorTool.exe");
    }
  }
}
