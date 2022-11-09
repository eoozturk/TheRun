using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddScore();
            Destroy(other.gameObject);
            
        }
        else if (other.CompareTag("End"))
        {
            player.runningSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            //Debug.Log("Touched Obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
