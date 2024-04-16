using UnityEngine;

public enum EventState
{
    Soleado,
    Lluvia,
    Nieve,
    Especial
}

[CreateAssetMenu(fileName = "EventData", menuName = "Calendar/EventData", order = 1)]
public class EventData : ScriptableObject
{
    public string eventName;
    public string eventDate;
    public Sprite eventImage;
    public EventState eventState;
}
