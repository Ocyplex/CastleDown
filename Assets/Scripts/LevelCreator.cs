﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{

    public Cube myCube;
    public Wall myWall;
    public ShowCube myShowCube;
    public Gun myGun;
    public PickAble[] myPickable = new PickAble[3];
    private Vector3[] wallPos;
    private int levelSize = 16; // Must be even number
    public List<Cube> cubeList;
    public int level = 1; //hardness

    void Start()
    {
        wallPos = new Vector3[4];
        CreateWallPos();
        createLevel();
    }

    void createLevel()
    {
        Debug.Log("Create Level");
        for (int i = 0; i < levelSize; i++)
        {
            for (int j = 0; j < levelSize; j++)
            {
                Instantiate(myCube,new Vector3(transform.position.x + i,transform.position.y,transform.position.z + j), Quaternion.identity);
            }
        }
        CreateShowCube();
        CreateWalls();
        SpawnGun();
        SpawnPickAble();
        GiveStats();
    }

    void CreateShowCube()
    {
        myShowCube.setLightRange(levelSize);
        Instantiate(myShowCube, new Vector3(transform.position.x - 0.5f + levelSize / 2, transform.position.y + 5, transform.position.z - 0.5f + levelSize / 2), Quaternion.identity);
    }

    void CreateWalls()
    {
        Vector3 scaleChange = new Vector3(levelSize, 3f, 1f);
        myWall.transform.localScale = scaleChange;
        for (int i = 0; i < wallPos.Length; i++)
        {
            if(i<2)
            {
                Instantiate(myWall, wallPos[i], Quaternion.identity);
            }
            else if(i>=2)
            {
                Instantiate(myWall, wallPos[i], Quaternion.Euler(0, 90f, 0));
            }
        }
    }

    void CreateWallPos()
    {
        wallPos[0] = new Vector3(levelSize/2 -0.5f ,1, transform.position.z + levelSize);
        wallPos[1] = new Vector3(levelSize / 2 - 0.5f, 1, -1);
        wallPos[2] = new Vector3(-1, 1, levelSize / 2 - 0.5f);
        wallPos[3] = new Vector3(levelSize +transform.position.x, 1, levelSize / 2 - 0.5f);
    }

    void SpawnPickAble()
    {

        for (int i = 0; i < myPickable.Length; i++)
        {
            float randx = Random.Range(0, levelSize);
            float randz = Random.Range(0, levelSize);
            Instantiate(myPickable[i], new Vector3(randx, 2f, randz), Quaternion.identity);
        }
    }

    void SpawnGun()
    {
        float randx = Random.Range(2, levelSize-2);
        float randz = Random.Range(2, levelSize-2);
        Instantiate(myGun, new Vector3(randx, 5f, randz), Quaternion.identity);
    }


    public void GiveStats()
    {
        int blue = 0; int red = 0; int green = 0;
        for (int i = 0; i < cubeList.Count; i++)
        {
            if(cubeList[i].GetComponent<Renderer>().material.color == Color.red)
            {
                red++;
            } else if(cubeList[i].GetComponent<Renderer>().material.color == Color.green)
            {
                green++;
            } else if(cubeList[i].GetComponent<Renderer>().material.color == Color.blue)
            {
                blue++;
            }
        }
        Debug.Log("Blue:" + blue + " Red:" + red + " Green:" + green);
    }

}

