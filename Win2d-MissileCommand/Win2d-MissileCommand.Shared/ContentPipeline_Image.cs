using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Threading.Tasks;

namespace Toodee
{
    public static class ContentPipeline_Image
    {
        

        /// <summary>
        /// Adds an image to an ImageDictionary of loaded assets.
        /// </summary>
        /// <param name="key">a named identifier for the asset</param>
        /// <param name="file_path">a path to the loaded asset</param>
        /// <returns></returns>
        static public async Task<bool> AddImage(string key, string file_path){

            if (ParentCanvas == null)
            {
                return false;
            }

            // load the bitmap from the file
            CanvasBitmap cb = await CanvasBitmap.LoadAsync(ParentCanvas, file_path);

            if (cb == null)
            {
                return false;
            }

            // check size 
            int size_before_add = ImageDictionary.Count;

            // add
            ImageDictionary.Add(key, cb);

            // check size again
            int size_after_add = ImageDictionary.Count;

            // check
            if (size_after_add > size_before_add)
            {
                return true;
            }

            // if nothing added, return false. 
            return false;

        }

        static public Dictionary<string, CanvasBitmap> ImageDictionary = new Dictionary<string, CanvasBitmap>();
        static public CanvasControl ParentCanvas = null;
    }
}
