using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
    public class ShadowBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom");
            Tooltip.SetDefault("70% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 208;
            item.ranged = true;
            item.width = 12;
            item.height = 38;
            item.maxStack = 1;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 12);
            item.rare = 11;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 12f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 30);
            recipe.AddIngredient(ItemID.Phantasm);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .70f;
        }
    }
}