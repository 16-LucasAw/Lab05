using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionsScript : MonoBehaviour
{

    public GameObject CoinCollected;
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            coinCount++;

            CoinCollected.GetComponent<Text>().text = "Coin collected: " + coinCount;

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            print("You lose");
        }
    }


}
