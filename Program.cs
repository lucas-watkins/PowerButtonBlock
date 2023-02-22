using PowerButtonBlock.Properties;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using Microsoft.Toolkit.Uwp.Notifications;



namespace PowerButtonBlock
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyCustomApplicationContext());
        }
      
        public class MyCustomApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;
            public MyCustomApplicationContext()
            {
                //Get Light or Dark Theme
            
               
               string uiSettings = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", "0").ToString();
               
                
                if (uiSettings == "1")
                {
                    // Initialize Tray Icon for Light Mode
                    trayIcon = new NotifyIcon()
                    {
                        Icon = Resources.AppIconLight,
                        ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Disable Power Button", blockPowerButton), new MenuItem("Exit", Exit) }),
                        Visible = true,
                    };
                }
                else if (uiSettings == "0")
                {
                    // Initialize Tray Icon for Light Mode
                    trayIcon = new NotifyIcon()
                    {
                        Icon = Resources.AppIconDark,
                        ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Disable Power Button", blockPowerButton), new MenuItem("Exit", Exit) }),
                        Visible = true,
                    };
                }
                enablePowerButtonNoEventArgs();
                }

            private void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                enablePowerButton(sender, e);
                trayIcon.Visible = false;
                Application.Exit();
            }

            private void blockPowerButton(object sender, EventArgs e)
            {
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "powercfg.exe";
                    p.StartInfo.Arguments = "-setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 0";
                    p.Start();
                    p.WaitForExit();
                    Process q = new Process();
                    q.StartInfo.UseShellExecute = false;
                    q.StartInfo.RedirectStandardOutput = true;
                    q.StartInfo.CreateNoWindow = true;
                    q.StartInfo.FileName = "powercfg.exe";
                    q.StartInfo.Arguments = "-setdcvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 0";
                    q.Start();
                    q.WaitForExit();
                    trayIcon.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Enable Power Button", enablePowerButton), new MenuItem("Exit", Exit) });
                    sendDisabledNotification();
            }

            private void enablePowerButton(object sender, EventArgs e)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "powercfg.exe";
                p.StartInfo.Arguments = "-setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 1";
                p.Start();
                p.WaitForExit();
                Process q = new Process();
                q.StartInfo.UseShellExecute= false;
                q.StartInfo.RedirectStandardOutput = true;
                q.StartInfo.CreateNoWindow = true;
                q.StartInfo.FileName = "powercfg.exe";
                q.StartInfo.Arguments = "-setdcvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 1";
                q.Start();
                q.WaitForExit();
                trayIcon.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Disable Power Button", blockPowerButton), new MenuItem("Exit", Exit) });
                sendEnabledNotification();
            }

            private void enablePowerButtonNoEventArgs()
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "powercfg.exe";
                p.StartInfo.Arguments = "-setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 1";
                p.Start();
                p.WaitForExit();
                Process q = new Process();
                q.StartInfo.UseShellExecute = false;
                q.StartInfo.RedirectStandardOutput = true;
                q.StartInfo.CreateNoWindow = true;
                q.StartInfo.FileName = "powercfg.exe";
                q.StartInfo.Arguments = "-setdcvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 7648efa3-dd9c-4e3e-b566-50f929386280 1";
                q.Start();
                q.WaitForExit();
                trayIcon.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Disable Power Button", blockPowerButton), new MenuItem("Exit", Exit) });
            }

            private void sendEnabledNotification()
            {
                new ToastContentBuilder()
                    .AddText("Power Button Enabled")
                    .Show();
            }

            private void sendDisabledNotification()
            {
                new ToastContentBuilder()
                    .AddText("Power Button Disabled")
                    .Show();
            }
        }
    }
}
