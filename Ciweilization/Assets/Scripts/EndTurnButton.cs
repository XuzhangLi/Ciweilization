using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTurnButton : Photon.MonoBehaviour
{
    Ciweilization ciweilization;
    AudioManager audioManager;

    //private TextMeshProUGUI activePlayerText;

    // Start is called before the first frame update
    private void Start()
    {
        ciweilization = GetComponent<Ciweilization>();

        audioManager = FindObjectOfType<AudioManager>();

        //activePlayerText = GameObject.Find("Canvas/Active Player Text").GetComponent<TextMeshProUGUI>();
        //activePlayerText.text = "player 1's turn!";
    }

    public void OnButtonPress()
    {
        //DealHeroesOnTurnZero();
        photonView.RPC("NextActivePlayer", PhotonTargets.AllBuffered);
 
        audioManager.Play("End Turn");
    }

    [PunRPC]
    public void NextActivePlayer()
    {
        if  (ciweilization.turn == 0)
        {
            if (ciweilization.activePlayerNumber == 1)
            {
                ciweilization.activePlayerNumber = 2;
                StartCoroutine(ciweilization.CiweilizationDealHeroes(2));
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                ciweilization.activePlayerNumber = 3;
                StartCoroutine(ciweilization.CiweilizationDealHeroes(3));
            }
            else if (ciweilization.activePlayerNumber == 3)
            {
                ciweilization.activePlayerNumber = 1;
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
                if (ciweilization.player2)
                {
                    ciweilization.player2.PlayerAtTheStartOfTurn();
                }
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                ciweilization.activePlayerNumber = 3;
                if (ciweilization.player3)
                {
                    ciweilization.player3.PlayerAtTheStartOfTurn();
                }
            }
            else if (ciweilization.activePlayerNumber == 3)
            {
                ciweilization.activePlayerNumber = 1;
                ciweilization.CiweilizationNextTurn();
                ciweilization.player1.PlayerAtTheStartOfTurn();
            }
            else
            {
                Debug.Log("Error! Invalid active player number.");
            }
        }
    }

    public void DealHeroesOnTurnZero()
    {
        if (ciweilization.turn == 0)
        {
            if (ciweilization.activePlayerNumber == 1)
            {
                StartCoroutine(ciweilization.CiweilizationDealHeroes(2));
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                StartCoroutine(ciweilization.CiweilizationDealHeroes(3));
            }
            else if (ciweilization.activePlayerNumber == 3)
            {

            }
        }
    }

}
