namespace Loupedeck.MultiMonitorAssistantPlugin {
  public abstract class BaseKnob : PluginDynamicAdjustment, IKnob {
    protected BaseKnob(string actionGroup, string actionName, string actionDescription) : base(actionName, actionDescription, actionGroup, true) { }

    protected override bool OnLoad() {
      if (OnKnobSetup()) {
        UpdateKnob();

        return base.OnLoad();
      }

      return false;
    }

    protected override bool OnUnload() {
      OnKnobTeardown();

      return base.OnLoad();
    }

    protected override void ApplyAdjustment(string _, int steps) {
      if (OnKnobTurn(steps))
        UpdateKnobValue();
    }

    protected override void RunCommand(string _) {
      if (OnKnobPress())
        UpdateKnobIcon();
    }

    public void UpdateKnobIcon() => ActionImageChanged();

    public void UpdateKnobValue() => AdjustmentValueChanged();

    public void UpdateKnob() {
      UpdateKnobValue();
      UpdateKnobIcon();
    }

    protected override string GetAdjustmentValue(string _) => GetKnobValue();

    protected override BitmapImage GetAdjustmentImage(string _, PluginImageSize imageSize) => GetKnobIcon(imageSize);

    public virtual bool OnKnobPress() => false;

    public virtual bool OnKnobTurn(int steps) => false;

    public virtual string GetKnobValue() => default;

    public virtual BitmapImage GetKnobIcon(PluginImageSize imageSize) => default;

    public virtual bool OnKnobSetup() => true;

    public virtual void OnKnobTeardown() { }
  }
}
