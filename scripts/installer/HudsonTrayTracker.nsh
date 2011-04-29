!include "MUI2.nsh"

!define PRODUCT_NAME "Hudson Tray Tracker"

Name "${PRODUCT_NAME}"
OutFile "HudsonTrayTrackerInstaller.exe"
InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
InstallDirRegKey HKLM "Software\${PRODUCT_NAME}" "InstallDirectory"
RequestExecutionLevel highest


!define MUI_ABORTWARNING

# settings for MUI_PAGE_FINISH
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_CHECKED
!define MUI_FINISHPAGE_RUN_TEXT "Run ${PRODUCT_NAME}"
!define MUI_FINISHPAGE_RUN_FUNCTION "LaunchApplication"


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

  File "${ROOT}\antlr.runtime.dll"
  File "${ROOT}\Common.Logging.dll"
  File "${ROOT}\Common.Logging.Log4Net.dll"
  File "${ROOT}\DevExpress.Data.v10.1.dll"
  File "${ROOT}\DevExpress.OfficeSkins.v10.1.dll"
  File "${ROOT}\DevExpress.Utils.v10.1.dll"
  File "${ROOT}\DevExpress.XtraBars.v10.1.dll"
  File "${ROOT}\DevExpress.XtraEditors.v10.1.dll"
  File "${ROOT}\DevExpress.XtraGrid.v10.1.dll"
  File "${ROOT}\HudsonTrayTracker.ico"
  File "${ROOT}\HudsonTrayTracker.exe"
  File "${ROOT}\HudsonTrayTracker.exe.config"
  File "${ROOT}\Iesi.Collections.dll"
  File "${ROOT}\log4net.dll"
  File "${ROOT}\LoggingConfig.xml"
  File "${ROOT}\Newtonsoft.Json.Net35.dll"
  File "${ROOT}\SmartThreadPool.dll"
  File "${ROOT}\Spring.Core.dll"

  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}.lnk" "$INSTDIR\HudsonTrayTracker.exe" "" "$INSTDIR\HudsonTrayTracker.ico"
  CreateShortCut "$SMSTARTUP\${PRODUCT_NAME}.lnk" "$INSTDIR\HudsonTrayTracker.exe" "" "$INSTDIR\HudsonTrayTracker.ico"

  WriteRegStr HKLM "Software\${PRODUCT_NAME}" "InstallDirectory" "$INSTDIR"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayName" "${PRODUCT_NAME}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "UninstallString" "$INSTDIR\uninstall.exe"

  WriteUninstaller "$INSTDIR\uninstall.exe"
  
SectionEnd


Section "Uninstall"
 
  # Always delete uninstaller first
  Delete "$INSTDIR\uninstall.exe"
 
  Delete "$INSTDIR\antlr.runtime.dll"
  Delete "$INSTDIR\Common.Logging.dll"
  Delete "$INSTDIR\Common.Logging.Log4Net.dll"
  Delete "$INSTDIR\DevExpress.Data.v10.1.dll"
  Delete "$INSTDIR\DevExpress.OfficeSkins.v10.1.dll"
  Delete "$INSTDIR\DevExpress.Utils.v10.1.dll"
  Delete "$INSTDIR\DevExpress.XtraBars.v10.1.dll"
  Delete "$INSTDIR\DevExpress.XtraEditors.v10.1.dll"
  Delete "$INSTDIR\DevExpress.XtraGrid.v10.1.dll"
  Delete "$INSTDIR\HudsonTrayTracker.ico"
  Delete "$INSTDIR\HudsonTrayTracker.exe"
  Delete "$INSTDIR\HudsonTrayTracker.exe.config"
  Delete "$INSTDIR\Iesi.Collections.dll"
  Delete "$INSTDIR\log4net.dll"
  Delete "$INSTDIR\LoggingConfig.xml"
  Delete "$INSTDIR\SmartThreadPool.dll"
  Delete "$INSTDIR\Spring.Core.dll"
  
  Delete "$SMPROGRAMS\${PRODUCT_NAME}.lnk"
  Delete "$SMSTARTUP\${PRODUCT_NAME}.lnk"

  RmDir "$INSTDIR"
 
SectionEnd

Function LaunchApplication
  ExecShell "" "$INSTDIR\HudsonTrayTracker.exe"
FunctionEnd
