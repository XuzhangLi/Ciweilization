using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
using TMPro;

public class Ciweilization : MonoBehaviour
{
    public static string[] suits = new string[] { "G", "R", "Y", "B" };
    public static string[] values = new string[] { "1", "2", "3", "4" };

    private AudioManager audioManager;

    public GameObject playerPrefab;

    [HideInInspector] public Player player1;
    [HideInInspector] public Player player2;
    [HideInInspector] public Player player3;

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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Switched to main scene.");
        Debug.Log("" + playerPrefab.name);

        locations = GetComponent<Locations>();

        CiweilizationSetUpPlayer(1);
        CiweilizationSetUpPlayer(2);
        CiweilizationSetUpPlayer(3);

        audioManager = FindObjectOfType<AudioManager>();

        turnText = GameObject.Find("Canvas/Turn Text").GetComponent<TextMeshProUGUI>();
        turnText.text = "Hero Selection";

        ruleText = GameObject.Find("Canvas/Rule Text").GetComponent<TextMeshProUGUI>();
        ruleText.text = "";
        //ruleText.color = new Color(0.2f, 1f, 0.2f, 1f);

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


        Debug.Log("Hero Selction Time.");
        PrepareCards();
        StartCoroutine(CiweilizationDealHeroes(1));

        audioManager.Play("Season Start");
        audioManager.Play("Theme");

