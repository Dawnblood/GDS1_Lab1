using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{

    public Rigidbody2D helicopterRGB;
    public float moveSpeed = 5f;
    Vector2 movement;

    GameObject levelManager;
    GameObject helicopter;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");

        helicopter = GameObject.Find("Helicopter");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftArrow) && helicopter.transform.rotation.y == 0)
        {
            helicopter.transform.Rotate(new Vector3(0, -180, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && helicopter.transform.rotation.y > 0)
        {
            helicopter.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void FixedUpdate()
    {
        helicopterRGB.MovePosition(helicopterRGB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else if (collision.tag == "Hospital" && levelManager.GetComponent<LevelManager>().soldierHelicopter > 0)
        {
            levelManager.GetComponent<LevelManager>().soldierHelicopter = 0;
        }
    }
}
