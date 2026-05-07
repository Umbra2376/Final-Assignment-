using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Christmas_Class
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;
        public pokemon(Texture2D texture, Rectangle rect, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }
    }
}
