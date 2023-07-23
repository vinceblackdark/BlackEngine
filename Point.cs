using System;
using static System.Console;
using System.Drawing;
using static System.Drawing.Color;
namespace MayaEngine
{
    public class Point
    {
        private int _posY { get; set; }
        private int _posX { get; set; }
        private Color _color { get; set; }
        private string _pointChar { get; set; }

        public Point(int posX, int posY, Color color, char pointChar)
        {
            _color = color;
            _pointChar = pointChar.ToString();
            _posY = posY;
            _posX = posX;
        }
        public Point(int posX, int posY, Color color)
        {
            _color = color;
            _pointChar = "░░";
            _posY = posY;
            _posX = posX;
        }

        public void Draw()
        {
            Render.WriteStringPastel(_posX , _posY, _pointChar, _color);
        }
        public void DrawBg()
        {
            Render.WriteStringPastel(_posX, _posY, _pointChar, _color);
        }
    }
}
