using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject currentPlayer;
    private Camera camera;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private bool player1Turn = true;
    [SerializeField] private float turnTimer;
    private float turnCooldown;
    private bool gameOver;

    void Start()
    {
        currentPlayer = player1;
    }

    void Update()
    {
        if (gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            ChangePlayer();

        turnCooldown -=  Time.deltaTime;
        if (turnCooldown < 0)
        {
            ChangePlayer();
            turnCooldown = turnTimer;
        }
    }

    public void ChangePlayer()
    {

        // Deactivate old current player
        currentPlayer.GetComponent<PlayerMovement>().enabled = false;
        currentPlayer.transform.GetChild(0).gameObject.SetActive(false);
        currentPlayer.transform.GetChild(4).gameObject.SetActive(false);


        // Change curent player
        if (player1Turn)
        {
            currentPlayer = player2;
            player1Turn = false;
        }
        else
        {
            currentPlayer = player1;
            player1Turn = true;
        }

        if (currentPlayer == null)
        {
            gameOver = true;
            return;
        }

        // Activate new current player
        currentPlayer.GetComponent<PlayerMovement>().enabled = true;
        currentPlayer.transform.GetChild(0).gameObject.SetActive(true);
        currentPlayer.transform.GetChild(4).gameObject.SetActive(true);
    }
}
