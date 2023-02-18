using System;
using System.Diagnostics;
using System.Windows.Forms;
using CountdownApp.Properties;
using System.Drawing;

namespace CountdownApp
{
    internal class ContextMenus
    {

        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem exitItem = new ToolStripMenuItem();
            exitItem.Text = "Close";
            exitItem.Click += new EventHandler(Exit_Click);
            exitItem.Image = Resources.Exit;
            menu.Items.Add(exitItem);

            return menu;
        }

        void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
