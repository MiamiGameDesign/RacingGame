using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Min(1, Mathf.Max(-1, transform.localPosition.x + (Input.GetAxis("Horizontal") * 3 * Time.deltaTime))), 0, 0);
        transform.localEulerAngles = new Vector3(0, Input.GetAxis("Horizontal") * 15, 0);
    }
}
