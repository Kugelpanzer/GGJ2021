using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBubble : MonoBehaviour
{

    public Text content;
    public float destroyText = 10f;
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        Invoke("SelfDestroy", destroyText);
    }
    public void SetBubble( string content)
    {
        if (this.gameObject != null)
            this.content.text = content;

    }

}
