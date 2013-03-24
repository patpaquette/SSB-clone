using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Systems.Collisions;
using Comp2501Game.EntityFactory;
using Microsoft.Xna.Framework;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Systems.StateMod
{
    class ActionSystem : GameSystem
    {
        public ActionSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Action);
        }

        public override void Initialize()
        {
            CollisionSystem.ActionCollision += new CollisionHandler(this.actionHitHandler);
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            List<GameObject> objsToAdd = new List<GameObject>();

            foreach (GameObject obj in this._objects)
            {
                CurrentActionComponent curActionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);

                if (!curActionComponent.curAction.GetDefinition().Equals(curActionComponent.LastActionDef))
                {
                    curActionComponent.InProgress = false;
                }

                if (curActionComponent.InProgress == false)
                {   
                    curActionComponent.InProgress = true;
                    curActionComponent.LastActionDef = curActionComponent.curAction.GetDefinition();

                    if (curActionComponent.GetActionInfo().GetType() == ActionType.AttackProjectile)
                    {
                        ActionInfoProjectile actInfo = (ActionInfoProjectile)curActionComponent.GetActionInfo();

                        objsToAdd.Add(
                            DynamicEntityFactory.BuildActionProjectile(
                                this._game,
                                obj,
                                actInfo,
                                Vector2.Zero,
                                actInfo.Velocity,
                                actInfo.Lifetime,
                                new List<Shape>{
                                    Shape.BuildRectangle(actInfo.BoundingBoxRect)
                                }
                            )
                        );
                    }
                }
            }

            foreach (GameObject obj in objsToAdd)
            {
                this._game.AddObject(obj);
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private void actionHitHandler(CollisionInfo colInfo, float timestep)
        {
            GameObject obj1 = colInfo.Entity1;
            GameObject obj2 = colInfo.Entity2;
        }
    }
}
