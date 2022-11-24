using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiationExample : MonoBehaviour
{
    public GameObject WhiteBlock;
    public double width = 13.5;
    public double height = 10;

    void Start()
    {
        for (float y = 0; y < height; y+=2)
        {
            for (float x = (float)-11.9; x < width; x+=3)
            {
                if(y<10)
                {
                    Instantiate(WhiteBlock, new Vector3(x, y, 0), Quaternion.identity);
                }
                
            }
        }
    }
}