using UnityEngine;

[CreateAssetMenu(fileName = "Attributes", menuName = "ScriptableObjects/AttributesScriptableObject", order = 1)]
public class AttributesScriptableObject : ScriptableObject
{
    public int vitality;
    public int strength;
    public int intellect;
    public int endurance;
}
