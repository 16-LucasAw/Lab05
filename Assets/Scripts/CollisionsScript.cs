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

    //public int timeRemainding;
    //public float timeLeft;
    //private float TimerValue;
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


        /*timeLeft -= Time.deltaTime;

        timeRemainding = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = "Timer: " + timeRemainding.ToString();

        if(totalCoin == coinCount)
        {
            if(timeLeft <= TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }

            else if(timeLeft <= 0)
            {
                SceneManager.LoadScene("GameLose");
            }
        }*/
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
