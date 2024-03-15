using System.Collections.Generic;

namespace Loupedeck.MultiMonitorAssistantPlugin {
  public class LayoutsAvailable {
    public readonly Layout Default;
    public readonly Layout CenterOnly;

    public LayoutsAvailable(MonitorsAvailable monitorsAvailable) {
      Default = CreateDefaultLayout(monitorsAvailable);
      CenterOnly = CreateCenterOnlyLayout(monitorsAvailable);
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

    private List<Monitor> GetAllMonitors(MonitorsAvailable monitorsAvailable) {
      List<Monitor> enable = new List<Monitor> {
        monitorsAvailable.Center
      };

      if (monitorsAvailable.Left != default)
        enable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right != default)
        enable.Add(monitorsAvailable.Right);

      return enable;
    }
  }
}
