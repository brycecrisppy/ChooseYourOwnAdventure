using System;
using System.Collections.Generic;
using SadConsole;
using Microsoft.Xna.Framework;
using MColor = Microsoft.Xna.Framework.Color;

namespace SadConsoleGame
{
    public class MapScreen: ContainerConsole
    {

        public SadConsole.Console MapConsole {get;}
        public Cell PlayerGlyph {get; set;}

        private Point _playerPosition;
        private Cell _playerPositionMapGlyph;

        public Point PlayerPosition
        {
            get => _playerPosition;
            private set
            {
                if (value.X < 0 || value.X >= MapConsole.Width || 
                    value.Y < 0 || value.Y >= MapConsole.Height)
                    {
                        return;
                    }

                _playerPositionMapGlyph.CopyAppearanceTo(MapConsole[_playerPosition.X, _playerPosition.Y]);

                _playerPosition = value;

                _playerPositionMapGlyph.CopyAppearanceFrom(MapConsole[_playerPosition.X, _playerPosition.Y]);

                PlayerGlyph.CopyAppearanceTo(MapConsole[_playerPosition.X, _playerPosition.Y]);

                MapConsole.IsDirty = true;
            }
        }

        public MapScreen()
        {
            int MapConsoleWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0);
            int MapConsoleHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0);
            
            MapConsole = new SadConsole.Console(MapConsoleWidth, MapConsoleHeight);

            MapConsole.DrawBox(new Microsoft.Xna.Framework.Rectangle(0, 0, MapConsole.Width, MapConsole.Height), new Cell(MColor.White, MColor.DarkGray, 0));
            MapConsole.Parent = this;

            PlayerGlyph = new Cell(MColor.White, MColor.Black, 1);
            _playerPosition = new Point(4, 4);
            _playerPositionMapGlyph = new Cell();
            _playerPositionMapGlyph.CopyAppearanceFrom(MapConsole[_playerPosition.X, _playerPosition.Y]);
            PlayerGlyph.CopyAppearanceTo(MapConsole[_playerPosition.X, _playerPosition.Y]);
        }

        public override bool ProcessKeyboard(SadConsole.Input.Keyboard info)
        {
            Point newPlayerPosition = PlayerPosition;
            while (info.KeysPressed.Count != 0) 
            {
                if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
                {
                    newPlayerPosition += Directions.North;
                }
                else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
                {
                    newPlayerPosition += Directions.South;
                }

                if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
                {
                    newPlayerPosition += Directions.West;
                }
                else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
                {
                    newPlayerPosition += Directions.East;
                }

                if (newPlayerPosition != PlayerPosition)
                {
                    PlayerPosition = newPlayerPosition;
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}