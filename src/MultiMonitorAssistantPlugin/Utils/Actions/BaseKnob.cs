namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System;

  public abstract class BaseKnob : PluginDynamicAdjustment, IKnob {
    protected BaseKnob(String actionGroup, String actionName, String actionDescription) : base(actionName, actionDescription, actionGroup, true) { }

    protected override Boolean OnLoad() {
      if (OnKnobSetup()) {
        UpdateKnob();

        return base.OnLoad();
      }

      return false;
    }

    protected override Boolean OnUnload() {
      OnKnobTeardown();

      return base.OnLoad();
    }

    protected override void ApplyAdjustment(String _, Int32 steps) {
      if (OnKnobTurn(steps))
        UpdateKnobValue();
    }

    protected override void RunCommand(String _) {
      if (OnKnobPress())
        UpdateKnobIcon();
    }

    public void UpdateKnobIcon() => ActionImageChanged();

    public void UpdateKnobValue() => AdjustmentValueChanged();

    public void UpdateKnob() {
      UpdateKnobValue();
      UpdateKnobIcon();
    }

    protected override String GetAdjustmentValue(String _) => GetKnobValue();

    protected override BitmapImage GetAdjustmentImage(String _, PluginImageSize imageSize) => GetKnobIcon(imageSize);

    public virtual Boolean OnKnobPress() => false;

    public virtual Boolean OnKnobTurn(Int32 steps) => false;

    public virtual String GetKnobValue() => default;

    public virtual BitmapImage GetKnobIcon(PluginImageSize imageSize) => default;

    public virtual Boolean OnKnobSetup() => true;

    public virtual void OnKnobTeardown() { }
  }
}
