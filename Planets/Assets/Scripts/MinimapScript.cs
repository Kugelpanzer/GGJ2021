using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinimapScript : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerExitHandler
{
    public bool clicked;
    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        clicked = false;

    }
    private void Update()
    {
        if (clicked)
        {
            // Debug.Log(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(UniverseLogicScript.logic.galaxyImage.rect.position));
            //float nesto2 = UniverseLogicScript.logic.sectorSizeY * UniverseLogicScript.logic.universe.GetLength(1) * UniverseLogicScript.logic.realScale;
            // Debug.LogError(v[2].x - v[1].x);
            // Debug.Log(nesto);
            // Debug.Log(nesto/(v[2].x-v[1].x));
            // Debug.Log(nesto2 /( v[1].y - v[0].y));
            // Debug.Log(v[1]);
            //  Debug.Log(newPos);
            //Debug.Log(RectTransformUtility.ScreenPointToLocalPointInRectangle());
            //Debug.Log(RectTransformUtility.ScreenPointToWorldPointInRectangle());
            //float nesto = UniverseLogicScript.logic.sectorSizeX * (UniverseLogicScript.logic.universe.GetLength(0)+1) * UniverseLogicScript.logic.realScale;

            Vector3[] v = new Vector3[4];
            UniverseLogicScript.logic.galaxyImage.GetWorldCorners(v);

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = pos - v[1];


            float nesto = UniverseLogicScript.logic.galaxyImage.rect.width* UniverseLogicScript.logic.realScale;
            float nesto2 = UniverseLogicScript.logic.galaxyImage.rect.height * UniverseLogicScript.logic.realScale;

            float f1 = nesto / (v[2].x - v[1].x);
            float f2 = nesto2 / (v[1].y - v[0].y);
            Camera.main.transform.position = new Vector3(newPos.x*f1,newPos.y*f2,newPos.z);



        }
    }
}
