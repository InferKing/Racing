using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
     private GameObject[] players;

    private void Awake()
    {
        players = new GameObject[2];
        players[0] = Instantiate(DataManager.gameObjects[int.Parse(DataPlayer.player.sprite)]);
        players[0].tag = "Player1";
        players[0].transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z);
        players[0].AddComponent<CarBehaviour>();
        players[0].name = "Player 1";
        players[1] = Instantiate(DataManager.gameObjects[int.Parse(DataPlayer.enemy.sprite)]);
        players[1].tag = "Player2";
        players[1].transform.position = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
        players[1].AddComponent<CarBehaviour>();
        players[1].name = "Player 2";
    }

    public static void AddPrize()
    {
        DataPlayer.money += Mathf.RoundToInt(1000 / DataPlayer.isWinner * DataPlayer.level / 2);
        DataPlayer.curExp += Mathf.RoundToInt(500 / DataPlayer.isWinner);
        if (DataPlayer.curExp >= DataPlayer.maxLvlExp)
        {
            DataPlayer.curExp -= DataPlayer.maxLvlExp;
            DataPlayer.maxLvlExp *= 2;
            DataPlayer.level += 1;
        }
        DataPlayer.isWinner = 0;
    }
}
