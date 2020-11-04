using Stride.Engine;

namespace Enigma_Engine
{
    class Enigma_EngineApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
