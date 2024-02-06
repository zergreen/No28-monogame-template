using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace No28.GameObject
{
    class Player
    {
        public bool isFacingForward = true;
        public bool isWalking = false;
        public bool isSword = false;
        public bool isGun = false;
        public bool isGrounded = false;

        private float movespeed = 1000f;
        private float dashforce = 500f;
        private float weaponswapCD = 0.5f;
        private float weaponswapTimer = 0f;
        //private float verticalVelocity = 0f;
        //private float gravity = 100f;

        // Health
        private int maxHP = 5;
        private int currentHP;

        // Jump
        public bool canJump = true;
        public bool isJumping = false;
        private float jumpforce = 500f;
        private float jumpCD = 0.3f;
        private float jumpTimer = 0f;

        // Dash
        public bool canDash = true;
        public bool isDashing = false;
        private float dashCD = 0.5f;
        private float dashTimer = 0f;

        // Shooting Light
        public bool canShootLight = true;
        public bool isShootingLight = false;
        private float shootLightCD = 0.3f;
        private float shootLightTimer = 0f;

        // Shooting Heavy
        public bool canShootHeavy = true;
        public bool isShootingHeavy = false;
        private float shootHeavyCD = 0.3f;
        private float shootHeavyTimer = 0f;

        private PLAYERSTATE playerState;

        private WEAPON weapon = WEAPON.NONE;

        private static SpriteEffects flip = SpriteEffects.None;

        private Texture2D texture = Singleton.Instance.PLAYERSPRITE;

        private Vector2 position;

        private Rectangle rectangle = new Rectangle(0, 64, 32, 64);

        public enum PLAYERSTATE
        {
            IDLE,
            WALKING,
            JUMPING,
            DASHING,
            SLASHING,
            SHOOTING_LIGHT,
            SHOOTING_HEAVY,
            DYING
        }

        public enum WEAPON
        {
            NONE,
            SWORD,
            LIGHTGUN,
        }

        public Player(Vector2 position) 
        {
            this.position = position;
            currentHP = maxHP;
        }

        public Vector2 GetPosition() { return position; }

        public int GetMaxHP() { return maxHP; }

        public float GetCurrentHP() { return currentHP; }

        public void SetNewPosition(Vector2 position)
        {
            this.position = position;
        }

        public void ApplyGravity(Vector2 direction, float force, GameTime gameTime)
        {
            if(!isGrounded)
            {
                position += direction * force * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public SpriteEffects CheckFlip() 
        { 
            if (isFacingForward) flip = SpriteEffects.None;
                else flip = SpriteEffects.FlipHorizontally;
            return flip;
        }

        public void CheckPlayerState()
        {
            if (isShootingLight) playerState = PLAYERSTATE.SHOOTING_LIGHT;
            else if (isShootingHeavy) playerState = PLAYERSTATE.SHOOTING_HEAVY;
            else if (isWalking) playerState = PLAYERSTATE.WALKING;
            else if (isJumping) playerState = PLAYERSTATE.JUMPING;
            else playerState = PLAYERSTATE.IDLE;
        }

        public void CheckWeaponState()
        {
            if (isSword) weapon = WEAPON.SWORD;
            else if (isGun) weapon = WEAPON.LIGHTGUN;
            else weapon = WEAPON.NONE;
        }

        public void Update(GameTime gameTime)
        {
            Singleton.Instance.KEYSTATE = Keyboard.GetState();

            // Check weapon state
            CheckWeaponState();

            // Check player state
            CheckPlayerState();

            // Check player flip
            CheckFlip();

            // Player movements
            Vector2 direction = Vector2.Zero;

            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.Right))
            {
                isFacingForward = true;
                isWalking = true;
                direction.X = 1;
                position += direction * movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.Left))
            {
                isFacingForward = false;
                isWalking = true;
                direction.X = -1;
                position += direction * movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                isWalking = false;
            }

            // Player jump
            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.Space) && jumpTimer <= 0f)
            {
                isJumping = true;
                direction.Y = -1;
                position += direction * jumpforce;

                jumpTimer = jumpCD;
            }
            else { isJumping = false; }
            
            if (jumpTimer > 0f)
            {
                jumpTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Player dash
            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.LeftShift))
            {
                if (canDash && dashTimer <= 0f)
                {
                    if (isFacingForward)
                    {
                        direction.X = 1;
                        position += direction * dashforce;
                    }
                    else
                    {
                        direction.X = -1;
                        position += direction * dashforce;
                    }
                    isDashing = true;
                    dashTimer = dashCD;
                }
                else isDashing = false;
            }

            if (dashTimer > 0f)
            {
                dashTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Player swap weapons
            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.A) && weaponswapTimer <= 0f)
            {
                if (!isSword && !isGun)
                {
                    isSword = true;
                    weaponswapTimer = weaponswapCD;
                }
                else if (isSword)
                {
                    isSword = false;
                    isGun = true;
                    weaponswapTimer = weaponswapCD;
                }
                else
                {
                    isSword = true;
                    weaponswapTimer = weaponswapCD;
                }
            }

            if (weaponswapTimer > 0f)
            {
                weaponswapTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Player shooting light
            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.X) && weapon == WEAPON.LIGHTGUN)
            {
                if (canShootLight && shootLightTimer <= 0f)
                {
                    isShootingLight = true;
                    currentHP --; 
                    Singleton.Instance.PROJECTILE.SpawnBulletLight(position);
                    shootLightTimer = shootLightCD;
                }
            }

            if (shootLightTimer > 0f)
            {
                shootLightTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                isShootingLight = false;
            }

            // Player shooting heavy

            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.C))
            {
                if (canShootHeavy && shootHeavyTimer <= 0f)
                {
                    isShootingHeavy = true;
                    Singleton.Instance.PROJECTILE.SpawnBulletHeavy(position);
                    shootHeavyTimer = shootHeavyCD;
                }
            }

            if (shootHeavyTimer > 0f)
            {
                shootHeavyTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (shootHeavyTimer <= 0f)
                {
                    isShootingHeavy = false;
                }
            }

            // Player slash

            if (Singleton.Instance.KEYSTATE.IsKeyDown(Keys.X) && weapon == WEAPON.SWORD)
            {
                
            }

            // Player health
            currentHP = Math.Max(currentHP, 0);

        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            // Draw player
            switch (playerState)
            {
                case PLAYERSTATE.IDLE:

                    if (weapon == WEAPON.NONE)
                    {
                        spriteBatch.Draw(texture, position, rectangle, Color.White, 0f, Vector2.Zero, 1f, flip, 1f);
                    }
                    else if (weapon == WEAPON.SWORD)
                    {
                        spriteBatch.Draw(texture, position, new Rectangle(32, 64, 32, 64), Color.White, 0f, Vector2.Zero, 1f, flip, 1f);
                    }
                    else spriteBatch.Draw(texture, position, new Rectangle(96, 64, 32, 64), Color.White, 0f, Vector2.Zero, 1f, flip, 1f);

                    break;

                case PLAYERSTATE.WALKING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(0, 128, 32, 64), flip, 4, 0.1f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);

                    break;

                case PLAYERSTATE.JUMPING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(0, 192, 64, 64), flip, 1, 0.5f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);

                    break;

                case PLAYERSTATE.DASHING:
                    Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(192, 0, 32, 64), flip, 1, 1f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);

                    break;

                case PLAYERSTATE.SLASHING:
                    //Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(), flip, 2, 0.2f);

                    break;

                case PLAYERSTATE.SHOOTING_LIGHT:
                    if (isFacingForward) Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(320, 128, 64, 64), flip, 1, 0.5f);
                    else Singleton.Instance.ANIMATOR.Animation(texture, new Vector2(position.X - 32, position.Y), new Rectangle(320, 128, 64, 64), flip, 1, 0.5f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);

                    break;

                case PLAYERSTATE.SHOOTING_HEAVY:
                    if (isFacingForward) Singleton.Instance.ANIMATOR.Animation(texture, position, new Rectangle(128, 64, 64, 64), flip, 1, 0.5f);
                    else Singleton.Instance.ANIMATOR.Animation(texture, new Vector2(position.X - 32, position.Y), new Rectangle(128, 64, 64, 64), flip, 1, 0.5f);
                    Singleton.Instance.ANIMATOR.Draw(spriteBatch);

                    break;

            }
        }
    }
}
