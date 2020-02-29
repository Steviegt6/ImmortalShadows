using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Projectiles
{
    public class ShadowBladeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DD2SquireSonicBoom);
            aiType = ProjectileID.DD2SquireSonicBoom;
            projectile.penetrate = 49;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 600);
            target.AddBuff(BuffType<Buffs.Debuffs.DarkFlame>(), 600);
        }
    }
}