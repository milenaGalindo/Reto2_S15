using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalSystem : MonoBehaviour
{

    [SerializeField]
    MedalData InfoMedallasNivel;
    [SerializeField]
    GameObject medallaBronze;
    [SerializeField]
    GameObject medallaPlata;
    [SerializeField]
    GameObject medallaOro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        medallaBronze.SetActive(InfoMedallasNivel.medallaBronce);
        medallaPlata.SetActive(InfoMedallasNivel.medallaPlata);
        medallaOro.SetActive(InfoMedallasNivel.medallaOro);
    }
}
