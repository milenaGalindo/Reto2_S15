using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResource : MonoBehaviour
{

    public InventoryManager _InventoryManager;
    //public itemData _scriptableOfResource;


    public void GiveResourceToPlayer(itemData _scriptableOfResource)
    {

        if (!_InventoryManager.isFull())
        {
            _InventoryManager.AddToInventory(_scriptableOfResource);
        }
    }

}
