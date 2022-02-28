using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageController : MonoBehaviour
{
    [SerializeField] private GameObject carPosition;
    [SerializeField] private GameObject playerInfoPosition;
    [SerializeField] private GameObject carInfo;
    private GameObject car;
    private string text;
    private void Start()
    {
        car = Instantiate(DataManager.gameObjects[int.Parse(DataPlayer.player.sprite)]);
        car.transform.position = carPosition.transform.position;
        car.transform.localScale *= 1.8f;

        StartCoroutine(MoveCar(car));

        text = $"Money: {DataPlayer.money}$\nLevel: {DataPlayer.level} ({DataPlayer.curExp}/{DataPlayer.maxLvlExp})";
       
        playerInfoPosition.GetComponent<Text>().text = text;

        text = $"Mass: {DataPlayer.player.mass} kg.\n\nVelocity: {DataPlayer.player.vel}\n\n" +
            $"Max speed: {DataPlayer.player.maxSpeed} km/h\n\nTransmission time: {DataPlayer.player.transm} sec.";

        carInfo.GetComponent<Text>().text = text;
    }

    private IEnumerator MoveCar(GameObject gObj)
    {
        while (true)
        {
            gObj.transform.position = new Vector3(gObj.transform.position.x, 
                gObj.transform.position.y + Mathf.Sin(Time.timeSinceLevelLoad * 4) / 500f, gObj.transform.position.z);
            yield return null;
        }
    }
}
