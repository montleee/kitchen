using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform GetKitchenObjectPos();
    public void SetKitchenObject(KitchenObjects kitchenObject);
    public KitchenObjects GetKitchenObject();
    public void ClearKitchenObject();
    public bool HasKitchenObject();
}
