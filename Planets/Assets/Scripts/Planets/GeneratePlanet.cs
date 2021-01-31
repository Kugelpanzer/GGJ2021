using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanet : MonoBehaviour
{

    public GameObject core=null;
    public GameObject light=null;
    public List<GameObject> layouts = new List<GameObject>();


    public static GeneratePlanet generate;
    public GameObject ReturnGeneratedPlanet()
    {
        //transform.eulerAngles = Vector3.forward * degrees;
        GameObject newCore = Instantiate(core);
        GameObject newLayout =Instantiate( layouts[Random.Range(0, layouts.Count)],newCore.transform);
        GameObject newLight = Instantiate(light, newCore.transform);

        newCore.GetComponent<SpriteRenderer>().color =RandomColor();
        newLayout.GetComponent<SpriteRenderer>().color = RandomColor();
        newLayout.transform.eulerAngles = Vector3.forward * Random.Range(0,180);
        newLight.transform.eulerAngles = Vector3.forward * Random.Range(0, 180);

        return newCore;
    }

    private Color RandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f),1f);
    }
    private void Awake()
    {
        generate = this;
    }
}
