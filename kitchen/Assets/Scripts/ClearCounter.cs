using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform topPosition;
    [SerializeField] private ClearCounter ClearCounter2;
    private KitchenObjects kitchenObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(ClearCounter2);
            }
        }
    }
    public void Interact(Player player)
    {
     if (kitchenObject == null)
        {
            Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab, topPosition);
            kitchenObjectsTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectPos()
    {
        return topPosition;
    }
    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObjects GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
