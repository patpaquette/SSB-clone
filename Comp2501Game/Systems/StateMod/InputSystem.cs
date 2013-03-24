using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Objects.Components.Types;


namespace Comp2501Game.Systems
{
    class InputSystem : GameSystem
    {
        public int PlayerNumber;

        public InputSystem(Game1 game, int playerNumber)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Action);
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Sprite);
            this._componentDependencies.Add(ComponentType.Arrow);
            this.PlayerNumber = playerNumber;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            //if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
            //{
            //    Console.WriteLine("pressed");
            //}
            //Console.WriteLine(this.PlayerNumber + " ");
            foreach (GameObject obj in this._objects)
            {
                //Console.WriteLine("here2");
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);
                SoundComponent soundComponent = (SoundComponent)obj.GetComponent(ComponentType.Sound);
                ArrowComponent arrowComponent = (ArrowComponent)obj.GetComponent(ComponentType.Arrow);


                if (playerComponent.PlayerNumber == this.PlayerNumber)
                {

                    if (actionComponent.curAction.curDirection == DirectionalAction.Left
                        && actionComponent.curAction.secondaryAction == SecondaryAction.Stand
                        && actionComponent.curAction.primaryAction == PrimaryAction.None)
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up)
                        {
                            if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                                && arrowComponent.keyPressed == KeyType.B)
                            {
                                actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                                actionComponent.curAction.primaryAction = PrimaryAction.Up_B;
                            }
                            else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                                && arrowComponent.keyPressed == KeyType.A)
                            {
                                // Console.WriteLine("This is C#");
                                actionComponent.curAction.primaryAction = PrimaryAction.Up_A;
                                actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                                spriteComponent.curColumn = 0;
                            }
                            else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up && arrowComponent.keyTimer > 200)
                            {
                                actionComponent.curAction.secondaryAction = SecondaryAction.Jump;
                                actionComponent.curAction.primaryAction = PrimaryAction.None;
                            }
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.curDirection = DirectionalAction.Right;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.curDirection = DirectionalAction.Right;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left && arrowComponent.keyTimer > 200)
                        {
                            //Console.WriteLine("This is C#");
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else if (arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.A;
                        }
                        else if (arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.B;
                        }
                        else if (arrowComponent.keyPressed == KeyType.R)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Grab;
                        }
                        else if (arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                            soundComponent.actionSoundList[6].Play();
                        }
                    }
                    else if (actionComponent.curAction.primaryAction == PrimaryAction.Down_B)
                    {
                        if (arrowComponent.keyPressed == KeyType.A
                            || arrowComponent.keyPressed == KeyType.B
                            && spriteComponent.curColumn > 3 && spriteComponent.CharacterType == SpriteType.Kirby)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Jump;
                        }
                    }
                    else if (actionComponent.curAction.curDirection == DirectionalAction.Right
                        && actionComponent.curAction.secondaryAction == SecondaryAction.Stand
                        && actionComponent.curAction.primaryAction == PrimaryAction.None)
                    {

                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_B;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.curDirection = DirectionalAction.Left;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Smash;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.curDirection = DirectionalAction.Left;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Jump;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else if (arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.A;
                        }
                        else if (arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.B;
                        }
                        else if (arrowComponent.keyPressed == KeyType.R)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Grab;
                        }
                        else if (arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                            soundComponent.actionSoundList[6].Play();
                        }
                    }
                    else if (actionComponent.curAction.curDirection == DirectionalAction.Right
                        && actionComponent.curAction.secondaryAction == SecondaryAction.Walk
                        && actionComponent.curAction.primaryAction == PrimaryAction.None)
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            //Console.WriteLine("pressed");  
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                        }
                        else
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                        }
                    }
                    else if (actionComponent.curAction.curDirection == DirectionalAction.Left
                        && actionComponent.curAction.secondaryAction == SecondaryAction.Walk
                        && actionComponent.curAction.primaryAction == PrimaryAction.None)
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                        }
                        else
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                        && actionComponent.curAction.primaryAction == PrimaryAction.None)
                    {

                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Roll_Right;

                            if (actionComponent.curAction.curDirection == DirectionalAction.Left)
                            {
                                actionComponent.curAction.curDirection = DirectionalAction.Right;
                            }
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Roll_Left;

                            if (actionComponent.curAction.curDirection == DirectionalAction.Right)
                            {
                                actionComponent.curAction.curDirection = DirectionalAction.Left;
                            }
                        }
                        else if (state.IsKeyDown(Keys.A)
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Grab;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                        }
                        else if (state.IsKeyDown(Keys.Up)
                            && arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Jump;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else if (arrowComponent.keyPressed == KeyType.Z)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Shield;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                        else
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                    }
                    else if (actionComponent.curAction.curDirection == DirectionalAction.Left
                        && (actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.None
                        || actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_B;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_B;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Backward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up && arrowComponent.keyTimer > 200
                            && actionComponent.curAction.secondaryAction != SecondaryAction.Second_Falling)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Second_Jump;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Drift_Right;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Drift_Left;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Fall_Faster;
                        }
                        else
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                    }
                    else if (actionComponent.curAction.curDirection == DirectionalAction.Right
                        && (actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                       && (actionComponent.curAction.primaryAction == PrimaryAction.None
                        || actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Up_B;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down
                            && arrowComponent.keyPressed == KeyType.B)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Down_B;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left
                            && arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Backward_A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.keyPressed == KeyType.A)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.A;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Up && arrowComponent.keyTimer > 200
                            && actionComponent.curAction.secondaryAction != SecondaryAction.Second_Falling)
                        {
                            actionComponent.curAction.secondaryAction = SecondaryAction.Second_Jump;
                            spriteComponent.curColumn = 0;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Drift_Right;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Drift_Left;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Down && arrowComponent.keyTimer > 200)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Fall_Faster;
                        }
                        else
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.None;
                        }
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Grab)
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Left;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Throw;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right)
                        {
                            actionComponent.curAction.primaryAction = PrimaryAction.Right;
                            actionComponent.curAction.secondaryAction = SecondaryAction.Throw;
                        }
                    }



                    if ((actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Jump
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                        && actionComponent.curAction.primaryAction != PrimaryAction.Down_B
                        && actionComponent.curAction.primaryAction != PrimaryAction.Up_B
                        && actionComponent.curAction.primaryAction != PrimaryAction.B)
                    {
                        if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Right)
                        {
                            actionComponent.curAction.drift = Drift.Right;
                        }
                        else if (arrowComponent.arrowKey == Objects.Components.Types.ArrowType.Left)
                        {
                            actionComponent.curAction.drift = Drift.Left;
                        }
                    }
                    else
                    {
                        actionComponent.curAction.drift = Drift.None;
                    }

                }

            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
