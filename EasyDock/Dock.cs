using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace EasyDock
{
    public partial class Dock : Form
    {
        public Dock()
        {
            appNames = new List<string>();
            appPaths = new List<string>();
            tempAppPaths = new List<string>();
            Apps.Read(ref appNames, ref appPaths);
            Apps.CalcAppCount(ref appNames, ref appPaths);
            tempAppPaths = appPaths;

            pictureBoxes = new PictureBox[Apps.APP_COUNT];
            Icons.FillIcons(ref pictureBoxes, ref appPaths);
            Controls.AddRange(pictureBoxes);

            InitializeComponent();

            this.BackgroundImage = Image.FromFile("bg.png");
            // Start animation
            Location = new Point(DesktopLocation.X, Screen.PrimaryScreen.Bounds.Height);
            Transition.run(this, "Top", Screen.PrimaryScreen.Bounds.Height - 140, new TransitionType_Deceleration(500));

            if (appNames.Count <= 0)
            {
                MessageBox.Show("Applications not found. Please add application");
                Application.Exit();
            }
        }

        static PictureBox[] pictureBoxes;
        public static int FORM_WIDTH, FORM_HEIGHT;
        List<string> appNames, appPaths;
        static List<string> tempAppPaths;

        private void EasyDock_Paint(object sender, PaintEventArgs e)
        {
            this.Region = new System.Drawing.Region(FormShape.GetShape());
            e.Graphics.DrawRectangle(new Pen(Color.White, 3), FormShape.GetFormRectangle());

            e.Graphics.DrawLines(new Pen(Color.White, 3), FormShape.GetDownBorder());
        }

        public static void Icons_MouseEnter(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            Zoom.ZoomIn(ref pictureBoxes[tag], tag);
        }

        private void Dock_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            Application.Exit();
        }

        public static void Icons_MouseLeave(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            Zoom.ZoomOut(ref pictureBoxes[tag], tag);
        }

        public static void Icons_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            System.Diagnostics.Process.Start(tempAppPaths[tag]);
        }

    }
}
