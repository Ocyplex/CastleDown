using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int health;

    void Start()
    {
        randomColor();
    }

    void randomColor()
    {
        int rand = Random.Range(0, 3);
        if(rand == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        } else if(rand == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        } else if (rand == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
