using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Projectiles
{
	public class ShadowGreatswordStar : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.CloneDefaults(503);
			aiType = 503;
			projectile.tileCollide = false;
		}

		public override bool PreKill(int timeLeft) 
		{
			projectile.type = 503;
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffType<Buffs.Debuffs.DarkFlame>(), 400);
		}
	}
}