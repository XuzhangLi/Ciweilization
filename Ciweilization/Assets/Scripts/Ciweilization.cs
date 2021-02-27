﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
using TMPro;

public class Ciweilization : Photon.MonoBehaviour
{
    public static string[] suits = new string[] { "G", "R", "Y", "B" };
    public static string[] values = new string[] { "1", "2", "3", "4" };

    private AudioManager audioManager;

    public GameObject playerPrefab;
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;

    public Player player1;
    public Player player2;
    public Player player3;

    public List<string>[] level1s;
    public List<string>[] level2s;
    public List<string>[] level3s;
    public List<string>[] level4s;
    public List<string>[] player1Heroes;
    public List<string>[] player2Heroes;
    public List<string>[] player3Heroes;
    public List<string>[] chances;

    public Sprite[] cardFaces1;
    public Sprite[] cardFaces2;
    public Sprite[] cardFaces3;
    public Sprite[] cardFaces4;
    public Sprite[] cardFacesHeroes;
    public Sprite[] cardFacesChances;

    public GameObject cardPrefab;
    public GameObject heroCardPrefab;
    public GameObject chanceCardPrefab;

    public GameObject[] level1Pos;
    public GameObject[] level2Pos;
    public GameObject[] level3Pos;
    public GameObject[] level4Pos;
    public GameObject[] player1Pos;
    public GameObject[] player2Pos;
    public GameObject[] player3Pos;
    public GameObject[] chancePos;
    public GameObject[] heroPos;

    [HideInInspector] public List<string> deck1;
    [HideInInspector] public List<string> deck2;
    [HideInInspector] public List<string> deck3;
    [HideInInspector] public List<string> deck4;
    public List<string> deckHeroes;
    public List<string> deckHeroesCopy;
    public List<string> deckChances;
    public List<string> deckChancesCopy;

    private List<string> level1_0 = new List<string>();
    private List<string> level1_1 = new List<string>();
    private List<string> level1_2 = new List<string>();
    private List<string> level1_3 = new List<string>();
    private List<string> level2_0 = new List<string>();
    private List<string> level2_1 = new List<string>();
    private List<string> level2_2 = new List<string>();
    private List<string> level3_0 = new List<string>();
    private List<string> level3_1 = new List<string>();
    private List<string> level4_0 = new List<string>();

    private List<string> player1_0 = new List<string>();
    private List<string> player1_1 = new List<string>();
    private List<string> player1_2 = new List<string>();
    private List<string> player2_0 = new List<string>();
    private List<string> player2_1 = new List<string>();
    private List<string> player2_2 = new List<string>();
    private List<string> player3_0 = new List<string>();
    private List<string> player3_1 = new List<string>();
    private List<string> player3_2 = new List<string>();

    private List<string> chance0 = new List<string>();
    private List<string> chance1 = new List<string>();
    private List<string> chance2 = new List<string>();

    public int turn;
    public bool isSpring;
    public bool isSummer;
    public bool isFall;
    public bool isWinter;

    private TextMeshProUGUI turnText;
    private TextMeshProUGUI ruleText;
    private TextMeshProUGUI playerConnectionText;
    private TextMeshProUGUI pingText;

    private Locations locations;

    public int activePlayerNumber = 0;

    [HideInInspector] public bool wonderG2 = false;
    [HideInInspector] public bool wonderR2 = false;
    [HideInInspector] public bool wonderY2 = false;
    [HideInInspector] public bool wonderB2 = false;
    [HideInInspector] public bool wonderG3 = false;
    [HideInInspector] public bool wonderR3 = false;
    [HideInInspector] public bool wonderY3 = false;
    [HideInInspector] public bool wonderB3 = false;
    [HideInInspector] public bool wonderG4 = false;
    [HideInInspector] public bool wonderR4 = false;
    [HideInInspector] public bool wonderY4 = false;
    [HideInInspector] public bool wonderB4 = false;

    public Image[] actives;
    public Sprite isActive;

    public int playerCount = 0;

    public GameObject sceneCamera;


