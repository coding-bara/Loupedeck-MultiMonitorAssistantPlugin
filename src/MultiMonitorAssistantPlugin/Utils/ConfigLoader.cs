namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.IO;

  public class ConfigLoader {
    public static Config Load() {
      var configFilePath = Path.Combine(MultiMonitorAssistant.PluginPath, "config.json");

      return File.Exists(configFilePath)
        ? UseExistingConfig(configFilePath)
        : UseDefaultConfig(configFilePath);
    }

    private static Config UseDefaultConfig(String configFilePath) {
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
      JsonHelpers.SerializeAnyObjectToFile(defaultConfig, configFilePath);

      EnrichConfigWithDefaults(defaultConfig);

      #if LOGGING
      Logger.Verbose($"Default config loaded: {JsonHelpers.SerializeAnyObject(defaultConfig)}");
      #endif

      return defaultConfig;
    }

    private static Config UseExistingConfig(String configFilePath) {
      var existingConfig = JsonHelpers.DeserializeAnyObjectFromFile<Config>(configFilePath);

      EnrichConfigWithDefaults(existingConfig);

      #if LOGGING
      Logger.Verbose($"Existing config loaded: {JsonHelpers.SerializeAnyObject(existingConfig)}");
      #endif

      return existingConfig;
    }

    private static void EnrichConfigWithDefaults(Config config) {
      if (string.IsNullOrWhiteSpace(config.ExePath))
        config.ExePath = Path.Combine(MultiMonitorAssistant.ResourcesPath, "MultiMonitorTool", "MultiMonitorTool.exe");
    }
  }
}
