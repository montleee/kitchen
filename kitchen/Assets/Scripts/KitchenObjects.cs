using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;

    public KitchenObjectsSO GetKitchenObjectsSO() { 
        return kitchenObjectSO; 
    }
}
