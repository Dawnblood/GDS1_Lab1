using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-8, -4, 0);
    private Vector3 pos2 = new Vector3(8, -4, 0);
    public float speed = 0.1f;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.3f, 7.1f);
    }

    // Update is called once per frame
    void Update()
    {

        //Instantiate(bullet, transform.position, Quaternion.identity);


        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong((Time.time * speed) / 2, 1f));
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
