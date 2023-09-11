using Etra.StarterAssets.Input;
using Etra.StarterAssets.Source.Interactions;
using UnityEngine;


namespace Etra.StarterAssets.Abilities
{
    public class ABILITY_ActivateCollect : EtraAbilityBaseClass
    {

        //Ability by: asour

        //Public variables
        [Header("Basics")]
        public float collectDistance = 2.0f; // The distance you can interact with an object       
        //[SerializeField] public int inventoryIndex;
        public GameObject _Player;
        public InventoryManager _InventoryManager;

        //Private variables
        private bool holdingInteract;
        private bool buttonPressed;


        //References
        StarterAssetsInputs starterAssetsInputs;
        ABILITY_CameraMovement camMoveScript;





        public override void abilityStart()
        {
            starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
            camMoveScript = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_CameraMovement>();
   
        }


        public override void abilityLateUpdate()
        {
            if (!enabled)
            {
                return;
            }
            //If the object is in range
            if (collectDistance > Vector3.Distance(camMoveScript.playerCameraRoot.transform.position, camMoveScript.pointCharacterIsLookingAt))
            {

                if (camMoveScript.raycastHit.transform.GetComponent<ObjectCollection>()) //Check if the object has the ObjectInteraction script
                {
                    //interactDistance
                    ObjectCollection collectable = camMoveScript.raycastHit.transform.GetComponent<ObjectCollection>(); // Get the object's interaction script

                    if (collectable.isCollectable)
                    {
                        var objectThatIsLookedAt = camMoveScript.raycastHit.transform.gameObject;

                        if (starterAssetsInputs.collect && !buttonPressed)
                        {
                            if (!_InventoryManager.isFull())
                            {
                                holdingInteract = true;
                                buttonPressed = true;
                                _InventoryManager.AddToInventory(camMoveScript.raycastHit.transform.gameObject.GetComponent<ObjectCollection>().TakeItem());
                            }                           
                            
                        }

                        else
                        {
                            holdingInteract = false;
                        }

                        if (buttonPressed == true && holdingInteract == false)
                        {
                            buttonPressed = false;

                        }
                    }                    

                }
            }
            else
            {
                if (starterAssetsInputs.collect && !buttonPressed)
                {
                    
                    if(_InventoryManager.inventario[_InventoryManager.inventoryIndex] != _InventoryManager.HollowSlothPrefab)
                    {

                        holdingInteract = true;
                        buttonPressed = true;

                        
                        GameObject itemModel = Instantiate(_InventoryManager.inventario[_InventoryManager.inventoryIndex].itemPrefab, _Player.transform.position + new Vector3(0f,2f,0f), Quaternion.identity);

                        if (itemModel.CompareTag("ArbolPlantable"))
                        {
                            itemModel.transform.position = _Player.transform.position;
                            itemModel.GetComponent<ObjectCollection>().SetInteractable(false);
                        }
                        else
                        {
                            itemModel.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }
                        _InventoryManager.RemoveFromInventory();
                    }
                  
                }


                else
                {
                    holdingInteract = false;
                }

                if (buttonPressed == true && holdingInteract == false)
                {
                    buttonPressed = false;

                }

            }
        }

    }
}