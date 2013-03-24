using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game
{
    public static class Config
    {
        public enum Actions
        {
            DEFAULT_PROJECTILE_VELOCITY_X = 1000,
            DEFAULT_PROJECTILE_VELOCITY_Y = 0,
            DEFAULT_PROJECTILE_LIFETIME = 30,
            DEFAULT_PROJECTILE_HIT_FORCE_X = 1000,
            DEFAULT_PROJECTILE_HIT_FORCE_Y = 0,
            DEFAULT_PROJECTILE_HIT_DAMAGE = 20,
            DEFAULT_PROJECTILE_BOUNDINGBOX_RECT_WIDTH = 50,
            DEFAULT_PROJECTILE_BOUNDINGBOX_RECT_HEIGHT = 50,
            DEFAULT_PROJECTILE_BOUNDINGBOX_RECT_X = -25,
            DEFAULT_PROJECTILE_BOUNDINGBOX_RECT_Y = -25
        }
    }
}
