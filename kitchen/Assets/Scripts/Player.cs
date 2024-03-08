using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 10;
    private int InputH;
    private int InputV;
    private bool isWalking;
    void Start()
    {
        
    }

    void Update()
    {
        InputH = (int)Input.GetAxisRaw("Horizontal");
        InputV = (int)Input.GetAxisRaw("Vertical");

        Vector3 movedir = new Vector3(InputH, 0f, InputV);
        transform.forward = Vector3.Slerp(transform.forward, movedir, Time.deltaTime* rotationSpeed);
        transform.position += movedir* speed* Time.deltaTime;
        isWalking = movedir != Vector3.zero;
    }

    public bool ReturnIsWalking()
    {
        return isWalking;
    }
}
