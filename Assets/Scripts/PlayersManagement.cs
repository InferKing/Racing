using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManagement : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    private bool wasTouched = false;
    private void Update()
    {
        if (DataPlayer.isWinner != 0 && !wasTouched)
        {
            wasTouched = true;
            gameObjects[1 - (DataPlayer.isWinner - 1)].GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
