using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region SINGLETON
    private static EventManager instance;
    public static EventManager Instance {
        get {
            if (instance == null)
                Debug.LogError("There is no instance of EventManager");

            return instance;
        }
    }

    public static Dictionary<string, Action> eventDic = new Dictionary<string, Action>();

    private void InitializeSingleton() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    #endregion

    private enum eventToCreate {
        OnPlayerDie,
        OnEnnemyDie,
        OnEnnemyCanSpawn,
        OnEnnemyCantSpawn,
        OnGameStart,
    }

    private void Awake() {
        InitializeSingleton();
        CreateEventPrefab();
    }

    private void CreateEventPrefab() {
        CreateEvent(eventToCreate.OnGameStart.ToString());
        CreateEvent(eventToCreate.OnPlayerDie.ToString());
        CreateEvent(eventToCreate.OnEnnemyDie.ToString());
        CreateEvent(eventToCreate.OnEnnemyCanSpawn.ToString());
        CreateEvent(eventToCreate.OnEnnemyCantSpawn.ToString());
    }

    public void CreateEvent(string _nameEvent) {
        if (eventDic.ContainsKey(_nameEvent))
            Debug.LogError($"You try to create a event, he already exist. Event name : {_nameEvent}");

        eventDic.Add(_nameEvent, null);
    }

    public void RemoveEvent(string _nameEvent) {
        if (!eventDic.ContainsKey(_nameEvent))
            Debug.LogError($"This event disn't exist. Event name : {_nameEvent}");

        eventDic.Remove(_nameEvent);
    }

    public void SubscribreToEvent(string _nameEvent, Action _function) {
        if (!eventDic.ContainsKey(_nameEvent))
            Debug.LogError($"This event disn't exist. Event name : {_nameEvent}");

        eventDic[_nameEvent] += _function;
    }

    public void UnsubscribeToEvent(string _nameEvent, Action _function) {
        if (!eventDic.ContainsKey(_nameEvent))
            Debug.LogError($"This event disn't exist. Event name : {_nameEvent}");

        eventDic[_nameEvent] -= _function;
    }

    public void TriggerEvent(string _nameEvent) {
        if (!eventDic.ContainsKey(_nameEvent))
            Debug.LogError($"This event disn't exist. Event name : {_nameEvent}");

        eventDic[_nameEvent]?.Invoke();
        Debug.Log($"{_nameEvent} trigger !");
    }

    public void ClearAllEvent() {
        eventDic.Clear();
    }
}
