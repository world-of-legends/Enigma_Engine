using Stride.Graphics;
using System;
using System.Collections.Generic;

namespace Enigma
{
    public static class Level
    {
        public static List<BaseEntity> entities = new List<BaseEntity>();
        public static GraphicsDevice Graphics { set; get; }
        public static CommandList ListCommand { set; get; }

        public static void LoadFrom(string path)
        {
            //pass
        }

        public static void Start(object window, IntPtr handle)
        {
            //WindowHandle windowHandle = new WindowHandle(Stride.Games.AppContextType.Desktop, window, handle);
            Graphics = GraphicsDevice.New(DeviceCreationFlags.None, GraphicsProfile.Level_10_0);
        }
    }
}
