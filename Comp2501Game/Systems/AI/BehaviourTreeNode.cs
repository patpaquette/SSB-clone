using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.AI;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems.AI
{
    abstract class BehaviourTreeNode
    {
        protected BehaviourNodeType _type;
        protected BehaviourNodeState _state;
        protected List<BehaviourTreeNode> _children;
        protected BehaviourComponent _behaviourComponent;
        protected GameObject _parent;
        protected Game1 _game;

        public BehaviourTreeNode(
            Game1 game,
            GameObject parent, 
            BehaviourNodeType type)
        {
            this._type = type;
            this._state = BehaviourNodeState.Ready;
            this._children = new List<BehaviourTreeNode>();
            this._behaviourComponent = (BehaviourComponent)parent.GetComponent(ComponentType.Behaviour);
            this._parent = parent;
            this._game = game;
        }

        public abstract bool Update(GameTime gameTime);

        public void AddChild(BehaviourTreeNode node)
        {
            this._children.Add(node);
        }

        public BehaviourNodeState GetState()
        {
            return this._state;
        }

        public void SetState(BehaviourNodeState state)
        {
            this._state = state;
        }

        public BehaviourNodeType GetType()
        {
            return this._type;
        }

        public List<BehaviourTreeNode> GetChildren()
        {
            return this._children;
        }

        public abstract string GetName();
    }
}
