using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week2Movement
{
    public class Character
    {
        public Texture2D Texture;
        public Keys JumpButton = Keys.Up;
        public int JumpPower = 20;
        public float Gravity = 1.4f;
        public float Speed = 0f;
        public Vector2 Pos = new Vector2(0, 0);

        public Character() { }

        public Character(Keys k, int jp, float g, Vector2 v)
        {
            JumpButton = k;
            JumpPower = jp;
            Gravity = g;
            Pos = v;
        }

        public Character(Texture2D t, Keys k, int jp, float g, Vector2 v)
        {
            Texture = t;
            JumpButton = k;
            JumpPower = jp;
            Gravity = g;
            Pos = v;
        }

        public void UpdateTexture(Texture2D t)
        {
            Texture = t;
        }
        public void Jump()
        {
            Speed = JumpPower;
        }

        public void UpdatePos(float time)
        {
            if (Speed != 0 && Pos.Y != 0)
            {
                Speed -= Gravity * time;
                Vector2 NewPos = new Vector2(0, Pos.Y + Speed);
                if (NewPos.Y <= 0)
                    NewPos = new Vector2(0, 0);
            }
        }
    }
}
