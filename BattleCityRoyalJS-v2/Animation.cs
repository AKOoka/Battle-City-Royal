using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v2.Desktop
{
    public class Animation
    {
        private Frame[] frames;
        private float startTime;
        private int currentFrameIndex;
        private bool isStarted;
        private bool isRun;
        private bool isLoop;
        private const float fps = 24;

        public Animation(Frame[] frames, int startFrame, bool isLoop)
        {
            this.frames = frames;
            this.startTime = 0.0f;
            this.currentFrameIndex = startFrame;
            this.isLoop = isLoop;
        }

        public void Start()
        {
            isStarted = true;
            isRun = true;
        }

        public void Stop()
        {
            isStarted = false;
            isRun = false;
            currentFrameIndex = 0;
        }

        public Frame GetCurrentFrame()
        {
            return frames[currentFrameIndex];
        }

        public void Update(GameTime gameTime)
        {
            if (isStarted)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
                isStarted = false;
            }

            if (isRun)
            {
                float frameDurationInSeconds = (float)frames[currentFrameIndex].Duration / fps;
                float time = startTime + frameDurationInSeconds;

                if (time <= gameTime.TotalGameTime.TotalSeconds)
                {
                    if (currentFrameIndex == frames.Length - 1 && !isLoop)
                    {
                        Stop();
                    }
                    else
                    {
                        startTime = (float)gameTime.TotalGameTime.TotalSeconds;
                        currentFrameIndex = (currentFrameIndex + 1) % frames.Length;
                    }
                }
            }
        }
    }

    public class Frame
    {
        private int duration;
        private Tile tile;

        public Frame(int duration, Tile tile)
        {
            this.duration = duration;
            this.tile = tile;
        }

        public int Duration { get => duration; }
        public Tile Tile { get => tile; }
    }
}