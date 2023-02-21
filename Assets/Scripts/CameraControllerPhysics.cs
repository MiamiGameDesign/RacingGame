using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerPhysics : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Camera camera;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        transform.position = target.position;
        camera.transform.localPosition = offset;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            target.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
