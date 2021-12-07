using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializationParameters : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private BoxCollider2D boxCol2D;
    
    private void Awake()
    {
        Player player = new Player(sprite, rb2D, boxCol2D, 1500, 50, 70);
        DataPlayer.player = player;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManagment.MainMenu();
    }
    
}
