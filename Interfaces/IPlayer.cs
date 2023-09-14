using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Interfaces
{
    public interface IPlayer : iUpdateable, iDrawable
    {
        // ISprite here
        public Vector2 position { get { return position; } set { position = value; } }
        public Vector2 prevPosition { get { return prevPosition; } private set { prevPosition = value; } }

        public Vector2 velocity { get { return velocity; } set { velocity = value; } }
        // IState here

        // other fields, health, booleans go here?

        public void Update();
    }
}
