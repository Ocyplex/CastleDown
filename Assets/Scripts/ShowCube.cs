using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCube : MonoBehaviour
{
    private LevelCreator myLevelCreator;
    private GameMaster myGameMaster;
    public Light myLight;
    public string myColor;
    public int changer;
    
    private void Start()
    {
        myLevelCreator = FindObjectOfType <LevelCreator>();
        myGameMaster = FindObjectOfType<GameMaster>();
        myGameMaster.AddMe(this);
        StartCoroutine(RandColor());   
    }


    public void setLightRange(int lightRange_)
    {
        myLight.range = lightRange_ * 1.5f;
    }



    IEnumerator RandColor()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0 && myLevelCreator.greenCubes > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            myColor = "green";
        }
        else if (rand == 1 && myLevelCreator.redCubes > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            myColor = "red";
        }
        else if (rand == 2 && myLevelCreator.blueCubes > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            myColor = "blue";
        }
        yield return new WaitForSeconds(4-changer);
        StartCoroutine(RandColor());
    }

    public void DeleteMe()
    {
            Destroy(this.gameObject);
    }

}