        actives[0].sprite = isActive;
        actives[1].sprite = isActive;
        actives[2].sprite = isActive;
        actives[0].enabled = false;
        actives[1].enabled = false;
        actives[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
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

    // takes in a level and how many copies are there for each card, gives out a deck
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

    public List<string> GenerateChanceDeck()
    {
        List<string> newDeck = new List<string>();
        for (int k = 0; k < cardFacesChances.Length; k++)
        {
            newDeck.Add("c" + k);
        }
        return newDeck;
    }

    public List<string> GenerateHeroDeck()
    {
        List<string> newDeck = new List<string>();
        for (int k = 0; k < cardFacesHeroes.Length; k++)
        {
            newDeck.Add("h" + k);
        }
        return newDeck;
    }

    //gives out 4 shuffled decks
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

    public void CiweilizationSetUpPlayer(int playerNum)
    {
        if (playerNum == 1)
        {
            GameObject player1Obj = Instantiate(playerPrefab, Vector3.zero, 
                                                                Quaternion.identity);
            player1Obj.name = "Test Player 1";
            player1 = player1Obj.GetComponent<Player>();
            player1.level1Pos = locations.player1Level1Pos;
            player1.level2Pos = locations.player1Level2Pos;
            player1.level3Pos = locations.player1Level3Pos;
            player1.level4Pos = locations.player1Level4Pos;
            player1.GetComponent<Energy>().energies = locations.player1Energies;

            player1.playerNumber = 1;
            player1.heroPos = heroPos[0];
        }
        else if (playerNum == 2)
        {
            GameObject player2Obj = Instantiate(playerPrefab, Vector3.zero,
                                                                Quaternion.identity);
            player2Obj.name = "Test Player 2";
            player2 = player2Obj.GetComponent<Player>();
            player2.level1Pos = locations.player2Level1Pos;
            player2.level2Pos = locations.player2Level2Pos;
            player2.level3Pos = locations.player2Level3Pos;
            player2.level4Pos = locations.player2Level4Pos;
            player2.GetComponent<Energy>().energies = locations.player2Energies;

            player2.playerNumber = 2;
            player2.heroPos = heroPos[1];
        }
        else if (playerNum == 3)
        {
            GameObject player3Obj = Instantiate(playerPrefab, Vector3.zero,
                                                                Quaternion.identity);
            player3Obj.name = "Test Player 3";
            player3 = player3Obj.GetComponent<Player>();
            player3.level1Pos = locations.player3Level1Pos;
            player3.level2Pos = locations.player3Level2Pos;
            player3.level3Pos = locations.player3Level3Pos;
            player3.level4Pos = locations.player3Level4Pos;
            player3.GetComponent<Energy>().energies = locations.player3Energies;

            player3.playerNumber = 3;
            player3.heroPos = heroPos[2];
        }
        else
        {
            Debug.Log("Error! A player has an invalid number.");
        }
    }

    //takes in a deck, shuffles the deck in a rather naive way
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

    IEnumerator CiweilizationDeal1()
    {
        for (int i = 0; i < 4; i++)
        {
            foreach (string card in level1s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(cardPrefab, level1Pos[i].transform.position, Quaternion.identity, level1Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
        }
    }

    IEnumerator CiweilizationDeal2()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (string card in level2s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(cardPrefab, level2Pos[i].transform.position, Quaternion.identity, level2Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
        }
    }

    IEnumerator CiweilizationDeal3()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (string card in level3s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(cardPrefab, level3Pos[i].transform.position, Quaternion.identity, level3Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
        }
    }

    IEnumerator CiweilizationDeal4()
    {
        for (int i = 0; i < 1; i++)
        {
            foreach (string card in level4s[i])
            {
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(cardPrefab, level4Pos[i].transform.position, Quaternion.identity, level4Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
        }
    }

    public IEnumerator CiweilizationDealHeroes(int playerNum)
    {
        for (int i = 0; i < 3; i++)
        {
            if (playerNum == 1)
            {
                string card = player1Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(heroCardPrefab, player1Pos[i].transform.position,
                                                            Quaternion.identity, player1Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;             
            }
            else if (playerNum == 2)
            {
                string card = player2Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(heroCardPrefab, player2Pos[i].transform.position,
                                                            Quaternion.identity, player2Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
            else if (playerNum == 3)
            {
                string card = player3Heroes[i].Last<string>();
                yield return new WaitForSeconds(0.1f);
                GameObject newCard = Instantiate(heroCardPrefab, player3Pos[i].transform.position,
                                                            Quaternion.identity, player3Pos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
            }
        }
    }

    public IEnumerator CiweilizationDealChances()
    {
        for (int i = 0; i < 3; i++)
        {
            string card = chances[i].Last<string>();
            yield return new WaitForSeconds(0.1f);
            GameObject newCard1 = Instantiate(chanceCardPrefab, chancePos[i].transform.position,
                                                Quaternion.identity, chancePos[i].transform);
            newCard1.name = card;
            newCard1.GetComponent<Selectable>().faceUp = true;
        }

        CiweilizationSortChances();
    }

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
    public void CiweilizationFill1(Vector3 position)
    {
        string card = deck1.Last<string>();
        deck1.RemoveAt(deck1.Count - 1);

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, level4Pos[0].transform);
        newCard.name = card;
        newCard.GetComponent<Selectable>().faceUp = true;
    }
    public void CiweilizationFill2(Vector3 position)
    {
        string card = deck2.Last<string>();
        deck2.RemoveAt(deck2.Count - 1);

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, level4Pos[0].transform);
        newCard.name = card;
        newCard.GetComponent<Selectable>().faceUp = true;
    }
    public void CiweilizationFill3(Vector3 position)
    {
        string card = deck3.Last<string>();
        deck3.RemoveAt(deck3.Count - 1);

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, level4Pos[0].transform);
        newCard.name = card;
        newCard.GetComponent<Selectable>().faceUp = true;
    }
    public void CiweilizationFill4(Vector3 position)
    {
        string card = deck4.Last<string>();
        deck4.RemoveAt(deck4.Count - 1);

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity, level4Pos[0].transform);
        newCard.name = card;
        newCard.GetComponent<Selectable>().faceUp = true;
    }

    public double CiweilizationCountPlayerMoves(Player player)
    {
        double count = 1f;
        int wonderLevel2 = player.PlayerGetWonder_G2() + player.PlayerGetWonder_R2()
                        + player.PlayerGetWonder_Y2() + player.PlayerGetWonder_B2();
        int wonderLevel3 = player.PlayerGetWonder_G3() + player.PlayerGetWonder_R3()
                        + player.PlayerGetWonder_Y3() + player.PlayerGetWonder_B3();
        int wonderLevel4 = player.PlayerGetWonder_G4() + player.PlayerGetWonder_R4()
                        + player.PlayerGetWonder_Y4() + player.PlayerGetWonder_B4();

        if (isSpring == true)
        {
            if (player.PlayerGetG1() >= 0)
            {
                count += player.PlayerGetG1() * 0.5f;
            }
            count += wonderLevel2;
        }
        else if (isSummer == true)
        {
            if (player.PlayerGetR2() + wonderLevel2 - player.PlayerGetWonder_R2() >= 0)
            {
                count += (player.PlayerGetR2() + wonderLevel2 - player.PlayerGetWonder_R2()) * 0.5f;
            }
            count += wonderLevel3;
        }
        else if (isFall == true)
        {
            if (player.PlayerGetY3() + wonderLevel3 - player.PlayerGetWonder_Y3() >= 0)
            {
                count += (player.PlayerGetY3() + wonderLevel3 - player.PlayerGetWonder_Y3()) * 0.5f;
            }
            count += wonderLevel4;
        }
        else if (isWinter == true)
        {
            if (wonderLevel4 + player.PlayerGetB4() >= 1)
            {
                count += (player.PlayerGetB3() + wonderLevel3 - player.PlayerGetWonder_B3()) * 0.5f;
                count += wonderLevel4 + player.PlayerGetB4() - player.PlayerGetWonder_B4();
                count -= 1;
            }
        }
        
        return count;
    }

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
            ruleText.text = "Spring Time! \n\n"
                    + "Get an extra move for every two green-1 buildings and " 
                    + "every level-2 wonders you have.\n"
                    + "(wonders counts as all colors.)";
            StartCoroutine(CiweilizationDeal1());
        }
        if (turn == 4 && isSpring == true)
        {
            //audioManager.StopPlaying("Spring Theme");
            //audioManager.Play("Summer Theme");
            audioManager.Play("Season Start");

            isSpring = false;
            isSummer = true;
            ruleText.text = "Summer Time! \n\n"
                                + "Gain an extra move for every two Red-2 buildings and every level-3 wonders you have.\n"
                                + "(wonders counts as all colors.)";
            //ruleText.color = Color.red;
            Debug.Log("Spring has past and summer has come.");
            StartCoroutine(CiweilizationDeal2());
        }
        else if (turn == 7 && isSummer == true)
        {
            //audioManager.StopPlaying("Summer Theme");
            //audioManager.Play("Fall Theme");
            audioManager.Play("Season Start");

            isSummer = false;
            isFall = true;
            ruleText.text = "Fall Time! \n\n"
                                + "Gain an extra move for every two Yellow-3 buildings and every level-4 wonders you have.\n"
                                + "(wonders counts as all colors.)";
            //ruleText.color = Color.yellow;
            Debug.Log("Summer has past and Fall has come.");
            StartCoroutine(CiweilizationDeal3());
        }
        else if (turn == 10 && isFall == true)
        {
            //audioManager.StopPlaying("Fall Theme");
            //audioManager.Play("Winter Theme");
            audioManager.Play("Season Start");

            isFall = false;
            isWinter = true;
            ruleText.text = "Winter Time! \n\n"
                    + "Gain an extra move for having two Blue-3 buildings and a Blue-4 building and,\n"
                    + "and gain an extra move for each two of additional Blue-3 buildings and for each"
                    + "one of additional two Blue-4 building you have.\n"
                    + "(wonders counts as all colors.)";
            //ruleText.color = Color.cyan;
            Debug.Log("Fall has past and winter has come.");
            StartCoroutine(CiweilizationDeal4());
        }

        turnText.text = "Turn" + " " + turn.ToString();

        //Give the players the correct number of moves for their next turn;
        player1.moves = CiweilizationCountPlayerMoves(player1);
        player2.moves = CiweilizationCountPlayerMoves(player2);
        player3.moves = CiweilizationCountPlayerMoves(player3);
    }
}
