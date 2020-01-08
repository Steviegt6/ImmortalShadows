using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Projectiles
{
    public class ShadowBladeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DD2SquireSonicBoom);
            aiType = ProjectileID.DD2SquireSonicBoom;
            projectile.penetrate = 99;
        }
    }
}