using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda
{
    public class SoundFactory
    {
        public SoundEffect ArrowBoomerang { get; set; } // Shooting an arrow or boomerang
        public Song BackgroundMusic { get; set; }
        public SoundEffect BombBlow { get; set; }
        public SoundEffect BombDrop { get; set; }
        public SoundEffect BossHit { get; set; }
        public SoundEffect BossScream1 { get; set; } // Aquamentus
        public SoundEffect BossScream2 { get; set; } // Dodongo
        public SoundEffect BossScream3 { get; set; }
        public SoundEffect Candle { get; set; }
        public SoundEffect DoorUnlock { get; set; }
        public SoundEffect EnemyDie { get; set; }
        public SoundEffect EnemyHit { get; set; }
        public SoundEffect Fanfare { get; set; } // New item fanfare
        public SoundEffect GetHeart { get; set; } // Heart or key
        public SoundEffect GetItem { get; set; } // Item or fairy
        public SoundEffect GetRupee { get; set; }
        public SoundEffect KeyAppear { get; set; }
        public SoundEffect LinkDie { get; set; }
        public SoundEffect LinkHurt { get; set; }
        public SoundEffect LowHealth { get; set; }
        public SoundEffect MagicalRod { get; set; } // Wizard shooting magic
        public SoundEffect Recorder { get; set; }
        public SoundEffect RefillLoop { get; set; } // Loopable portion of health refill or rupee count change
        public SoundEffect Secret { get; set; } // Found a secret, correct solution, puzzle solved
        public SoundEffect Shield { get; set; }
        public SoundEffect Shore { get; set; } // Shore water
        public SoundEffect Stairs { get; set; }
        public SoundEffect SwordCombined { get; set; }
        public SoundEffect SwordShoot { get; set; }
        public SoundEffect SwordSlash { get; set; }
        public SoundEffect Text { get; set; } // Used also when health refills or rupee count changes
        public SoundEffect TextSlow { get; set; }
        public SoundEffect VineBoom { get; set; }

        private static SoundFactory instance = new();
        public static SoundFactory getInstance()
        {
            instance ??= new();

            return instance;
        }
        private SoundFactory() {}
        public void LoadTextures()
        {
            ContentManager content = Game1.getInstance().Content;
            ArrowBoomerang = content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang");
            BackgroundMusic = content.Load<Song>("SoundEffects/Underworld_BGM");
            BombBlow = content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Blow");
            BombDrop = content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Drop");
            BossHit = content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Hit");
            BossScream1 = content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream1");
            BossScream2 = content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream2");
            BossScream3 = content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream3");
            Candle = content.Load<SoundEffect>("SoundEffects/LOZ_Candle");
            DoorUnlock = content.Load<SoundEffect>("SoundEffects/LOZ_Door_Unlock");
            EnemyDie = content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Die");
            EnemyHit = content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Hit");
            Fanfare = content.Load<SoundEffect>("SoundEffects/LOZ_Fanfare");
            GetHeart = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Heart");
            GetItem = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Item");
            GetRupee = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Rupee");
            KeyAppear = content.Load<SoundEffect>("SoundEffects/LOZ_Key_Appear");
            LinkDie = content.Load<SoundEffect>("SoundEffects/LOZ_Link_Die");
            LinkHurt = content.Load<SoundEffect>("SoundEffects/LOZ_Link_Hurt");
            LowHealth = content.Load<SoundEffect>("SoundEffects/LOZ_LowHealth");
            MagicalRod = content.Load<SoundEffect>("SoundEffects/LOZ_MagicalRod");
            Recorder = content.Load<SoundEffect>("SoundEffects/LOZ_Recorder");
            RefillLoop = content.Load<SoundEffect>("SoundEffects/LOZ_Refill_Loop");
            Secret = content.Load<SoundEffect>("SoundEffects/LOZ_Secret");
            Shield = content.Load<SoundEffect>("SoundEffects/LOZ_Shield");
            Shore = content.Load<SoundEffect>("SoundEffects/LOZ_Shore");
            Stairs = content.Load<SoundEffect>("SoundEffects/LOZ_Stairs");
            SwordCombined = content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Combined");
            SwordShoot = content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Shoot");
            SwordSlash = content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Slash");
            Text = content.Load<SoundEffect>("SoundEffects/LOZ_Text");
            TextSlow = content.Load<SoundEffect>("SoundEffects/LOZ_Text_Slow");
            VineBoom = content.Load<SoundEffect>("SoundEffects/vine-boom-sound-effect"); // Sprint 5 feature ;)

            MediaPlayer.Play(BackgroundMusic);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }
        public static void PlaySound(SoundEffect sound, float volume, float pitch, float pan)
        {
            sound.Play(volume, pitch, pan);
        }
        public void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(BackgroundMusic);
        }
    }
}
