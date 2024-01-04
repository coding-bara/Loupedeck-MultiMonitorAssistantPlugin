namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public class State {
    public delegate void IsBusyChangedEvent();
    public event IsBusyChangedEvent IsBusyChanged;

    private Boolean _isBusy;

    public Boolean IsBusy {
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
