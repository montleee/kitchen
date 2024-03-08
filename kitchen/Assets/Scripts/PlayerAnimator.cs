using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
     private Animator anim;
    [SerializeField] Player player;
    void Awake()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("IsWalking", player.ReturnIsWalking());
    }
}
