using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ImmortalShadows.NPCs.ShadowAmalg;
using ImmortalShadows.Items.ShadowAmalg;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows
{
	public class ImmortalShadows : Mod
	{
		public ImmortalShadows()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		
        public override void PostSetupContent()
        {
            //Cenus support
            Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
                 censusMod.Call("TownNPCCondition", NPCType("Shadow Creature"), "Have a Shadow Chunk in your inventory");
            }

			Mod bossList = ModLoader.GetMod("BossChecklist");
			if (bossList != null)
			{
				bossList.Call("AddBossWithInfo", "Shadow Amalgamation", 14.0f, (Func<bool>)(() => ShadowWorld.downedShadowAmalg), string.Format("Use a [i:{0}] after beating the Moon Lord", ItemType("SAsummon")));
			}
		}
	}
}