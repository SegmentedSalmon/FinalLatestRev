using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Camera
    {
        public Matrix transform;
        Vector2 centre;

        public Camera()
        {

        }

        public void Update(Vector2 position)
        {
            centre = new Vector2(position.X - (1680 / 4), -(position.Y - (1050 / 4)));

            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-centre.X, centre.Y, 0));
        }
    }
}
