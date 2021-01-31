
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
	public double MinRandomEventDelta = 0.1;
	/// <summary>
	/// Maximum time in minutes that an random event can happen after a last event
	/// </summary>
	public double MaxRandomEventDelta = 0.5;
	/// <summary>
	/// Time in minutes before the next timeline event that no random events are allowed
	/// </summary>
	public double BeforeTimelineEventRandomEventDelta = 0.1;
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
	TimelineEvent _nextTimelineEvent;
	double _nextTimelineEventTime;
	RandomEvent _nextRandomEvent;
	double _nextRandomEventTime;

	void Awake ()
    {
		time = this;
		_timelineEvents = JsonUtility.FromJson<TimelineEventCollection> ( TimelineEventsFile.text );
		_randomEvents = JsonUtility.FromJson<RandomEventCollection> ( RandomEventsFile.text );
		OnGameStart();
	}

	public bool CheckEnd()
    {
		if (GameFraction > 1)
			return true;
		else
			return false;
    }
	void Update()
    {
		_gameTime = Time.time / 60 - _gameStartTime;

		if (_nextTimelineEvent != null && _gameTime >= _nextTimelineEventTime)
		{
			ExecuteTimelineEvent ( _nextTimelineEvent );
			return;
		}

		if (_nextRandomEvent != null && _gameTime >= _nextRandomEventTime)
		{
			ExecuteRandomEvent ( _nextRandomEvent );
		}
    }

	public void OnGameStart ()
	{
		_gameStartTime = Time.time / 60;
		_gameTime = 0;
		_lastEventTime = 0;
		_timelineEvents.OnGameStart ();
		_randomEvents.OnGameStart ();
		PrepareNextTimelineEvent ();
		PrepareNextRandomEvent ();
	}

	public void ExecuteTimelineEvent ( TimelineEvent timelineEvent )
	{
		Debug.Log ( JsonUtility.ToJson ( timelineEvent, true ) );
		SpawnText.t.SpawnUiText(timelineEvent);
		timelineEvent.Triggered = true;
		AfterEvent ();
	}

	public void ExecuteRandomEvent ( RandomEvent randomEvent )
	{
		Debug.Log ( JsonUtility.ToJson ( randomEvent, true ) );
		SpawnText.t.SpawnRandomText(randomEvent);
		randomEvent.Triggered = true;
		AfterEvent ();
	}

	void AfterEvent()
	{
		_lastEventTime = _gameTime;
		PrepareNextTimelineEvent ();
		PrepareNextRandomEvent ();
	}

	void PrepareNextTimelineEvent()
	{
		_nextTimelineEvent =
			(
				from e in _timelineEvents
				where !e.Triggered
				orderby e.Time
				select e
			).FirstOrDefault ();
		_nextTimelineEventTime = _nextTimelineEvent == null ? GameDuration : _nextTimelineEvent.Time;
	}

	void PrepareNextRandomEvent ()
	{
		_nextRandomEventTime = _lastEventTime + MinRandomEventDelta + ( MaxRandomEventDelta - MinRandomEventDelta ) * UnityEngine.Random.value;
		if ( _nextRandomEventTime > _nextTimelineEventTime - BeforeTimelineEventRandomEventDelta )
			_nextRandomEvent = null;
		else
		{
			IEnumerable<RandomEvent> randomEventsLeft =
				from e in _randomEvents
				where !e.Triggered
				select e;
			int randomEventsLeftCount = randomEventsLeft.Count ();
			_nextRandomEvent = randomEventsLeftCount == 0 ? null : randomEventsLeft.ElementAt ( UnityEngine.Random.Range ( 0, randomEventsLeftCount ) );
		}
	}
}
