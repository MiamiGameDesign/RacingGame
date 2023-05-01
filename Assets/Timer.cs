using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textBoxT, textBoxB, textBoxL;
    float startTime, timeElapsed, bestTime, currLapTime, startTimeL, timeElapsedL;
    int lapsDone = 0;
    private bool lapCompleted = false;
    private bool actionCompleted = false;
    public AudioSource success;
    void Start()
    {
        startTime = Time.time;
        startTimeL = Time.time;
        bestTime = float.MaxValue;
        textBoxB.GetComponent<Text>().text = "Best Time: 0";
    }
    void Update()
    {

        timeElapsed = (Time.time - startTime) * Time.timeScale;
        timeElapsedL = (Time.time - startTimeL) * Time.timeScale;
        textBoxL.GetComponent<Text>().text = "Laps Completed: " + lapsDone + "\nCurrent Lap Time: "  + (Mathf.Round(timeElapsedL * 100f) / 100f);
        textBoxT.GetComponent<Text>().text = "Total Time: " + (Mathf.Round(timeElapsed * 100f) / 100f);
        if (lapCompleted && !actionCompleted)
        {
            startTimeL = Time.time;
            lapsDone++;
            success.Play();
            if ((Mathf.Round(timeElapsedL * 100f) / 100f) < bestTime)
            {
                bestTime = (Mathf.Round(timeElapsedL * 100f) / 100f);
                textBoxB.GetComponent<Text>().text = "Best Time: " + bestTime;
            }
            actionCompleted = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        lapCompleted = true;
    }
    private void OnTriggerExit(Collider other)
    {
        lapCompleted = false;
        StartCoroutine(pause());
        
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.3f);
        actionCompleted = false;
    }
}
