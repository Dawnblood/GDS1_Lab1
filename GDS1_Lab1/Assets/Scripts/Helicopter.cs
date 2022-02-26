using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{

    public Rigidbody2D helicopter;
    public float moveSpeed = 5f;
    Vector2 movement;

    GameObject LevelManager;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        helicopter.MovePosition(helicopter.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else if (collision.tag == "Hospital" && LevelManager.GetComponent<LevelManager>().soldierHelicopter > 0)
        {
            LevelManager.GetComponent<LevelManager>().soldierHelicopter = 0;
        }
    }
}
