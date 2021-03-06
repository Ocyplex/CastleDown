using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private ShowCube myShowCube;
    private float fireRate = 0;
    public Bullet myBullet;
    [SerializeField]public Cube myCube;
    private LevelCreator myLevelCreator;
    private AudioSource myGunSound;
    private GameMaster myGameMaster;
    private bool reseted = false;
    private CanonRotator myCR;
    private CanonBarrel myCB;


    void Start()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myShowCube = FindObjectOfType<ShowCube>();
        myGunSound = GetComponent<AudioSource>();
        myGameMaster = FindObjectOfType<GameMaster>();
        myGameMaster.AddMe(this);
        myCR = FindObjectOfType<CanonRotator>();
        //myCB = FindObjectOfType<CanonBarrel>();
        myCR.AddGunScript(this);
        StartCoroutine(RegularShooting());
    }

    private void Update()
    {
        if(myCube == null && myGameMaster.gameON && !reseted)
        {
            Debug.Log("Make reset!");
            reseted = true;
        }
    }

    void Shoot()
    {
        myBullet.myCube = myCube;
        myBullet.hasTarget = true;
        myCR.Shoot(myBullet);
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
        }
        else if(rand == 1)
        {
            FindNearestCube();
        }
        else if(rand == 2)
        {
            FindRandomCube();
        }
    }

    public void IncreaseFireRate()
    {
        fireRate = myLevelCreator.level * 0.1f;
    }


    IEnumerator RegularShooting()
    {
        //RandomRange();
        FindRandomCube();
        myCR.RotateToTarget();
        //myCB.RotateToTarget();
        Shoot();
        yield return new WaitForSeconds(3.5f-myLevelCreator.level - fireRate);
        StartCoroutine(RegularShooting());
    }

    public void DeleteMe()
    {
            StopCoroutine(RegularShooting());
            Destroy(this.gameObject);
    }

    public void ResetAim()//When pickable destroy aim cube of gun
    {
        StopCoroutine(RegularShooting());
    }


}
