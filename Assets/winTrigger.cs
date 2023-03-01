using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
    }
}
