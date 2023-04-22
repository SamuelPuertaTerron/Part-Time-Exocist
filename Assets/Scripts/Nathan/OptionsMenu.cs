using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
   
    public Animator animator;
    public GameObject mainMenuButtons;

   public void Change(bool Open)
    {
        animator.SetBool("Open", Open);
        animator.SetBool("CanPlay", true);
        mainMenuButtons.SetActive(false);
    }
    //added a new function for using your code as a base for the back button, simple fix. Jay 
    public void BackButton(bool Open){
        animator.SetBool("Open", Open);
        animator.SetBool("CanPlay", true);
        mainMenuButtons.SetActive(true);
    }
}
