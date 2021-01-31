using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EarthPlanet : Planet//,IPointerClickHandler
{
    public static EarthPlanet earth;

    public void OnMouseDown()
    {
        Debug.Log("Victory");
        LevelController.levelController.GoToScene(2);
    }
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
