
using System;

[Serializable]
public class RandomEvent
{
	public string Text;
	[NonSerialized]
	public bool Triggered = false;
}
