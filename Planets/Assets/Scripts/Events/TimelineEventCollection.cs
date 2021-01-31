
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class TimelineEventCollection : IEnumerable <TimelineEvent>
{
	public List<TimelineEvent> TimelineEvents = new List<TimelineEvent>();

	public TimelineEvent this [int index]
	{
		get => TimelineEvents [index];
		set => TimelineEvents [index] = value;
	}

	public IEnumerator<TimelineEvent> GetEnumerator () => ( (IEnumerable<TimelineEvent>) TimelineEvents ).GetEnumerator ();
	IEnumerator IEnumerable.GetEnumerator () => ( (IEnumerable<TimelineEvent>) TimelineEvents ).GetEnumerator ();

	public void OnGameStart()
	{
		foreach ( TimelineEvent timelineEvent in TimelineEvents ) timelineEvent.Triggered = false;
	}
}
