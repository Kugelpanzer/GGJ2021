using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintHolder : MonoBehaviour
{

    public GameObject planetPrefab;
    public GameObject arrow;
    public Quadrant quad;

    public void SetArrow()
    {
        switch (quad)
        {
            case Quadrant.down: 
                arrow.transform.eulerAngles = Vector3.forward ;
                break;
            case Quadrant.up:
                arrow.transform.eulerAngles = Vector3.forward * 180;
                break;
            case Quadrant.left:
                arrow.transform.eulerAngles = Vector3.forward * 270;
                break;
            case Quadrant.right:
                arrow.transform.eulerAngles = Vector3.forward *90;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
     //   SetArrow();
        //GameObject gj = GeneratePlanet.generate.ReturnGeneratedPlanet();


    }
    public void AddPlanet(GameObject gj)
    {
        GameObject ggj = Instantiate(gj);
        ggj.transform.position = transform.position;
        ggj.transform.SetParent(this.gameObject.transform);
        ggj.transform.localScale = new Vector2(40, 40);
        ggj.GetComponent<SpriteRenderer>().sortingOrder = 5;
        foreach(Transform child in ggj.transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder += 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
