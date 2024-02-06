using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using No28.GameObject;
using System.Collections.Generic;

namespace No28
{
    class Level
    {
        private Texture2D texture = Singleton.Instance.TILESPRITE;
        private Texture2D ore = Singleton.Instance.ORESPRITE;
        private Texture2D fallen = Singleton.Instance.FALLEN;

        public static List<Block> blocks = new List<Block>();

        public enum Blocks
        {
            NONE,
            GRASS,
            BOX,
            TOP_LEFT_VINE,
            TOP_MID_VINE,
            TOP_RIGHT_VINE,
            MID_LEFT_VINE,
            MID_MID_VINE,
            MID_RIGHT_VINE,
            BOT_LEFT_VINE,
            BOT_MID_VINE,
            BOT_RIGHT_VINE,
            DIRT,
            ACTIVE_ORE,
            ORE,
            FALLEN
        }

        public Level()
        {
            for (int i = 0; i < 34; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, i * 32, 20 * 32, 32, 32)); //ground
            }
            //tutorial
            blocks.Add(new Block(Blocks.GRASS, 5 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 9 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 9 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 14 * 32, 19 * 32, 32, 32)); 
            blocks.Add(new Block(Blocks.DIRT, 14 * 32, 18 * 32, 32, 32)); 
            blocks.Add(new Block(Blocks.GRASS, 14 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 15 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 20 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 21 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 21 * 32, 18 * 32, 32, 32));
            for (int i = 0; i < 7; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (27+i) * 32, 19 * 32, 32, 32));
            }
            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (27 + i) * 32, 18 * 32, 32, 32));
            }
            for (int i = 0; i < 3; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (31 + i) * 32, 18 * 32, 32, 32));
                blocks.Add(new Block(Blocks.GRASS, (31 + i) * 32, 17 * 32, 32, 32));
            }
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 28 * 32 , 17 * 32-16, 32, 32));
            for (int i = 0; i < 6; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (38 + i) * 32, 20 * 32, 32, 32)); //ground
            }

            blocks.Add(new Block(Blocks.DIRT, 38 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 38 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 38 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 38 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 38 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 38 * 32, 14 * 32, 32, 32));
            for (int i = 0; i < 3; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, 38 * 32, (13-i) * 32, 32, 32));
            }
            blocks.Add(new Block(Blocks.DIRT, 39 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 39 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 39 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 42 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 42 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 43 * 32, 19 * 32, 32, 32));
            //last level 1 
            for (int i = 0; i < 23; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (46 + i) * 32, 20 * 32, 32, 32)); //ground
            }
            blocks.Add(new Block(Blocks.DIRT, 46 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 46 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 46 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 47 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 47 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 53 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 54 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 55 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 55 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 53 * 32, 16 * 32, 32, 32));
            for (int i = 0; i < 5; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (56 ) * 32, (19-i) * 32, 32, 32)); 
            }
            blocks.Add(new Block(Blocks.GRASS, 55 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 56 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 57 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 58 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.FALLEN, 56 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 57 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 57 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 59 * 32, 16 * 32 -16 , 32, 32));
            blocks.Add(new Block(Blocks.BOT_LEFT_VINE, 60 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_LEFT_VINE, 60 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 61 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 61 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 59 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 60 * 32, 17 * 32, 32, 32));
            for (int i = 0; i < 18  ; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (61) * 32, (17 - i) * 32, 32, 32)); //pillar
            }
            blocks.Add(new Block(Blocks.GRASS, 68 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 65 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 62 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 64 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 67 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 68 * 32, 13 * 32, 32, 32));
            // last level 2
            for (int i = 0; i < 18; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (74 + i) * 32, 20 * 32, 32, 32)); //ground
            }

            blocks.Add(new Block(Blocks.DIRT, 91 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 91 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 91 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 91 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.FALLEN, 88 * 32, 18 * 32 , 32, 32)); //fallen
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 88 * 32, 13 * 32-16, 32, 32)); //ore
            blocks.Add(new Block(Blocks.GRASS, 76 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 77 * 32, 15 * 32, 32, 32));
            for (int i = 0; i < 14; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (78 + i) * 32, 15 * 32, 32, 32)); //platform
                blocks.Add(new Block(Blocks.GRASS, (78 + i) * 32, 14 * 32, 32, 32));
            }
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 80 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 80 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 80 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 80 * 32, 10 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_LEFT_VINE, 84 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_LEFT_VINE, 84 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_LEFT_VINE, 84 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_LEFT_VINE, 84 * 32, 10 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_MID_VINE, 85 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 85 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 85 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 85 * 32, 10 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 92 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 90 * 32, 10 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 93 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 96 * 32, 6 * 32, 32, 32));

            for (int i = 0; i < 15; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (97) * 32, (19 - i) * 32, 32, 32)); //pillar
            }
            for (int i = 0; i < 13; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (97 + i) * 32, 4 * 32, 32, 32)); //platform
            }
            for (int i = 0; i < 12; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (100 + i) * 32, 7 * 32, 32, 32)); //platform
            }
            for (int i = 0; i < 12; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (98   + i) * 32, 10 * 32, 32, 32)); //platform
            }
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 99 * 32, 9 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 99 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 99 * 32, 7 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 99 * 32, 6 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 99 * 32, 5 * 32, 32, 32));

            for (int i = 0; i < 2; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (98 + i) * 32, 14 * 32, 32, 32)); //platform
            }
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 98 * 32, 13 * 32 - 16, 32, 32));
            for (int i = 0; i < 7; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (104 + i) * 32, 14 * 32, 32, 32)); //platform
            }
            for (int i = 0; i < 13; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (99 + i) * 32, 17 * 32, 32, 32)); //platform
            }
            for (int i = 0; i < 12; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (97 + i) * 32, 20 * 32, 32, 32)); //platform
            }
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 112 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 112 * 32, 18 * 32, 32, 32));
            for (int i = 0; i < 18; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (112) * 32, (17 - i) * 32, 32, 32)); //pillar
            }

            for (int i = 0; i < 10; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (112 + i) * 32, 20 * 32, 32, 32)); //ground
            }
            for (int i = 0; i < 6; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (115 + i) * 32, (20-i) * 32, 32, 32)); //stairs
            }
            blocks.Add(new Block(Blocks.GRASS, 113 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 114 * 32, 16 * 32, 32, 32));
            
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 118 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 118 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 118 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 118 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 118 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 118 * 32, 11 * 32, 32, 32));

            blocks.Add(new Block(Blocks.MID_RIGHT_VINE, 119 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_RIGHT_VINE, 119 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_RIGHT_VINE, 119 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_RIGHT_VINE, 119 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_RIGHT_VINE, 119 * 32, 11 * 32, 32, 32));

            for (int i = 0; i < 12  ; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (120) * 32, (11 - i) * 32, 32, 32)); //pillar
            }
            blocks.Add(new Block(Blocks.GRASS, 125 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 126 * 32, 12 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 121 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 123 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 126 * 32, 8 * 32, 32, 32));
            for (int i = 0; i < 5; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (126) * 32, (4 - i) * 32, 32, 32)); //pillar
            }
            blocks.Add(new Block(Blocks.DIRT, 127 * 32, 10 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 127 * 32, 9 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_MID_VINE, 127 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 127 * 32, 7 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 127 * 32, 6 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 127 * 32, 5 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 127 * 32, 4 * 32, 32, 32));
            for (int i = 0; i < 3; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (125 + i) * 32, 20 * 32, 32, 32)); //upgrade  ground
            }
            blocks.Add(new Block(Blocks.FALLEN, 125 * 32, 18 * 32, 32, 32)); //fallen
            for (int i = 0; i < 16; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (131) * 32, (15 - i) * 32, 32, 32)); //pillar
            }
            for (int i = 0; i < 5; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (131 + i) * 32, 20 * 32, 32, 32)); //ground
                blocks.Add(new Block(Blocks.GRASS, (131 + i) * 32, 19 * 32, 32, 32)); 
            }
            blocks.Add(new Block(Blocks.GRASS, 138 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 139 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 140 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 139 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 137 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 135 * 32, 12 * 32, 32, 32));
            for (int i=0; i < 3;i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (132+i) * 32, 10 * 32, 32, 32));
            }
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 132 * 32, 9 * 32 - 16, 32, 32));
            for (int i = 0; i < 3; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (139 + i) * 32, 10 * 32, 32, 32));
            }
            
            blocks.Add(new Block(Blocks.BOT_MID_VINE, 139 * 32, 9 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 139 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 139 * 32, 7 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_MID_VINE, 141 * 32, 9 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 141 * 32, 8 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 141 * 32, 7 * 32, 32, 32));

            blocks.Add(new Block(Blocks.GRASS, 144 * 32, 10 * 32, 32, 32));
            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (147 + i) * 32, 10 * 32, 32, 32));
            }
            blocks.Add(new Block(Blocks.FALLEN, 149 * 32, 8 * 32, 32, 32)); //fallen
            blocks.Add(new Block(Blocks.GRASS, 146 * 32, 13 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 144 * 32, 16 * 32, 32, 32));

            for (int i = 0; i < 7; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (142) * 32, (18 - i) * 32, 32, 32)); //pillar
            }
            for (int i = 0; i < 17; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (147 + i) * 32, 20 * 32, 32, 32)); //ground
            }
            blocks.Add(new Block(Blocks.DIRT, 153 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 153 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 161 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 161 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 162 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 162 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 162 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 166 * 32, 19 * 32, 32, 32));
            blocks.Add(new Block(Blocks.DIRT, 166 * 32, 18 * 32, 32, 32));
            blocks.Add(new Block(Blocks.GRASS, 166 * 32, 17 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_LEFT_VINE, 165 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_LEFT_VINE, 165 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_LEFT_VINE, 165 * 32, 14 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_MID_VINE, 166 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_MID_VINE, 166 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_MID_VINE, 166 * 32, 14 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOT_RIGHT_VINE, 167 * 32, 16 * 32, 32, 32));
            blocks.Add(new Block(Blocks.MID_RIGHT_VINE, 167 * 32, 15 * 32, 32, 32));
            blocks.Add(new Block(Blocks.TOP_RIGHT_VINE, 167 * 32, 14 * 32, 32, 32));
            
            for (int i = 0; i < 10; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (167 + i) * 32, 17 * 32, 32, 32)); //platform
            }
            blocks.Add(new Block(Blocks.ACTIVE_ORE, 170 * 32, 16 * 32 - 16, 32, 32));

            //boss chamber
            for (int i = 0; i < 40; i++)
            {
                blocks.Add(new Block(Blocks.GRASS, (200 + i) * 32, 20 * 32, 32, 32)); //ground
            }
            for (int i = 0; i < 20; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (200) * 32, (19 - i) * 32, 32, 32)); //pillar
            }
            for (int i = 0; i < 20; i++)
            {
                blocks.Add(new Block(Blocks.DIRT, (239) * 32, (19 - i) * 32, 32, 32)); //pillar
            }

            blocks.Add(new Block(Blocks.BOX, 213 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 214 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 215 * 32, 14 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOX, 220 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 221 * 32, 14 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 222 * 32, 14 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOX, 207 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 208 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 209 * 32, 17 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOX, 207 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 208 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 209 * 32, 11 * 32, 32, 32));
            
            blocks.Add(new Block(Blocks.BOX, 226 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 227 * 32, 17 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 228 * 32, 17 * 32, 32, 32));

            blocks.Add(new Block(Blocks.BOX, 226 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 227 * 32, 11 * 32, 32, 32));
            blocks.Add(new Block(Blocks.BOX, 228 * 32, 11 * 32, 32, 32));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var block in blocks)
            {
                switch(block.blockType)
                {
                    case Blocks.GRASS:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(160, 32, 32, 32), Color.White);
                        
                        break;

                    case Blocks.BOX:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(128, 32, 32, 32), Color.White);

                        break;

                    case Blocks.TOP_LEFT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(0, 0, 32, 32), Color.White);

                        break;

                    case Blocks.TOP_MID_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(0, 32, 32, 32), Color.White);

                        break;

                    case Blocks.TOP_RIGHT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(0, 64, 32, 32), Color.White);

                        break;

                    case Blocks.MID_LEFT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(32, 0, 32, 32), Color.White);

                        break;

                    case Blocks.MID_MID_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(32, 32, 32, 32), Color.White);

                        break;

                    case Blocks.MID_RIGHT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(32, 64, 32, 32), Color.White);

                        break;

                    case Blocks.BOT_LEFT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(64, 0, 32, 32), Color.White);

                        break;

                    case Blocks.BOT_MID_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(64, 32, 32, 32), Color.White);

                        break;

                    case Blocks.BOT_RIGHT_VINE:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(64, 64, 32, 32), Color.White);

                        break;

                    case Blocks.DIRT:
                        spriteBatch.Draw(texture, new Vector2(block.position.X, block.position.Y), new Rectangle(160, 64, 32, 32), Color.White);

                        break;

                    case Blocks.ACTIVE_ORE:
                        spriteBatch.Draw(ore, new Vector2(block.position.X, block.position.Y), new Rectangle(0, 0, 64, 48), Color.White);

                        break;

                    case Blocks.ORE:
                        spriteBatch.Draw(ore, new Vector2(block.position.X, block.position.Y), new Rectangle(64, 0, 64, 48), Color.White);

                        break;

                    case Blocks.FALLEN:
                        spriteBatch.Draw(fallen, new Vector2(block.position.X, block.position.Y), new Rectangle(0, 0, 64, 64), Color.White);

                        break;
                }
            }

        }
    }
}
