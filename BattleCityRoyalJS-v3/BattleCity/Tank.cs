﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v3.Desktop
{
    public enum TankType
    {
        Tank1 = 0,
        Tank2,
        Tank3,
        Tank4,
        Tank5,
        Tank6,
        Tank7,
        Tank8
    }

    public class Tank
    {
        private Vector2 position;
        private Vector2 offset;
        private Vector2 orientation;
        private float rotation;
        private Color color;
        private float velocity;
        private TankController controller;
        private TankCanon tankCanon;
        private AABB aabb;
        private Animation animationIdle;
        private Animation animationDrive;

        public AABB Aabb { get => aabb; }

        public Tank(TankController controller, ProjectilePool projectilePool, TankType tankType, Vector2 spawnPosition, Color color)
        {
            position = spawnPosition;
            orientation = Orientation.East;
            this.color = color;
            rotation = 0;
            velocity = 80;
            this.controller = controller;
            offset = new Vector2(0, 0);

            switch (tankType)
            {
                case TankType.Tank1:
                    offset.X = 6.5f;
                    offset.Y = 6.5f;
                    break;
                case TankType.Tank2:
                    offset.X = 6.5f;
                    offset.Y = 8f;
                    break;
                case TankType.Tank3:
                    offset.X = 6.5f;
                    offset.Y = 7.5f;
                    break;
                case TankType.Tank4:
                    offset.X = 7f;
                    offset.Y = 7.5f;
                    break;
                case TankType.Tank5:
                    offset.X = 6.5f;
                    offset.Y = 7.5f;
                    break;
                case TankType.Tank6:
                    offset.X = 6.5f;
                    offset.Y = 7.5f;
                    break;
                case TankType.Tank7:
                    offset.X = 6.5f;
                    offset.Y = 7.5f;
                    break;
                case TankType.Tank8:
                    offset.X = 6.5f;
                    offset.Y = 7.5f;
                    break;
            }

            aabb = new AABB(new Rectangle((int)(position.X - offset.X * 2), (int)(position.Y - offset.Y * 2), (int)(offset.X * 2), (int)(offset.Y * 2)));

            tankCanon = new TankCanon(controller, projectilePool);

            Frame[] idleAnimationFrames = { new Frame(1, new Tile(15, (int)tankType)) };
            Frame[] driveAnimationFrames = { new Frame(4, new Tile(14, (int)tankType)), new Frame(4, new Tile(15, (int)tankType)) };

            this.animationIdle = new Animation(idleAnimationFrames, 0, true);
            this.animationDrive = new Animation(driveAnimationFrames, 0, true);

            this.animationDrive.Start();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite, SpriteFont font)
        {
            spriteBatch.Draw(sprite, position - offset, animationDrive.GetCurrentFrame().Tile.GetSourceRectangle(), color, rotation, offset, 1.0f, SpriteEffects.None, 0.0f);
        }

        public void Update(GameTime gameTime)
        {
            controller.Update(gameTime);
            animationIdle.Update(gameTime);
            animationDrive.Update(gameTime);

            if (controller.Direction == Orientation.East)
            {
                rotation = 0.0f;
                orientation = Orientation.East;
            }
            if (controller.Direction == Orientation.South)
            {
                rotation = (float)(Math.PI * 0.5);
                orientation = Orientation.South;
            }
            if (controller.Direction == Orientation.West)
            {
                rotation = (float)(Math.PI);
                orientation = Orientation.West;
            }
            if (controller.Direction == Orientation.North)
            {
                rotation = (float)(Math.PI * 1.5);
                orientation = Orientation.North;
            }
                
            Vector2 delta = controller.Direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += delta;
            aabb.Min += delta;
            aabb.Max += delta;

            tankCanon.Position = position - offset + orientation * offset.X;
            tankCanon.Direction = orientation;

            tankCanon.Update(gameTime);
        }
    }
}