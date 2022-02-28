using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    public int count;
    public float width;
    private GameObject gObj;
    private BoxCollider2D boxColl;
    private void Start()
    {
        for (int i = 0; i < count+1; i++)
        {
            gObj = Instantiate(gameObj);
            gObj.transform.position = new Vector2(transform.position.x + width * i, transform.position.y);
            if (i == count)
            {
                gObj.tag = "Finish";
                boxColl = gObj.AddComponent<BoxCollider2D>();
                boxColl.isTrigger = true;
            }
        }
    }

    public (float,float) GetDistance()
    {
        return (transform.position.x, transform.position.x + width * count);
    }

}
