using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public AudioClip joe;
    public void StartGame() {
        SceneManager.LoadScene("Ohio");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Jazz()
    {
        AudioSource.PlayClipAtPoint(joe, new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Start is
    //
    // called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
