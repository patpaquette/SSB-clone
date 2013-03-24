using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class Transform2DComponent : ObjectComponent
    {
        private Matrix _transform;
        private float _rotation;
        private Vector2 _translation;
        private Vector2 _scale;

        public Transform2DComponent(GameObject parent, Vector2 translation, float rotationDeg, Vector2 scale)
            : base(parent)
        {
            this._translation = translation;
            this._rotation = rotationDeg * (float)Math.PI / 180;
            this._translation = translation;
            this._scale = scale;

            this.calculateTransform();
        }

        /*public Transform2DComponent()
        {
            // TODO: Complete member initialization
        }*/

        public Matrix GetTransform()
        {
            return this._transform;
        }

        public Matrix GetCompoundTransform()
        {
            if (this.ParentEntity.GetParent() != null)
            {
                Transform2DComponent parentTransformComponent =
                    (Transform2DComponent)this.ParentEntity.GetParent().GetComponent(ComponentType.Transform2D);

                return Matrix.Multiply(parentTransformComponent.GetTransform(), this._transform);
            }

            return this._transform;
        }

        public void SetTransform(Matrix transform)
        {
            this._transform = transform;
        }

        public Vector2 GetTranslation()
        {
            Vector3 translation = this.GetTransform().Translation;
            return new Vector2(translation.X, translation.Y);
        }

        public void SetTranslation(Vector2 translation)
        {
            this._translation = translation;
            this.calculateTransform();
        }

        public void AddTranslation(Vector2 translation)
        {
            this._translation += translation;
            this.SetTransform(Matrix.Multiply(
                this._transform, Matrix.CreateTranslation(translation.X, translation.Y, 0.0f))
            );

        }

        public float GetRotationDeg()
        {
            return this._rotation * 180 / (float)Math.PI;
        }

        public void SetRotationDeg(float deg)
        {
            this._rotation = deg * (float)Math.PI / 180;
            this.calculateTransform();
        }

        public void SetScale(Vector2 scale)
        {
            this._scale = scale;
            this.calculateTransform();
        }

        public Vector2 GetScale()
        {
            return this._scale;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Transform2D;
        }

        private void calculateTransform()
        {
            this._transform = Matrix.CreateScale(this._scale.X, this._scale.Y, 1.0f);
            this._transform = Matrix.Multiply(this._transform, Matrix.CreateRotationZ(this._rotation));
            this._transform = Matrix.Multiply(
                this._transform,
                Matrix.CreateTranslation(this._translation.X, this._translation.Y, 0.0f));
        }
    }
}
