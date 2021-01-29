using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTurnButton : MonoBehaviour
{
    Ciweilization ciweilization;
    AudioManager audioManager;

    private TextMeshProUGUI activePlayerText;

    // Start is called before the first frame update
    private void Start()
    {
        ciweilization = GetComponent<Ciweilization>();

        audioManager = FindObjectOfType<AudioManager>();

        activePlayerText = GameObject.Find("Canvas/Active Player Text").GetComponent<TextMeshProUGUI>();
        activePlayerText.text = "player 1's turn!";
    }

    public void OnButtonPress()
    {
        NextActivePlayer();
 
        audioManager.Play("End Turn");
    }

    public void NextActivePlayer()
    {
        if  (ciweilization.turn == 0)
        {
            if (ciweilization.activePlayerNumber == 1)
            {
                ciweilization.activePlayerNumber = 2;
                activePlayerText.text = "player 2's turn!";
                StartCoroutine(ciweilization.CiweilizationDealHeroes(2));
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                ciweilization.activePlayerNumber = 3;
                activePlayerText.text = "player 3's turn!";
                StartCoroutine(ciweilization.CiweilizationDealHeroes(3));
            }
            else if (ciweilization.activePlayerNumber == 3)
            {
                ciweilization.activePlayerNumber = 1;
                activePlayerText.text = "player 1's turn!";
                ciweilization.CiweilizationNextTurn();
                ciweilization.CiweilizationSortHeroes();
            }
            else
            {
                Debug.Log("Error! Invalid active player number.");
            }
        }
        else
        {
            if (ciweilization.activePlayerNumber == 1)
            {
                ciweilization.activePlayerNumber = 2;
                activePlayerText.text = "player 2's turn!";
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                ciweilization.activePlayerNumber = 3;
                activePlayerText.text = "player 3's turn!";
            }
            else if (ciweilization.activePlayerNumber == 3)
            {
                ciweilization.activePlayerNumber = 1;
                activePlayerText.text = "player 1's turn!";
                ciweilization.CiweilizationNextTurn();
            }
            else
            {
                Debug.Log("Error! Invalid active player number.");
            }
        }
    }
}
