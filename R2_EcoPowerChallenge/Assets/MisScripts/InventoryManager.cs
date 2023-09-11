using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EtrasStarterAssets;

public class InventoryManager : MonoBehaviour
{

    
    [Header("Items en el inventario")]
    public itemData[] inventario;

    [SerializeField] public int tamanoInventario = 3;
    public itemData HollowSlothPrefab;

    public ItemSprite[] itemSloths;
    public int inventoryIndex;


    void Start()
    {
        inventario = new itemData[tamanoInventario];
        for (int i = 0; i < inventario.Length; i++)
        {
            inventario[i] = HollowSlothPrefab;
        }

    }

    public void AddToInventory(itemData objectToAdd)
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i] == HollowSlothPrefab)
            {
                inventario[i] = objectToAdd;
                itemSloths[i].setIcon(objectToAdd.itemIcon);
   
                break;
                
            }
            else
            {
                if (i == inventario.Length-1) {

                    break;
                }

                
            }
        }
    }

    public itemData SelectFromInventory()
    {
        itemData objectToThrow = inventario[inventoryIndex];

        if (objectToThrow == HollowSlothPrefab)
        {

            return null;           
        }

        else
        {

            return objectToThrow;
        }
    }

    public void RemoveFromInventory()
    {

        if (inventario[inventoryIndex] == HollowSlothPrefab)
        {
         
        }

        else
        {
            inventario[inventoryIndex] = HollowSlothPrefab;
            itemSloths[inventoryIndex].setIcon(HollowSlothPrefab.itemIcon);

        }
    }

    public bool isFull()
    {

        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i] == HollowSlothPrefab) return false;
        }
        return true;
    }



}
