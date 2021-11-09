using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotator : MonoBehaviour
{
    private Gun myGun;
    public GameObject myBody;
    public Cube myCube;
    private float rotationSpeed = 60f;


    void Update()
    {
        //TestRotation();
    }

    public void RotateToTarget()
    {

        myCube = myGun.myCube;
        Vector3 dir = new Vector3(myCube.transform.position.x, myBody.transform.position.y, myCube.transform.position.z) - myBody.transform.position;
        //Physics.Raycast(transform.position, dir, 8);
        //Debug.DrawRay(transform.position, dir, Color.green, 5f);

      
        float rotationZ = Mathf.Atan2(-dir.x, dir.z) * Mathf.Rad2Deg;
        Debug.Log(rotationZ);
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);



    }

    private void TestRotation()
    {
        transform.Rotate(new Vector3(0, 0, 30f) * rotationSpeed * Time.deltaTime);
    }

    public void AddGunScript(Gun myGun_)
    {
        myGun = myGun_;
    }
}
