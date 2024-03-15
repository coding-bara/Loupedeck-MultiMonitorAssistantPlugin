namespace Loupedeck.MultiMonitorAssistantPlugin {
  public interface IKnob {
    bool OnKnobSetup();

    void OnKnobTeardown();

    bool OnKnobPress();

    bool OnKnobTurn(int steps);

    string GetKnobValue();

    BitmapImage GetKnobIcon(PluginImageSize imageSize);

    void UpdateKnobIcon();

    void UpdateKnobValue();

    void UpdateKnob();
  }
}
