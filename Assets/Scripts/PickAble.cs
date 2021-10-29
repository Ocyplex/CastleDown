using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAble : MonoBehaviour
{

    private LevelCreator myLevelCreator;
    private ShowCube myShowCube;
    private float rotationSpeed = 25f;


    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myShowCube = FindObjectOfType<ShowCube>();
    }
    private void Update()
    {
        RotateMe();
        MyColor();
    }

    void ChangeColores()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            myLevelCreator.cubeList[i].RandomColor();
        }
    }

    void RotateMe()
    {
        float xAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(xAngle,xAngle,xAngle);
    }

    public void UseMe(Player myPlayer_)
    {
        if(gameObject.name==("Pill(Clone)"))
        { 
        ChangeColores();
        GravityCubes();
        }else if(gameObject.name==("Line(Clone)"))
        {
            myPlayer_.LineUse();
            myLevelCreator.GiveStats();
        }else if(gameObject.name == ("Magic(Clone)"))
        {
            int listOld = myLevelCreator.cubeList.Count;
            for (int i = 0; i < listOld; i++)
            {
                if(myLevelCreator.cubeList[i].GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color)
                {                  
                    myLevelCreator.cubeList[i].DeleteMeFromList();
                }
            }
        }
        Destroy(this.gameObject);
    }

    private void MyColor()
    {
        if (gameObject.name == ("Magic(Clone)"))
        {
            gameObject.GetComponent<Renderer>().material.color = myShowCube.GetComponent<Renderer>().material.color;

        }
    }
    
    void GravityCubes()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            myLevelCreator.cubeList[i].gravityBool = true;
        }
    }

}
