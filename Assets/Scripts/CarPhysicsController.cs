using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CarPhysicsController : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 8;
    public float accel = 100;
    public float turnSpeed = 80;

    public float groundCheckDistance = .5f;

    public Vector3 groundCheckHalfExtents;

    private void Awake()
    {
        Time.timeScale = 2;
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 5;
        
        // Remove friction
        var collider = GetComponent<Collider>();
        collider.sharedMaterial = new PhysicMaterial();
        collider.sharedMaterial.frictionCombine = PhysicMaterialCombine.Multiply;
        collider.sharedMaterial.dynamicFriction = 0;
        collider.sharedMaterial.staticFriction = 0;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        bool grounded = Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance);
        //bool grounded = Physics.BoxCast(transform.position, groundCheckHalfExtents, -transform.up, out hit, transform.rotation, groundCheckDistance);
        var movementNormal = grounded ? hit.normal : transform.up;

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);

        var groundedVelocity = rb.velocity - Vector3.Dot(movementNormal, rb.velocity) * movementNormal;

        rb.velocity += Step(groundedVelocity, transform.forward * moveSpeed, accel * Time.fixedDeltaTime);
    }

    // Move from one vector to another by a certain amount.
    private Vector3 Step(Vector3 from, Vector3 to, float by)
    {
        var diff = to - from;
        if (to.sqrMagnitude < by * by)
            return diff;
        return diff.normalized * by;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + -transform.up * groundCheckDistance, groundCheckHalfExtents * 2f);
        Gizmos.DrawLine(transform.position, transform.position - groundCheckDistance * transform.up);
    }
}
