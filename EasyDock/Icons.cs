using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyDock
{
    class Icons
    {
        public static Size IMAGE_SIZE_NORMAL = new Size(27, 27);
        public static Size IMAGE_SIZE_ZOOM = new Size(40, 40);
        private static Icon tempIco;

        public static void FillIcons(ref PictureBox[] pics, ref List<string> iconPaths)
        {
            for (int i = 0; i < pics.Length; i++)
            {
                CreatePicBox(ref pics, ref iconPaths, i * 40 + 6, 6, i);
                if (i > 3)
                    break;
            }

            if (pics.Length > 5)
            {
                for (int i = 5; i < pics.Length; i++)
                {
                    CreatePicBox(ref pics, ref iconPaths, (i - 5) * 40 + 6, 46, i);
                }
            }
        }

        private static void CreatePicBox(ref PictureBox[] pics, ref List<string> iconPaths, int x, int y, int i)
        {
            pics[i] = new PictureBox();
            pics[i].SizeMode = PictureBoxSizeMode.StretchImage;
            pics[i].Size = IMAGE_SIZE_NORMAL;
            pics[i].Location = new Point(x, y);
            tempIco = Icon.ExtractAssociatedIcon(iconPaths[i]);
            pics[i].Image = tempIco.ToBitmap();
            pics[i].BackColor = Color.Transparent;
            pics[i].Cursor = Cursors.Hand;
            pics[i].Tag = i;
            pics[i].MouseEnter += Dock.Icons_MouseEnter;
            pics[i].MouseLeave += Dock.Icons_MouseLeave;
            pics[i].Click += Dock.Icons_Click; ;
        }
        
        
    }
}
