using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Perfected Blade");
			Tooltip.SetDefault("Shoots a beam that passes through tiles and pierces through a lot of enemies"
				+ "\nMelee hits inflict Ichor and Daybroken");
		}

		public override void SetDefaults() 
		{
			item.damage = 265;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 35);
			item.rare = 11;
			item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowBladeProj");
			item.shootSpeed = 17f;
			item.scale = 1.3f;
			item.useTurn = true;
			item.crit = 14;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)

		{

			target.AddBuff(BuffID.Ichor, 1200);
			target.AddBuff(BuffID.Daybreak, 600);

		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 24);
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