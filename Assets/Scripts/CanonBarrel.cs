using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBarrel : MonoBehaviour
{
    private CanonRotator myCR;
    [SerializeField] private Cube myCube;
    public GameObject myBody;
    // Start is called before the first frame update
    void Start()
    {
        myCR = GetComponentInParent<CanonRotator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateToTarget()
    {
        myCube = myCR.myCube;
        Vector3 dir = myCube.transform.position - myBody.transform.position;
        myBody.transform.LookAt(dir);

        float rotationX = Mathf.Atan2(dir.z, -dir.x) * Mathf.Rad2Deg;
        //transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
