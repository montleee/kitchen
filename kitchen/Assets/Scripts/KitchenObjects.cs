using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;

    private ClearCounter clearCounter;
    public KitchenObjectsSO GetKitchenObjectsSO() { 
        return kitchenObjectSO; 
    }
    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("ERR");
        }
        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectPos();
        transform.localPosition = Vector3.zero;

    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
