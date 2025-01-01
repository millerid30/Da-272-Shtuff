using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // this script has timer that starts at a certain value and the time will go down.
    public float startTime = 10;
    public float endTime = 0;
    public float currentTime;
    public TMP_Text timerText;
    public Image timer;
    private Animator anim;
    [Header("Timer Starts Flashing")]
    [Range(1f, 100f)] public float warningTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            AddTime(30);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            RemoveTime(30);
        }

        if (currentTime < warningTime)
        {
            anim.SetBool("LowTime", true);
        }
        else
        {
            anim.SetBool("LowTime", false);
        }
        // stop timer when current time is <= 0
        if (currentTime <= endTime)
        {
            //currentTime = 0;
            //return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        currentTime = currentTime - Time.deltaTime;
        timerText.text = currentTime.ToString("0.0");
        timer.fillAmount = currentTime/startTime;
    }
    void AddTime(float time)
    {
        currentTime += time;
        currentTime = Mathf.Clamp(currentTime, 0, startTime);
    }
    void RemoveTime(float time)
    {
        currentTime -= time;
        currentTime = Mathf.Clamp(currentTime, 0, startTime);
    }
}