using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UniverseLogicScript : MonoBehaviour
{
    public static UniverseLogicScript logic;

    public int numberOfPlanetsInGalaxy=6;
    [Range(0, 1)]
    public float chanceOfHint;

    public List<GameObject> allUniquePlanetsPrefab = new List<GameObject>();
    public GameObject earth;
    public GameObject genericPlanetPrefab;
    public GameObject hintPlanetPrefab;

    public List<HintHolder> hintHolder= new List<HintHolder>();


    public Dictionary<Quadrant, List<GameObject>> hints = new Dictionary<Quadrant, List<GameObject>>();
    private int numberOfPlanets;

    int x;
    int y;

    public Planet[,] universe;
    public RectTransform galaxyImage;

    public float realScale=0.1f;

   // private float sectorSize;
    public float sectorSizeX;
    public float sectorSizeY;


    // Start is called before the first frame update
    void Awake()
    {
        numberOfPlanets = numberOfPlanetsInGalaxy * 9;
        //sectorSize =( galaxyImage.rect.width * galaxyImage.rect.height * 9)/numberOfPlanets;
        //sectorSizeX =   galaxyImage.rect.width/ sectorSize;
        //sectorSizeY =  galaxyImage.rect.height/ sectorSize;
        sectorSizeX = galaxyImage.rect.width/(numberOfPlanetsInGalaxy*3);
        sectorSizeY = galaxyImage.rect.height / (numberOfPlanetsInGalaxy*3);
 //       Debug.Log(sectorSizeX);
   //     Debug.Log(sectorSizeY);
        logic = this;

        universe = new Planet[numberOfPlanetsInGalaxy * 3, numberOfPlanetsInGalaxy * 3];

    }
    private void Start()
    {
        GenerateHints();
        SpawnUniverse();

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
        for(int j=0; j < universe.GetLength(1); j++)
            {
                if (universe[i, j] == null)
                {
                    if (Random.Range(0, 1f) < chanceOfHint)
                    {
                        //HINT PLANETS
                        planet= Instantiate(hintPlanetPrefab);
                        universe[i, j] = planet.GetComponent<Planet>();
                        universe[i, j].SetPlanetPosition(j, i);
                        planet.GetComponent<HintPlanet>().SetPlanetImage();

                        
                    }
                    else
                    {
                        //NORMAL PLANETS
                        planet = Instantiate(genericPlanetPrefab);
                        GeneratePlanet.generate.ReturnGeneratedPlanet().transform.SetParent(planet.transform);
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
    private void GenerateHints()
    {
        List<Quadrant> quadrant = new List<Quadrant>() { Quadrant.down, Quadrant.left, Quadrant.right, Quadrant.up, (Quadrant)Random.Range(0, 4), (Quadrant)Random.Range(0, 4) };
        int i = 0;
        foreach(Quadrant q in quadrant)
        {
            hintHolder[i].quad = q;
            GameObject planetPrefab = GeneratePlanet.generate.ReturnGeneratedPlanet();
            planetPrefab.transform.position = new Vector2(-9000, 0);
            hintHolder[i].planetPrefab = planetPrefab;
            hintHolder[i].SetArrow();
            hintHolder[i].AddPlanet(planetPrefab);
            if (hints.ContainsKey(q))
            {
                hints[q].Add(planetPrefab);
            }
            else
            {
                hints[q] = new List<GameObject>();
                hints[q].Add(planetPrefab);
            }
            i++;
        }
    }
    private Cor ReturnCordinate()
    {
        Cor c = null;
        while (c == null)
        {
            int xx = Random.Range(0, universe.GetLength(1));
            int yy= Random.Range(0, universe.GetLength(0));
            if (universe[yy, xx] == null)
            {
                c = new Cor(yy, xx);
            }
        }

        return c;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
