using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlanetType
{

}
public class Planet : MonoBehaviour
{
    public PlanetType type;

    public int x;
    public int y;


    public virtual void SetPlanetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector2(
            UniverseLogicScript.logic.sectorSizeX* UniverseLogicScript.logic.realScale,
            UniverseLogicScript.logic.sectorSizeY * UniverseLogicScript.logic.realScale
            );
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
