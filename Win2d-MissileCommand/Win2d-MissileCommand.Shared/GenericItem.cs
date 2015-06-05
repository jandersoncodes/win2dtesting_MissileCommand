using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Graphics;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Numerics;
using Windows.Foundation;


namespace Toodee
{
    public class GenericItem
    {

        public GenericItem(string name = "")
        {
            this.Name = name;
            this.DrawBoundingRectangle = false;
        }
        
        /// <summary>
        /// Update the GenericItem.
        /// </summary>
        /// <param name="dt">A delta time since the last update was called.</param>
        public virtual void Update(TimeSpan dt)
        {
            //this.Location = new Vector2(this.Location.X, this.Location.Y + 1);
            // Update each objects location on the screen. 
            
        }

        /// <summary>
        /// Draw the GenericItem.
        /// </summary>
        /// <param name="cds">A surface to draw on.</param>
        public virtual void Draw(CanvasDrawingSession cds)
        {
            if (Bitmap == null)
            {
                return;
            }

            cds.DrawImage(Bitmap, Location);
            
            // only draw bounding rectangle if true
            if (DrawBoundingRectangle)
            {
                cds.DrawRectangle(BoundingRectangle, Windows.UI.Colors.Purple);
            }
            
        }

        //i added.
        public virtual void DrawGeoLine(CanvasDrawingSession cds) 
        {
            if (LineEndpoint == null)
            {
                return;
            }
            if (Bitmap != null)
            {
                return;
            }

            cds.DrawLine(Location, LineEndpoint, Windows.UI.Colors.Green);

        }
        
        /// <summary>
        /// Assign a bitmap from our ContentPipline ImageDictionary to the GenericItem CanvasBitmap
        /// </summary>
        /// <param name="key">a named reference to an item in an ImageDictionary</param>
        /// <returns>Returns True when Image is found in Dictionary, False if not.</returns>
        public bool SetBitmapFromImageDictionary(string key)
        {
            CanvasBitmap cb = null;
            if (ContentPipeline_Image.ImageDictionary.TryGetValue(key, out cb)){
                this.Bitmap = cb;
                this.Size = this.Bitmap.SizeInPixels;
                return true;
            }

            return false;
        }

        // properties
        public string Name { get; set; }
        public Vector2 Location { get; set; }
        public CanvasBitmap Bitmap {get; set;}
        public BitmapSize Size { get; set; }
        public Rect BoundingRectangle
        {
            get { return new Rect(Location.X, Location.Y, Size.Width -1, Size.Height -1); }
        }

        public Vector2 LineEndpoint { get; set; } // i added

        public bool DrawBoundingRectangle { get; set; }


        // update method
        // draw method
    }
}
