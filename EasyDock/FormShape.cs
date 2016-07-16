using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace EasyDock
{
    class FormShape
    {
        /// <summary>
        /// Create form shape
        /// </summary>
        /// <returns>Return created GraphicsPath object</returns>
        public static GraphicsPath GetShape()
        {
            Dock.FORM_WIDTH = (Apps.APP_COUNT <= 5) ? Apps.APP_COUNT * 40 : 200;
            Dock.FORM_HEIGHT = (Apps.APP_COUNT <= 5) ? 40 : 80;
            GraphicsPath shape = new GraphicsPath();
            shape.AddRectangle(new Rectangle(0, 0, Dock.FORM_WIDTH, Dock.FORM_HEIGHT));

            Point[] points = new Point[3];
            points[0] = new Point(Dock.FORM_WIDTH / 2 - 10, Dock.FORM_HEIGHT);
            points[1] = new Point(Dock.FORM_WIDTH / 2 + 10, Dock.FORM_HEIGHT);
            points[2] = new Point(Dock.FORM_WIDTH / 2, Dock.FORM_HEIGHT + 10);
            shape.AddPolygon(points);

            return shape;
        }

        /// <summary>
        /// Get Form Border
        /// </summary>
        /// <returns>Return form rectangle without down border</returns>
        public static Rectangle GetFormRectangle()
        {
            return new Rectangle(new Point(0, 0), new Size(Dock.FORM_WIDTH, Dock.FORM_HEIGHT + 10));
        }

        public static Point[] GetDownBorder()
        {
            Point[] points = new Point[5];
            points[0] = new Point(0, Dock.FORM_HEIGHT);
            points[1] = new Point(Dock.FORM_WIDTH / 2 - 10, Dock.FORM_HEIGHT);
            points[2] = new Point(Dock.FORM_WIDTH / 2, Dock.FORM_HEIGHT + 10);
            points[3] = new Point(Dock.FORM_WIDTH / 2 + 10, Dock.FORM_HEIGHT);
            points[4] = new Point(Dock.FORM_WIDTH, Dock.FORM_HEIGHT);
            return points;
        }
    }
}
