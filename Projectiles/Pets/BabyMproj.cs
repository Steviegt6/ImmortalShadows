using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Projectiles.Pets
{
	public class BabyMproj : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Baby Metroid");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			projectile.width = 32;
			projectile.height = 30;
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI()
        {
            Player player = Main.player[projectile.owner];
            ImmortalPlayer modPlayer = player.GetModPlayer<ImmortalPlayer>();
            if(player.dead) 
            {
                modPlayer.babyMpet = false;
            }
            if(modPlayer.babyMpet)
            {
                projectile.timeLeft = 2;
            }
		}
	}
}