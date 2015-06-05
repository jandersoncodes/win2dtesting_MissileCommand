using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas;

using Toodee; // our IMagePipline library

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win2d_MissileCommand
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // keeps track of if all images are loaded.
        public bool isAllImagesLoaded = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// CreateResources is where we load in assets. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void myDrawingSurface_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            // Load in assets
            ContentPipeline_Image.ParentCanvas = sender;

            await ContentPipeline_Image.AddImage("cannon", @"Assets/tm_cannon.png");
            await ContentPipeline_Image.AddImage("clone", @"Assets/tm_clone.png");


            

            // setup the scene (this really should be done in another function)
            GenericScene gs = new GenericScene("test");

            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                GenericItem gi = new GenericItem("test");
                gi.Location = new System.Numerics.Vector2(r.Next(0,1000), r.Next(0,800));
                gi.SetBitmapFromImageDictionary("cannon");
                
                gs.AddObject(gi);
            }

            SceneManager.AddScene(gs);
            SceneManager.CurrentScene = gs;

            isAllImagesLoaded = true;

            sender.Invalidate();
        }

        /// <summary>
        /// Our Draw Function.
        /// </summary>
        /// <param name="sender">A Canvas Control.</param>
        /// <param name="args">Drawing Arguments.</param>
        private void myDrawingSurface_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            CanvasDrawingSession cds = args.DrawingSession;
            

            if (isAllImagesLoaded)
            {
                if (SceneManager.CurrentScene != null)
                {
                    SceneManager.CurrentScene.Draw(cds);
                }
                

            }

        }
    }
}



// Replaced by ContentPipline_Image Library
//CanvasBitmap cannon;
//CanvasBitmap clone;


// no londer needed with ContentPipline_Image library
//cannon = await CanvasBitmap.LoadAsync(sender, @"Assets/tm_cannon.png");
//clone = await CanvasBitmap.LoadAsync(sender, @"Assets/tm_clone.png");

            //// Draw a line from (0,0) to (200,200) in white
            //cds.DrawLine(0, 0, 200, 200, Windows.UI.Colors.White);

            //// Draw a circle300, 300) with radius of 50 in yellow.
            //cds.DrawCircle(300, 300, 50, Windows.UI.Colors.Yellow);

            //// Draw a fill circle at (500,500) with radius of 50 in green.
            //cds.FillCircle(500, 500, 50, Windows.UI.Colors.Green);

            //// Draw rectangle at (200, 100) 100x100 in blue
            //cds.DrawRectangle(200, 100, 100, 100, Windows.UI.Colors.Blue);

            //// Draw filled rectangle at (400,400) 40x40 in red  
            //cds.FillRectangle(400, 400, 40, 40, Windows.UI.Colors.Red);
            
            //// Draw hellow world on the screen. 
            //cds.DrawText("Hellow World", 400, 800, Windows.UI.Colors.White);

//cds.DrawImage(cannon, 150, 400);
//cds.DrawImage(clone, 500, 500);

                // define a canvas bitmap to store files into. 
                //CanvasBitmap cb = null;
                //if (ContentPipeline_Image.ImageDictionary.TryGetValue("cannon", out cb))
                //{
                //    cds.DrawImage(cb, 150, 400);
                //}

                //if (ContentPipeline_Image.ImageDictionary.TryGetValue("clone", out cb))
                //{
                //    cds.DrawImage(cb, 500, 500);
                //}