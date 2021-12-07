using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private RoadGenerator road;
    private void Update()
    {
        if (transform.position.x < road.transform.position.x + road.width * road.count)
            transform.position = new Vector3(trans.position.x,transform.position.y,-10);
    }
}