    /* Start is called before the first frame update. */
    void Start()
    {
        Debug.Log("Switched to main scene.");
        Debug.Log("" + playerPrefab.name);

        locations = GetComponent<Locations>();

        turnText = GameObject.Find("Canvas/Turn Text").GetComponent<TextMeshProUGUI>();
        turnText.text = "Hero Selection Time";

        //numOfPlayers += 1;
        //CiweilizationSetUpPlayer(1);
        //CiweilizationSetUpPlayer(2);
        //CiweilizationSetUpPlayer(3);

        ruleText = GameObject.Find("Canvas/Rule Text").GetComponent<TextMeshProUGUI>();
        ruleText.text = "";

        pingText = GameObject.Find("Canvas/Ping Text").GetComponent<TextMeshProUGUI>();
        pingText.text = "";

        playerConnectionText = GameObject.Find("Canvas/Player Connection Text").GetComponent<TextMeshProUGUI>();
        playerConnectionText.text = "Players Connected: " + playerCount;

        audioManager = FindObjectOfType<AudioManager>();

        turn = 0;
        activePlayerNumber = 1;
        wonderG2 = wonderR2 = wonderY2 = wonderB2 = wonderG3 = wonderR3 = wonderY3 = wonderB3 =
            wonderG4 = wonderR4 = wonderY4 = wonderB4 = false;

        isSpring = false;
        isSummer = false;
        isFall = false;
        isWinter = false;

        level1s = new List<string>[] { level1_0, level1_1, level1_2, level1_3 };
        level2s = new List<string>[] { level2_0, level2_1, level2_2 };
        level3s = new List<string>[] { level3_0, level3_1 };
        level4s = new List<string>[] { level4_0 };

        player1Heroes = new List<string>[] { player1_0, player1_1, player1_2 };
        player2Heroes = new List<string>[] { player2_0, player2_1, player2_2 };
        player3Heroes = new List<string>[] { player3_0, player3_1, player3_2 };
        chances = new List<string>[] { chance0, chance1, chance2 };


        Debug.Log("Hero Selection Time.");
        PrepareCards();
        //StartCoroutine(CiweilizationDealHeroes(1));

        audioManager.Play("Season Start");
        audioManager.Play("Theme");

        actives[0].sprite = isActive;
        actives[1].sprite = isActive;
        actives[2].sprite = isActive;
        actives[0].enabled = false;
        actives[1].enabled = false;
        actives[2].enabled = false;
    }

    /* Update is called once per frame */
    void Update()
    {
        playerConnectionText.text = "Players Connected: " + playerCount;

        pingText.text = ("Ping: + " + PhotonNetwork.GetPing());

        ShowActivePlayerBar();
    }

    /* Show active player bar according to current active player. */
    public void ShowActivePlayerBar()
    {
        if (activePlayerNumber == 1)
        {
            actives[0].enabled = true;
            actives[1].enabled = false;
            actives[2].enabled = false;
        }
        else if (activePlayerNumber == 2)
        {
            actives[0].enabled = false;
            actives[1].enabled = true;
            actives[2].enabled = false;
        }
        else if (activePlayerNumber == 3)
        {
            actives[0].enabled = false;
            actives[1].enabled = false;
            actives[2].enabled = true;
        }
    }


