using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    public static SpawnText t;
    public GameObject textPrefab;
    public GameObject randomTextPrefab;
    public GameObject placment;




    public void SpawnUiText(TimelineEvent e)
    {
        GameObject gj = Instantiate(textPrefab,placment.transform);
        //gj.transform.SetParent(this.gameObject.transform);
        gj.GetComponent<Bubble>().SetBubble(e.Header, e.Text, e.God);
        
    }
    public void SpawnRandomText(RandomEvent e)
    {
        GameObject gj = Instantiate(randomTextPrefab,placment.transform);
        //gj.transform.SetParent(this.gameObject.transform);
        gj.GetComponent<RandomBubble>().SetBubble(e.Text);
    }
    private void Awake()
    {
        t = this;
    }
}
