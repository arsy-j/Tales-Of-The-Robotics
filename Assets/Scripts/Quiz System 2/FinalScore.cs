using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{

    public GameObject hideTempScore;
    // Start is called before the first frame update
    void Start()
    {
        hideTempScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("skorFinal").ToString();
    }
}
