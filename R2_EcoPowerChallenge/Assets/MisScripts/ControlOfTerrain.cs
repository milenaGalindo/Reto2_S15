using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEditor;
using EtrasStarterAssets;


public class ControlOfTerrain : MonoBehaviour
{

    [SerializeField]
    public ForestData _ForestData;
    public int mapNumber;
    public int previousMapNumber;

    public GameObject currentEnabledMap;
    public GameObject[] allMaps;

    public string[] namesOfAudios;
    public AudioManager _AudioManager;

    public InventoryManager _InventoryManager;
    public itemData _scriptableOfTree;
    public MedalData _ForestMedalData;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (GameObject map in allMaps)
        {
            map.SetActive(false);
        }       
    }

    private void Start()
    {
        mapNumber = _ForestData.CurrentMap;
        allMaps[mapNumber].SetActive(true);
        setAudio(mapNumber);
    }

    // Update is called once per frame
    void Update()
    {
        checkTreeCount();
        if (mapNumber != previousMapNumber) UpdateMap();
        previousMapNumber = mapNumber;
    }


    void checkTreeCount()
    {
        if (_ForestData.fullTreesPlanted < 3)
        {
            mapNumber = 0;
        }

        else if (_ForestData.fullTreesPlanted >= 3 && _ForestData.fullTreesPlanted < 10)
        {
            mapNumber = 1;
            _ForestMedalData.medallaBronce = true;
        }

        else if (_ForestData.fullTreesPlanted >= 10 && _ForestData.fullTreesPlanted < 20)
        {
            mapNumber = 2;
            _ForestMedalData.medallaPlata = true;
        }

        else if (_ForestData.fullTreesPlanted >= 20)
        {
            mapNumber = 3;
            _ForestMedalData.medallaOro = true;
        }

        else
        {
            mapNumber = 0;
        }

    }


    void UpdateMap()
    {
        allMaps[mapNumber].SetActive(true);
        Physics.gravity = new Vector3(0f, 0f, 0f);
        allMaps[previousMapNumber].SetActive(false);
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        setAudio(mapNumber);

    }


    public void GiveTreeToPlayer()
    {

        if (!_InventoryManager.isFull())
        {
            _InventoryManager.AddToInventory(_scriptableOfTree);
        }        
    }

    public void setAudio(int indexNombresAudios)
    {
        _AudioManager.stopAllSounds();
        _AudioManager.Play(namesOfAudios[indexNombresAudios]);
    }

}

