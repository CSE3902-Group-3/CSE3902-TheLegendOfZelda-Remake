﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IHUD
    {
        public void Update(GameTime gameTime);
        public void Show();
    }
}
