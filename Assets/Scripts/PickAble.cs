using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAble : MonoBehaviour
{

    private LevelCreator myLevelCreator;
    private GameMaster myGameMaster;
    private ShowCube myShowCube;
    private Gun myGun;
    private float rotationSpeed = 25f;


    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myShowCube = FindObjectOfType<ShowCube>();
        myGameMaster = FindObjectOfType<GameMaster>();
        myGun = FindObjectOfType<Gun>();
        myGameMaster.AddMe(this);
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
        myLevelCreator.CheckCubeAmount();
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
        }else if(gameObject.name==("Line(Clone)"))
        {
            myPlayer_.LineUse();
            myLevelCreator.GiveStats();
            myGun.IncreaseFireRate();
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
            myGun.ResetAim();
            GravityCubes();
        }
        myGameMaster.DeletePickAbleFromList(this);
    }

    private void MyColor()
    {
        if (gameObject.name == ("Magic(Clone)") & myShowCube != null)
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
