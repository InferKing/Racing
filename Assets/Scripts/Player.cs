using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb2D;
    public BoxCollider2D coll2D;
    public float mass;
    public float vel;
    public float maxSpeed;

    public Player(SpriteRenderer sprite, Rigidbody2D rb2D, BoxCollider2D coll2D, float mass, float vel, float maxSpeed)
    {
        this.sprite = sprite;
        this.rb2D = rb2D;
        this.coll2D = coll2D;
        this.mass = mass;
        this.vel = vel;
        this.maxSpeed = maxSpeed;
    }
}
