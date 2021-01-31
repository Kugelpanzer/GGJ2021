
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class RandomEventCollection : IEnumerable <RandomEvent>
{
	public List<RandomEvent> RandomEvents = new List<RandomEvent> ();

	public RandomEvent this [int index]
	{
		get => RandomEvents [index];
		set => RandomEvents [index] = value;
	}

	public IEnumerator<RandomEvent> GetEnumerator () => ( (IEnumerable<RandomEvent>) RandomEvents ).GetEnumerator ();
	IEnumerator IEnumerable.GetEnumerator () => ( (IEnumerable<RandomEvent>) RandomEvents ).GetEnumerator ();

	public void OnGameStart ()
	{
		foreach ( RandomEvent randomEvent in RandomEvents ) randomEvent.Triggered = false;
	}
}
