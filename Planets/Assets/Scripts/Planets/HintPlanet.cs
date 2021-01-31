using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quadrant
{
    up,
    down,
    left,
    right
}

public class HintPlanet : GenericPlanet
{
    GameObject planetPrefab;
    public List<Quadrant> ReturnListQuadrants()
    {
        List<Quadrant> q = new List<Quadrant>();
        if (transform.position.x > EarthPlanet.earth.transform.position.x)
        {
            q.Add(Quadrant.left);
        }
        else
        {
            q.Add(Quadrant.right);
        }
        if (transform.position.y > EarthPlanet.earth.transform.position.y)
        {
            q.Add(Quadrant.down);
        }
        else
        {
            q.Add(Quadrant.up);
        }
        
        return q;
    }

    
    public void SetPlanetImage()
    {
        GenerateName();
        List<Quadrant> listQ = ReturnListQuadrants();
        Quadrant q = listQ[Random.Range(0, listQ.Count)];
      //  Debug.Log("Q:" + q);
        List<GameObject> planet = UniverseLogicScript.logic.hints[q];
        planetPrefab = Instantiate(planet[Random.Range(0, planet.Count)]);
        planetPrefab.transform.SetParent(transform);
        planetPrefab.transform.localPosition = Vector3.zero;
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
