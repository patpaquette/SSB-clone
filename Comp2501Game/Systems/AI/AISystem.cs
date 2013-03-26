using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Objects.Components.AI.Pathfinding;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.AI;

namespace Comp2501Game.Systems.AI
{
    class AISystem : GameSystem
    {
        private AStarPathfindingSystem _pathfinding;

        public AISystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.AIController);
            this._componentDependencies.Add(ComponentType.Behaviour);
            this._componentDependencies.Add(ComponentType.AStar);
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.Action);
        }

        public override void Initialize()
        {
            this._pathfinding = (AStarPathfindingSystem)this._game.GetService("Pathfinding");
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                AStarComponent aStarComponent =
                    (AStarComponent)obj.GetComponent(ComponentType.AStar);
                Transform2DComponent transformComponent =
                    (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                CurrentActionComponent curActionComponent =
                    (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                BehaviourComponent behaviourComponent =
                    (BehaviourComponent)obj.GetComponent(ComponentType.Behaviour);


                behaviourComponent.Root.Update(gameTime);
                
                
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
