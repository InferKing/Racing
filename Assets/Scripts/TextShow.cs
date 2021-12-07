using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    [SerializeField] private RoadGenerator road;
    [SerializeField] private CarBehaviour car;
    [SerializeField] private GameObject[] gObj;
    private float total;

    private void Update()
    {
        if (DataPlayer.isWinner != 0)
            gObj[DataPlayer.isWinner - 1].SetActive(true);
        SetText();
    }

    private void SetText()
    {
        total = Mathf.Round((car.GetPosition() / road.GetDistance().Item2)  * 100 - 0.15f);
        if (total > 100)
            total = 100;
        gObj[2].GetComponent<Text>().text = $"Total: {total}%";
        gObj[3].GetComponent<Text>().text = $"Current Speed: {Mathf.Round(car.GetVelocity()-0.2f)}";
        if (Time.timeSinceLevelLoad < 2.8f)
        {
            gObj[4].GetComponent<Text>().text = $"{Mathf.Round(3.3f - Time.timeSinceLevelLoad)}";
        }
        else if (Time.timeSinceLevelLoad > 2.8f && Time.timeSinceLevelLoad < 5) gObj[4].GetComponent<Text>().text = "Go!";
        else gObj[4].GetComponent<Text>().text = "";

    }
}
