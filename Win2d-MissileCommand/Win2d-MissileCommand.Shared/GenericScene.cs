using System;
using System.Collections.Generic;
using System.Text;

namespace Toodee
{
    public class GenericScene : GenericItem
    {

        public GenericScene(string name)
            : base(name)
        {

        }
        public override void Update(TimeSpan dt)
        {
            foreach (GenericItem gi in objects)
            {
                gi.Update(dt);
            }
        }

        public override void Draw(Microsoft.Graphics.Canvas.CanvasDrawingSession cds)
        {
            foreach (GenericItem gi in objects)
            {
                gi.Draw(cds);
            }
        }

        // I added
        public override void DrawGeoLine(Microsoft.Graphics.Canvas.CanvasDrawingSession cds)
        {
            foreach (GenericItem gi in objects)
            {
                gi.DrawGeoLine(cds);
            }
        }

        public bool AddObject(GenericItem gi)
        {
            if (objects == null)
            {
                return false;
            }

            int size_before_add = objects.Count;
            objects.Add(gi);
            int size_after_add = objects.Count;

            if (size_after_add > size_before_add)
            {
                return true;
            }

            return false;
        }

        public bool RemoveObject(GenericItem gi)
        {
            return objects.Remove(gi);
        }

        public bool RemoveObject(int index)
        {
            int size_before_rem = objects.Count;
            objects.RemoveAt(index);
            int size_after_rem = objects.Count;

            if (size_after_rem < size_before_rem)
            {
                return true;
            }

            return false;
            
        }


        protected List<GenericItem> objects = new List<GenericItem>();

    }
}
