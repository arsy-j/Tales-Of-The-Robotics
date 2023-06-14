using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class SceneExitSc : MonoBehaviour
{
    private bool InRange;
    public GameObject visualIcon;
    public string SceneToEnggange;

    private void Awake() 
    {
        visualIcon.SetActive(false);
    }

    private void Update() 
    {
        if (InRange)
        {
            visualIcon.SetActive(true);
        }
        else 
        {
            visualIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            InRange = true ;
            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            InRange = false ;
        }   
    }

    public void ChangeSceneScript(InputAction.CallbackContext context)
    {
        //uncomment to debug
        //Debug.Log("Dialogue Here");

        if (InRange && context.performed)
        {
            SceneManager.LoadScene(SceneToEnggange);
        }
    }

}
