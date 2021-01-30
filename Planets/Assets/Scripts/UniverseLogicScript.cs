using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UniverseLogicScript : MonoBehaviour
{
    public static UniverseLogicScript logic;

    public int numberOfPlanetsInGalaxy;
    [Range(0, 1)]
    public float chanceOfHint;

    public List<GameObject> allUniquePlanetsPrefab = new List<GameObject>();
    public GameObject earth;
    public GameObject genericPlanetPrefab;
    public GameObject hintPlanetPrefab;




    public Dictionary<Quadrant, List<HintPlanet>> hints = new Dictionary<Quadrant, List<HintPlanet>>();
    private int numberOfPlanets;

    int x;
    int y;

    public Planet[,] universe;
    public static RectTransform galaxyImage;

    public float realScale=0.1f;

    private float sectorSize;
    public float sectorSizeX;
    public float sectorSizeY;


    // Start is called before the first frame update
    void Start()
    {
        sectorSize =( galaxyImage.rect.width * galaxyImage.rect.height * 9)/numberOfPlanets;
        sectorSizeX = sectorSize / galaxyImage.rect.width;
        sectorSizeY = sectorSize / galaxyImage.rect.height;

        logic = this;
        numberOfPlanets = numberOfPlanetsInGalaxy * 9;
        universe = new Planet[numberOfPlanetsInGalaxy * 3, numberOfPlanetsInGalaxy * 3];
    }

    public void SpawnUniverse()
    {
        //SPAWNING EARTH
        int x = Random.Range(0, universe.GetLength(1));
        int y = Random.Range(0, universe.GetLength(0));
        GameObject planet = Instantiate(earth);
        universe[y,x] = planet.GetComponent<Planet>();
        universe[y, x].SetPlanetPosition(x, y);


        //SPAWNING UNIQUE
        foreach(GameObject gj in allUniquePlanetsPrefab)
        {
            Cor c = ReturnCordinate();
            x = c.x;
            y = c.y;
            planet = Instantiate(gj);
            universe[y, x] = planet.GetComponent<Planet>();
            universe[y, x].SetPlanetPosition(x, y);
        }


        
        for(int i = 0; i < universe.GetLength(0); i++)
        for(int j=0; i < universe.GetLength(1); j++)
            {
                if (universe[i, j] == null)
                {
                    if (Random.Range(0, 1) < chanceOfHint)
                    {
                        //HINT PLANETS
                        //ADD LATER
                    }
                    else
                    {
                        //NORMAL PLANETS
                        planet = Instantiate(genericPlanetPrefab);
                        universe[i, j] = planet.GetComponent<Planet>();
                        universe[i, j].SetPlanetPosition(j,i);
                    }
                }
            }



    }
    /* private void SpawnEarth(EarthPlanet planet, int x, int y)
     {

     }
     private void SpawnHint(HintPlanet planet,int x, int y)
     {

     }
     private void SpawnUnique(Planet planet, int x, int y)
     {

     }*/

    private Cor ReturnCordinate()
    {
        Cor c = null;
        while (c == null)
        {
            if (universe[y, x] == null)
            {
                c = new Cor(x, y);
            }
        }

        return c;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
