
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
	/// <summary>
	/// Game duration in minutes
	/// </summary>
	public double GameDuration = 5;
	/// <summary>
	/// Current game time in minutes
	/// </summary>
	public double GameTime { get { return _gameTime; } }
	/// <summary>
	/// Current game time in fraction of total game duration
	/// </summary>
	public double GameFraction { get { return _gameTime / GameDuration; } }

	TimelineEventCollection _timelineEvents = new TimelineEventCollection ();
	RandomEventCollection _randomEvents = new RandomEventCollection ();

	double _gameStartTime;
	double _lastEventTime;
	double _gameTime;

	void Awake ()
    {
		time = this;
		_timelineEvents = JsonUtility.FromJson<TimelineEventCollection> ( TimelineEventsFile.text );
		_randomEvents = JsonUtility.FromJson<RandomEventCollection> ( RandomEventsFile.text );
	}

	void Update()
    {
		_gameTime = Time.time / 60 - _gameStartTime;
		TimelineEvent timelineEvent =
			(
				from e in _timelineEvents
				where e.Time < _gameTime && !e.Triggered
				orderby e.Time
				select e
			).FirstOrDefault();
		if ( timelineEvent != null )
		{
			ExecuteTimelineEvent ( timelineEvent );
			return;
		}
    }

	public void OnGameStart ()
	{
		_gameStartTime = Time.time / 60;
		_gameTime = 0;
		_lastEventTime = 0;
		_timelineEvents.OnGameStart ();
		_randomEvents.OnGameStart ();
	}

	public void ExecuteTimelineEvent ( TimelineEvent timelineEvent )
	{
		Debug.Log ( JsonUtility.ToJson ( timelineEvent, true ) );
		// do UI shit
		timelineEvent.Triggered = true;
		_lastEventTime = _gameTime;
	}

	public void ExecuteRandomEvent ( RandomEvent randomEvent )
	{
		Debug.Log ( JsonUtility.ToJson ( randomEvent, true ) );
		// do UI shit
	}
}
