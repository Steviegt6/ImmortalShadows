using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadeSaber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shade Saber");
			Tooltip.SetDefault("That's gonna leave a mark."
			    + "\nTrue melee weapon"
				+ "\nInflicts Betsy's Curse, Shadowflame and Dark Inferno on enemies");
		}

		public override void SetDefaults() 
		{
			item.damage = 500;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 26);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.5f;
			item.useTurn = true;
			item.crit = 14;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 24);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox) 
		{
			if (Main.rand.NextBool(10)) 
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Dusts.ShadowDust>());
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(BuffID.BetsysCurse, 1200);
			target.AddBuff(BuffID.ShadowFlame, 600);
			target.AddBuff(BuffType<Buffs.Debuffs.DarkFlame>(), 300);
		}
	}
}