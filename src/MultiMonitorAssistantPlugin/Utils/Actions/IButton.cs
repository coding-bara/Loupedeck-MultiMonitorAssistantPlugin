namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public interface IButton {
    Boolean OnButtonPress();

    String GetButtonValue();

    BitmapImage GetButtonIcon(PluginImageSize imageSize);

    Boolean OnButtonSetup();

    void OnButtonTeardown();

    void UpdateButtonIcon();

    void UpdateButton();
  }
}
