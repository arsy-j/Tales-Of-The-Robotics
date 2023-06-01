using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCScript : MonoBehaviour

{
    public DialogueTrigger trigger;
    public GameObject visualCue ;
    private bool playerInRange;

    private InputAction.CallbackContext context;


    private void Awake() 
    {
        visualCue.SetActive(false);
    }
    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(context.performed)
            {
                trigger.StartDialogue();               
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerInRange = true ;
            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerInRange = false ;
        }   
    }
}
