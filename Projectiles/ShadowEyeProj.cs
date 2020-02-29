using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImmortalShadows.Projectiles
{
    public class ShadowEyeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = false;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            aiType = ProjectileID.EyeLaser;
            projectile.aiStyle = 1;
            projectile.hostile = true;
            projectile.light = 0.75f;
            projectile.alpha = 255;
            projectile.extraUpdates = 2;
            projectile.scale = 1.7f;
            projectile.timeLeft = 600;
        }
    }
}