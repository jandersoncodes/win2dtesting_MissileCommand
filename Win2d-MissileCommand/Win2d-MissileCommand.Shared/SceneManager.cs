using System;
using System.Collections.Generic;
using System.Text;

namespace Toodee
{
    public static class SceneManager
    {

        // The scene 'storyboards' 
        public static Dictionary<string, GenericScene> SceneDictionary = new Dictionary<string, GenericScene>();

        public static bool AddScene(GenericScene gs)
        {
            
            int size_before_add = SceneDictionary.Count;
            SceneDictionary.Add(gs.Name, gs);
            int size_after_add = SceneDictionary.Count;

            if (size_after_add > size_before_add)
            {
                return true;
            }

            return false;
        }

        public static GenericScene CurrentScene { get; set; }


        //TODO:

        // Remove Scene.
    }
}
