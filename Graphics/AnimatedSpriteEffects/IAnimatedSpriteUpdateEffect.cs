﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IAnimatedSpriteUpdateEffect : IAnimatedSpriteEffect
    {
        public void ExecuteEffect();
    }
}
