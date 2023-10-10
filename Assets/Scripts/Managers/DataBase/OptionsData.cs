using UnityEngine;

[CreateAssetMenu(fileName = "OptionsData", menuName = "ScriptableObjects/OptionsData")]
public class OptionsData : ScriptableObject
{
    public bool FunnyOptions;
    public int Volume;
    public int Resolution;
    public int Language;
    public int TimeMultiplier;
}

