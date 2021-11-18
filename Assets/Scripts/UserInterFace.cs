using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UserInterFace : MonoBehaviour
{
    public Canvas myCanvas;
    private LevelCreator myLevelCreator;
    public GameObject menuCam;
    private GameMaster myGameMaster;
    public Text myText;
    public Text endText;
    public Text playerText;

    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        myCanvas = FindObjectOfType<Canvas>();
        myGameMaster = FindObjectOfType<GameMaster>();
    }

    public void SetDifficultyNormal()
    {
        myLevelCreator.level = 2;
        Reset();
    }

    public void SetDifficultyEasy()
    {
        myLevelCreator.level = 1;
        Reset();

    }

    public void SetDifficultyHard()
    {
        myLevelCreator.level = 3;
        Reset();

    }

    public void ActivateAll()
    {
        myCanvas.enabled = true;
        menuCam.SetActive(true);
    }

    private void Reset()
    {
        myCanvas.enabled = false;
        myGameMaster.gameON = true;
        menuCam.SetActive(false);
        myGameMaster.mySoundScript.MakeReset();
        myText.text = "Game created by Kevin Cicholinski";
    }

    public void ShowMusicInfo()
    {
        myText.text = "8Bit Menu by David Renda and Retro Platforming by David Fesliyan";
    }
    
    public void ShowStats()
    {
        endText.text = "Only " + myGameMaster.cubesLeft.ToString() + " cubes left!";
    }   

    public void JoinGame(PlayerInput playerInput)
    {
        playerText.text = myGameMaster.myPlayers.Count + 1 + "Player";
        Debug.Log("This");
    }
    

}
