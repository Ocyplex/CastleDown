using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCube : MonoBehaviour
{

    public Light myLight;

    private void Start()
    {
    }

    public void setLightRange(int lightRange_)
    {
        myLight.range = lightRange_;
    }

}
