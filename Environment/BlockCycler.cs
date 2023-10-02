using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class BlockCycler
    {
        private SpriteFactory spriteFactory;
        private List<Block> blocks;
        private Vector2 pos;
        private int index = 0;
        public BlockCycler(Vector2 pos) {
            this.pos = pos;
            spriteFactory = Game1.getInstance().spriteFactory;
            blocks = new List<Block>();

            blocks.Add(new Block(spriteFactory.CreateFloorTileSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWallSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateFishSculptureSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateDragonSculptureSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateBlackTileSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateSandTileSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateBlueTileSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateStairsSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateBrickSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateLadderSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWallNorthSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWallWestSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWallEastSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWallSouthSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateNorthOpenDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWestOpenDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateEastOpenDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateSouthOpenDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateNorthLockedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWestLockedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateEastLockedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateSouthLockedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateNorthClosedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWestClosedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateEastClosedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateSouthClosedDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateNorthHoleDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateWestHoleDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateEastHoleDoorSprite(), pos));
            blocks.Add(new Block(spriteFactory.CreateSouthHoleDoorSprite(), pos));

            foreach(Block block in blocks)
            {
                block.enabled = false;
            }
        }

        public void cycleForward()
        {
            blocks[index].enabled = false;
            index++;
            if(index >= blocks.Count)
            {
                index = 0;
            }
            blocks[index].enabled = true;
        }

        public void cycleBackward()
        {
            blocks[index].enabled = false;
            index--;
            if (index < 0)
            {
                index = blocks.Count - 1;
            }
            blocks[index].enabled = true;
        }
    }
}
