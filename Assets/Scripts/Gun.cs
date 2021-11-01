using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private ShowCube myShowCube;
    public Bullet myBullet;
    private Cube myCube;
    private LevelCreator myLevelCreator;
    private AudioSource myGunSound;
    private GameMaster myGameMaster;




    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myShowCube = FindObjectOfType<ShowCube>();
        myGunSound = GetComponent<AudioSource>();
        myGameMaster = FindObjectOfType<GameMaster>();
        myGameMaster.AddMe(this);
        StartCoroutine(RegularShooting());
    }

    private void Update()
    {
        DeleteMe();
    }

    void Shoot()
    {
        Vector3 start = new Vector3(transform.position.x, transform.position.y - 0.6f,transform.position.z);
        myBullet.myCube = myCube;
        myBullet.hasTarget = true;
        Instantiate(myBullet, start, Quaternion.identity);
        myGunSound.Play();
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

    void FindRandomCube()
    {
        int rand = Random.Range(0, myLevelCreator.cubeList.Count);
        if(myLevelCreator.cubeList[rand].myColor == myShowCube.myColor)
        {
            myCube = myLevelCreator.cubeList[rand];
        }else
        {
            FindRandomCube();
        }
    }

    void RandomRange()
    {
        int rand = Random.Range(0, 3);
        if(rand == 0)
        {
            FindFarestCube();
            Debug.Log("Farest");
        }
        else if(rand == 1)
        {
            FindNearestCube();
            Debug.Log("Nearest");
        }
        else if(rand == 2)
        {
            FindRandomCube();
            Debug.Log("Random");
        }
    }


    IEnumerator RegularShooting()
    {
        RandomRange();
        Shoot();
        yield return new WaitForSeconds(3.5f-myLevelCreator.level);
        StartCoroutine(RegularShooting());
    }

    void DeleteMe()
    {
        if(myLevelCreator.deleteLevel)
        {
            Destroy(this.gameObject);
        }
    }
}
