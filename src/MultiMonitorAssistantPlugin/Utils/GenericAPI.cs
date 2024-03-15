using System;
using System.Diagnostics;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class GenericAPI {
    private readonly string _exePath;

    protected GenericAPI(string exePath) {
      _exePath = exePath;
    }

    protected delegate T ParseRawOutputCallback<T>(string[] rawOutput);

    protected T RunCommand<T>(string command, ParseRawOutputCallback<T> parseRawOutputCallback) {
      T parsedOutput = default;

      try {
        var process = new Process {
          StartInfo = new ProcessStartInfo(_exePath, command) {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
          }
        };
        process.Start();

        var rawOutput = process.StandardOutput.ReadToEnd().Split().RemoveAll(string.IsNullOrWhiteSpace);

        process.WaitForExit();

        #if LOGGING
        var exitCode = process.ExitCode;
        #endif

        process.Close();

        parsedOutput = parseRawOutputCallback.Invoke(rawOutput);

        #if LOGGING
        Logger.Verbose($"'{_exePath} {command}' succeeded with output: {parsedOutput}. ({exitCode})");
        #endif
      } catch (Exception e) {
        Logger.Error(e, $"'{_exePath} {command}' failed with message: '{e.Message}'.");
      }

      return parsedOutput;
    }

    protected void RunCommand(string command) {
      try {
        var process = new Process {
          StartInfo = new ProcessStartInfo(_exePath, command) {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
          }
        };
        process.Start();
        process.WaitForExit();

        #if LOGGING
        var exitCode = process.ExitCode;
        #endif

        process.Close();
        #if LOGGING
        Logger.Verbose($"'{_exePath} {command}' succeeded. ({exitCode})");
        #endif
      } catch (Exception e) {
        Logger.Error(e, $"'{_exePath} {command}' failed with message: '{e.Message}'.");
      }
    }
  }
}
