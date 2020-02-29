using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowMageWeapon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Crystal Shadow");
			Tooltip.SetDefault("Shoots an explosive crystal charge");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.mana = 19;
			item.UseSound = SoundID.Item109;
			item.useStyle = 5;
			item.damage = 170;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 36;
			item.height = 40;
			item.shoot = 521;
			item.shootSpeed = 15f;
			item.knockBack = 4.4f;
			item.magic = true;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 14, 0, 0);
			item.rare = 11;
			item.noMelee = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalSerpent);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 14);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}