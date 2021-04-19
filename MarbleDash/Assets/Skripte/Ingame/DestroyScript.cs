using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyScript : MonoBehaviour
{
    public Slider SliderBlue, SliderRed;
    public Text TextBlue, TextRed;
    public GameObject GameManger;

    private int countBlue = 0;
    static public int scoreBlue = 0;

    private int countRed = 0;
    static public int scoreRed = 0;

    void setScoreText(int score, Text t)
    {
        string message = score.ToString() + " / 2";
        t.text = message;
    }

    private void Awake()
    {
        SliderBlue.value = 0;
        SliderRed.value = 0;
        TextBlue.text = "0 / 2";
        TextRed.text = "0 / 2";

    }
    void OnCollisionEnter(Collision element)
    {
        if (element.gameObject.CompareTag("Red"))
        {
            Destroy(element.gameObject);
            countRed++;
            if (countRed == 10)
            {
                countRed = 0;
                countBlue = 0;

                scoreBlue++;
                SliderBlue.value = scoreBlue;
                setScoreText(scoreBlue, TextBlue);
                GameManger.GetComponent<InitialiserGOs>().Initialize();
               
            }
        }

        if (element.gameObject.CompareTag("Blue"))
        {
            Destroy(element.gameObject);
            countBlue++;
            if (countBlue == 10)
            {
                countBlue = 0;
                countRed = 0;

                scoreRed++;
                SliderRed.value = scoreRed;
                setScoreText(scoreRed, TextRed);
                GameManger.GetComponent<InitialiserGOs>().Initialize();
               
            }
        }
        Destroy(element.gameObject);
    }
}