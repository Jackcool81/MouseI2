using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{   
    //IMPORTANT
    //Amount of time this scene's timer allows the player, in seconds
    private int countdownFrom = 315;

    //text object that the timer will write to, to display the time remaining
    public Text timertext;
    //values the timer uses to display the correct minutes and seconds
    private int minutes;
    private int seconds;

    void Start()
    {
        timerInitialize();                  //the timer text gets set to what countdownFrom is, translated from seconds to Minutes:Seconds
        StartCoroutine(startCountdown());   //the timer function itself is started, using a coroutine
    }

    void Update()
    {
        //this is so that instead of displaying 5 minutes and 6 seconds as 5:6, it will display 5:06
        //also handles updating the timer's text to reflect the amount of time left
        if (seconds < 10)
        {
            timertext.text = minutes + ":0" + seconds;
        }
        else
        {
            timertext.text = minutes + ":" + seconds;  
        }
        
    }

    private void timerInitialize()  
    {
        print(countdownFrom);
        minutes = (countdownFrom/60);
        seconds = (countdownFrom%60);
    }
    private IEnumerator startCountdown()
    {
        print("function started");
        int count = 0;
        while (count < countdownFrom)
        {
            yield return new WaitForSeconds(1);
            count++;
            if (seconds == 0)
            {
                seconds = 60;
                seconds--;
                minutes--;
            }
            else if (seconds != 60)
            {
                seconds--;
            }
        }
        excitingThing();
    }

    //please replace this function with what we need, probably something like loading the ship scene
    private void excitingThing()
    {
        print("timer finished");
    }
}
