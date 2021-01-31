﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Text header;
    public Text content;
    public Text god;
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
