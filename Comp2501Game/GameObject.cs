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
        protected GameObject _parent;
        public List<GameObject> Children;

        public GameObject(Game game)
            : this(game, null)
        {
        }

        public GameObject(Game game, GameObject parent)
            : base(game)
        {
            this._components = new Dictionary<ComponentType, ObjectComponent>();
            this.Children = new List<GameObject>();
            this.SetParent(parent);
        }

        public void SetParent(GameObject parent)
        {
            this._parent = parent;

            if (parent != null)
            {
                parent.Children.Add(this);
            }
        }

        public GameObject GetParent()
        {
            return this._parent;
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

        public static bool AreRelated(GameObject obj1, GameObject obj2)
        {
            if (obj1._parent == obj2 ||
                obj2._parent == obj1 ||
                obj1 == obj2)
            {
                return true;
            }

            return false;
        }
    }
}
