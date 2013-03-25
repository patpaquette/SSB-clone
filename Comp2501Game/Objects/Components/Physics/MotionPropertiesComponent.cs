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
        private Vector2 _velocityVector;
        public Vector2 TemporaryVelocityVector;
        public Vector2 AggregateForcesVector;
        public float Mass;
        public List<Impulse> Impulses;
        public float MaxGroundSpeed;
        public float MaxAirSpeed;
        public MotionState State;


        public MotionPropertiesComponent(GameObject parent, float mass)
            : this(parent, mass, 1000.0f, 10000.0f)
        {
        }

        public MotionPropertiesComponent(GameObject parent, float mass, float maxGroundVelocity, float maxAirVelocity)
            : base(parent)
        {
            this.State = MotionState.Unknown;
            this.MaxGroundSpeed = maxGroundVelocity;
            this.MaxAirSpeed = maxAirVelocity;
            this.Mass = mass;
            this.LastAccelerationVector = Vector2.Zero;
            this.AccelerationVector = Vector2.Zero;
            this._velocityVector = Vector2.Zero;
            this.Impulses = new List<Impulse>();
        }

        public Vector2 GetVelocity()
        {
            return this._velocityVector;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocityVector = Vector2.Zero;
            this.AddVelocity(velocity);
        }

        public void AddVelocity(Vector2 velocity)
        {
            this._velocityVector += velocity;
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
