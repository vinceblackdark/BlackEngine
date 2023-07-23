using System;
using static System.Console;
using System.Drawing;
using static System.Drawing.Color;
using static MayaEngine.Resources;
namespace MayaEngine
{
    public class Frame
    {
        private int _posY { get; set; }
        private int _posX { get; set; }
        private Color _color { get; set; }
        private string _frameFile { get; set; }
        private string[] _frame { get; set; }

        public Frame(int posX, int posY, Color color, string frame)
        {
            _posX = posX;
            _posY = posY;
            _color = color;
            _frameFile = frame;
            _frame = GetFrameArray(_frameFile);
        }
        public void Draw()
        {
            Render.WriteStringArrayPastel(_posX, _posY, _frame, _color);
        }
        public void DrawBg()
        {
            Render.WriteStringArrayPastelBg(_posX, _posY, _frame, _color);
        }

        public string[] GetFrame()
        {
            return _frame;
        }

    }
}
