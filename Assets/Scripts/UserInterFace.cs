using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterFace : MonoBehaviour
{
    public Canvas myCanvas;
    private LevelCreator myLevelCreator;
    private Camera menuCam;
    private GameMaster myGameMaster;


    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
        menuCam = FindObjectOfType<Camera>();
        myCanvas = FindObjectOfType<Canvas>();
        myGameMaster = FindObjectOfType<GameMaster>();
    }

    public void SetDifficultyNormal()
    {
        myLevelCreator.level = 2;
        myCanvas.enabled = false;
        menuCam.enabled = false;
        myGameMaster.gameON = true;
    }

    public void SetDifficultyEasy()
    {
        myLevelCreator.level = 1;
        myCanvas.enabled = false;
        menuCam.enabled = false;
        myGameMaster.gameON = true;
    }

    public void SetDifficultyHard()
    {
        myLevelCreator.level = 3;
        myCanvas.enabled = false;
        menuCam.enabled = false;
        myGameMaster.gameON = true;
    }

    public void ActivateAll()
    {
        myCanvas.enabled = true;
        menuCam.enabled = true;
    }

}
