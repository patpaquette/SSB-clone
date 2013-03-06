using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class MeshComponent : ObjectComponent
    {
        public List<Vector2> Vertices;

        public MeshComponent(GameObject parent, List<Vector2> vertices)
            : base(parent)
        {
            this.Vertices = vertices;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Mesh;
        }
    }
}
