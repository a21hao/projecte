using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    public void setSpeed(float s)
    {
        speed = s;
    }

    public void setDirection(Vector3 d)
    {
        direction = d;
    }

    public void setRotation(float alfa)
    {
        transform.localRotation = Quaternion.Euler(0, 0, alfa);
    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void Move(float s, Vector3 d)
    {
        transform.position += d * s * Time.deltaTime;
    }

    public void Move(Vector3 d)
    {
        transform.position += d * speed * Time.deltaTime;
    }
}

