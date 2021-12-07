using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    private float mass;
    private float vel;
    private float maxSpeed;

    private float currentSpeed = 0;
    private bool canDrive = true;
    private int index = 0;

    private Rigidbody2D rb;
    private BoxCollider2D boxColl2d;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxColl2d = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        mass = DataPlayer.player.mass;
        vel = DataPlayer.player.vel;
        maxSpeed = DataPlayer.player.maxSpeed;

        currentSpeed = 10000 / mass * vel;
    }
    private void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > 3)           
            Run();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Player1") DataPlayer.isWinner = 1;
        else if (gameObject.name == "Player2") DataPlayer.isWinner = 2;
    }

    private void Run()
    {
        if (rb.velocity.x < maxSpeed)
            rb.AddForce(new Vector2(currentSpeed, 0) * Time.fixedDeltaTime * Mathf.Pow(rb.velocity.x, -1 / 3), ForceMode2D.Force);
        
    }

    public float GetPosition()
    {
        return transform.position.x;
    }

    public float GetVelocity()
    {
        return rb.velocity.x;
    }
}
// ленина 50, 14 этаж, 146 офис
