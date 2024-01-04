namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;
  using System.Linq;
  using System.Threading;

  public class LayoutManager {
    private readonly ToolAPI _api;
    private readonly State _state;

    private Thread _activationThread;
    private Thread _monitoringThread;

    public delegate void ActivationProgressEvent(String layoutID, Int32 progress);
    public event ActivationProgressEvent ActivationProgress;

    public LayoutManager(ToolAPI api, State state) {
      _api = api;
      _state = state;
    }

    public void Activate(Layout layout) {
      if (_state.IsBusy)
        return;

      _activationThread = new Thread(ThreadedActivation(layout));
      _monitoringThread = new Thread(ThreadedMonitoring(_activationThread));
      _monitoringThread.Start();
    }

    private ThreadStart ThreadedMonitoring(Thread activationThread) => () => {
      _state.IsBusy = true;

      activationThread.Start();
      activationThread.Join();

      _state.IsBusy = false;
    };

    private ThreadStart ThreadedActivation(Layout layout) => () => {
      try {
        ActivationProgress?.Invoke(layout.ID, 0);
        Thread.Sleep(250);

        var actionsRequired = layout.Enable.Count + (layout.Disable?.Count ?? 0f);
        var actionsDone = 0f;

        foreach (var monitor in layout.Enable.OrderBy(o => o.Index).ToList()) {
          _api.SetMonitors(monitor.Config);

          actionsDone += 1;

          ActivationProgress?.Invoke(layout.ID, (Int32) CalculateActivationProgress(actionsDone, actionsRequired));
          Thread.Sleep(2500);
        }

        Thread.Sleep(250);

        if (layout.Disable != default)
          foreach (var monitor in layout.Disable) {
            _api.Disable(monitor.ShortName);

            actionsDone += 1;

            ActivationProgress?.Invoke(layout.ID, (Int32) CalculateActivationProgress(actionsDone, actionsRequired));
            Thread.Sleep(250);
          }

        ActivationProgress?.Invoke(layout.ID, 90);
        Thread.Sleep(1000);

        ActivationProgress?.Invoke(layout.ID, 100);
        Thread.Sleep(250);
      } catch (Exception e) {
        Logger.Error(e, "Something went wrong!");
      } finally {
        ActivationProgress?.Invoke(layout.ID, -1);
      }
    };

    private static Single CalculateActivationProgress(Single actionsDone, Single actionsRequired) => 80f * (actionsDone / actionsRequired);
  }
}
