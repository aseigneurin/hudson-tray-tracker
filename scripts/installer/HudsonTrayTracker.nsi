!define ROOT "..\..\Hudson Tray Tracker\bin\Release"

OutFile "HudsonTrayTrackerInstaller.exee"

Section "Hudson Tray Tracker"

  SetOverwrite on
  SetOutPath "$INSTDIR"

  File "${ROOT}\HudsonTrayTracker.exe"
  
SectionEnd