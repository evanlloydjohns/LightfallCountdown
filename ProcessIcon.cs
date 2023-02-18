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

        public ProcessIcon()
        {
            releaseDate = new DateTime(2023, 2, 28, 12, 0, 0);
            releaseIcon = new NotifyIcon();
        }

        public void Display()
        {
            // Create System Tray Icon
            releaseIcon.Icon = Resources.Lightfall_Icon_XSmall;
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
            DateTime futureTime = new DateTime(2023, 2, 28, 12, 0, 0); // Replace with your desired future time

            TimeSpan timeRemaining = futureTime - DateTime.Now;

            string timeRemainingText = String.Format(
                "Light falls in \n{0} days\n{1} hours\n{2} minutes\n{3} seconds", 
                timeRemaining.Days, 
                timeRemaining.Hours, 
                timeRemaining.Minutes, 
                timeRemaining.Seconds
            );
            releaseIcon.Text = timeRemainingText;
        }

        public void Dispose()
        {
            releaseIcon.Dispose();
        }
    }
}
