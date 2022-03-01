using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-8, -4, 0);
    private Vector3 pos2 = new Vector3(8, -4, 0);
    public float speed = 0.1f;

    private int tankTimer = 3954;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong((Time.time * speed) / 2, 1f));

        Shoot();
    }

    void Shoot()
    {
        if (tankTimer > 0)
        {
            tankTimer -= 1;
        }
        else
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            tankTimer = 3954;
        }
    }
}
