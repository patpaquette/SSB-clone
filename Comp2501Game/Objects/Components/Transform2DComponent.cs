using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class Transform2DComponent : ObjectComponent
    {
        private float _rotation;
        private Vector2 _translation;
        private Vector2 _scale;
        private TestObject testObject;
        private Vector2 position;

        public Transform2DComponent(GameObject parent, Vector2 translation, float rotationDeg, Vector2 scale)
            : base(parent)
        {
            this._translation = translation;
            this._rotation = rotationDeg * (float)Math.PI / 180;
            this._translation = translation;
            this._scale = scale;
        }

        public Vector2 GetTranslation()
        {
            return this._translation;
        }

        public void SetTranslation(Vector2 translation)
        {
            this._translation = translation;
        }

        public void AddTranslation(Vector2 translation)
        {
            this._translation += translation;
        }

        public float GetRotationDeg()
        {
            return this._rotation * 180 / (float)Math.PI;
        }

        public Vector2 GetScale()
        {
            return this._scale;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Transform2D;
        }
    }
}
