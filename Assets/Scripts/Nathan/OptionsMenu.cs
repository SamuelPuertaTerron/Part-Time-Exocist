using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
   
    public Animator animator;

   public void Change(bool Open)
    {
        animator.SetBool("Open", Open);
        animator.SetBool("CanPlay", true);
    }
}
