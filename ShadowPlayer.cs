using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ImmortalShadows
{
	public class ShadowPlayer : ModPlayer
	{
		public bool shadowLightPet;

		public override void ResetEffects() 
		{
			shadowLightPet = false;
		}
	}
}