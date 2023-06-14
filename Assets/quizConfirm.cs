using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quizConfirm : MonoBehaviour
{
    public string QuizSceneTarget;
    public void ConfirmQuiz()
    {
        SceneManager.LoadScene(QuizSceneTarget);
    }

    public void CancelQuiz()
    {
        gameObject.SetActive(false);
    }
}
