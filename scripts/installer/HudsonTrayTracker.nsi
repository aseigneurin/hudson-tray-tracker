!define ROOT "..\..\HudsonTrayTracker\bin\Release"

OutFile "HudsonTrayTrackerInstaller.exe"

Section "Hudson Tray Tracker"

  SetOverwrite on
  SetOutPath "$INSTDIR"

  File "${ROOT}\HudsonTrayTracker.exe"
  
SectionEnd