using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private float direction;
    
    private void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
    public void Move(Vector3 d)
    {
        d.Normalize();
        transform.position += d * speed * Time.deltaTime;
    }

    public void MoveWithOtherSpeed(Vector3 d, float speed2)
    {
        d.Normalize();
        transform.position += d * speed2 * Time.deltaTime;
    }
    public void MoveRB2D(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    public void MoveRB2D2(Vector2 dir)
    {
        dir.Normalize();
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
    public void MoveProvisional(float direction, float s)
    {
        float dir = direction;

        if (Physics2D.gravity.y < 0)
        {
            dir = -dir;
        }

        Vector2 newPosition = rb.position + Vector2.right * dir * s * Time.deltaTime;
        rb.MovePosition(newPosition);

        
        //transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

    }
    public void Flip(float escala)
    {
        Vector3 scale = transform.localScale;
        scale.x = escala;
        transform.localScale = scale;
    }
    public void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Para que salte el muñeco le doy un impulso con una variable 

    }

    public void MoveDirection(float move)
    {
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
    }

    public void RotationObject(Vector3 dir)
    {
        float alfa = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, alfa);
    }

    
}
