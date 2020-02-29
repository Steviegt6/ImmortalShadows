using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Buffs
{
	public class ShadowLightPet : ModBuff
	{
		public override void SetDefaults() 
		{
			DisplayName.SetDefault("Dark Eye");
			Description.SetDefault("A Dark Eye that provides light");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
			Main.debuff[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			 player.statLifeMax2 += 25;
			
			player.GetModPlayer<ImmortalPlayer>().shadowLightPet = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.ShadowLightPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.ShadowLightPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}