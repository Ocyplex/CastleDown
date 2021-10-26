using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAble : MonoBehaviour
{

    private LevelCreator myLevelCreator;
    public bool changeColor = false;

    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
    }
    private void Update()
    {
        if(changeColor)
        {
            ChangeColores();
        }
    }

    void ChangeColores()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            myLevelCreator.cubeList[i].RandomColor();
            changeColor = false;
        }
    }

}
