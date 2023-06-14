using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizAnswer : MonoBehaviour
{
    public GameObject feed_Benar, Feed_Salah; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correctAnswer (bool answer)
    {
        if (answer)
        {
            feed_Benar.SetActive(false);
            feed_Benar.SetActive(true);
            int Score = PlayerPrefs.GetInt("skor")+10;
            PlayerPrefs.SetInt ("skor",Score);
            int FinalScore = PlayerPrefs.GetInt("skorFinal")+10;
            PlayerPrefs.SetInt ("skorFinal", FinalScore);
        }
        else
        {
            Feed_Salah.SetActive(false);
            Feed_Salah.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex()+1).gameObject.SetActive(true);
    }

}
