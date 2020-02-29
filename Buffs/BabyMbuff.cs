using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Buffs
{
	public class BabyMbuff : ModBuff
	{
		public override void SetDefaults() 
		{
			DisplayName.SetDefault("Baby Metroid");
			Description.SetDefault("It loves you!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.GetModPlayer<ImmortalPlayer>().babyMpet = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.BabyMproj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.BabyMproj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}