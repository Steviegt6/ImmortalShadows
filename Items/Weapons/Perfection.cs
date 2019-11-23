using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class Perfection : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Perfection");
			Tooltip.SetDefault("Nice."
			    + "\nShoots a projectile that goes through tiles");
		}

		public override void SetDefaults() 
		{
			item.damage = 300;
			item.melee = true;
			item.width = 46;
			item.height = 54;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 45);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.DD2SquireSonicBoom;
			item.shootSpeed = 16f;
			item.scale = 1.5f;
			item.useTurn = true;
			item.crit = 14;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperShortsword);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 45);
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