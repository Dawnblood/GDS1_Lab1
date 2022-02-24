using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour
{

    public Rigidbody2D helicopter;
    public float moveSpeed = 3f;
    Vector2 movement;

    public int soldierHelicopter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Trigger Enter");

        if (collision.tag == "Tree")
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else if (collision.tag == "Hospital")
        {
            soldierHelicopter -= 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger Stay");

        if (collision.tag == "Hospital")
        {
            soldierHelicopter -= 1;
        }
    }
}
