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
          "index": 1, // Use the value which is display on the monitor from "system" > "display".
          // In order to get the next two values, you need to run the MultiMonitorTool.exe once by yourself.
          // Therefore, run this in your explorer "%localappdata%\Loupedeck\Plugins\MultiMonitorAssistant\win\Resources\MultiMonitorTool\MultiMonitorTool.exe".
          // You can now see your monitors in a list.
          // Use the value from the "Short Monitor ID" column which matches your monitor (e.g. if index is 1 then use "\\.\DISPLAY1" which results in "BNQ7F6E" in my case).
          "shortName": "BNQ7F6E",
          // To get the "config" value, first enable usage of the Short Monitor ID.
          // To do this, click "Options" > "Copy /SetMonitors Command Mode" > "Use Short Monitor ID as Name".
          // Now select all monitors in your list and click "Edit" > "Copy /SetMonitors Command".
          // The config is now copied into your clipboard, paste it somewhere.
          // Take the part, according to your monitor shortName (e.g. if shortName is BNQ7F6E then use "Name=BNQ7F6E ..." as in my case).
          "config": "Name=BNQ7F6E BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=144 PositionX=-1080 PositionY=80"
        },
        "top": {
          "index": 2, // Use the value which is display on the monitor from "system" > "display".
          "shortName": "BNQ7F58", // Likewise as described above.
          "config": "Name=BNQ7F58 BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=120 PositionX=320 PositionY=-1080" // Likewise as described above.
        },
        "center": {
          "index": 3, // Use the value which is display on the monitor from "system" > "display".
          "shortName": "GSM7797", // Likewise as described above.
          "config": "Name=GSM7797 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=0 PositionY=0 Primary=1" // Likewise as described above.
        },
        "right": {
          "index": 4, // Use the value which is display on the monitor from "system" > "display".
          "shortName": "BNQ7F6F", // Likewise as described above.
          "config": "Name=BNQ7F6F BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=120 PositionX=2560 PositionY=80" // Likewise as described above.
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
          "index": 1,
          "shortName": "BNQ7F6E",
          "config": "Name=BNQ7F6E BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=144 PositionX=-1080 PositionY=80"
        },
        "top": {
          "index": 2,
          "shortName": "BNQ7F58",
          "config": "Name=BNQ7F58 BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=120 PositionX=320 PositionY=-1080"
        },
        "center": {
          "index": 3,
          "shortName": "GSM7797",
          "config": "Name=GSM7797 BitsPerPixel=32 Width=2560 Height=1440 DisplayFrequency=240 PositionX=0 PositionY=0 Primary=1"
        },
        "right": {
          "index": 4,
          "shortName": "BNQ7F6F",
          "config": "Name=BNQ7F6F BitsPerPixel=32 Width=1920 Height=1080 DisplayFrequency=120 PositionX=2560 PositionY=80"
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
