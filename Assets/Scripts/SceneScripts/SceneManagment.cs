using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagment : MonoBehaviour
{
    public static void StartRace()
    {
        SceneManager.LoadScene("Racing");
    }
    public static void EnemyChoosing()
    {
        SceneManager.LoadScene("ChoosingEnemy");
    }
    public static void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void Garage()
    {
        SceneManager.LoadScene("Garage");
    }
}
