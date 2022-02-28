using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    GameObject LevelManager;

    public float radius = 5f;
    public LayerMask filterMask;

    private Collider2D checkCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
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
