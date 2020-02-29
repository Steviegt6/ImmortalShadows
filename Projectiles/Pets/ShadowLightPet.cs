using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Projectiles.Pets
{
	public class ShadowLightPet : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Eye Pet");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.SuspiciousTentacle);
			aiType = ProjectileID.SuspiciousTentacle;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.suspiciouslookingTentacle = false;
			return true;
		}

		public override void AI()
        {
            Player player = Main.player[projectile.owner];
            ImmortalPlayer modPlayer = player.GetModPlayer<ImmortalPlayer>();
            if(player.dead) 
            {
                modPlayer.shadowLightPet = false;
            }
            if(modPlayer.shadowLightPet)
            {
                projectile.timeLeft = 2;
            }
        }
	}
}