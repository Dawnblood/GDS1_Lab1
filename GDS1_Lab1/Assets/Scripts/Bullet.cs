using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 0.01f;

    public GameObject tank;

    private float currentLerpTime = 0f;
    private float lerpTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.Find("Tank");

        pos1 = new Vector3(tank.transform.position.x, -4, 0);
        pos2 = new Vector3(tank.transform.position.x, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentLerpTime += Time.deltaTime;

        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float percent = currentLerpTime / lerpTime;

        transform.position = Vector3.Lerp(pos1, pos2, percent);

        if (transform.position.y == 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Helicopter")
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
    }
}
