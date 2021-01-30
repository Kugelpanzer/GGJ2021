using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlanet : Planet
{
    public static EarthPlanet earth;
    // Start is called before the first frame update
    void Awake()
    {
        earth = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