    /* Takes in a level and how many copies are there for each card; 
    Gives out a deck of buildings. */
    public static List<string> GenerateDeck(string v, int x) 
    {
        List<string> newDeck = new List<string>();
        for (int i = 0; i < x; i++)
        {
            foreach (string s in suits)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    /* Generates the chance deck as a list of strings. */
    public List<string> GenerateChanceDeck()
    {
        List<string> newDeck = new List<string>();
        for (int k = 0; k < cardFacesChances.Length; k++)
        {
            newDeck.Add("c" + k);
        }
        return newDeck;
    }

    /* Generates the hero deck as a list of strings. */
    public List<string> GenerateHeroDeck()
    {
        List<string> newDeck = new List<string>();
        for (int k = 0; k < cardFacesHeroes.Length; k++)
        {
            newDeck.Add("h" + k);
        }
        return newDeck;
    }

    /* Generates and shuffles the building decks, the hero deck, and the chance deck. */
    public void PrepareCards()
    {
        deck1 = GenerateDeck("1", 12);
        deck2 = GenerateDeck("2", 9);
        deck3 = GenerateDeck("3", 6);
        deck4 = GenerateDeck("4", 3);
        deckHeroes = GenerateHeroDeck();
        deckChances = GenerateChanceDeck();

        Shuffle(deck1);
        Shuffle(deck2);
        Shuffle(deck3);
        Shuffle(deck4);
        Shuffle(deckHeroes);
        Shuffle(deckChances);

        CiweilizationSort();
        CiweilizationSortHeroes();
        CiweilizationSortChances();
    }

    /* Takes in a player number;
     * Set up the corresponding player, including its building, hero, and energy locations
     * and its player number. */
    public void CiweilizationSetUpPlayer()
    {
        photonView.RPC("AddPlayerCount", PhotonTargets.AllBuffered);

        if (playerCount == 1)
        {
            GameObject player1Obj = PhotonNetwork.Instantiate(playerPrefab1.name,
                                    new Vector2(this.transform.position.x, this.transform.position.y),
                                    Quaternion.identity, 0);

            photonView.RPC("AssignPlayerParameters", PhotonTargets.AllBuffered, 1);
        }
        else if (playerCount == 2)
        {
            GameObject player2Obj = PhotonNetwork.Instantiate(playerPrefab2.name,
                                    new Vector2(this.transform.position.x, this.transform.position.y),
                                    Quaternion.identity, 0);

            photonView.RPC("AssignPlayerParameters", PhotonTargets.AllBuffered, 2);
        }
        else if (playerCount == 3)
        {
            GameObject player3Obj = PhotonNetwork.Instantiate(playerPrefab3.name,
                                    new Vector2(this.transform.position.x, this.transform.position.y),
                                    Quaternion.identity, 0);

            photonView.RPC("AssignPlayerParameters", PhotonTargets.AllBuffered, 3);
        }
        else
        {
            Debug.Log("Error! A player has an invalid number.");
        }
    }

    [PunRPC]
    public void AssignPlayerParameters(int num)
    {
        if (num == 1)
        {

            GameObject obj = GameObject.FindGameObjectWithTag("Player1");
            obj.name = "Test Player 1";
            player1 = obj.GetComponent<Player>();
            player1.level1Pos = locations.player1Level1Pos;
            player1.level2Pos = locations.player1Level2Pos;
            player1.level3Pos = locations.player1Level3Pos;
            player1.level4Pos = locations.player1Level4Pos;
            player1.GetComponent<Energy>().energies = locations.player1Energies;
            player1.startEnergy = true;

            player1.playerNumber = 1;
            player1.heroPos = heroPos[0];
            
            
        }
        else if (num == 2)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player2");
            obj.name = "Test Player 2";
            player2 = obj.GetComponent<Player>();
            player2.level1Pos = locations.player2Level1Pos;
            player2.level2Pos = locations.player2Level2Pos;
            player2.level3Pos = locations.player2Level3Pos;
            player2.level4Pos = locations.player2Level4Pos;
            player2.GetComponent<Energy>().energies = locations.player2Energies;
            player2.startEnergy = true;

            player2.playerNumber = 2;
            player2.heroPos = heroPos[1];
        }
        else if (num == 3)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player3");
            obj.name = "Test Player 3";
            player3 = obj.GetComponent<Player>();
            player3.level1Pos = locations.player3Level1Pos;
            player3.level2Pos = locations.player3Level2Pos;
            player3.level3Pos = locations.player3Level3Pos;
            player3.level4Pos = locations.player3Level4Pos;
            player3.GetComponent<Energy>().energies = locations.player3Energies;
            player3.startEnergy = true;

            player3.playerNumber = 3;
            player3.heroPos = heroPos[2];
        }
    }

    [PunRPC]
    public void AddPlayerCount()
    {
        if (playerCount < 3)
        {
            playerCount += 1;
        }
    }

