using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDock
{
    class Zoom
    {
        
        public static void ZoomIn(ref System.Windows.Forms.PictureBox pic, int tag)
        {
            Transitions.Transition zoomTransition = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(100));
            zoomTransition.add(pic, "Width", Icons.IMAGE_SIZE_ZOOM.Width);
            zoomTransition.add(pic, "Height", Icons.IMAGE_SIZE_ZOOM.Height);
            zoomTransition.add(pic, "Left", (tag <= 4) ? tag * Icons.IMAGE_SIZE_ZOOM.Width : (tag - 5) * Icons.IMAGE_SIZE_ZOOM.Width);
            zoomTransition.add(pic, "Top", (tag <= 4) ? 0 : 40);
            zoomTransition.run();
        }

        public static void ZoomOut(ref System.Windows.Forms.PictureBox pic, int tag)
        {
            Transitions.Transition zoomTransition = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(100));
            zoomTransition.add(pic, "Width", Icons.IMAGE_SIZE_NORMAL.Width);
            zoomTransition.add(pic, "Height", Icons.IMAGE_SIZE_NORMAL.Height);
            zoomTransition.add(pic, "Left", (tag <= 4) ? tag * Icons.IMAGE_SIZE_ZOOM.Width + 6 : (tag - 5) * Icons.IMAGE_SIZE_ZOOM.Width + 6);
            zoomTransition.add(pic, "Top", (tag <= 4) ? 6 : 46);
            zoomTransition.run();
        }

    }
}
