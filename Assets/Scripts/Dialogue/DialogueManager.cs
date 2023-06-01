using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float leanScaleSpeed = 0.5f ;
    public float leanTransparentSpeed = 0.5f ;
    public Text actorName;
    public Text MessageText;
    public RectTransform MessagePanel;
    public static bool isActive = false;
    Message[] CurrentMessage;
    Actor[] CurrentActors;
    int activeMessage = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        CurrentMessage = messages;
        CurrentActors = actors ;
        activeMessage = 0 ;
        isActive = true ;
        //enable for debugging
        Debug.Log("Started conversation! loaded messages :" + messages.Length);
        displayMessages();
        MessagePanel.LeanScale(Vector3.one, leanScaleSpeed).setEaseInOutExpo();
    }

    void displayMessages()
    {
        Message messageToDisplay = CurrentMessage[activeMessage];
        MessageText.text = messageToDisplay.message;

        Actor actorToDisplay = CurrentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;

        animateTextColor();

    }
    public void nextMessage()
    {
        activeMessage++;
        if (activeMessage < CurrentMessage.Length)
        {
            displayMessages();
        }
        else 
        {
            Debug.Log("Conversation Ended");
            isActive = false;
            MessagePanel.LeanScale(Vector3.zero, leanScaleSpeed).setEaseInOutExpo();
        }
    }

    void animateTextColor()
    {
        LeanTween.textAlpha(MessageText.rectTransform, 0, 0);
        LeanTween.textAlpha(MessageText.rectTransform, 1, leanTransparentSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        MessagePanel.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && isActive == true) 
        {
            nextMessage();
        }
    }
}
