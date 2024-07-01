using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public float time;
    public TextMeshPro display3D;
    private bool _timerIsRunning = true;

    private UnityEvent callWhenExpired;

    void Start()
    {
        callWhenExpired = new UnityEvent();
        callWhenExpired.AddListener(GameInfo.Instance.GameEnding);
        _timerIsRunning = true;
        StartCoroutine(timeee());
    }


    IEnumerator  timeee()
    {
        while(_timerIsRunning)
        {
             DisplayNewTime();
            yield return new WaitForSeconds(1f);
            time -= 1f;
          
        }
        
        callWhenExpired.Invoke();
    }

    public void DisplayNewTime()
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float secs = Mathf.FloorToInt(time % 60);
        if (minutes == 0 && secs == 0)
        {
            _timerIsRunning = false;
        }

        string seconds = secs.ToString();
        if (secs < 10) seconds = "0" + seconds;
        display3D.text= minutes + ":" + seconds;

    }
}
