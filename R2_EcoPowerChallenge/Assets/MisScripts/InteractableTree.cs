using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Etra.StarterAssets.Source.Interactions
{
    public class InteractableTree : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        public estadosCrecimiento estadoActual;
        private int totalCiclos;
        private int contadorCiclos;
        private int currentIconIndex;

        private bool fertilizanteOAgua;

        public Sprite[] iconoFertilizanteoAgua;
        public ForestData _ForestData;
        public SpriteRenderer displayIcono;

        public enum estadosCrecimiento
        {
            Brote,
            Joven,
            Adulto,
            Final
        }

        void Start()
        {            
            estadoActual = estadosCrecimiento.Brote;
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Debug.Log("El arbol es un Brote");
            contadorCiclos = 0;
            totalCiclos = (int)Random.Range(1, 3);           
            fertilizanteOAgua = Random.value < 0.5f;
            ChangeIcon();
            
            GetComponent<ObjectCollection>().SetInteractable(false);
        }


        void updateTreeState()
        {
            switch (estadoActual)
            {
                case estadosCrecimiento.Brote:
                    Debug.Log("El arbol es Joven");
                    estadoActual = estadosCrecimiento.Joven;
                    gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    break;

                case estadosCrecimiento.Joven:
                    Debug.Log("El arbol es Adulto");
                    estadoActual = estadosCrecimiento.Adulto;
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

                    break;

                case estadosCrecimiento.Adulto:
                    Debug.Log("El arbol completó su crecimiento");
                    estadoActual = estadosCrecimiento.Final;                    
                    gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    _ForestData.fullTreesPlanted++;
                    ChangeIcon(2);
                    break;

                default:
                    Debug.Log("Esto no debería pasar :'3");
                    gameObject.transform.localScale = new Vector3(3f, 3f, 3f);                                      
                    break;
            }
        }



        private void OnTriggerStay(Collider other)
        {
            if (estadoActual != estadosCrecimiento.Final)
            {
                if (contadorCiclos <= totalCiclos)
                {
                    if (other.gameObject.CompareTag("Fertilizante") && fertilizanteOAgua)
                    {
                        contadorCiclos++;
                        Destroy(other.gameObject);
                        fertilizanteOAgua = Random.value < 0.5f;
                    }

                    else if (other.gameObject.CompareTag("AguaRiego") && !fertilizanteOAgua)
                    {
                        contadorCiclos++;
                        Destroy(other.gameObject);
                        fertilizanteOAgua = Random.value < 0.5f;
                    }

                    ChangeIcon();
                }

                else
                {
                    updateTreeState();
                    totalCiclos = (int)Random.Range(1, 3);
                    contadorCiclos = 0;
                }

            }

        }

        void ChangeIcon()
        {
            if (fertilizanteOAgua) currentIconIndex = 0;
            else currentIconIndex = 1;

            displayIcono.sprite = iconoFertilizanteoAgua[currentIconIndex];
        }

        void ChangeIcon(int choseIndex)
        {
            displayIcono.sprite = iconoFertilizanteoAgua[choseIndex];
        }




    }

}
