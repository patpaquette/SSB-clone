using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components.Physics
{
    class MotionPropertiesComponent : ObjectComponent
    {
        public Vector2 LastAccelerationVector;
        public Vector2 AccelerationVector;
        public Vector2 VelocityVector;
        public Vector2 AggregateForcesVector;
        public float Mass;
        public List<Impulse> Impulses;


        public MotionPropertiesComponent(GameObject parent, float mass)
            : base(parent)
        {
            this.Mass = mass;
            this.LastAccelerationVector = Vector2.Zero;
            this.AccelerationVector = Vector2.Zero;
            this.VelocityVector = Vector2.Zero;
            this.Impulses = new List<Impulse>();
        }

        public void AddForce(Vector2 force)
        {
            this.AggregateForcesVector += force;
        }

        public void ResetForces()
        {
            this.AggregateForcesVector = Vector2.Zero;
        }

        public void AddImpulse(Impulse impulse)
        {
            this.Impulses.Add(impulse);
        }

        public override ComponentType GetType()
        {
            return ComponentType.MotionProperties;
        }

    }
}
