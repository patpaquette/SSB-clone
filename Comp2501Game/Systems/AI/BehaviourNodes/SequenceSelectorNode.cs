using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.AI;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.AI.BehaviourNodes
{
    class SequenceSelectorNode : BehaviourTreeNode
    {
        public SequenceSelectorNode(
            Game1 game,
            GameObject parent)
            : base(game, parent, BehaviourNodeType.SequenceSelector)
        {
        }

        public override bool Update(GameTime gameTime)
        {
            foreach (BehaviourTreeNode node in this._children)
            {
                if (!node.Update(gameTime))
                {
                    return false;
                }
            }

            return true;
        }

        public override string GetName()
        {
            return "Sequence selector";
        }
    }
}
