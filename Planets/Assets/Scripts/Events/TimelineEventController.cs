using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimelineEventController : MonoBehaviour
{
	public TextAsset TimelineEventsFile;

	void Awake()
	{
		TimelineEventCollection timelineEvents = JsonUtility.FromJson<TimelineEventCollection> ( TimelineEventsFile.text );
		foreach (TimelineEvent timelineEvent in timelineEvents)
		{
			Debug.Log ( JsonUtility.ToJson ( timelineEvent, true ) );
		}
	}

	void Update()
	{
		
	}
}
