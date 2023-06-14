using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class QuizTrigger : MonoBehaviour
{
    public GameObject confirmationQuiz;
    private bool InRange;
    public GameObject VisualCueQuiz;

    private void Awake() 
    {
        VisualCueQuiz.SetActive(false);
    }

    private void Update() 
    {
        if (InRange)
        {
            VisualCueQuiz.SetActive(true);
        }
        else 
        {
            VisualCueQuiz.SetActive(false);
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

    public void EnterQuiz(InputAction.CallbackContext context)
    {
        //uncomment to debug
        //Debug.Log("Dialogue Here");

        if (InRange && context.performed)
        {
            confirmationQuiz.SetActive(true);
        }
    }

}
