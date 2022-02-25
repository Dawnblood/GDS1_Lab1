using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{

    public int soldiersSaved = 0;

    public Text soldiersSavedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soldiersSavedText.text = soldiersSaved.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Helicopter")
        {
            soldiersSaved += collision.gameObject.GetComponent<Helicopter>().soldierHelicopter;
        }
    }
}
