using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Helicopter" && levelManager.GetComponent<LevelManager>().soldierHelicopter > 0)
        {
            levelManager.GetComponent<LevelManager>().soldiersSaved += levelManager.GetComponent<LevelManager>().soldierHelicopter;

            levelManager.GetComponent<AudioSource>().Play();
        }
    }
}
