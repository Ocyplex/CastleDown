using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCube : MonoBehaviour
{

    public Light myLight;
    public string myColor;

    private void Start()
    {
        StartCoroutine(RandColor());
        
    }

    public void setLightRange(int lightRange_)
    {
        myLight.range = lightRange_ * 1.5f;
    }



    IEnumerator RandColor()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            myColor = "green";
        }
        else if (rand == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            myColor = "red";
        }
        else if (rand == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            myColor = "blue";
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(RandColor());
    }
}
