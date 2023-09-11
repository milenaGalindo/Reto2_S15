using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Etra.StarterAssets.Input;


public class ItemSprite : MonoBehaviour
{
    public Sprite emptySprite;


    private void Start()
    {
        GetComponent<Image>().sprite = emptySprite;
    }




    public void setIcon(Sprite icon)
    {

        gameObject.GetComponent<Image>().sprite = icon;
    }



}



