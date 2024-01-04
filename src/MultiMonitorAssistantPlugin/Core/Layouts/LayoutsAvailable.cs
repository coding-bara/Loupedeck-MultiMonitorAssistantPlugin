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

    private static Layout CreateDefaultLayout(MonitorsAvailable monitorsAvailable) {
      if (monitorsAvailable.Center.ShortName == "-")
        return default;

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Default",
        Enable = enable
      };
    }

    private static List<Monitor> GetAllMonitors(MonitorsAvailable monitorsAvailable) {
      List<Monitor> enable = new List<Monitor> {
        monitorsAvailable.Center
      };

      if (monitorsAvailable.Top.ShortName != "-")
        enable.Add(monitorsAvailable.Top);

      if (monitorsAvailable.Left.ShortName != "-")
        enable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right.ShortName != "-")
        enable.Add(monitorsAvailable.Right);

      return enable;
    }

    private static Layout CreateCenterOnlyLayout(MonitorsAvailable monitorsAvailable) {
      if (monitorsAvailable.Center.ShortName == "-")
        return default;

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Top.ShortName != "-")
        disable.Add(monitorsAvailable.Top);

      if (monitorsAvailable.Left.ShortName != "-")
        disable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right.ShortName != "-")
        disable.Add(monitorsAvailable.Right);

      return new Layout {
        ID = "CenterOnly",
        Enable = enable,
        Disable = disable
      };
    }

    private static Layout CreateHorizontalLayout(MonitorsAvailable monitorsAvailable) {
      if (
        monitorsAvailable.Center.ShortName == "-" ||
        (monitorsAvailable.Left.ShortName == "-" && monitorsAvailable.Right.ShortName == "-")
      )
        return default;

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Top.ShortName != "-")
        disable.Add(monitorsAvailable.Top);

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Horizontal",
        Enable = enable,
        Disable = disable
      };
    }

    private static Layout CreateVerticalLayout(MonitorsAvailable monitorsAvailable) {
      if (
        monitorsAvailable.Center.ShortName == "-" ||
        monitorsAvailable.Top.ShortName == "-"
      )
        return default;

      List<Monitor> disable = new List<Monitor>();

      if (monitorsAvailable.Left.ShortName != "-")
        disable.Add(monitorsAvailable.Left);

      if (monitorsAvailable.Right.ShortName != "-")
        disable.Add(monitorsAvailable.Right);

      List<Monitor> enable = GetAllMonitors(monitorsAvailable);

      return new Layout {
        ID = "Vertical",
        Enable = enable,
        Disable = disable
      };
    }
  }
}
