using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Projectiles.Minions
{
	public class ShadeCell : ShadeCellAI
	{
		public override void SetStaticDefaults() 
		{
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults() 
		{
			projectile.netImportant = true;
			projectile.width = 24;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 20f;
			shoot = mod.ProjectileType("MiniShadeCell");
			shootSpeed = 12f;
		}
		
		public override void CheckActive() {
			Player player = Main.player[projectile.owner];
			ShadowPlayer modPlayer = player.GetModPlayer<ShadowPlayer>();
			if (player.dead) {
				modPlayer.shadowMinion = false;
			}
			if (modPlayer.shadowMinion) {
				projectile.timeLeft = 2;
			}
		}
		
		public override void SelectFrame() 
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8) 
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
		}
	}
}
