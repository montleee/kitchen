using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;

    private IKitchenObjectParent KitchenObjectParent;
    public KitchenObjectsSO GetKitchenObjectsSO() { 
        return kitchenObjectSO; 
    }
    public void SetKitchenObjectParent(IKitchenObjectParent KitchenObjectParent)
    {
        if (this.KitchenObjectParent != null)
        {
            this.KitchenObjectParent.ClearKitchenObject();
        }
        this.KitchenObjectParent = KitchenObjectParent;

        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("ERR");
        }
        KitchenObjectParent.SetKitchenObject(this);

        transform.parent = KitchenObjectParent.GetKitchenObjectPos();
        transform.localPosition = Vector3.zero;

    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return KitchenObjectParent;
    }
}