    /* Takes in a deck, shuffles the deck in a rather naive way. */
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    /* Deals 4 level-1 buildings from the box */
    IEnumerator CiweilizationDeal1()
    {
        for (int i = 0; i < 4; i++)
        {
            foreach (string card in level1s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, 
                                                    level1Pos[i].transform.position, 
                                                    Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
        }
    }

    /* Deals 3 level-2 buildings from the box */
    IEnumerator CiweilizationDeal2()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (string card in level2s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name,
                                    level2Pos[i].transform.position,
                                    Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
        }
    }

    /* Deals 2 level-3 buildings from the box */
    IEnumerator CiweilizationDeal3()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (string card in level3s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name,
                                     level3Pos[i].transform.position,
                                     Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
        }
    }

    /* Deals 1 level-4 buildings from the box */
    IEnumerator CiweilizationDeal4()
    {
        for (int i = 0; i < 1; i++)
        {
            foreach (string card in level4s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name,
                                    level4Pos[i].transform.position,
                                    Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
        }
    }

    /* Takes in a player number, and deals 3 heroes for that player from the box.*/
    public IEnumerator CiweilizationDealHeroes(int playerNum)
    {
        for (int i = 0; i < 3; i++)
        {
            if (playerNum == 1 && player1.photonView.isMine)
            {
                string card = player1Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                
                GameObject newCard = PhotonNetwork.Instantiate(heroCardPrefab.name, player1Pos[i].transform.position,
                                                            Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;
                
                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);       
            }
            else if (playerNum == 2 && player2.photonView.isMine)
            {
                string card = player2Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(heroCardPrefab.name, player1Pos[i].transform.position,
                                                            Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
            else if (playerNum == 3 && player3.photonView.isMine)
            {
                string card = player3Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = PhotonNetwork.Instantiate(heroCardPrefab.name, player1Pos[i].transform.position,
                                                            Quaternion.identity, 0);
                int id = newCard.GetPhotonView().viewID;

                photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
            }
        }
    }

    [PunRPC]
    public void SetCardName(int id, string cardName)
    {
        PhotonView.Find(id).gameObject.name = cardName;
    }

    /* Deal out three chances from the box, and prepares the box for next time.*/
    public IEnumerator CiweilizationDealChances()
    {
        for (int i = 0; i < 3; i++)
        {
            string card = chances[i].Last<string>();
            yield return new WaitForSeconds(0.1f);
            GameObject newCard = PhotonNetwork.Instantiate(chanceCardPrefab.name, 
                                                            chancePos[i].transform.position,
                                                            Quaternion.identity, 0);
            int id = newCard.GetPhotonView().viewID;

            photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
        }

        CiweilizationSortChances();
    }

    /* Put cards in building decks into their corresponding boxs, so they are ready to be dealt out.*/
    public void CiweilizationSort()
    {
        for (int i = 0; i < 4; i++)
        {
            level1s[i].Add(deck1.Last<string>());
            deck1.RemoveAt(deck1.Count - 1);
        }
        for (int i = 0; i < 3; i++)
        {
            level2s[i].Add(deck2.Last<string>());
            deck2.RemoveAt(deck2.Count - 1);
        }
        for (int i = 0; i < 2; i++)
        {
            level3s[i].Add(deck3.Last<string>());
            deck3.RemoveAt(deck3.Count - 1);
        }
        for (int i = 0; i < 1; i++)
        {
            level4s[i].Add(deck4.Last<string>());
            deck4.RemoveAt(deck4.Count - 1);
        }
    }

    /* Generates hero cards (strings) and put them into their corresponding boxs, 
     * so they are ready to be dealt out.*/
    public void CiweilizationSortHeroes()
    {
        deckHeroes = GenerateHeroDeck();
        Shuffle(deckHeroes);

        for (int i = 0; i < 3; i++)
        {
            player1Heroes[i].Add(deckHeroes.Last<string>());
            deckHeroes.RemoveAt(deckHeroes.Count - 1);

            player2Heroes[i].Add(deckHeroes.Last<string>());
            deckHeroes.RemoveAt(deckHeroes.Count - 1);

            player3Heroes[i].Add(deckHeroes.Last<string>());
            deckHeroes.RemoveAt(deckHeroes.Count - 1);
        }
    }

    /* Generates chance cards (strings) and put them into their corresponding boxs, 
     * so they are ready to be dealt out.*/
    public void CiweilizationSortChances()
    {
        deckChances = GenerateChanceDeck();
        Shuffle(deckChances);

        for (int i = 0; i < 3; i++)
        {
            chances[i].Add(deckChances.Last<string>());
            deckChances.RemoveAt(deckChances.Count - 1);
        }
    }

    /* Takes in the vector3 position of the missing level-1 card on the board,
     * and fill in the top card from the level-1 building deck.*/
    public void CiweilizationFill1(Vector3 position)
    {
        if (player1.photonView.isMine)
        {
            string card = deck1.Last<string>();
            deck1.RemoveAt(deck1.Count - 1);

            GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, position,
                                                           Quaternion.identity, 0);

            int id = newCard.GetPhotonView().viewID;

            photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
        }
    }

    /* Takes in the vector3 position of the missing level-2 card on the board,
     * and fill in the top card from the level-2 building deck.*/
    public void CiweilizationFill2(Vector3 position)
    {
        if (player1.photonView.isMine)
        {
            string card = deck2.Last<string>();
            deck2.RemoveAt(deck2.Count - 1);

            GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, position,
                                                           Quaternion.identity, 0);
            int id = newCard.GetPhotonView().viewID;

            photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
        }
    }

    /* Takes in the vector3 position of the missing level-3 card on the board,
     * and fill in the top card from the level-3 building deck.*/
    public void CiweilizationFill3(Vector3 position)
    {
        if (player1.photonView.isMine)
        {
            string card = deck3.Last<string>();
            deck3.RemoveAt(deck3.Count - 1);

            GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, position,
                                                           Quaternion.identity, 0);
            int id = newCard.GetPhotonView().viewID;

            photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
        }
    }

    /* Takes in the vector3 position of the missing level-4 card on the board,
     * and fill in the top card from the level-4 building deck.*/
    public void CiweilizationFill4(Vector3 position)
    {
        if (player1.photonView.isMine)
        {
            string card = deck4.Last<string>();
            deck4.RemoveAt(deck4.Count - 1);

            GameObject newCard = PhotonNetwork.Instantiate(cardPrefab.name, position,
                                                           Quaternion.identity, 0);
            int id = newCard.GetPhotonView().viewID;

            photonView.RPC("SetCardName", PhotonTargets.AllBuffered, id, card);
        }
    }

    /* Takes in a player, and return the numder of moves that player should get in the current season.*/
    public double CiweilizationCountPlayerMoves(Player player)
    {
        double count = 1f;
        int wonderLevel2 = player.PlayerGetWonder_G2() + player.PlayerGetWonder_R2()
                        + player.PlayerGetWonder_Y2() + player.PlayerGetWonder_B2();
        int wonderLevel3 = player.PlayerGetWonder_G3() + player.PlayerGetWonder_R3()
                        + player.PlayerGetWonder_Y3() + player.PlayerGetWonder_B3();
        int wonderLevel4 = player.PlayerGetWonder_G4() + player.PlayerGetWonder_R4()
                        + player.PlayerGetWonder_Y4() + player.PlayerGetWonder_B4();
        int level1 = player.PlayerGetG1() + player.PlayerGetR1() +
                        player.PlayerGetY1() + player.PlayerGetB1();
        int level2 = player.PlayerGetG2() + player.PlayerGetR2() +
                        player.PlayerGetY2() + player.PlayerGetB2();
        int level3 = player.PlayerGetG3() + player.PlayerGetR3() +
                        player.PlayerGetY3() + player.PlayerGetB3();
        int level4 = player.PlayerGetG4() + player.PlayerGetR4() +
                        player.PlayerGetY4() + player.PlayerGetB4();
        if (isSpring == true)
        {
            count += level1 * 0.25f;
            count += level2 * 0.5f;
            count += player.PlayerGetG1() * 0.25f;
            count += player.PlayerGetG2() * 0.5f;
        }
        else if (isSummer == true)
        {
            count += level2 * 0.25f;
            count += level3 * 0.5f;
            count += player.PlayerGetR2() * 0.25f;
            count += player.PlayerGetR3() * 0.5f;
        }
        else if (isFall == true)
        {
            count += level3 * 0.25f;
            count += level4 * 0.5f;
            count += player.PlayerGetY3() * 0.25f;
            count += player.PlayerGetY4() * 0.5f;
        }
        else if (isWinter == true)
        {
            count += player.PlayerGetB4() * 0.25f;
            count += level4 * 0.25f;
            count += player.PlayerGetB3() * 0.25f;
            count += (wonderLevel3 * 0.25f + wonderLevel2 * 0.25f);
            count -= player.PlayerGetWonder_B3() * 0.25f;
        }
        
        return count;
    }

    /* Start next turn, give players moves, and changes season if needed.*/
    public void CiweilizationNextTurn()
    {
        turn += 1;

        if (turn == 1)
        {
            //audioManager.StopPlaying("Theme");
            //audioManager.Play("Spring Theme");
            audioManager.Play("Season Start");

            isSpring = true;
            Debug.Log("You've selected heroes. Spring comes!");
            ruleText.text = "Era of Agriculture!\n\n"
                    + "(1) Gain 0.25 move for every level-1.\n"
                    + "(2) Gain 0.5 move for every level-2.\n"
                    + "(3) Doubles for Green.";
            if (player1.photonView.isMine)
            {
                StartCoroutine(CiweilizationDeal1());
            }
        }
        if (turn == 4 && isSpring == true)
        {
            //audioManager.StopPlaying("Spring Theme");
            //audioManager.Play("Summer Theme");
            audioManager.Play("Season Start");

            isSpring = false;
            isSummer = true;
            ruleText.text = "Era of Industry! \n\n"
                    + "(1) Gain 0.25 move for every level-2.\n"
                    + "(2) Gain 0.5 move for every level-3.\n"
                    + "(3) Doubles for Red.";
            //ruleText.color = Color.red;
            Debug.Log("Spring has past and summer has come.");
            if (player1.photonView.isMine)
            {
                StartCoroutine(CiweilizationDeal2());
            }
        }
        else if (turn == 7 && isSummer == true)
        {
            //audioManager.StopPlaying("Summer Theme");
            //audioManager.Play("Fall Theme");
            audioManager.Play("Season Start");

            isSummer = false;
            isFall = true;
            ruleText.text = "Era of Commerce! \n\n"
                    + "(1) Gain 0.25 move for every level-3.\n"
                    + "(2) Gain 0.5 move for every level-4.\n"
                    + "(3) Doubles for Yellow.";
            //ruleText.color = Color.yellow;
            Debug.Log("Summer has past and Fall has come.");
            if (player1.photonView.isMine)
            {
                StartCoroutine(CiweilizationDeal3());
            }
        }
        else if (turn == 10 && isFall == true)
        {
            //audioManager.StopPlaying("Fall Theme");
            //audioManager.Play("Winter Theme");
            audioManager.Play("Season Start");

            isFall = false;
            isWinter = true;
            ruleText.text = "Era of Science! \n\n"
                    + "(1) Gain 0.5 move for every blue-4.\n"
                    + "(2) Gain 0.25 move for every blue-3, level-4, or wonder.";
            //ruleText.color = Color.cyan;
            Debug.Log("Fall has past and winter has come.");
            if (player1.photonView.isMine)
            {
                StartCoroutine(CiweilizationDeal4());
            }
        }

        turnText.text = "Turn" + " " + turn.ToString();

        //Give the players the correct number of moves for their next turn;

        player1.moves = CiweilizationCountPlayerMoves(player1);
        player2.moves = CiweilizationCountPlayerMoves(player2);
        player3.moves = CiweilizationCountPlayerMoves(player3);
    }

    /* Deal out the starting building cards according to season. */
    public void CiweilizationNextTurnDeal()
    {
        if (turn == 1)
        {
            StartCoroutine(CiweilizationDeal1());
        }
        else if (turn == 4)
        {
            StartCoroutine(CiweilizationDeal2());
        }
        else if (turn == 7)
        {
            StartCoroutine(CiweilizationDeal3());
        }
        else if (turn == 10)
        {
            StartCoroutine(CiweilizationDeal4());
        }
        else
        {
            Debug.Log("Error! Invalid turn number.");
        }
    }
}
