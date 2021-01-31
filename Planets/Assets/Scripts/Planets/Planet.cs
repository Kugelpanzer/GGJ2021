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

    public float offsetX;
    public float offsetY;

    public GameObject planetOnMinimap;

    public string planetName;
    public virtual void SetPlanetPosition(int x, int y)
    {
        
        this.x = x;
        this.y = y;
        offsetX =  Random.Range(0, 0.7f );
        offsetY =  Random.Range(0, 0.7f );
        transform.position = new Vector2(
            UniverseLogicScript.logic.sectorSizeX * (x + offsetX)* UniverseLogicScript.logic.realScale,
            -UniverseLogicScript.logic.sectorSizeY * (y + offsetY) * UniverseLogicScript.logic.realScale

            );
        GameObject m=Instantiate(planetOnMinimap);
        m.GetComponent<MinimapPlanet>().SetPlanetPosition(this);
    }
    public void GenerateName()
    {
        string abc = "";
        switch (Random.Range(0, 3))
        {
            case 0: abc += "a"; break;
            case 1: abc += "b"; break;
            case 2: abc += "c"; break;
        }
        planetName = "Planet " + Random.Range(0, 1000) + abc;
    }
    private void OnMouseDown()
    {
        Debug.Log(planetName);
        PlanetName.planetName.SetName(planetName);
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
