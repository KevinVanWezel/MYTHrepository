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
    private void Look(bool right)
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
     
     private void Animate(bool Walking)
    {
        
        if(Walking == true)
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
            Animate(true); 
            Look(false);
          
          
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Animate(true);
            Look(true);
          
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Animate(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Animate(false);
        }

    }


}