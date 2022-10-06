using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionsScript : MonoBehaviour
{

    public GameObject CoinCollected;
    private int coinCount;

    private int totalCoin;

    public float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coins").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer //
        timerText.text = "Time: " + timer;
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }

        if(coinCount == totalCoin)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            coinCount++;

            CoinCollected.GetComponent<Text>().text = "Coin collected: " + coinCount;

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLose");
        }
    }

}
