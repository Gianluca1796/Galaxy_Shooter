using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations_Player : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            _animator.SetBool("TurnLeft", true);
            _animator.SetBool("TurnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.A ) || Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            _animator.SetBool("TurnLeft", false);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("TurnLeft", false);
            _animator.SetBool("TurnRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetBool("TurnRight", false);
        }

    }
    
}


