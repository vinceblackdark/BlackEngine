using System;
using static System.Console;
using System.Drawing;
using static System.Drawing.Color;
namespace MayaEngine
{
    public class Triangle
    {
        private int _height { get; set; }
        private Color _color { get; set; }
        private char _triangleChar { get; set; }
        private int _posY { get; set; }
        private int _posX { get; set; }
        public Triangle(int posX, int posY, int height, Color color, char triangleChar)
        {
            _height = height;
            _posY = posY;
            _posX = posX;
            _color = color;
            _triangleChar = triangleChar;
        }
        public void Draw()
        {
            for (int i = 1; i <= _height; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Render.WriteCharPastel(_posX + i + 1, _posY + j, _triangleChar, _color);
                }
            }
        }
        public void DrawBg()
        {
            for (int i = 1; i <= _height; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Render.WriteCharPastelBg(_posX + i + 1, _posY + j, _triangleChar, _color);
                }
            }
        }
    }
}
