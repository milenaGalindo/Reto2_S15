using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "medalData", menuName = "EcoPowerChallenge/medalData")]

public class MedalData : ScriptableObject
{
    [SerializeField]
    public bool medallaBronce;
    [SerializeField]
    public bool medallaPlata;
    [SerializeField]
    public bool medallaOro;

    public bool getBronze()
    {
        return medallaBronce;
    }



    public bool getPlata()
    {
        return medallaPlata;
    }

    public bool getOro()
    {
        return medallaOro;
    }

}




