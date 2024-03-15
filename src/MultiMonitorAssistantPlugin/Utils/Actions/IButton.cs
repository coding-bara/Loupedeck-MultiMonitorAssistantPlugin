namespace Loupedeck.MultiMonitorAssistantPlugin {
  public interface IButton {
    bool OnButtonPress();

    string GetButtonValue();

    BitmapImage GetButtonIcon(PluginImageSize imageSize);

    bool OnButtonSetup();

    void OnButtonTeardown();

    void UpdateButtonIcon();

    void UpdateButton();
  }
}
