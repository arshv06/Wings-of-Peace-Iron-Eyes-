using UnityEngine;

[CreateAssetMenu(fileName = "LocationData", menuName = "Location/LocationData", order = 1)]
public class LocationData : ScriptableObject
{
    public string locationName;   // The name of the location
    public string locationInfo;   // The info or description of the location
}
