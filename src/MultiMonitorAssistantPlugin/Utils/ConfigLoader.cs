namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.IO;

  public class ConfigLoader {
    private readonly String _configPath;
    private readonly String _resourcesPath;

    public ConfigLoader(String pluginPath, String resourcesPath) {
      _configPath = Path.Combine(pluginPath, "config.json");
      _resourcesPath = resourcesPath;
    }

    public Config Load() {
      return File.Exists(_configPath)
        ? UseExistingConfig(_configPath)
        : UseDefaultConfig(_configPath);
    }

    private Config UseDefaultConfig(String configPath) {
      var defaultConfig = new Config {
        Monitors = new MonitorsConfig {
          Top = new MonitorConfig {
            ShortName = "-",
            Index = -1,
            Config = "-"
          },
          Left = new MonitorConfig {
            ShortName = "-",
            Index = -1,
            Config = "-"
          },
          Right = new MonitorConfig {
            ShortName = "-",
            Index = -1,
            Config = "-"
          },
          Center = new MonitorConfig {
            ShortName = "-",
            Index = -1,
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

    private Config UseExistingConfig(String configPath) {
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
