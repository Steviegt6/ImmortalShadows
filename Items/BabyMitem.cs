using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class BabyMitem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Metroid Egg");
			Tooltip.SetDefault("Summons a pet Baby Metroid");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.BabyMproj>();
			item.buffType = BuffType<Buffs.BabyMbuff>();
			item.rare = 6;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 40);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddIngredient(ItemID.SoulofFlight);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) 
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) 
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}