using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class StandardDrawer : IDrawer
    {
        public void Draw(List<IDrawable> drawables, Matrix transformMatrix, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            spriteBatch.End();
        }
    }
}
