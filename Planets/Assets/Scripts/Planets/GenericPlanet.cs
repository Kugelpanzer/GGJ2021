using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlanet : Planet
{

    public virtual void GenerateLook()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        string abc = "";
        switch (Random.Range(0, 3))
        {
            case 0: abc += "a";break;
            case 1: abc += "b"; break;
            case 2: abc += "c"; break;
        }
        planetName = "Planet " + Random.Range(0, 1000)+abc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
