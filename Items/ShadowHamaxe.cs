using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items
{
	public class ShadowHamaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadowflare Hamaxe");
		}

		public override void SetDefaults() 
		{
			item.damage = 70;
			item.melee = true;
			item.width = 56;
			item.height = 54;
			item.useTime = 6;
			item.useAnimation = 20;
			item.axe = 30;          //Note that the axe power displayed in-game is this value multiplied by 5
			item.hammer = 180;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(gold: 20);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarHamaxeSolar);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 35);
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
