using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject omObject;
    public Animator animator;
    public void Start()
    {
        animator = omObject.GetComponent<Animator>();
    }
        
    void ChangeDirection(float direction)
    {
        animator.SetFloat("Direction", direction);
    }
}
