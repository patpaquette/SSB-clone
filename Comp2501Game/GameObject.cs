using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;

namespace Comp2501Game
{
    public class GameObject : GameComponent
    {
        protected Dictionary<ComponentType, ObjectComponent> _components;

        public GameObject(Game game)
            : base(game)
        {
            this._components = new Dictionary<ComponentType, ObjectComponent>();
        }

        public void AddComponent(ObjectComponent component)
        {
            this._components.Add(component.GetType(), component);
        }

        public ObjectComponent GetComponent(ComponentType type)
        {
            if (this._components.ContainsKey(type))
            {
                return this._components[type];
            }
            else
            {
                return null;
            }
        }

        public Dictionary<ComponentType, ObjectComponent> GetObjectComponents()
        {
            return this._components;
        }

        public bool HasComponent(ComponentType type)
        {
            if (this._components.ContainsKey(type))
            {
                return true;
            }
            return false;
        }
    }
}
