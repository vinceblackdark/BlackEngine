using System;
using static System.Console;
using System.Drawing;
using static System.Drawing.Color;
namespace MayaEngine
{
    public class Circle
    {
        private char _circleChar { get; set; }
        private int _radius { get; set; }
        private Color _color { get; set; }
        private int _posX { get; set; }
        private int _posY { get; set; }
        public Circle(int posX,int posY, int radius, Color color, char circleChar)
        {
            _posY = posY;
            _posX = posX;
            _color = color;
            _radius = radius;
            _circleChar = circleChar;
        }
        public void Draw()
        {
            for (int y = -_radius; y <= _radius; y++)
            {
                for (int x = -_radius; x <= _radius; x++)
                {
                    double distance = Math.Sqrt(x * x + (y * 2) * (y * 2));
                    if (distance <= _radius)
                    {

                        Render.WriteStringPastel(_posX + x, _posY + y, _circleChar.ToString(), _color);
                    }
                    else
                    {
                        Render.WriteStringPastelBg(_posX, _posY, " ", Color.Black);
                    }
                }
            }
        }
        public void DrawBg()
        {
            for (int y = -_radius; y <= _radius; y++)
            {
                for (int x = -_radius; x <= _radius; x++)
                {
                    double distance = Math.Sqrt(x * x + (y * 2) * (y * 2));
                    if (distance <= _radius)
                    {

                        Render.WriteStringPastelBg(_posX + x, _posY + y, _circleChar.ToString(), _color);
                    }
                    else
                    {
                        Render.WriteStringPastelBg(_posX, _posY, " ", Color.Black);
                    }
                }
            }
        }
    }
    public class Oval
    {
        public int _radius { get; set; }
        public Color _color { get; set; }
        public char _ovalChar { get; set; }
        public int _posY { get; set; }
        public int _posX { get; set; }

        public int _WindowWidth = WindowWidth;
        public int _WindowHeight = WindowHeight;
        public bool _ShowCursor = CursorVisible = false;
        public Oval(int posX, int posY, int radius, Color color, char ovalChar)
        {
            _radius = radius;
            _color = color;
            _ovalChar = ovalChar;
            _posY = posY;
            _posX = posX;
        }
        public void Draw()
        {
            for (int y = -_radius; y <= _radius; y++)
            {
                for (int x = -_radius; x <= _radius; x++)
                {
                    double distance = Math.Sqrt(x * x + (y * 2) * (y * 2));
                    if (distance <= _radius)
                    {
                        Render.WriteStringPastel(_posX + x, _posY + y, _ovalChar.ToString(), _color);
                    }
                    else
                    {
                        Render.WriteStringPastelBg(_posX, _posY, " ", Color.Black);
                    }
                }
            }
        }
        public void DrawBg()
        {
            for (int y = -_radius; y <= _radius; y++)
            {
                for (int x = -_radius; x <= _radius; x++)
                {
                    double distance = Math.Sqrt(x * x + (y * 2) * (y * 2));
                    if (distance <= _radius)
                    {
                        Render.WriteStringPastelBg(_posX + x, _posY + y, _ovalChar.ToString(), _color);
                    }
                    else
                    {
                        Render.WriteStringPastelBg(_posX, _posY, " ", Color.Black);
                    }
                }
            }
        }
    }
}
