using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class arcadeControls : MonoBehaviour
{

    public AudioSource a;
    // Update is called once per frame
    void Start()
    {
        a.loop = true;
        a.PlayDelayed(8.5f);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
