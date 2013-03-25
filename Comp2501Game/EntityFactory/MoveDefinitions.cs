using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.EntityFactory
{
    class MoveDefinitions
    {
        public static Dictionary<ActionDefinition, ActionInfo> GetYoshiMoves()
        {
            return new Dictionary<ActionDefinition, ActionInfo>()
                    {
                        {
                            new ActionDefinition(DirectionalAction.Left, PrimaryAction.A, SecondaryAction.Stand),
                            new ActionInfoProjectile(
                                new Vector2(-1000.0f, -1000.0f),
                                100,
                                new Vector2(0.0f, -5.0f),
                                20,
                                new Rectangle(-25, 80, 50, 50)
                            )
                        },
                         {
                            new ActionDefinition(DirectionalAction.Right, PrimaryAction.A, SecondaryAction.Stand),
                            new ActionInfoProjectile(
                                new Vector2(1000.0f, -1000.0f),
                                100,
                                new Vector2(0.0f, -5.0f),
                                20,
                                new Rectangle(-25, 80, 50, 50)
                            )
                        },
                        {
                            new ActionDefinition(DirectionalAction.Right, PrimaryAction.Forward_A, SecondaryAction.Smash),
                            new ActionInfoProjectile(
                                new Vector2(1000.0f, 0.0f),
                                70,
                                new Vector2(20.0f, -20.0f),
                                50,
                                new Rectangle(-50, -50, 100, 100)
                            )
                        },
                        {
                            new ActionDefinition(DirectionalAction.Left, PrimaryAction.Forward_A, SecondaryAction.Smash),
                            new ActionInfoProjectile(
                                new Vector2(-1000.0f, 0.0f),
                                70,
                                new Vector2(-20.0f, -20.0f),
                                50,
                                new Rectangle(-50, -50, 100, 100)
                            )
                        }
                    };
        }

        public static Dictionary<ActionDefinition, ActionInfo> GetKirbyMoves()
        {
            return new Dictionary<ActionDefinition, ActionInfo>();
        }
    }
}
