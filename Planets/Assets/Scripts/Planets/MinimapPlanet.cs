using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlanet : MonoBehaviour
{

    int x;
    int y;
    public virtual void SetPlanetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector2(
            UniverseLogicScript.logic.sectorSizeX ,
            UniverseLogicScript.logic.sectorSizeY 
            );
    }
}
