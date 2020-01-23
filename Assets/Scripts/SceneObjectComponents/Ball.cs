using System.Collections;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public event Action BallReset = delegate { };

    public float XAxisAcceleration { get; set; }
    public float ZAxisAcceleration { get; set; }
    public Vector3 CurrentPosition => transform.position;

    [SerializeField] private float maxXAcceleration = 20f;  
    [SerializeField] private float maxZAcceleration = 20f;
    [SerializeField] private float maxXVelocity = 60f;
    private float minXVelocity;
    [SerializeField] private float maxZVelocity = 60f;
    private float minZVelocity;

    [SerializeField] float fallSpeed = 1f;

    private new Rigidbody rigidbody;

    private bool isInputAllowed = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();        
        minXVelocity = -maxXVelocity;
        minZVelocity = -maxZVelocity;
        StartCoroutine(DelayInput(1f));
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void FreezeBall()
    {
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        rigidbody.isKinematic = true;
    }

    public void ResetBall()
    {
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = new Vector3(0f, 0f, 0f);
        rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        StartCoroutine(DelayInput(0.5f));
        BallReset();
    }

    private void AddForceToRigidbody(Vector3 force)
    {
        rigidbody.AddForce(force);
    }

    private void FixedUpdate()
    {
        if (isInputAllowed)
        {
            if (XAxisAcceleration != 0)
            {
                XAxisAcceleration = XAxisAcceleration * maxXAcceleration;
                AddForceToRigidbody(new Vector3(XAxisAcceleration, 0f, 0f));
            }

            if (ZAxisAcceleration != 0)
            {
                ZAxisAcceleration = ZAxisAcceleration * maxZAcceleration;
                AddForceToRigidbody(new Vector3(0f, 0f, ZAxisAcceleration));
            }
        }        

        ClampVelocity();
    }

    public void ContinueFall(Vector3 holePosition)
    {
        isInputAllowed = false;
        Vector3 direction = (holePosition - transform.position).normalized;
        rigidbody.velocity = fallSpeed * direction;
    }

    public void EndFall()
    {
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        rigidbody.isKinematic = true;
    }
    
    private void ClampVelocity()
    {
        float clampedX = Mathf.Clamp(rigidbody.velocity.x, minXVelocity, maxXVelocity);
        float clampedZ = Mathf.Clamp(rigidbody.velocity.z, minZVelocity, maxZVelocity);

        rigidbody.velocity = new Vector3(clampedX, rigidbody.velocity.y, clampedZ);
    }

    private IEnumerator DelayInput(float time)
    {
        yield return new WaitForSeconds(time);
        isInputAllowed = true;
    }
}
