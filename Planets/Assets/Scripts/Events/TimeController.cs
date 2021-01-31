
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeController : MonoBehaviour
{
	public static TimeController time;

	public TextAsset TimelineEventsFile;
	public TextAsset RandomEventsFile;

	/// <summary>
	/// Minimum time in minutes that an random event can happen after a last event
	/// </summary>
	public double MinRandomEventDelta = 0.15;
	/// <summary>
	/// Maximum time in minutes that an random event can happen after a last event
	/// </summary>
	public double MaxRandomEventDelta = 0.7;

	TimelineEventCollection _timelineEvents = new TimelineEventCollection ();
	RandomEventCollection _randomEvents = new RandomEventCollection ();

	double _gameStartTime;
	double _lastEventTime;

	void Awake ()
    {
		time = this;
		_timelineEvents = JsonUtility.FromJson<TimelineEventCollection> ( TimelineEventsFile.text );
		_randomEvents = JsonUtility.FromJson<RandomEventCollection> ( RandomEventsFile.text );
	}

	void Update()
    {
		double gameTime = Time.time / 60 - _gameStartTime;
		TimelineEvent timelineEvent =
			(
				from e in _timelineEvents
				where e.Time < gameTime && !e.Triggered
				orderby e.Time
				select e
			).FirstOrDefault();
		if ( timelineEvent != null )
		{
			ExecuteTimelineEvent ( timelineEvent, gameTime );
			return;
		}
    }

	public void OnGameStart ()
	{
		_gameStartTime = Time.time / 60;
		_lastEventTime = 0;
		_timelineEvents.OnGameStart ();
		_randomEvents.OnGameStart ();
	}

	public void ExecuteTimelineEvent ( TimelineEvent timelineEvent, double gameTime )
	{
		Debug.Log ( JsonUtility.ToJson ( timelineEvent, true ) );
		// do UI shit
		timelineEvent.Triggered = true;
		_lastEventTime = gameTime;
	}

	public void ExecuteRandomEvent ( RandomEvent randomEvent )
	{
		Debug.Log ( JsonUtility.ToJson ( randomEvent, true ) );
		// do UI shit
	}

	public double CurrentGameTime ()
	{
		return 0;
	}
}
