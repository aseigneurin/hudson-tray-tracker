!include "MUI2.nsh"

!define ROOT "..\..\HudsonTrayTracker\bin\Release"
!define PRODUCT_NAME "Hudson Tray Tracker"

Name "${PRODUCT_NAME}"
OutFile "HudsonTrayTrackerInstaller.exe"
InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
InstallDirRegKey HKLM "Software\${PRODUCT_NAME}" "InstallDirectory"


!define MUI_ABORTWARNING

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"


Section

  SetOverwrite on
  SetOutPath "$INSTDIR"

  File "${ROOT}\DevExpress.Data.v8.3.dll"
  File "${ROOT}\DevExpress.OfficeSkins.v8.3.dll"
  File "${ROOT}\DevExpress.Utils.v8.3.dll"
  File "${ROOT}\DevExpress.XtraBars.v8.3.dll"
  File "${ROOT}\DevExpress.XtraEditors.v8.3.dll"
  File "${ROOT}\DevExpress.XtraGrid.v8.3.dll"
  File "${ROOT}\Dotnet.Commons.Logging.Log4net.dll"
  File "${ROOT}\Dotnet.Commons.Logging.dll"
  File "${ROOT}\HudsonTrayTracker.exe"
  File "${ROOT}\HudsonTrayTracker.exe.config"
  File "${ROOT}\Iesi.Collections.dll"
  File "${ROOT}\log4net.dll"

  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}.lnk" "$INSTDIR\HudsonTrayTracker.exe"
  CreateShortCut "$SMSTARTUP\${PRODUCT_NAME}.lnk" "$INSTDIR\HudsonTrayTracker.exe"

  WriteRegStr HKLM "Software\${PRODUCT_NAME}" "InstallDirectory" "$INSTDIR"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayName" "${PRODUCT_NAME}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "UninstallString" "$INSTDIR\uninstall.exe"

  WriteUninstaller "$INSTDIR\uninstall.exe"
  
SectionEnd


Section "Uninstall"
 
  # Always delete uninstaller first
  Delete $INSTDIR\uninstaller.exe
 
  Delete "${ROOT}\DevExpress.Data.v8.3.dll"
  Delete "${ROOT}\DevExpress.OfficeSkins.v8.3.dll"
  Delete "${ROOT}\DevExpress.Utils.v8.3.dll"
  Delete "${ROOT}\DevExpress.XtraBars.v8.3.dll"
  Delete "${ROOT}\DevExpress.XtraEditors.v8.3.dll"
  Delete "${ROOT}\DevExpress.XtraGrid.v8.3.dll"
  Delete "${ROOT}\Dotnet.Commons.Logging.Log4net.dll"
  Delete "${ROOT}\Dotnet.Commons.Logging.dll"
  Delete "${ROOT}\HudsonTrayTracker.exe"
  Delete "${ROOT}\HudsonTrayTracker.exe.config"
  Delete "${ROOT}\Iesi.Collections.dll"
  Delete "${ROOT}\log4net.dll"
  
  Delete "$SMPROGRAMS\${PRODUCT_NAME}.lnk"
  Delete "$SMSTARTUP\${PRODUCT_NAME}.lnk"

  RmDir "$INSTDIR"
 
SectionEnd