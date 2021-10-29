using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private ShowCube myShowCube;
    public Bullet myBullet;
    private Cube myCube;
    private LevelCreator myLevelCreator;

    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myShowCube = FindObjectOfType<ShowCube>();
        StartCoroutine(RegularShooting());
    }

    private void Update()
    {

    }

    void Shoot()
    {
        Vector3 start = new Vector3(transform.position.x, transform.position.y - 0.6f,transform.position.z);
        myBullet.myCube = myCube;
        myBullet.hasTarget = true;
        Instantiate(myBullet, start, Quaternion.identity);
    }

    void FindNearestCube()
    {
        //Debug.Log("Found " + myLevelCreator.cubeList.Count + "cubes!");
        float nearest = 10f;

        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            float test = Vector3.Distance(transform.position, myLevelCreator.cubeList[i].transform.position);
            if(test < nearest && myLevelCreator.cubeList[i].myColor == myShowCube.myColor)
            {
                nearest = test;
                myCube = myLevelCreator.cubeList[i];
            }
        }     
    }


    void FindFarestCube()
    {
        float farest = 0; //Maybe Levelsize
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            float test = Vector3.Distance(transform.position, myLevelCreator.cubeList[i].transform.position);
            if (test > farest && myLevelCreator.cubeList[i].myColor == myShowCube.myColor)
            {
                farest = test;
                myCube = myLevelCreator.cubeList[i];
            }
        }
    }

    void RandomRange()
    {
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            FindFarestCube();
        }
        else
        {
            FindNearestCube();
        }
    }


    IEnumerator RegularShooting()
    {
        RandomRange();
        Shoot();
        yield return new WaitForSeconds(3-myLevelCreator.level);
        StartCoroutine(RegularShooting());
    }
}
