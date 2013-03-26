using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Systems.AI;
using Comp2501Game.Systems.AI.BehaviourNodes;
using Comp2501Game.Objects.Components.AI;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.EntityFactory
{
    class BehaviourFactory
    {
        public static BehaviourTreeNode Easy(
            Game1 game, 
            GameObject entity1, 
            GameObject opponent)
        {
            PrioritySelectorNode root = new PrioritySelectorNode(
                game,
                entity1
            );

            SequenceSelectorNode attackSequence = new SequenceSelectorNode(
                game,
                entity1
            );

            CondEntityProximityNode conditionDistance30 = new CondEntityProximityNode(
                game,
                entity1,
                opponent,
                150.0f
            );

            ActionMoveToPlayerNode moveToOpponent = new ActionMoveToPlayerNode(
                game,
                entity1,
                opponent,
                (AStarPathfindingSystem)game.GetService("Pathfinding"),
                false
            );

            ActionAttackNode attackOpponent = new ActionAttackNode(
                game,
                entity1,
                new ActionDefinition(
                    DirectionalAction.Right,
                    PrimaryAction.A,
                    SecondaryAction.Walk
                )
            );

            //root.AddChild(moveToOpponent);
            root.AddChild(attackSequence);
            attackSequence.AddChild(conditionDistance30);
            attackSequence.AddChild(attackOpponent);
            //root.AddChild(moveToOpponent);

            return root;
        }
    }
}
