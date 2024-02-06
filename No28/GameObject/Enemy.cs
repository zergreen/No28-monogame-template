using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace No28.GameObject
{
    class Enemy
    {
        public List<Shroom> shrooms = new List<Shroom>();

        public List<Chomper> chompers = new List<Chomper>(); 

        public Enemy()
        {
            //Shroom shroom = new Shroom(new Vector2(Singleton.GAMEWIDTH / 2, Singleton.GAMEHEIGHT / 2));
            //shrooms.Add(shroom);
            //level 1
            shrooms.Add(new Shroom(new Vector2(18 * 32, 19 * 32)));
            chompers.Add(new Chomper(new Vector2(24 * 32, 18 * 32)));

            //level 2
            shrooms.Add(new Shroom(new Vector2(48 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(51 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(54 * 32, 18 * 32)));

            chompers.Add(new Chomper(new Vector2(63 * 32, 18 * 32)));
            shrooms.Add(new Shroom(new Vector2(66 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(68 * 32, 12 * 32)));

            //level 3 
            shrooms.Add(new Shroom(new Vector2(76 * 32, 19 * 32)));
            chompers.Add(new Chomper(new Vector2(79 * 32, 18 * 32)));
            chompers.Add(new Chomper(new Vector2(82 * 32, 18 * 32)));
            shrooms.Add(new Shroom(new Vector2(84 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(86 * 32, 19 * 32)));

            chompers.Add(new Chomper(new Vector2(82 * 32, 12 * 32)));
            
            shrooms.Add(new Shroom(new Vector2(99 * 32, 3 * 32)));
            chompers.Add(new Chomper(new Vector2(103 * 32, 2 * 32)));
            shrooms.Add(new Shroom(new Vector2(107 * 32, 3 * 32)));

            shrooms.Add(new Shroom(new Vector2(107 * 32, 6 * 32)));
            chompers.Add(new Chomper(new Vector2(103 * 32, 5 * 32)));
            
            shrooms.Add(new Shroom(new Vector2(98 * 32, 9 * 32)));
            chompers.Add(new Chomper(new Vector2(103 * 32, 8 * 32)));
            shrooms.Add(new Shroom(new Vector2(107 * 32, 9 * 32)));

            chompers.Add(new Chomper(new Vector2(105 * 32, 12 * 32)));

            chompers.Add(new Chomper(new Vector2(99 * 32, 15 * 32)));
            chompers.Add(new Chomper(new Vector2(103 * 32, 15 * 32)));
            chompers.Add(new Chomper(new Vector2(106 * 32, 15 * 32)));

            shrooms.Add(new Shroom(new Vector2(103 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(106 * 32, 19 * 32)));
            chompers.Add(new Chomper(new Vector2(114 * 32, 18 * 32)));
            shrooms.Add(new Shroom(new Vector2(120 * 32, 14 * 32)));

            chompers.Add(new Chomper(new Vector2(133 * 32, 17 * 32)));
            shrooms.Add(new Shroom(new Vector2(140 * 32, 17 * 32)));
            shrooms.Add(new Shroom(new Vector2(140 * 32, 9 * 32)));

            shrooms.Add(new Shroom(new Vector2(148 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(150 * 32, 19 * 32)));
            shrooms.Add(new Shroom(new Vector2(152 * 32, 19 * 32)));
            chompers.Add(new Chomper(new Vector2(155 * 32, 18 * 32)));
            chompers.Add(new Chomper(new Vector2(158     * 32, 18 * 32)));

            //Chomper chomper = new Chomper(new Vector2(Singleton.GAMEWIDTH / 2, Singleton.GAMEHEIGHT / 2));
            //chompers.Add(chomper);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var shroom in shrooms)
            {
                shroom.Update(gameTime);
            }

            foreach (var chomper in chompers)
            {
                chomper.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var shroom in shrooms)
            {
                shroom.Draw(spriteBatch);
            }

            foreach (var chomper in chompers)
            {
                chomper.Draw(spriteBatch);
            }
        }
    }

    class Shroom
    {
        private bool isAlive = true;
        private bool isFacingRight = false;
        private bool isIdle = false;
        private bool isWalking = false;
        private bool isDying = false;

        private float movespeed = 300f;

        private Vector2 position;

        private SpriteEffects effect = SpriteEffects.None;

        private SHROOMSTATE state;

        private Texture2D texture;

        private enum SHROOMSTATE
        {
            IDLE,
            WALKING,
            DYING,
        }

        public Shroom(Vector2 position)
        {
            this.position = position;
            texture = Singleton.Instance.SHROOMSPRITE;
        }

        public void CheckFacing()
        {
            if (!isFacingRight) effect = SpriteEffects.None;
            else effect = SpriteEffects.FlipHorizontally;
        }

        public void CheckState()
        {
            if (isWalking) state = SHROOMSTATE.WALKING;
            else if (isDying) state = SHROOMSTATE.DYING;
            else state = SHROOMSTATE.IDLE;
        }

        public void WalkPattern(Vector2 point1, Vector2 point2, GameTime gameTime)
        {

        }

        public void Walk(Vector2 point, GameTime gameTime)
        {

        }

        public void Stop()
        {

        }

        public void Update(GameTime gameTime)
        {
            CheckFacing();
            CheckState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case SHROOMSTATE.IDLE:
                    spriteBatch.Draw(texture, position, new Rectangle(0, 0, 32, 32), Color.White);
                    break;

                case SHROOMSTATE.WALKING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(0, 32, 32, 32), effect, 4, 0.2f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);
                    break;

                case SHROOMSTATE.DYING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(32, 0, 32, 32), effect, 4, 0.2f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);
                    break;
            }

        }
    }

    class Chomper
    {
        private bool isFacingRight = false;
        private bool isAggro = false;
        private bool isAttacking = false;
        private bool isDying = false;

        private int searchRadius = 5;

        private Vector2 position;

        private Texture2D texture;

        private SpriteEffects effect = SpriteEffects.None;

        private Chomper.STATE state;

        public Chomper(Vector2 position)
        {
            this.position = position;
            texture = Singleton.Instance.CHOMPERSPRITE;
        }

        enum STATE
        {
            IDLE,
            ATTACKING,
            DYING
        }
        public void CheckFacing()
        {
            if (!isFacingRight) effect = SpriteEffects.None;
            else effect = SpriteEffects.FlipHorizontally;
        }

        public void CheckState()
        {
            if (isAttacking) state = STATE.ATTACKING;
            else if (isDying) state = STATE.DYING;
            else state = STATE.IDLE;
        }

        public void SearchForPlayer(Vector2 playerPosition)
        {
            if (!isAggro)
            {
                Rectangle player = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 32, 64);
                Rectangle chomp = new Rectangle((int)position.X - searchRadius * 32, (int)position.Y - searchRadius * 32, 64 + 32 * searchRadius, 64 + 32 * searchRadius);

                if (chomp.Intersects(player))
                {
                    isAggro = true;
                }
            }
        }

        public void Teleport(Vector2 playerPosition)
        {

        }

        public void Update(GameTime gameTime)
        {
            CheckFacing();
            CheckState();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case STATE.IDLE:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(0, 0, 64, 64), effect, 2, 0.5f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);
                    break;

                case STATE.ATTACKING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(160, 64, 96, 64), effect, 2, 0.2f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);
                    break;

                case STATE.DYING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(192, 0, 64, 64), effect, 3, 1f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);
                    break;
            }
        }
    }

    class Boss
    {
        int health = 80;

        Vector2 position;

        Texture2D texture = Singleton.Instance.BOSSSPRITE;

        public Boss(Vector2 postion)
        {
            this.position = postion;
        }

        public void AttackPattern(GameTime gameTime)
        {
            /*switch (health)
            {
                case health > 
            }*/
        }

        public void PlatformAttack()
        {

        }

        public void FloorAttack()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
