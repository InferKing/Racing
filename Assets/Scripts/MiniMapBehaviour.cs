using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapBehaviour : MonoBehaviour
{
    [SerializeField] private RoadGenerator road;
    private CarBehaviour player;
    private bool onEnd = false;

    private float endPos, startPos, winPos; // 15.6f from 0.0 --- 1981.18 from 0.0

    private void Start()
    {
        if (gameObject.name == "Player1map")
        {
            player = GameObject.FindGameObjectWithTag("Player1").GetComponent<CarBehaviour>();
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarBehaviour>();
        }
        //endPos = road.GetDistance().Item2;
        //startPos = player.GetPosition();
        winPos = 15.6f / (road.GetDistance().Item2 - road.GetDistance().Item1); // посчитано руками, поменять
    }

    private void Update()
    {
        if (transform.localPosition.x >= road.GetDistance().Item2 * winPos - 3.1f && !onEnd)
        {
            transform.localPosition = new Vector3(road.GetDistance().Item2 * winPos - 3.1f, transform.localPosition.y, transform.localPosition.z);
            onEnd = true;
        }
        if (!onEnd)
        {
            transform.localPosition = new Vector3((player.GetPosition() - 10) * winPos - 3.1f, transform.localPosition.y, transform.localPosition.z);
        }
    }

}
