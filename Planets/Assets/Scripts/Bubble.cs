using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Text header;
    public Text content;
    public Text god;
    private void Start()
    {
        Invoke("SelfDestroy", destroyText);
    }
    public float destroyText = 10f;
    public void SelfDestroy()
    {
        if(this.gameObject!=null)
            Destroy(gameObject);
    }

    public void SetBubble(string header, string content, string god)
    {
        this.header.text = header;
        this.content.text = content;
        this.god.text ="God: "+ god;
    }

}
