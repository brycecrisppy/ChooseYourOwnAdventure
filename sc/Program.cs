using System;
using SadConsole;
using Microsoft.Xna.Framework;

namespace SadConsoleGame
{
    public class Program
    {
        static void Init()
        {
            Global.CurrentScreen = new MapScreen();
            Global.CurrentScreen.IsFocused = true;
        }

        static void Main()
        {
            SadConsole.Game.Create(80, 25);

            SadConsole.Game.OnInitialize = Init;

            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }
    }
}