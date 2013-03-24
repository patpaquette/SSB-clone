using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems;

namespace Comp2501Game
{
    public abstract class GameSystem : GameComponent
    {
        protected Game1 _game;
        protected List<ComponentType> _componentDependencies;
        protected List<GameObject> _objects;

        public GameSystem(Game1 game)
            : base(game)
        {
            this._game = game;
            //this._game.RegisterSystem(this);
            this._componentDependencies = new List<ComponentType>();
            this._objects = new List<GameObject>();
        }

        public bool TryRegisterObject(GameObject obj)
        {
            foreach (ComponentType type in this._componentDependencies)
            {
                if (!obj.HasComponent(type))
                {
                    return false;
                }
            }
            this._objects.Add(obj);
            return true;
        }

        public void UnregisterObject(GameObject objToRemove)
        {
            this._objects.Remove(objToRemove);
        }

        public abstract SystemType GetType();
    }
}
