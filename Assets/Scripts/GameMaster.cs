using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private Player myPlayer;
    private LevelCreator myLevelCreator;
    private ShowCube myShowCube;
    private Gun myGun;
    private PickAble[] myPickAbles = new PickAble[3];
    [SerializeField] private UserInterFace myUI;
    public bool gameON;
    // Start is called before the first frame update
    void Start()
    {
        myLevelCreator = GetComponent<LevelCreator>();
        myUI = GetComponent<UserInterFace>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameON)
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
        for (int i = 0; i < 3; i++)
        {
            if (myPickAbles[i] == null)
            {
                myPickAbles[i] = myPickAble_;
                break;
            }
        }
    }


    void CheckPlayerDead()
    {
        if (myPlayer.transform.position.y < -5f)
        {
            Debug.Log("Jere");
            DeleteLevel();
            ActivateUI();
            Destroy(myPlayer.gameObject);
            gameON = false;
        }
    }

    void DeleteLevel()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            myLevelCreator.DeleteAll();
        }
        Destroy(myGun.gameObject);
        Destroy(myShowCube.gameObject);
        for (int i = 0; i < myPickAbles.Length; i++)
        {
            Destroy(myPickAbles[i].gameObject);
        }    
    }

    void ActivateUI()
    {
        myUI.ActivateAll();
        Cursor.lockState = CursorLockMode.Confined;
    }
}
