using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Soldiers;

    public int soldiersSaved;
    public Text soldiersSavedText;

    public int soldierHelicopter;
    public Text soldiersHelicopterText;

    // Start is called before the first frame update
    void Start()
    {
        Soldiers = GameObject.FindGameObjectsWithTag("Soldier");

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

        if (soldiersSaved == Soldiers.Length)
        {
            SceneManager.LoadScene("You Win", LoadSceneMode.Single);
        }

    }
}
