using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour,
    IPointerClickHandler,  
    IPointerDownHandler,  
    IPointerUpHandler  
{

   [SerializeField] int ID;
    public int ID_Set{
        get{return ID;}
        set{ID+=value;}
    }
    public int SetID{
        set{ID = value;}
    }

     Image NowImage;
     void Start(){
        NowImage = GetComponent<Image>();
     }
    public Sprite Set_Image{
        set{NowImage.sprite = value;}
    }

    public void DestroyBox(){
        this.gameObject.SetActive(false);
    }
    public void ActiveBox(){
        this.gameObject.SetActive(true);
    }
    public bool CheckIsActive(){
        return this.gameObject.activeSelf;
    }

    public Action<int> OnSelect;

    // クリック
    public void OnPointerClick(PointerEventData eventData){
        OnSelect(ID);
    }  
    // 押したとき  
    public void OnPointerDown(PointerEventData eventData){}  
    // 離したとき  
    public void OnPointerUp(PointerEventData eventData){}  
}
