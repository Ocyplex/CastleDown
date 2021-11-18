using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColor : MonoBehaviour
{
    [SerializeField]
    private Player myPlayer;
    

    void Start()
    {
        myPlayer = GetComponentInParent<Player>();
        SetColor();
    }

    void SetColor()
    {
        if(myPlayer.index == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }


}
