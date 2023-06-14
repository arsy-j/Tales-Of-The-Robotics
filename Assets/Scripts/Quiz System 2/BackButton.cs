using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButton : MonoBehaviour
{
    public string PreviousScene;
    // Start is called before the first frame update
    public void BackToScene()
    {
        SceneManager.LoadScene(PreviousScene);
    }
}
