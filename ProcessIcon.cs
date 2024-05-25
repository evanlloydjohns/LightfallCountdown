using System;
using System.Diagnostics;
using System.Windows.Forms;
using CountdownApp.Properties;
using System.Resources;


// Credit for system tray setup: https://www.codeproject.com/Articles/290013/Formless-System-Tray-Application
namespace CountdownApp
{
    internal class ProcessIcon : IDisposable
    {
        NotifyIcon releaseIcon;
        DateTime releaseDate;
        TimeSpan timeRemaining;
        string displayFormatString;

        public ProcessIcon()
        {
            releaseIcon = new NotifyIcon();
            releaseDate = new DateTime(2024, 6, 4, 11, 0, 0);
            displayFormatString = "{0} days\n{1} hours\n{2} minutes\n{3} seconds";
        }

        public void Display()
        {
            // Create System Tray Icon
            releaseIcon.Icon = Resources.Destiny_Tricorn_XSmall;
            releaseIcon.Visible = true;

            // Set Up Timer
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateTimer;
            timer.Start();

            // Add Context Menu to System Tray Icon
            releaseIcon.ContextMenuStrip = new ContextMenus().Create();
        }

        public void UpdateTimer(object sender, EventArgs e) 
        {
            timeRemaining = releaseDate - DateTime.Now;

            releaseIcon.Text = String.Format(
                displayFormatString,
                timeRemaining.Days,
                timeRemaining.Hours,
                timeRemaining.Minutes,
                timeRemaining.Seconds
            );
        }

        public void Dispose()
        {
            releaseIcon.Dispose();
        }
    }
}
