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
        protected string _name;

        public GameSystem(Game1 game)
            : this(game, "")
        {
        }

        public GameSystem(Game1 game, string name)
            : base(game)
        {
            this._game = game;
            //this._game.RegisterSystem(this);
            this._componentDependencies = new List<ComponentType>();
            this._objects = new List<GameObject>();
            this._name = name;
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

        public string GetName()
        {
            return this._name;
        }

        public abstract SystemType GetType();
    }
}
