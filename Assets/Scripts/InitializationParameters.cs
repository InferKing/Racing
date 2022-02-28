using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializationParameters : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    // [SerializeField] private Sprite[] spritesDetail;
    public List<List<Detail>> detailList = new List<List<Detail>>();
    private static List<Detail> massList = new List<Detail>();
    private static List<Detail> velList = new List<Detail>();
    private static List<Detail> maxSpeedList = new List<Detail>();
    private static List<Detail> transmList = new List<Detail>();

    private void Awake()
    {

        // create details

        detailList.Add(massList);
        detailList.Add(velList);
        detailList.Add(maxSpeedList);
        detailList.Add(transmList);

        for (int i = 0; i <= 4; i++)
        {
            Detail tempDetail = new Detail();
            // tempDetail.sprite = spritesDetail[Random.Range(0,spritesDetail.Length-1)];
            tempDetail.level = i*2 + 1;
            tempDetail.mass = 1700 - i * 50;
            tempDetail.vel = 5 * i;
            tempDetail.maxSpeed = 2 * i;
            tempDetail.transm = 0;
            tempDetail.price = 1000 * (i + 2);
            massList.Add(tempDetail);
            tempDetail = new Detail();
            tempDetail.level = i * 3 + 1;
            tempDetail.mass = -5 * i;
            tempDetail.vel = 50 + i * 20;
            tempDetail.maxSpeed = 4 * i + 1;
            tempDetail.transm = -0.07f * i / 2;
            tempDetail.price = 1700 * (i + Mathf.Pow(2,i));
            velList.Add(tempDetail);
            tempDetail = new Detail();
            tempDetail.level = i * 2 + 1;
            tempDetail.mass = 4 + i * 7;
            tempDetail.vel = -2 * (i + 1);
            tempDetail.maxSpeed = 120 + i * 25;
            tempDetail.transm = 0.04f * i;
            tempDetail.price = 1200 * (i + 2);
            maxSpeedList.Add(tempDetail);
            tempDetail = new Detail();
            tempDetail.level = i * 4 + 1;
            tempDetail.mass = i * 3 + 1;
            tempDetail.vel = 4 * (i + 3);
            tempDetail.maxSpeed = 5 * i;
            tempDetail.transm = 0.8f - 0.08f * i;
            tempDetail.price = 2500 * (i + Mathf.Pow(2, i));
            transmList.Add(tempDetail);
        }

        // should make JSON

        DataPlayer.player = SetParams(DataPlayer.level);

    }
    private void Start()
    {
        SceneManagment.MainMenu();
    }

    public static Player SetParams(int level)
    {
        Player plr;
        float tmp1, tmp2, tmp3, tmp4;
        int index = -1;
        Detail tempDetail1, tempDetail2, tempDetail3, tempDetail4;
        foreach (Detail item in massList)
        {
            if (item.level <= level)
            {
                index++;
            }
        }
        tempDetail1 = massList[Random.Range(0, index)];
        index = -1;
        foreach (Detail item in velList)
        {
            if (item.level <= level)
            {
                index++;
            }
        }
        tempDetail2 = velList[Random.Range(0, index)];
        index = -1;
        foreach (Detail item in maxSpeedList)
        {
            if (item.level <= level)
            {
                index++;
            }
        }
        tempDetail3 = maxSpeedList[Random.Range(0, index)];
        index = -1;
        foreach (Detail item in transmList)
        {
            if (item.level <= level)
            {
                index++;
            }
        }
        tempDetail4 = transmList[Random.Range(0, index)];
        tmp1 = tempDetail1.mass + tempDetail2.mass + tempDetail3.mass + tempDetail4.mass;
        tmp2 = tempDetail1.vel + tempDetail2.vel + tempDetail3.vel + tempDetail4.vel;
        tmp3 = tempDetail1.maxSpeed + tempDetail2.maxSpeed + tempDetail3.maxSpeed + tempDetail4.maxSpeed;
        tmp4 = tempDetail1.transm + tempDetail2.transm + tempDetail3.transm + tempDetail4.transm;
        plr = new Player("0",tmp1,tmp2,tmp3,tmp4);
        return plr;
    }
}
