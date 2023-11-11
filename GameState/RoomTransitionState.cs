using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class RoomTransitionState : IGameState
    {
        public RoomTransitionState(){}
        public void Update(GameTime gameTime)
        {
            CameraController.GetInstance().mainCamera.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
