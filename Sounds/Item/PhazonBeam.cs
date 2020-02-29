using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;

namespace ImmortalShadows.Sounds.Item
{
	public class PhazonBeam : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type) 
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * .5f;
			soundInstance.Pan = pan;
			soundInstance.Pitch = 0f;
			return soundInstance;
		}
	}
}
