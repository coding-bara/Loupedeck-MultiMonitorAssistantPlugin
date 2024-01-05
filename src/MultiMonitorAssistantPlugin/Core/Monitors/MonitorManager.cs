namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.Threading;

  public class MonitorManager {
    private readonly ToolAPI _api;
    private readonly State _state;

    private Thread _sleepThread;
    private Thread _monitoringThread;

    public MonitorManager(ToolAPI api, State state) {
      _api = api;
      _state = state;
    }

    public void Sleep(Monitor monitor) {
      if (_state.IsBusy)
        return;

      _sleepThread = new Thread(ThreadedSleep(monitor));
      _monitoringThread = new Thread(ThreadedMonitoring(_sleepThread));
      _monitoringThread.Start();
    }

    private ThreadStart ThreadedMonitoring(Thread toggleThread) => () => {
      _state.IsBusy = true;

      toggleThread.Start();
      toggleThread.Join();

      _state.IsBusy = false;
    };

    private ThreadStart ThreadedSleep(Monitor monitor) => () => {
      try {
        Thread.Sleep(1000);

        _api.Disable(monitor.ShortName);

        Thread.Sleep(1000);
      } catch (Exception e) {
        Logger.Error(e, $"'ThreadedSleep' failed with message: '{e.Message}' and stacktrace: '{e.StackTrace}'.");
      }
    };
  }
}
