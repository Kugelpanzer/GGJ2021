using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlanet : MonoBehaviour
{

    int x;
    int y;
    public virtual void SetPlanetPosition(Planet planet)
    {
        
        this.x = planet.x;
        this.y = planet.y;
        transform.SetParent(UniverseLogicScript.logic.galaxyImage);
        transform.localPosition = new Vector2(
              UniverseLogicScript.logic.sectorSizeX * (x + planet.offsetX),
             -UniverseLogicScript.logic.sectorSizeY* (y + planet.offsetY) 
            ) - 
            new Vector2(UniverseLogicScript.logic.galaxyImage.rect.width/2,
            -UniverseLogicScript.logic.galaxyImage.rect.height/2);
            ;
        transform.localScale = new Vector3(0.3f, 0.3f, 1);
    }
}
