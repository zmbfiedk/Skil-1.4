using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimations : MonoBehaviour
{
    [SerializeField] TankController controller;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (controller.SP > 0.5f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (controller.SP < 0.5f) 
        {
            anim.SetBool("isReversing", true);
        }
        else
        {
            anim.SetBool("isReversing", false);
        }

    }
}
