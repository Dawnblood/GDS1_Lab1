using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject soldier;
    public int numSoldiers;

    public int soldiersSaved;
    public Text soldiersSavedText;

    public int soldierHelicopter;
    public Text soldiersHelicopterText;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSoldiers();

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

        numSoldiers = Random.Range(4, 8);

        for (int i = 0; i < numSoldiers; i++)
        {
            float spawnPosX = Random.Range(5.4f, 11.45f);
            float spawnPosY = Random.Range(4f, -4f);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            Instantiate(soldier, spawnPos, Quaternion.identity);
        }
    }
}
