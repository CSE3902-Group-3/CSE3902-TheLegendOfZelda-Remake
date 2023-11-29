using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IDrawer
    {
        public void Draw(List<IDrawable> drawables, Matrix transformMatrix, SpriteBatch spriteBatch);
    }
}
