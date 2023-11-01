﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal interface IGameState: IUpdateable
    {
        public void Draw();
    }
}