using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    GameObject LevelManager;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Helicopter" && LevelManager.GetComponent<LevelManager>().soldierHelicopter < 2)
        {
            LevelManager.GetComponent<LevelManager>().soldierHelicopter += 1;

            Destroy(this.gameObject);
        }
    }
}
