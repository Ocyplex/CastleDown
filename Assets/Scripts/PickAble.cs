using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAble : MonoBehaviour
{

    private LevelCreator myLevelCreator;
    private float rotationSpeed = 25f;


    void Start()
    {
        myLevelCreator = FindObjectOfType<LevelCreator>();
    }
    private void Update()
    {
        RotateMe();
    }

    void ChangeColores()
    {
        for (int i = 0; i < myLevelCreator.cubeList.Count; i++)
        {
            myLevelCreator.cubeList[i].RandomColor();
        }
    }

    void RotateMe()
    {
        float xAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(xAngle,xAngle,xAngle);
    }

    public void UseMe()
    {
        ChangeColores();
        Destroy(this.gameObject);
    }


}
