using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Helicopter" && collision.gameObject.GetComponent<Helicopter>().soldierHelicopter < 2)
        {
            collision.gameObject.GetComponent<Helicopter>().soldierHelicopter += 1;

            Debug.Log(collision.gameObject.GetComponent<Helicopter>().soldierHelicopter);

            Destroy(this.gameObject);
        }
    }
}
