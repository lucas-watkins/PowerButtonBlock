; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "PowerButtonBlock"
#define MyAppVersion "1.0"
#define MyAppPublisher "Lucas Watkins"
#define MyAppURL "https://github.com/lucas-watkins/PowerButtonBlock"
#define MyAppExeName "PowerButtonBlock.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{7E832894-FD9D-47C1-86AD-CA26D77F4796}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir=C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\Inno Setup
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\PowerButtonBlock.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\PowerButtonBlock.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\Microsoft.Toolkit.Uwp.Notifications.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Lucas Watkins\Documents\MyScripts\PowerButtonBlock\bin\main\Microsoft.Toolkit.Uwp.Notifications.pdb"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commonstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

