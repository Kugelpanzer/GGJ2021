using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyUIScript : MonoBehaviour
{
    public static GalaxyUIScript UI;

    public Image galaxyImage;
    // Start is called before the first frame update
    void Awake()
    {
        UI = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
