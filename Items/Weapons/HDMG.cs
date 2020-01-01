using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class HDMG : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("H.D.M.G.");
			Tooltip.SetDefault("The Hell Dolphin Machine Gun."
			    + "\n66% chance not to consume ammo");
		}

		public override void SetDefaults() 
		{
			item.damage = 168;
			item.ranged = true;
			item.width = 66;
			item.height = 32;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 30);
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 14;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 18);
			recipe.AddIngredient(ItemID.SDMG);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .66f;
		}
	}
}
