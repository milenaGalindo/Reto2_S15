using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace Etra.StarterAssets.Input
{
    public class ItemHighlight : MonoBehaviour
    {       

        [SerializeField]
        public StarterAssetsInputs _InputRef;
        public int currentSloth;



        void Start()
        {
            currentSloth = -1;
        }


        void Update()
        {
            currentSloth = (int)_InputRef.usableItemScroll + 2;


            if (currentSloth == 1)
            {
                GetComponent<RectTransform>().localPosition = new Vector2(-200f, 0f);
            }

            if (currentSloth == 2)
            {
                GetComponent<RectTransform>().localPosition = new Vector2(0, 0f);
            }

            if (currentSloth == 3)
            {
                GetComponent<RectTransform>().localPosition = new Vector2(200f, 0f);
            }

            GetComponentInParent<InventoryManager>().inventoryIndex = currentSloth - 1;


        }  
        

    }
}

