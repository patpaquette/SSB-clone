using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems
{
    class HealthSystem : GameSystem
    {
        private Vector2 _position;
        private float _currentDamage;
        private int _shownDamage;

        public HealthSystem(Game1 game)
            :base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.Health); 
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public void addDamage(float damageAdded)
        {
            this._currentDamage += damageAdded;
            this._shownDamage = (int)_currentDamage;
        }

        public void heal(int tbRemoved)
        {
            this._currentDamage += tbRemoved;
            this._shownDamage = (int)_currentDamage;
        }

        public void resetDamage()
        {
            this._currentDamage = 0.0f;
            this._shownDamage = 0;
        }


    }
}
