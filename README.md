# BlinkStick-Microsoft-Teams-Status
This will track your local Microsoft Teams online status and will push that to your BlinkStick to create a 'busy light'

Welcome to the BlinkStick-Microsoft-Teams-Status project!
I couldn't find a pre-built package to get my Microsoft Teams status and display it on my BlinkStick, so I made one!

This project scans a local log file created by Microsoft Teams and looks for the last entry of StatusIndicatorStateService and pulls the shown status. Are there other ways to get the Teams status?... yeah. But I didn't want to register an Azure app, give it GRAPH API permissions, and then query GRAPH API for my online status. This seems like a pretty easy quick way to grab my current Teams status.

From there I match up colors and blinking status with each different Teams status and then push it to the BlinkStick.

I hope this code helps someone else save some time creating their project. It is written using VB.NET in Visual Studio 2022 (free Community version).

Enjoy!
