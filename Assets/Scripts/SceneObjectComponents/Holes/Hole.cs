using UnityEngine;
using System;

public abstract class Hole : MonoBehaviour
{
    public static event Action<Vector3, Action> BallInHole = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.transform.parent.GetComponent<Ball>();
        if (ball != null)
        {
            BallInHole(new Vector3(transform.position.x, 0f, transform.position.z), DoHoleEffect);
        }
    }

    public abstract void DoHoleEffect();
}
