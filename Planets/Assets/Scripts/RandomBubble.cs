using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBubble : MonoBehaviour
{

    public Text content;

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void SetBubble( string content)
    {
        this.content.text = content;

    }
    public void Start()
    {
        
    }
}
