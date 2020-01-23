using UnityEngine;
using System;

public class BoardBottomBottom : MonoBehaviour
{
    public event Action FallEnded = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if(ball!=null)
        {
            ball.EndFall();
            FallEnded();
        }
    }
}
