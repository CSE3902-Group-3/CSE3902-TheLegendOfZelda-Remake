using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Interfaces
{
    public interface iSprite : iDrawable
    {
        public void UpdatePos(Vector2 pos);
    }
}
