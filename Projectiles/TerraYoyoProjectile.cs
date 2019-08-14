using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Projectiles
{
	public class TerraYoyoProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 420f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.Terrarian);
			projectile.damage = 124;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Terrarian;
		}

		public override void PostAI() 
		{
			if (Main.rand.NextBool()) 
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}
