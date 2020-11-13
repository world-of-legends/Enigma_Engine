using Stride.Engine;
using Stride.Graphics;
using System;
using System.Collections.Generic;

namespace Enigma
{
    /// <summary>
    /// Class representing Level on time of executing game
    /// </summary>
    public static class RuntimeLevel
    {
        public static List<BaseEntity> entities = new List<BaseEntity>();
        public static Renderer renderer;
        public static Game game;

        public static void LoadFrom(string path)
        {
            //pass
        }

        public static void Start()
        {
            game = new Game();
            game.Run();
            renderer = new Renderer(game.GraphicsDevice);
        }

        public static T GetEntity<T>(string name) where T : BaseEntity
        {
            foreach (BaseEntity e in entities)
            {
                if (e.name == name)
                    return (T)e;
            }
            return null;
        }

        public static List<T> GetEntities<T>(string name) where T : BaseEntity
        {
            List<T> ret = new List<T>();
            foreach (BaseEntity e in entities)
            {
                if (e.name == name)
                    ret.Add((T)e);
            }
            return ret;
        }
    }
}
