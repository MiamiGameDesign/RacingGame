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
        transform.position = target.position;
        camera.transform.localPosition = offset;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            target.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
