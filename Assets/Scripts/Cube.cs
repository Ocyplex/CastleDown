using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private LevelCreator myLevelCreator;
    public string myColor;
    public int health;

    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        RandomColor();
        AddMeToList();
    }

    void AddMeToList()
    {
        myLevelCreator.cubeList.Add(this);
    }

    public void RandomColor()
    {
        int rand = Random.Range(0, 3);
        if(rand == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            myColor = "green";
        } else if(rand == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            myColor = "red";
        } else if (rand == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            myColor = "blue";
        }
    }
    public void DeleteMeFromList()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            if(myLevelCreator.cubeList[i]==this)
            {
                myLevelCreator.cubeList.RemoveAt(i);
            }
        }
        
    }
}
