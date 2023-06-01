using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class MainGameMechanic : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> UnAnswerdQuestion;

    private Question currentQuestion;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private Text trueAnswerText;

    [SerializeField]
    private Text falseAnswerText;

    [SerializeField]
    private float TimeDelayQuestion = 1f;

    void Start()
    {
        if (UnAnswerdQuestion == null || UnAnswerdQuestion.Count == 0) 
        {
            UnAnswerdQuestion = questions.ToList<Question>();
        }

        SetCurrentQuestion();

        //uncomment for debugging
        //Debug.Log (currentQuestion.QuestionFact + "is " + currentQuestion.isTrue);
    }

    IEnumerator transitionToNextQuestion () 
    {   
        UnAnswerdQuestion.Remove(currentQuestion);

        yield return new WaitForSeconds(TimeDelayQuestion);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionindex = Random.Range(0, UnAnswerdQuestion.Count);
        currentQuestion = UnAnswerdQuestion[randomQuestionindex];
        questionText.text = currentQuestion.QuestionFact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "KAMU BENAR";
            falseAnswerText.text = "YAH SALAH";
        }
        else
        {
            trueAnswerText.text = "YAH SALAH";
            falseAnswerText.text = "KAMU BENAR";
        }

    }

    public void UserSelectTrue()
    {
        Animator.SetTrigger("True");
        if(currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
        }
        else 
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(transitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        Animator.SetTrigger("False");
        if(!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
        }
        else 
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(transitionToNextQuestion());
    }
}
