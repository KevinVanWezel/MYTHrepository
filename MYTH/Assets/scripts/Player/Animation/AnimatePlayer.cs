using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    /*
     * Handles all the animations of the player
     */
    
    bool LeftRight = false;
  
    GameObject playerDirector;
    Animator _Anim;

    void Start()
    {
        playerDirector = GameObject.FindGameObjectWithTag("Parent");
        playerDirector.GetComponent<PlayerInput>();
        _Anim = GetComponent<Animator>();
    }
    public void Look(bool right)
    {

        if (right == true)
        {
            
            print("test2");
            if (LeftRight == true)
            {

                transform.Rotate(Time.deltaTime, 180, 0);
                LeftRight = false;
            }
        }
       
        if (right == false)
        {
           
            if (LeftRight == false)
            {


                transform.Rotate(Time.deltaTime, 180, 0);
                LeftRight = true;
            }
        }
      
    }
     
    public void Animate(bool walking)
    {
        
        if(walking == true)
        {
            _Anim.SetTrigger("RightWalking");
        }
        else
        {
            _Anim.SetTrigger("IdleR");
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {          
           // Look(false);
          
          
        }

        if (Input.GetKeyDown(KeyCode.D))
        {            
         //   Look(true);
          
            
        }

    }


}