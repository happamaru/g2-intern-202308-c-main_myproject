using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asobikata : MonoBehaviour
{
    [SerializeField] GameObject AsobiObj;
    [SerializeField] GameObject[] Asobis;
    [SerializeField] GameObject CloseButton;
    [SerializeField] Text AsobiPage;

    public void OpenAsobikata(){
        AsobiPage.text = "1/6";
        AsobiObj.SetActive(true);
        CloseButton.SetActive(true);
        Asobis[0].SetActive(true);
    }
    public void CloseAsobikata(){
        AsobiObj.SetActive(false);
        CloseButton.SetActive(false);
    }

    public void NextAsobi(int index){
        AsobiPage.text = (index+2).ToString() + "/6";
        if(index != 5){
        Asobis[index].SetActive(false);
        Asobis[index+1].SetActive(true);
        }else{
            Asobis[index].SetActive(false);
            CloseButton.SetActive(false);
            AsobiObj.SetActive(false);
        }
    }
}
