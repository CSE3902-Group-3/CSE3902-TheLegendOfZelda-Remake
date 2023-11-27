using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class ShaderDrawer : IDrawer
    {
        public void Draw(List<IDrawable> drawables, Matrix transformMatrix, SpriteBatch spriteBatch)
        {
            //This is necessary to preserve drawing order in drawables list, it could make less spritebatch calls if drawing layers were kept as separate lists
            Effect currentShader = ShaderHolder.normalShader;
            spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix, effect: currentShader);
            foreach (IDrawable drawable in drawables)
            {

                Effect thisShader = drawable is IHasShader ? (drawable as IHasShader).ActiveShader : ShaderHolder.normalShader;

                if(currentShader != thisShader)
                {
                    spriteBatch.End();
                    currentShader = thisShader;
                    spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix, effect: currentShader);
                }

                drawable.Draw();
            }
            spriteBatch.End();
        }
    }
}
