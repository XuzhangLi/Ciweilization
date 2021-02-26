﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

public class UserInput : Photon.MonoBehaviour
{
    private Ciweilization ciweilization;

    [HideInInspector] public Player player;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        ciweilization = FindObjectOfType<Ciweilization>();

        audioManager = FindObjectOfType<AudioManager>();

        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ciweilization.activePlayerNumber == player.playerNumber)
        {
            if (ciweilization.activePlayerNumber == 1)
            {
                if (ciweilization.player1.photonView.isMine)
                {
                    GetMouseClick();
                }
            }
            else if (ciweilization.activePlayerNumber == 2)
            {
                if (ciweilization.player2.photonView.isMine)
                {
                    GetMouseClick();
                }
            }
            else if (ciweilization.activePlayerNumber == 3)
            {
                if (ciweilization.player3.photonView.isMine)
                {
                    GetMouseClick();
                }
            }
        }
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // if left click
        {
            // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //Debug.Log("you just clicked on something.");

                if (hit.collider.CompareTag("Card"))
                {
                    if (player.moves >= 1)
                    {
                        BuyCard(hit.collider.gameObject);
                    }
                    else
                    {
                        audioManager.Play("Warning");
                    }
                }

                else if (hit.collider.CompareTag("TestCard"))
                {
                    BuyTestCard(hit.collider.gameObject);
                }

                else if (hit.collider.CompareTag("Emote"))
                {

                    Debug.Log("You just clicked on an emote.");
                    string name = hit.collider.gameObject.GetComponent<Emote>().name;
                    audioManager.Play(name);
                }

                else if (hit.collider.CompareTag("HeroTrigger"))
                {
                    Debug.Log("You just clicked on a hero trigger.");
                    //write these into a function later
                    StartCoroutine(ciweilization.CiweilizationDealHeroes(player.playerNumber));
                    ciweilization.CiweilizationSortHeroes();
                    audioManager.Play("Coin");
                }

                else if (hit.collider.CompareTag("HeroCard"))
                {
                    Debug.Log("You just clicked on a hero card.");
                    SelectHero(hit.collider.gameObject);
                    audioManager.Play("Coin");
                }

                else if (hit.collider.CompareTag("ChanceTrigger"))
                {
                    Debug.Log("You just clicked on a chance trigger.");
                    //write these into a function later
                    StartCoroutine(ciweilization.CiweilizationDealChances());
                    audioManager.Play("Coin");
                }

                else if (hit.collider.CompareTag("ChanceCard"))
                {
                    Debug.Log("You just clicked on a chance card.");
                    //write these into a function later
                    DestroyAll("ChanceCard");
                    audioManager.Play("Coin");
                }

                else if (hit.collider.CompareTag("Hero"))
                {
                    Debug.Log("You just clicked on a hero. You get half extra move.");
                    player.moves += 0.5f;
                    audioManager.Play("Discard");
                }
            }
        }

        else if (Input.GetMouseButtonDown(1)) //if right click
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.collider.CompareTag("Card"))
                {
                    DiscardCard(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("BuildingPlayer1"))
                {
                    DestroyBuilding(hit.collider.gameObject, ciweilization.player1);
                }
                else if (hit.collider.CompareTag("BuildingPlayer2"))
                {
                    DestroyBuilding(hit.collider.gameObject, ciweilization.player2);
                }
                else if (hit.collider.CompareTag("BuildingPlayer3"))
                {
                    DestroyBuilding(hit.collider.gameObject, ciweilization.player3);
                }
                else if (hit.collider.CompareTag("Hero"))
                {
                    player.moves -= 0.5f;
                    audioManager.Play("Discard");
                }
            }
        }
    }

    void DestroyBuilding(GameObject obj, Player attackedPlayer)
    {
        Debug.Log("you just right clicked on a building.");

        string name = obj.GetComponent<BuildingDisplay>().testName;
        Destroy(obj);
        attackedPlayer.PlayerDelete(name);

        audioManager.Play("Discard");
    }
    void BuyCard(GameObject obj)
    {
        char chr = (obj.name[1]);
        int level = (int)(chr - '0');
        Debug.Log("you just clicked on a card." + level);

        Vector3 position = obj.transform.position;
        Destroy(obj);
        Fill(level, position);
        player.PlayerBuild(obj.name);
        player.moves -= 1;
    }

    void DiscardCard(GameObject obj)
    {
        char chr = (obj.name[1]);
        int level = (int)(chr - '0');
        Debug.Log("you just right clicked on a card." + level);

        Vector3 position = obj.transform.position;
        Destroy(obj);
        Fill(level, position);

        audioManager.Play("Discard");
    }
    void BuyTestCard(GameObject obj)
    {
        Debug.Log("you just clicked on a test card.");

        string name = obj.GetComponent<BuildingDisplay>().testName;

        if (name[0] == 'M')
        {
            string suit = "";
            System.Random random = new System.Random();
            int k = random.Next(4);
            if (k == 0)
            {
                suit = "G";
            }
            else if (k == 1)
            {
                suit = "R";
            }
            else if (k == 2)
            {
                suit = "Y";
            }
            else if (k == 3)
            {
                suit = "B";
            }
            else
            {
                Debug.Log("Error! Randomed an invalid suit.");
            }

            name = suit + name[1].ToString();
        }

        player.PlayerBuild(name);
    }

    void Fill(int level, Vector3 position)
    {
        if (level == 1)
        {
            ciweilization.CiweilizationFill1(position);
        }
        else if (level == 2)
        {
            ciweilization.CiweilizationFill2(position);
        }
        else if (level == 3)
        {
            ciweilization.CiweilizationFill3(position);
        }
        else if (level == 4)
        {
            ciweilization.CiweilizationFill4(position);
        }
        else
        {
            Debug.Log("Error! The input need to be a level between 1 to 4");
        }


        Debug.Log("User Input Fill Method Called.");
    }

    void SelectHero(GameObject obj)
    {
        if (player.heroObj)
        {
            PhotonNetwork.Destroy(player.heroObj);
        }
        GameObject hero = PhotonNetwork.Instantiate("Hero", player.heroPos.transform.position, 
                                        Quaternion.identity, 0);
        player.heroObj = hero;

        int id = player.heroObj.GetPhotonView().viewID;

        photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, obj.name);

        DestroyAll("HeroCard");
    }
    void DestroyAll(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < targets.Length; i++)
        {
            PhotonNetwork.Destroy(targets[i]);
        }
    }

    [PunRPC]
    public void SetCardName(int id, string cardName)
    {
        PhotonView.Find(id).gameObject.name = cardName;
    }
}
