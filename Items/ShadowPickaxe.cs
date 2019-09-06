using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items
{
	public class ShadowPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadowflare Pickaxe");
		}

		public override void SetDefaults() 
		{
			item.damage = 90;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 4;
			item.useAnimation = 12;
			item.pick = 235;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlarePickaxe);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) 
		{
			if (Main.rand.NextBool(10)) 
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("ShadowDust"));
			}
		}
	}
}