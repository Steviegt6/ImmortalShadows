using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ImmortalShadows
{
	public class ImmortalShadows : Mod
	{
		public ImmortalShadows()
		{
			
		}
		
        public override void PostSetupContent()
        {
            Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
                 censusMod.Call("TownNPCCondition", NPCType("Shadow Creature"), "Have a shadow chunk in your inventory");
            }
        }
	}
}