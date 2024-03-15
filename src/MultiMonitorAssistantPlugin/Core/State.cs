namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class State {
    public delegate void IsBusyChangedEvent();
    public event IsBusyChangedEvent IsBusyChanged;

    private bool _isBusy;

    public bool IsBusy {
      get => _isBusy;
      set {
        if (value != _isBusy) {
          _isBusy = value;
          IsBusyChanged?.Invoke();
        }
      }
    }
  }
}
