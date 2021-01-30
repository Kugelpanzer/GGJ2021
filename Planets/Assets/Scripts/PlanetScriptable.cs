using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Planet",menuName ="Planet")]
public class PlanetScriptable : ScriptableObject
{
    public string Name = "";

    [TextArea]
    public string Description = "";


}
