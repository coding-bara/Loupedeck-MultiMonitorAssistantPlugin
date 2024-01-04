namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public interface IKnob {
    Boolean OnKnobSetup();

    void OnKnobTeardown();

    Boolean OnKnobPress();

    Boolean OnKnobTurn(Int32 steps);

    String GetKnobValue();

    BitmapImage GetKnobIcon(PluginImageSize imageSize);

    void UpdateKnobIcon();

    void UpdateKnobValue();

    void UpdateKnob();
  }
}
