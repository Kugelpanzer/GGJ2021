using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class PlanetName : MonoBehaviour
{
    public static PlanetName planetName;
    public float time = 2f;

    public Text textName;

    public void SetName(string name)
    {
        textName.text = name;
        Invoke("RemoveName", time);
        
    }

    public void RemoveName()
    {
        textName.text = "";
    }

    private void Awake()
    {
        planetName = this;
        textName.text = "";
    }
}
