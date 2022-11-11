using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score, maxScore;
    public Text scoreText;

    public PlayerController playerControl;
    public Animator playerAnim;
    public GameObject player;
    public GameObject endPanel;

    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddScore();
            Destroy(other.gameObject);
            
        }
        else if (other.CompareTag("End"))
        {
            playerControl.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z);

            if(score >= maxScore)
            {
                playerAnim.SetBool("win",true);
            }
            else
            {
                playerAnim.SetBool("lose", true);
                endPanel.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
