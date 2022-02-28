using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManagement : MonoBehaviour
{
    private GameObject[] gameObjects;
    private bool wasTouched = false;

    private void Start()
    {
        gameObjects = new GameObject[2];
        gameObjects[0] = GameObject.FindGameObjectWithTag("Player1");
        gameObjects[1] = GameObject.FindGameObjectWithTag("Player2");
    }
    private void Update()
    {
        if (DataPlayer.isWinner != 0 && !wasTouched)
        {
            wasTouched = true;
            gameObjects[1 - (DataPlayer.isWinner - 1)].GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
