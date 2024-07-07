using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameInfo : MonoBehaviour
{
    public static GameInfo Instance { get; private set; }
    public float score;
    public float winScore;
    public TextMeshPro textScore;
    public InitializeLevel initializer;
    public TextMeshPro endText;
    public XRRayInteractor ray;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

//        print("instantiated");
        initializer.init();
        UpdateScore(0);
       
    }


    public void UpdateScore(float extraScore)
    {
        score += extraScore;
        textScore.text = "Score: " + score.ToString();
        print(score);
    }

    public void GameEnding()
    {
         endText.gameObject.SetActive(true);
        if (score >= winScore)
        {
           
            //do winning thing
        //    print("you won");
            endText.text = "you won.";
            return;
        }
        else
        {
            //do lose thing
           // print("you lost");
           
            endText.text = "You lost";
        }

        StartCoroutine(Returner());
//TODO: cutszene or something for ending condition.
    }
    
    IEnumerator  Returner()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}