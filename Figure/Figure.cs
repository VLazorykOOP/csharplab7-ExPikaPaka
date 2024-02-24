using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Figures {
    public abstract class Figure {
        public int x;
        public int y;
        public int width;
        public int height;
        public Color color;

        public Figure() {
            x = y = width = height = 0;
            color = Color.White;
        }

        public abstract void Draw(Graphics graphics);
    }

    public class Star : Figure {
        public override void Draw(Graphics graphics) {
            Pen pen = new Pen(color);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Point[] starPoints = new Point[10];
            starPoints[0] = new Point((int)(x + 0.5 * width), (int)(y + 0.0 * height));
            starPoints[1] = new Point((int)(x + 0.6 * width), (int)(y + 0.4 * height));
            starPoints[2] = new Point((int)(x + 1 * width), (int)(y + 0.4 * height));
            starPoints[3] = new Point((int)(x + 0.65 * width), (int)(y + 0.6 * height));
            starPoints[4] = new Point((int)(x + 0.8 * width), (int)(y + 1 * height));
            starPoints[5] = new Point((int)(x + 0.5 * width), (int)(y + 0.75 * height));
            starPoints[6] = new Point((int)(x + 0.2 * width), (int)(y + 1 * height));
            starPoints[7] = new Point((int)(x + 0.35 * width), (int)(y + 0.6 * height));
            starPoints[8] = new Point((int)(x + 0.0 * width), (int)(y + 0.4 * height));
            starPoints[9] = new Point((int)(x + 0.4 * width), (int)(y + 0.4 * height));

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(starPoints);
            path.CloseFigure();

            SolidBrush brush = new SolidBrush(color);
            graphics.FillPath(brush, path);

            graphics.DrawPath(pen, path);

            pen.Dispose();
            path.Dispose();
        }
    }

    public class Ellipse : Figure {
        public override void Draw(Graphics graphics) {
            Brush brush = new SolidBrush(color);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillEllipse(brush, x, y, width, height);

            brush.Dispose();
        }
    }

    public class Sector : Figure {
        public override void Draw(Graphics graphics) {
            Pen pen = new Pen(color);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            path.AddPie(x, y, width, height, 0, 90);

            SolidBrush brush = new SolidBrush(color);
            graphics.FillPath(brush, path);

            graphics.DrawPath(pen, path);

            pen.Dispose();
            path.Dispose();
        }
    }

    public class Rect : Figure {
        public override void Draw(Graphics graphics) {
            Brush brush = new SolidBrush(color);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.FillRectangle(brush, x, y, width, height);
            brush.Dispose();
        }
    }
}