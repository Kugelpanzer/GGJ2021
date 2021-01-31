using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    Text header;
    Text content;
    Text god;
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void SetBubble(string header, string content, string god)
    {
        this.header.text = header;
        this.content.text = content;
        this.god.text ="God: "+ god;
    }

}
