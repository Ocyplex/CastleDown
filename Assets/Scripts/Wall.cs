using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    void Start()
    {
        setColor();
    }

    public void setColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

}
