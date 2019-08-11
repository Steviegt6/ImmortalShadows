using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Projectiles
{
	public class ShadowGreatswordStar : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Greatsword Star");
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(503);
			aiType = 503;
		}

		public override bool PreKill(int timeLeft) 
		{
			projectile.type = 503;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) 
		{
			for (int i = 0; i < 3; i++) 
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, 503, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
}