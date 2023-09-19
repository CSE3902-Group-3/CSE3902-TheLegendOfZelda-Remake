using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Interfaces
{
    public interface IPlayer : IUpdateable
    {
        ISprite sprite { get; }

        public void UseItem();

        public void ChangeItem(int index);
        public void ChangeWeapon(int index);

        public void Reset();
    }
}
