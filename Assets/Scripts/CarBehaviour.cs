using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    private float[] transm;

    private float mass;
    private float vel;
    private float maxSpeed;
    private float transmTime;
    private float minY, maxY, tm;
    private int isUp, countTransm = 1;

    private float currentSpeed = 0;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.tag == "Player1")
        {
            mass = DataPlayer.player.mass;
            vel = DataPlayer.player.vel;
            maxSpeed = DataPlayer.player.maxSpeed;
            transmTime = DataPlayer.player.transm;
        }
        else
        {
            mass = DataPlayer.enemy.mass;
            vel = DataPlayer.enemy.vel;
            maxSpeed = DataPlayer.enemy.maxSpeed;
            transmTime = DataPlayer.enemy.transm;
        }

        transm = new float[5];
        for (int i = 0; i < 5; i++)
        {
            transm[i] = maxSpeed / 6 * (i + 1);
        }


        currentSpeed = 10000 / mass * vel;

        minY = transform.position.y - 0.3f;
        maxY = transform.position.y + 0.4f;
        isUp = Mathf.RoundToInt(Random.value) * 2 - 1;
        tm = rb.velocity.x / maxSpeed;

        StartCoroutine(Run(transmTime));
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > 3)
        {
            tm = rb.velocity.x / maxSpeed;
            if (transform.position.y < maxY && transform.position.y > minY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0004f * tm * isUp , transform.position.z);
            }
            else if (transform.position.y >= maxY)
            {
                isUp = -1;
                transform.position = new Vector3(transform.position.x, maxY - 0.0001f, transform.position.z);
            }
            else if (transform.position.y <= minY)
            {
                isUp = 1;
                transform.position = new Vector3(transform.position.x, minY + 0.0001f, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            StopCoroutine("Run");
            rb.drag = 2f;
            if (gameObject.name == "Player 1") { DataPlayer.isWinner = 1; }
            else if (gameObject.name == "Player 2") { DataPlayer.isWinner = 2; }
        }
    }

    private bool IsInRange()
    {
        for (int i = 0; i < 5; i++)
        {
            if (rb.velocity.x > transm[i] - 1f && rb.velocity.x < transm[i] + 1f)
            {
                transm[i] = -1f;
                countTransm++;
                return true;
            }
        }
        return false;
    }

    public float GetPosition()
    {
        return transform.position.x;
    }

    public float GetVelocity()
    {
        return rb.velocity.x;
    }

    private IEnumerator Run(float t)
    {
        
        while (true)
        {
            if (Time.timeSinceLevelLoad > 3)
            {
                
                if (!IsInRange())
                {
                    if (rb.velocity.x < maxSpeed)
                        rb.AddForce(new Vector2(currentSpeed, 0) * 0.01f * Mathf.Pow(rb.velocity.x, 1/2) * Mathf.Pow(2f,1/countTransm), ForceMode2D.Force);
                    yield return new WaitForSeconds(0.005f);
                }
                else
                {
                    yield return StartCoroutine(TransmissionTime(t));
                }
            }
            yield return null;
        }
    }

    private IEnumerator TransmissionTime(float t)
    {
        float x = 0, xSpeed = rb.velocity.x;
        while (x < t)
        {
            x += 0.005f;
            rb.AddForce(new Vector2(currentSpeed, 0) * 0.01f * Mathf.Pow(rb.velocity.x, 1/2) * Mathf.Pow(2f, 1 / countTransm) * 0.25f, ForceMode2D.Force);
            yield return new WaitForSeconds(0.005f);
        }
        yield return null;
    }
}
// ленина 50, 14 этаж, 146 офис
