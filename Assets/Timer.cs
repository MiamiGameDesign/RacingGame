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
    void Start()
    {
        startTime = Time.time;
        startTimeL = Time.time;
        bestTime = float.MaxValue;
        textBoxB.GetComponent<Text>().text = "Best Time: 0";
    }
    void Update()
    {
        
        if (Time.timeScale == 1)
        {
            timeElapsed = (Time.time - startTime) * Time.timeScale;
            timeElapsedL = (Time.time - startTimeL) * Time.timeScale;
        }
        /*Debug.Log("z: " + transform.position.z + " y: " + transform.position.y);
        Debug.Log("Coordinates good? " + (transform.position.x >= -22 && transform.position.x <= -13 && transform.position.z >= -42 && transform.position.z <= -40 && transform.position.y > 0 && transform.position.y < 1.1));
        Debug.Log("time: " + (Mathf.Round(timeElapsed * 100f) / 100f) % 60);*/
        textBoxL.GetComponent<Text>().text = "Laps Completed: " + lapsDone + "\nCurrent Lap Time: "  + (Mathf.Round(timeElapsedL * 100f) / 100f) % 60;
        textBoxT.GetComponent<Text>().text = "Total Time: " + (Mathf.Round(timeElapsed * 100f) / 100f) % 60;
        if (lapCompleted && !actionCompleted)
        {
            startTimeL = Time.time;
            lapsDone++;
            if ((Mathf.Round(timeElapsedL * 100f) / 100f) % 60 < bestTime)
            {
                bestTime = (Mathf.Round(timeElapsedL * 100f) / 100f) % 60;
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
