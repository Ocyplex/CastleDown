using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 0.75f;
    private Vector3 myDir;
    public bool hasTarget;
    public Cube myCube;


    private void Start()
    {
        SetDirection();
        StartCoroutine(DestroyMe());
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
        transform.Translate(myDir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " bullet hit this");
        if (collision.gameObject.GetComponent<Cube>())
        {
            collision.gameObject.GetComponent<Cube>().DeleteMeFromList();
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
