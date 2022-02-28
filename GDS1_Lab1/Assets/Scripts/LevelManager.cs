using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject soldier;
    public int numSoldiers;

    public Collider2D[] colliders;
    public float radius;

    public int soldiersSaved;
    public Text soldiersSavedText;

    public int soldierHelicopter;
    public Text soldiersHelicopterText;

    // Start is called before the first frame update
    void Start()
    {

        numSoldiers = Random.Range(4, 8);

        for (int i = 0; i < numSoldiers; i++)
        {
            SpawnSoldiers();
        }

        soldiersSaved = 0;

        soldierHelicopter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        soldiersSavedText.text = soldiersSaved.ToString();

        soldiersHelicopterText.text = soldierHelicopter.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level");
        }

        if (soldiersSaved == numSoldiers)
        {
            SceneManager.LoadScene("You Win", LoadSceneMode.Single);
        }

    }

    public void SpawnSoldiers()
    {
        Vector3 spawnPos = new Vector3(0, 0 , 0);
        bool canSpawn = false;

        while (!canSpawn)
        {
            float spawnPosX = Random.Range(5.4f, 11.45f);
            float spawnPosY = Random.Range(4f, -4f);
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            canSpawn = PreventSpawnOverlap(spawnPos);

            if (canSpawn)
            {
                break;
            }
        }

        GameObject newSoldier = Instantiate(soldier, spawnPos, Quaternion.identity) as GameObject;
    }

    private bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
