using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public interface IGameState: IUpdateable
    {
        public void Draw(SpriteBatch _spriteBatch);
    }
}
