using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Toodee
{
    class GameTimer
    {

        public GameTimer(CanvasControl surface = null, int UPS = 60, int FPS = 30)
        {
            UpdateTimer = new DispatcherTimer();
            UpdateTimer.Interval = TimeSpan.FromMilliseconds(1000 / UPS); // 60 updates per 1000ms (1s)
            UpdateTimer.Tick += UpdateTimer_Tick;

            // set FPS
            TimeBetweenDraw = TimeSpan.FromMilliseconds(1000 / FPS); // default fps target, 30 updates per 1000ms (1s // 30FPS)

            LastUpdateTime = DateTime.Now;
            LastDrawTime = DateTime.Now;
            TotalAppTime = TimeSpan.FromMilliseconds(0);

            // set the CanvasControl
            ParentCanvas = surface;

            UpdateTimer.Start();
        }

        void UpdateTimer_Tick(object sender, object e)
        {
            if (!isUpdating)
            {
                isUpdating = true;

                // compute the delta time
                TimeSpan dt = DateTime.Now - LastUpdateTime;

                // update the last time the program has updated to now
                LastUpdateTime = DateTime.Now;

                // update the total app time
                TotalAppTime += dt;

                // update the current scene
                if (SceneManager.CurrentScene != null)
                {
                    SceneManager.CurrentScene.Update(dt);
                }

                // figure out if we need to draw/refresh the screen
                TimeSpan dt_draw = DateTime.Now - LastDrawTime;

                if (dt_draw > TimeBetweenDraw)
                {
                    // Call Refresh
                    if (ParentCanvas != null)
                    {
                        ParentCanvas.Invalidate();
                        LastDrawTime = DateTime.Now;
                    }
                }

                isUpdating = false;
            }
        }

        // Properties
        private DispatcherTimer UpdateTimer;

        public bool isUpdating = false;

        public TimeSpan TotalAppTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public DateTime LastDrawTime { get; set; }

        public TimeSpan TimeBetweenDraw { get; set; }

        public CanvasControl ParentCanvas { get; set; }


        // TODO

        // Keep track of time
        // Call update x number of times per second (UPS: updates per second)
        // we draw the current scene x number of times per second. (FPS: frames per second)


 
    }
}
