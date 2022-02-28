using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Helicopter" && levelManager.GetComponent<LevelManager>().soldierHelicopter < 2)
        {
            Destroy(this.gameObject);
        }
    }
}
