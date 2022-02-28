using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string sprite;
    public float mass;
    public float vel;
    public float maxSpeed;
    public float transm;

    public Player(string sprite, float mass, float vel, float maxSpeed, float transm)
    {
        this.sprite = sprite;
        this.mass = mass;
        this.vel = vel;
        this.maxSpeed = maxSpeed;
        this.transm = transm;
    }
}

public class Detail : MonoBehaviour
{
    public Sprite sprite { get; set; }
    public float mass { get; set; }
    public float vel { get; set; }
    public float maxSpeed { get; set; }
    public float transm { get; set; }
    public float price { get; set; }
    public int level;

}
