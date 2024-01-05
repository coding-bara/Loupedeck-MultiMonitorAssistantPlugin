namespace Loupedeck.MultiMonitorAssistantPlugin {
  using System.Collections.Generic;

  public class LayoutsAvailable {
    public readonly Layout Default;
    public readonly Layout CenterOnly;
    public readonly Layout Horizontal;
    public readonly Layout Vertical;

    public LayoutsAvailable(MonitorsAvailable monitorsAvailable) {
      Default = CreateDefaultLayout(monitorsAvailable);
      CenterOnly = CreateCenterOnlyLayout(monitorsAvailable);
      Horizontal = CreateHorizontalLayout(monitorsAvailable);
      Vertical = CreateVerticalLayout(monitorsAvailable);
    }

    private Layout CreateDefaultLayout(MonitorsAvailable monitorsAvailable) {
      if (monitorsAvailable.Center == default)
        return default;

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Default",
        Enable = enable
      };
    }

    private Layout CreateCenterOnlyLayout(MonitorsAvailable monitorsAvailable) {
      if (monitorsAvailable.Center == default)
        return default;

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Top != default)
        disable.Add(monitorsAvailable.Top);

      if (monitorsAvailable.Left != default)
        disable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right != default)
        disable.Add(monitorsAvailable.Right);

      return new Layout {
        ID = "CenterOnly",
        Enable = enable,
        Disable = disable
      };
    }

    private Layout CreateHorizontalLayout(MonitorsAvailable monitorsAvailable) {
      if (
        monitorsAvailable.Center == default ||
        (monitorsAvailable.Left == default && monitorsAvailable.Right == default)
      )
        return default;

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Top != default)
        disable.Add(monitorsAvailable.Top);

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Horizontal",
        Enable = enable,
        Disable = disable
      };
    }

    private Layout CreateVerticalLayout(MonitorsAvailable monitorsAvailable) {
      if (
        monitorsAvailable.Center == default ||
        monitorsAvailable.Top == default
      )
        return default;

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Left != default)
        disable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right != default)
        disable.Add(monitorsAvailable.Right);

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Vertical",
        Enable = enable,
        Disable = disable
      };
    }

    private List<Monitor> GetAllMonitors(MonitorsAvailable monitorsAvailable) {
      List<Monitor> enable = new List<Monitor> {
        monitorsAvailable.Center
      };

      if (monitorsAvailable.Top != default)
        enable.Add(monitorsAvailable.Top);

      if (monitorsAvailable.Left != default)
        enable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right != default)
        enable.Add(monitorsAvailable.Right);

      return enable;
    }
  }
}
