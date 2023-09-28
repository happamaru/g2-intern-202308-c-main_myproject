using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ThrowArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool canThrow;
    public bool CanThrow { get { return canThrow; } }


    public void OnPointerEnter(PointerEventData eventData)
    {
        canThrow = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canThrow = false; 
    }
}

