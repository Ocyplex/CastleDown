using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]private Player myPlayer;
    [SerializeField] private LevelCreator myLevelCreator;
    [SerializeField] private ShowCube myShowCube;
    [SerializeField] private Gun myGun;
    [SerializeField]private List<PickAble> pickAbleList;
    [SerializeField] private UserInterFace myUI;
    [SerializeField] public SoundScript mySoundScript;
    public int cubesLeft = 0;
    public bool gameON = false;
    


    void Start()
    {
        myLevelCreator = GetComponent<LevelCreator>();
        myUI = GetComponent<UserInterFace>();
        mySoundScript = GetComponent<SoundScript>();
    }

  


    void Update()
    {
        if(gameON && myPlayer != null)
        { 

        CheckPlayerDead();
        }
    }

    public void AddMe(Player myPlayer_)
    {
        myPlayer = myPlayer_;
    }

    public void AddMe(Gun myGun_)
    {
        myGun = myGun_;
    }

    public void AddMe(ShowCube myShowCube_)
    {
        myShowCube = myShowCube_;
    }

    public void AddMe(PickAble myPickAble_)
    {
        pickAbleList.Add(myPickAble_);
    }

    public void SaveCubes()
    {
        Debug.Log("I return Cubes " + myLevelCreator.cubeList.Count);
        cubesLeft = myLevelCreator.cubeList.Count;
    }


    void CheckPlayerDead()
    {
        if (myPlayer.transform.position.y < -5f && myPlayer != null)
        {
            SaveCubes();
            gameON = false;
            ActivateUI();
            Destroy(myPlayer.gameObject);
            DeleteLevel();
            myLevelCreator.isRunning = false;
            myPlayer = null;
            mySoundScript.MakeReset();
        }
    }

    void DeleteLevel()
    {
        int realLenght = myLevelCreator.cubeList.Count;
        for (int i = 0; i < realLenght; i++)
        {
            myLevelCreator.DeleteAll();
        }
        myGun.DeleteMe();
        myShowCube.DeleteMe();
        DeleteAllPickable();

    }

    void ActivateUI()
    {
        myUI.ActivateAll();
        
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DeletePickAbleFromList(PickAble pickAble_)
    {
        int realCount = pickAbleList.Count;
        for (int i = 0; i < realCount; i++)
        {
            if(pickAbleList[i] == pickAble_)
            {
                pickAbleList.RemoveAt(i);
                Destroy(pickAble_.gameObject);
            }
        }
    }

    void DeleteAllPickable()
    {

        int realCount = pickAbleList.Count;
        for (int i = 0; i < realCount; i++)
        {
            Destroy(pickAbleList[i].gameObject);
        }
        pickAbleList.Clear();
    }
}
