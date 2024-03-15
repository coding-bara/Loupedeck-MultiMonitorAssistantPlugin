# 1. Table of content
- [1. Table of content](#1-table-of-content)
- [2. What is this plugin about?](#2-what-is-this-plugin-about)
- [3. How to setup?](#3-how-to-setup)
- [4. How to support, give feedback or contribute?](#4-how-to-support-give-feedback-or-contribute)

# 2. What is this plugin about?

With this plugin you can control your multi monitor setup:

* You can activate different layouts.
* You can send monitors to sleep.

It uses [MultiMonitorTool](https://www.nirsoft.net/utils/multi_monitor_tool.html) in version 2.10 to implement these features.
MultiMonitorTool is shipped within the plugin in the x64 version.
If you need the x32 version, you can download it [here](https://www.nirsoft.net/utils/multimonitortool.zip).

**Limitations**:

* There is only a Windows version of the plugin.
* There are no plausibility checks, so expect Loupedesk.exe to crash if you accidentally configure it incorrectly.

# 3. How to setup?

1. Fire up Loupedeck.
2. Install a binary release of the plugin.
3. Restart Loupedeck. A default `config.json` has now been generated for you.
4. You can find the `config.json` in here: `%userprofile%\.loupedeck\MultiMonitorAssistant`.
5. Edit it to your needs, like described below:
   ```json5
    // entire, possible config.json
    {
      "monitors": {
        "left": {
          "windowsIndex": 1, // Use the value which is displayed on the monitor from "system" > "display".
          // In order to get the next two values, you need to run the MultiMonitorTool.exe once by yourself.
          // Therefore, run this in your explorer "%localappdata%\Loupedeck\Plugins\MultiMonitorAssistant\win\Resources\MultiMonitorTool\MultiMonitorTool.exe".
          // You can now see your monitors listed.
          // Use the value from the "Name" column which matches your monitor (e.g. "\\.\DISPLAY2").
          "name": "\\\\.\\DISPLAY2",
          // To get the "config" value, first enable usage of "Use \\.\DISPLAYx as Name".
          // To do this, click "Options" > "Copy /SetMonitors Command Mode" > "Use \\.\DISPLAYx as Name".
          // Now select all monitors in your list and click "Edit" > "Copy /SetMonitors Command".
          // The config is now copied into your clipboard, paste it somewhere.
          // Take the part, according to your monitor name (e.g. if name is \\.\DISPLAY1 then use "Name=\\.\DISPLAY1 ...").
          "config": "Name=\\\\.\\DISPLAY2 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=-2560 PositionY=0"
        },
        "center": {
          "windowsIndex": 3, // Use the value which is display on the monitor from "system" > "display".
          "name": "\\\\.\\DISPLAY1", // Likewise as described above.
          "config": "Name=\\\\.\\DISPLAY1 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=0 PositionY=0 Primary=1" // Likewise as described above.
        },
        "right": {
          "windowsIndex": 2, // Use the value which is display on the monitor from "system" > "display".
          "name": "\\\\.\\DISPLAY3", // Likewise as described above.
          "config": "Name=\\\\.\\DISPLAY3 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=2560 PositionY=0" // Likewise as described above.
        },
      },
      // Only needs to be specified if you need the x32 version of MultiMonitorTool.
      // The path has to be absolute.
      "exePath": "C:\\your\\path\\to\\MultiMonitorTool.exe",
    }
    ```
    ```json5
    // example config.json
    {
      "monitors": {
        "left": {
          "windowsIndex": 1,
          "name": "\\\\.\\DISPLAY2",
          "config": "Name=\\\\.\\DISPLAY2 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=-2560 PositionY=0"
        },
        "center": {
          "windowsIndex": 3,
          "name": "\\\\.\\DISPLAY1",
          "config": "Name=\\\\.\\DISPLAY1 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=0 PositionY=0 Primary=1"
        },
        "right": {
          "windowsIndex": 2,
          "name": "\\\\.\\DISPLAY3",
          "config": "Name=\\\\.\\DISPLAY3 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=2560 PositionY=0"
        }
      }
    }
    ```
6. Restart Loupedeck, the plugin is now ready for use.

# 4. How to support, give feedback or contribute?

* You found a bug?
  I would love to hear about it [here](https://github.com/coding-bara/Loupedeck-MultiMonitorAssistantPlugin/issues/new/choose).

* You have a feature request?
  Feel free to fork the repository and create some PR's.
