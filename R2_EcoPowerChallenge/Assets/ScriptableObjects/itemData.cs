using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itamData", menuName = "EcoPowerChallenge/itemData")]
public class itemData : ScriptableObject
{
    [SerializeField]
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    
}
