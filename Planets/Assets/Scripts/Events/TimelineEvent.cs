
using System;

[Serializable]
public class TimelineEvent
{
	public double Time;
	public string Header;
	public string Text;
	public string God;
	[NonSerialized]
	public bool Triggered = false;
}
