using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform topPosition;
    public void Interact()
    {
     
        Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab, topPosition);
        kitchenObjectsTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectsTransform.GetComponent<KitchenObjects>().GetKitchenObjectsSO());
    }
}
