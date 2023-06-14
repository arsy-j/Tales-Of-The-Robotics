using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCScript : MonoBehaviour

{
    public DialogueTrigger trigger;
    public GameObject visualCue ;
    private bool playerInRange;    

    private void Awake() 
    {
        //set icon to disappear first
        visualCue.SetActive(false);
    }
    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
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
    public void StartDialogueScript(InputAction.CallbackContext context)
    {
        //uncomment to debug
        //Debug.Log("Dialogue Here");

        if (playerInRange && context.performed)
        {
            trigger.StartDialogue();
        }
    }
}
