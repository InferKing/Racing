using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Text text;
    private Player player;
    private void Start()
    {
        ShowEnemy();
    }
    private Player GetPlayer()
    {
        player = InitializationParameters.SetParams(DataPlayer.level + 1);
        return player;
    }

    public void SetEnemy()
    {
        DataPlayer.enemy = player;
    }

    public void ShowEnemy()
    {
        player = GetPlayer();
        text.text = $"����� ������: {player.mass}\n��������� ������: {player.vel}\n" +
            $"������������ �������� ������: {player.maxSpeed}\n�����������: {Mathf.Round(player.transm * 100) / 100f}";
    }
}
