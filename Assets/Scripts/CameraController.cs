using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform trans;
    [SerializeField] private RoadGenerator road;
    private void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();    
    }
    private void Update()
    {
        if (transform.position.x < road.transform.position.x + road.width * road.count)
            transform.position = new Vector3(trans.position.x + 2,transform.position.y,-10);
    }
}
