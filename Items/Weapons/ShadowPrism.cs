using ImmortalShadows.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowPrism : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Last Prism EX");
			Tooltip.SetDefault("Charges up a beam that disintegrates anything and everything."
			    + "\nCan drain your mana before it even fully charges");
		}

		public override void SetDefaults() 
		{
			item.damage = 300;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;
			item.mana = 14;
			item.rare = 11;
			item.width = 16;
			item.height = 16;
			item.useTime = 10;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 30f;
			item.useAnimation = 10;
			item.shoot = ProjectileType<ShadowDeathLaser>();
			item.value = Item.sellPrice(gold: 25);
			item.reuseDelay = 5;
			item.knockBack = 0f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LastPrism, 2);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 45);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
