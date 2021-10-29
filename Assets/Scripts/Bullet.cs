using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 0.5f;
    private Vector3 myDir;
    public bool hasTarget;
    public Cube myCube;


    private void Start()
    {
        SetDirection();
    }

    private void Update()
    {
        if(hasTarget)
        {
            GoToTarget();
        }
    }

    public void SetDirection()
    {
        myDir = myCube.transform.position - transform.position;
    }

    void GoToTarget()
    {
        transform.Translate(myDir * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Cube>())
        {
            collision.gameObject.GetComponent<Cube>().DeleteMeFromList();
            Destroy(this.gameObject);
        }
    }
}
