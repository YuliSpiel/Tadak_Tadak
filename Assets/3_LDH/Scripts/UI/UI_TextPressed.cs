using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_TextPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform buttonTxt;
    private Vector2 originVector2;
    public float UnitsToMove;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonTxt = transform.GetChild(0).GetComponent<RectTransform>();
        originVector2 = buttonTxt.anchoredPosition;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonTxt.anchoredPosition = new Vector2(originVector2.x, UnitsToMove);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonTxt.anchoredPosition = originVector2;
    }
}
