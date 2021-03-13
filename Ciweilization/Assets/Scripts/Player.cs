﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Photon.MonoBehaviour
{

    public int playerNumber = 0;

    protected int G1, G2, G3, G4, R1, R2, R3, R4, Y1, Y2, Y3, Y4, B1, B2, B3, B4;

    protected bool Wonder_G1, Wonder_G2, Wonder_G3, Wonder_G4, Wonder_R1, Wonder_R2, Wonder_R3, Wonder_R4,
        Wonder_Y1, Wonder_Y2, Wonder_Y3, Wonder_Y4, Wonder_B1, Wonder_B2, Wonder_B3, Wonder_B4;

    protected AudioManager audioManager;

    public GameObject heroObj;
    public GameObject testEmptyObj;

    public double moves = 0f;
    [HideInInspector] public double defaultMoves = 1f;
    public double savedMoves = 0f;

    [HideInInspector] public float xOffset = 0.08f;
    [HideInInspector] public float yOffset = -0.08f;
    [HideInInspector] public float zOffset = -0.08f;

    [HideInInspector] public Ciweilization ciweilization;

    public GameObject[] level1Prefabs;
    public GameObject[] level2Prefabs;
    public GameObject[] level3Prefabs;
    public GameObject[] level4Prefabs;

    [HideInInspector] public GameObject[] level1Pos = new GameObject[4];
    [HideInInspector] public GameObject[] level2Pos = new GameObject[4];
    [HideInInspector] public GameObject[] level3Pos = new GameObject[4];
    [HideInInspector] public GameObject[] level4Pos = new GameObject[4];
    public GameObject heroPos;

    public bool startEnergy = false;

    public bool heroPowerModeOn = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        moves = 0;
        savedMoves = 0;

        G1 = G2 = G3 = G4 = R1 = R2 = R3 = R4 = Y1 = Y2 = Y3 = Y4 = B1 = B2 = B3 = B4 = 0;

        Wonder_G1 = Wonder_G2 = Wonder_G3 = Wonder_G4 = Wonder_R1 = Wonder_R2 = Wonder_R3 = Wonder_R4
    = Wonder_Y1 = Wonder_Y2 = Wonder_Y3 = Wonder_Y4 = Wonder_B1 = Wonder_B2 = Wonder_B3 = Wonder_B4 = false;

        audioManager = FindObjectOfType<AudioManager>();

        ciweilization = FindObjectOfType<Ciweilization>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    /* Build the given building for the player and build a wonders if triples.
     * Only display the building if the client owns the player. */
    public virtual void PlayerBuild(string name)
    {
        ////////////////////////////////////////////// Level 1 buildings
        if (name == "G1")
        {
            G1 += 1;
            audioManager.Play("Coin");
            //Change PlayerDisplay function into non-RPC, target player from both 
            //player already calls PlayerBuild. We should only call PlayerDisplay if
            //photonView.isMine is true.
            PlayerDisplay("G1", G1, false);
            if (G1 == 3)
            {
                PlayerWBuild("Wonder_G2");
                Debug.Log("A triple! You get a wonder!");
            }
        }
        else if (name == "R1")
        {
            R1 += 1;
            audioManager.Play("Coin");
            PlayerDisplay("R1", R1, false);
            if (R1 == 3)
            {
                PlayerWBuild("Wonder_R2");
                Debug.Log("A triple! You get a wonder!");
            }
        }
        else if (name == "Y1")
        {
            Y1 += 1;
            audioManager.Play("Coin");
            PlayerDisplay("Y1", Y1, false);
            if (Y1 == 3)
            {
                PlayerWBuild("Wonder_Y2");
                Debug.Log("A triple! You get a wonder!");
            }
        }
        else if (name == "B1")
        {
            B1 += 1;
            audioManager.Play("Coin");
            PlayerDisplay("B1", B1, false);
            if (B1 == 3)
            {
                PlayerWBuild("Wonder_B2");
                Debug.Log("A triple! You get a wonder!");
            }
        }

        //////////////////////////////////////////////  Level 2 buildings

        else if (name == "G2")
        {
            if (G1 + G2 != 0)
            {
                G2 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("G2", G2, false);
                if (G2 == 3)
                {
                    PlayerWBuild("Wonder_G3");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "R2")
        {
            if (R1 + R2 != 0)
            {
                R2 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("R2", R2, false);
                if (R2 == 3)
                {
                    PlayerWBuild("Wonder_R3");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "Y2")
        {
            if (Y1 + Y2 != 0)
            {
                Y2 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("Y2", Y2, false);
                if (Y2 == 3)
                {
                    PlayerWBuild("Wonder_Y3");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "B2")
        {
            if (B1 + B2 != 0)
            {
                B2 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("B2", B2, false);
                if (B2 == 3)
                {
                    PlayerWBuild("Wonder_B3");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }

        //////////////////////////////////////////////  Level 3 buildings

        else if (name == "G3")
        {
            if (G2 + G3 != 0)
            {
                G3 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("G3", G3, false);
                if (G3 == 3)
                {
                    PlayerWBuild("Wonder_G4");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "R3")
        {
            if (R2 + R3 != 0)
            {
                R3 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("R3", R3, false);
                if (R3 == 3)
                {
                    PlayerWBuild("Wonder_R4");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "Y3")
        {
            if (Y2 + Y3 != 0)
            {
                Y3 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("Y3", Y3, false);
                if (Y3 == 3)
                {
                    PlayerWBuild("Wonder_Y4");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "B3")
        {
            if (B2 + B3 != 0)
            {
                B3 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("B3", B3, false);
                if (B3 == 3)
                {
                    PlayerWBuild("Wonder_B4");
                    Debug.Log("A triple! You get a wonder!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }

        //////////////////////////////////////////////  Level 4 buildings

        else if (name == "G4")
        {
            if (G3 + G4 != 0)
            {
                G4 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("G4", G4, false);
                if ((R4 + Y4 + B4 > 0) || (Wonder_G4 == true))
                {
                    EndGameWhenTurnEnds();
                }
                else
                {
                    Debug.Log("You only need another different level-4 to win!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "R4")
        {
            if (R3 + R4 != 0)
            {
                R4 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("R4", R4, false);
                if ((G4 + Y4 + B4 > 0) || (Wonder_R4 == true))
                {
                    EndGameWhenTurnEnds();
                }
                else
                {
                    Debug.Log("You only need another different level-4 to win!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "Y4")
        {
            if (Y3 + Y4 != 0)
            {
                Y4 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("Y4", Y4, false);
                if ((G4 + R4 + B4 > 0) || (Wonder_Y4 == true))
                {
                    EndGameWhenTurnEnds();
                }
                else
                {
                    Debug.Log("You only need another different level-4 to win!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
        else if (name == "B4")
        {
            if (B3 + B4 != 0)
            {
                B4 += 1;
                audioManager.Play("Coin");
                PlayerDisplay("B4", B4, false);
                if ((G4 + R4 + Y4 > 0) || (Wonder_B4 == true))
                {
                    EndGameWhenTurnEnds();
                }
                else
                {
                    Debug.Log("You only need another different level-4 to win!");
                }
            }
            else
            {
                audioManager.Play("Discard");
                Debug.Log("You can't build this right now. You need to build the building below this first.");
            }
        }
    }

    /* Build the given wonder for the player and build another wonders if triples. */
    public virtual void PlayerWBuild(string name)
    {
        //////////////////////////////////////////////  Level 2 buildings
        if (name == "Wonder_G2" && ciweilization.wonderG2 == false)
        {
            Wonder_G2 = true;
            G2 += 1;
            ciweilization.wonderG2 = true;
            PlayerDisplay("G2", G2, true);
            audioManager.Play("Wonder");

            //Gives a random level-1/level-2/level-3 at the start of every future era.

            if (G2 == 3)
            {
                PlayerWBuild("Wonder_G3");
            }
        }
        else if (name == "Wonder_R2" && ciweilization.wonderR2 == false)
        {
            Wonder_R2 = true;
            R2 += 1;
            ciweilization.wonderR2 = true;
            PlayerDisplay("R2", R2, true);
            audioManager.Play("Wonder");

            //Ignore all passive negative effects applied to you;
            //Everytime one of your building is destroyed, gain 0.25 base move.

            if (R2 == 3)
            {
                PlayerWBuild("Wonder_R3");
            }
        }
        else if (name == "Wonder_Y2" && ciweilization.wonderY2 == false)
        {
            Wonder_Y2 = true;
            Y2 += 1;
            ciweilization.wonderY2 = true;
            PlayerDisplay("Y2", Y2, true);
            audioManager.Play("Wonder");
            if (Y2 == 3)
            {
                PlayerWBuild("Wonder_Y3");
            }
            //You only need to pay one move to discover a chance instead of an entire turn.
        }
        else if (name == "Wonder_B2" && ciweilization.wonderB2 == false)
        {
            Wonder_B2 = true;
            B2 += 1;
            ciweilization.wonderB2 = true;
            PlayerDisplay("B2", B2, true);
            audioManager.Play("Wonder");
            if (B2 == 3)
            {
                PlayerWBuild("Wonder_B3");
            }
            //Prevent other players to build B1.
        }

        //////////////////////////////////////////////  Level 3 buildings
        else if (name == "Wonder_G3" && ciweilization.wonderG3 == false)
        {
            Wonder_G3 = true;
            G3 += 1;
            ciweilization.wonderG3 = true;
            PlayerDisplay("G3", G3, true);
            audioManager.Play("Wonder");
            if (G3 == 3)
            {
                PlayerWBuild("Wonder_G4");
            }
            //If you have 4 or more different kinds of level-2 buildings, build 3 random level-4 buildings.
        }
        else if (name == "Wonder_R3" && ciweilization.wonderR3 == false)
        {
            Wonder_R3 = true;
            R3 += 1;
            ciweilization.wonderR3 = true;
            PlayerDisplay("R3", R3, true);
            audioManager.Play("Wonder");
            if (R3 == 3)
            {
                PlayerWBuild("Wonder_R4");
            }
            //If you have 6 or more other Red buildings, gain 0.25 base move. 
        }
        else if (name == "Wonder_Y3" && ciweilization.wonderY3 == false)
        {
            Wonder_Y3 = true;
            Y3 += 1;
            ciweilization.wonderY3 = true;
            PlayerDisplay("Y3", Y3, true);
            audioManager.Play("Wonder");
            if (Y3 == 3)
            {
                PlayerWBuild("Wonder_Y4");
            }
            //If you have discovered a chance this game,
                //you may store any number of leftover moves to your next turn.
        }
        else if (name == "Wonder_B3" && ciweilization.wonderB3 == false)
        {
            Wonder_B3 = true;
            B3 += 1;
            ciweilization.wonderB3 = true;
            PlayerDisplay("B3", B3, true);
            audioManager.Play("Wonder");
            if (B3 == 3)
            {
                PlayerWBuild("Wonder_B4");
            }
            //If you have a Blue-4 already, upgrades all your level-1 buildings.
        }

        //////////////////////////////////////////////  Level 4 buildings
        else if (name == "Wonder_G4" && ciweilization.wonderG4 == false)
        {
            Wonder_G4 = true;
            G4 += 1;
            ciweilization.wonderG4 = true;
            PlayerDisplay("G4", G4, true);
            audioManager.Play("Wonder");
            if ((G4 + R4 + Y4 + B4 >= 2))
            {
                EndGameWhenTurnEnds();
            }
            else
            {
                Debug.Log("You only need another different level-4 to win!");
            }
            //For each of your green buildings, build a random building of the same level.
        }
        else if (name == "Wonder_R4" && ciweilization.wonderR4 == false)
        {
            Wonder_R4 = true;
            R4 += 1;
            ciweilization.wonderR4 = true;
            PlayerDisplay("R4", R4, true);
            audioManager.Play("Wonder");
            if ((G4 + R4 + Y4 + B4 >= 2))
            {
                EndGameWhenTurnEnds();
            }
            else
            {
                Debug.Log("You only need another different level-4 to win!");
            }
            //Lose 0.5 base move, but gain 0.5 extra move this turn.
                //(If you have less than 1 move at the start of your turn, it counts as you have 1 move.)
        }
        else if (name == "Wonder_Y4" && ciweilization.wonderY4 == false)
        {
            Wonder_Y4 = true;
            Y4 += 1;
            ciweilization.wonderY4 = true;
            PlayerDisplay("Y4", Y4, true);
            audioManager.Play("Wonder");
            if ((G4 + R4 + Y4 + B4 >= 2))
            {
                EndGameWhenTurnEnds();
            }
            else
            {
                Debug.Log("You only need another different level-4 to win!");
            }
            //Discover a free chance a the start of your next turn.
        }
        else if (name == "Wonder_B4" && ciweilization.wonderB4 == false)
        {
            Wonder_B4 = true;
            B4 += 1;
            ciweilization.wonderB4 = true;
            PlayerDisplay("B4", B4, true);
            audioManager.Play("Wonder");
            if ((G4 + R4 + Y4 + B4 >= 2))
            {
                EndGameWhenTurnEnds();
            }
            else
            {
                Debug.Log("You only need another different level-4 to win!");
            }
            //Build a copy of each level-4 building owned by players.
                //If you can't build a certain level-4 building, 
                    //build the highest level building you can of that color insetad.
        }

        ////////////////////////////////////////////// Wonder already built
        else
        {
            Debug.Log("You can't build the wonder because it's already built.");
        }
    }

    /* Return a random color building name of the given level. */
    public string RandomBuilding(int level)
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

        return suit + level;
    }

    /* Delete the given building for the player. */
    public void PlayerDelete(string name)
    {
        if (name == "G1")
        {
            G1 -= 1;
        }
        else if (name == "R1")
        {
            R1 -= 1;
        }
        else if (name == "Y1")
        {
            Y1 -= 1;
        }
        else if (name == "B1")
        {
            B1 -= 1;
        }
        else if (name == "G2")
        {
            G2 -= 1;
        }
        else if (name == "R2")
        {
            R2 -= 1;
        }
        else if (name == "Y2")
        {
            Y2 -= 1;
        }
        else if (name == "B2")
        {
            B2 -= 1;
        }
        else if (name == "G3")
        {
            G3 -= 1;
        }
        else if (name == "R3")
        {
            R3 -= 1;
        }
        else if (name == "Y3")
        {
            Y3 -= 1;
        }
        else if (name == "B3")
        {
            B3 -= 1;
        }
        else if (name == "G4")
        {
            G4 -= 1;
        }
        else if (name == "R4")
        {
            R4 -= 1;
        }
        else if (name == "Y4")
        {
            Y4 -= 1;
        }
        else if (name == "B4")
        {
            B4 -= 1;
        }
        else
        {
            Debug.Log("Error! You just deleted a building with an invalid name.");
        }
    }

    /* Mark this is the last turn of the game. 
     * If the client owns the winnign player, plays a winning sound and mark
     the player as winning. */
    protected void EndGameWhenTurnEnds()
    {
        if (photonView.isMine)
        {
            ciweilization.win = true;
            photonView.RPC("PlayAudioForAll", PhotonTargets.AllBuffered, "Win");
        }
        Debug.Log("Some player has reached the victory condition. " +
            "The game ends by the end of the turn.");
        ciweilization.isLastTurn = true;
    }

    /* Instantiate a building for the player and set its tag to the player's building tag if 
     the client owns the player. */
    public void PlayerDisplay(string name, int num, bool isWonder)
    {
        Quaternion quat = Quaternion.identity;
        GameObject building;

        // This function does nothing if the client doesn't own the player.
        if (photonView.isMine == false)
        {
            Debug.Log("PlayerDisplayCalledWithWrongClient.");
            return;
        }
        else
        {
            Debug.Log("PlayerDisplayCalledWithRightClient.");
        }

        if (isWonder == false)
        {
            /////////////////////////////////// Level 1 Building Displays
            if (name == "G1")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level1Prefabs[0].name, 
                                                  new Vector3(level1Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "R1")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level1Prefabs[1].name,
                                                  new Vector3(level1Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "Y1")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level1Prefabs[2].name,
                                                  new Vector3(level1Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "B1")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level1Prefabs[3].name,
                                                  new Vector3(level1Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }

            /////////////////////////////////// Level 2 Building Displays
            else if (name == "G2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[0].name,
                                                  new Vector3(level2Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "R2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[1].name,
                                                  new Vector3(level2Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "Y2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[2].name,
                                                  new Vector3(level2Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "B2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[3].name,
                                                  new Vector3(level2Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }

            /////////////////////////////////// Level 3 Building Displays
            else if (name == "G3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[0].name,
                                                  new Vector3(level3Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "R3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[1].name,
                                                  new Vector3(level3Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "Y3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[2].name,
                                                  new Vector3(level3Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "B3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[3].name,
                                                  new Vector3(level3Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }

            /////////////////////////////////// Level 4 Building Displays
            else if (name == "G4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[0].name,
                                                  new Vector3(level4Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "R4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[1].name,
                                                  new Vector3(level4Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "Y4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[2].name,
                                                  new Vector3(level4Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
            else if (name == "B4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[3].name,
                                                  new Vector3(level4Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
                photonView.RPC("ChangeTagForPlayer", PhotonTargets.AllBuffered, building.GetPhotonView().viewID);
            }
        }

        ///////////////////////////////////////////////// Wonders
        else if (isWonder == true)
        {
            /////////////////////////////////// Level 2 Wonder Displays

            if (name == "G2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[4].name, 
                                                  new Vector3(level2Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "R2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[5].name,
                                                  new Vector3(level2Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "Y2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[6].name,
                                                  new Vector3(level2Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "B2")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level2Prefabs[7].name,
                                                  new Vector3(level2Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }

            /////////////////////////////////// Level 3 Wonder Displays
            else if (name == "G3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[4].name,
                                                  new Vector3(level3Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "R3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[5].name,
                                                  new Vector3(level3Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "Y3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[6].name,
                                                  new Vector3(level3Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "B3")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level3Prefabs[7].name,
                                                  new Vector3(level3Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }

            /////////////////////////////////// Level 4 Wonder Displays
            else if (name == "G4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[4].name,
                                                  new Vector3(level4Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[0].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "R4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[5].name,
                                                  new Vector3(level4Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[1].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "Y4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[6].name,
                                                  new Vector3(level4Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[2].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
            else if (name == "B4")
            {
                building = PhotonNetwork.Instantiate("Player Display Prefabs/" + level4Prefabs[7].name,
                                                  new Vector3(level4Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[3].transform.position.z + (num - 1) * zOffset),
                                                  quat, 0);
            }
        }
    }

    /* Count the number of moves the player should get in the current season.*/
    public virtual double CountMoves()
    {
        /* Unused parameters but useful notes when coding for hero players:
        int level1 = PlayerGetG1() + PlayerGetR1() +
                PlayerGetY1() + PlayerGetB1();
        int level2 = PlayerGetG2() + PlayerGetR2() +
                        PlayerGetY2() + PlayerGetB2();
        int level3 = PlayerGetG3() + PlayerGetR3() +
                PlayerGetY3() + PlayerGetB3();
        int level4 = PlayerGetG4() + PlayerGetR4() +
                        PlayerGetY4() + PlayerGetB4();
        int wonderLevel2 = PlayerGetWonder_G2() + PlayerGetWonder_R2()
                + PlayerGetWonder_Y2() + PlayerGetWonder_B2();
        int wonderLevel3 = PlayerGetWonder_G3() + PlayerGetWonder_R3()
                + PlayerGetWonder_Y3() + PlayerGetWonder_B3();
        int wonderLevel4 = PlayerGetWonder_G4() + PlayerGetWonder_R4()
                + PlayerGetWonder_Y4() + PlayerGetWonder_B4(); */

        double count = defaultMoves;

        if (ciweilization.isSpring == true)
        {
            count += CountMovesSpring();
        }
        else if (ciweilization.isSummer == true)
        {
            count += CountMovesSummer();
        }
        else if (ciweilization.isFall == true)
        {
            count += CountMovesFall();
        }
        else if (ciweilization.isWinter == true)
        {
            count += CountMovesWinter();
        }

        count += savedMoves;
        savedMoves = 0f;

        return count;
    }

    /* Count the number of extra moves the player should get in Spring.*/
    protected virtual double CountMovesSpring()
    {
        int level1 = PlayerGetG1() + PlayerGetR1() +
                        PlayerGetY1() + PlayerGetB1();
        int level2 = PlayerGetG2() + PlayerGetR2() +
                        PlayerGetY2() + PlayerGetB2();

        double count = 0f;
        count += level1 * 0.25f;
        count += level2 * 0.5f;
        count += PlayerGetG1() * 0.25f;
        count += PlayerGetG2() * 0.5f;

        return count;
    }

    /* Count the number of extra moves the player should get in Summer.*/
    protected virtual double CountMovesSummer()
    {

        int level2 = PlayerGetG2() + PlayerGetR2() +
                        PlayerGetY2() + PlayerGetB2();
        int level3 = PlayerGetG3() + PlayerGetR3() +
                        PlayerGetY3() + PlayerGetB3();

        double count = 0f;
        count += level2 * 0.25f;
        count += level3 * 0.5f;
        count += PlayerGetR2() * 0.25f;
        count += PlayerGetR3() * 0.5f;

        return count;
    }

    /* Count the number of extra moves the player should get in Fall.*/
    protected virtual double CountMovesFall()
    {
        int level3 = PlayerGetG3() + PlayerGetR3() +
                        PlayerGetY3() + PlayerGetB3();
        int level4 = PlayerGetG4() + PlayerGetR4() +
                        PlayerGetY4() + PlayerGetB4();

        double count = 0f;
        count += level3 * 0.25f;
        count += level4 * 0.5f;
        count += PlayerGetY3() * 0.25f;
        count += PlayerGetY4() * 0.5f;

        return count;
    }

    /* Count the number of extra moves the player should get in Winter.*/
    protected virtual double CountMovesWinter()
    {
        int level4 = PlayerGetG4() + PlayerGetR4() +
                        PlayerGetY4() + PlayerGetB4();

        int wonderLevel2 = PlayerGetWonder_G2() + PlayerGetWonder_R2()
                + PlayerGetWonder_Y2() + PlayerGetWonder_B2();
        int wonderLevel3 = PlayerGetWonder_G3() + PlayerGetWonder_R3()
                + PlayerGetWonder_Y3() + PlayerGetWonder_B3();
        int wonderLevel4 = PlayerGetWonder_G4() + PlayerGetWonder_R4()
                + PlayerGetWonder_Y4() + PlayerGetWonder_B4();
        int wonderTotal = wonderLevel2 + wonderLevel3 + wonderLevel4;

        double count = 0f;
        count += level4 * 0.25f;
        count += (wonderLevel3 * 0.25f + wonderLevel2 * 0.25f);
        count += PlayerGetB4() * 0.25f;
        count += PlayerGetB3() * 0.25f;

        return count;
    }

    /* Change the given object's tag to the player's building according to the player number. */
    [PunRPC]
    public void ChangeTagForPlayer(int objID)
    {
        GameObject obj = PhotonView.Find(objID).gameObject;

        if (playerNumber == 1)
        {
            obj.tag = "BuildingPlayer1";
        }
        else if (playerNumber == 2)
        {
            obj.tag = "BuildingPlayer2";
        }
        else if (playerNumber == 3)
        {
            obj.tag = "BuildingPlayer3";
        }
        else
        {
            Debug.Log("Invalid player number.");
        }
    }

    /* Change the player's moves by given amount. */
    [PunRPC]
    public void ChangePlayerMoves(float x)
    {
        moves += x;
    }

    public virtual void PlayerStartSpring()
    {
        //Do nothing if there isn't any hero powers.
    }
    public virtual void PlayerStartSummer()
    {
        if (Wonder_G2)
        {
            string suit = "";
            int level = 1;
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

            PlayWonderAbilityAudio();
            PlayerBuild(suit + level);
        }
    }
    public virtual void PlayerStartFall()
    {
        if (Wonder_G2)
        {
            string suit = "";
            int level = 2;
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

            PlayWonderAbilityAudio();
            PlayerBuild(suit + level);
        }
    }
    public virtual void PlayerStartWinter()
    {
        if (Wonder_G2)
        {
            string suit = "";
            int level = 3;
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

            PlayWonderAbilityAudio();
            PlayerBuild(suit + level);
        }
    }
    public virtual void PlayerStartRound()
    {
        //Do nothing if there isn't any hero powers.
    }
    public virtual void PlayerAtTheStartOfTurn()
    {
        //Do nothing if there isn't any hero powers.
    }

    /* Play the hero power audio for the player's client. */
    public void PlayHeroPowerAudio()
    {
        audioManager.Play("Hero Power");
    }

    /* Play the wonder ability audio for the player's client. */
    public void PlayWonderAbilityAudio()
    {
        audioManager.Play("Wonder Ability");
    }

    public int BoolToInt(bool b)
    {
        if (b == true)
        {
            return 1;
        }
        return 0;
    }

    public int PlayerGetG1()
    {
        return G1;
    }
    public int PlayerGetR1()
    {
        return R1;
    }
    public int PlayerGetY1()
    {
        return Y1;
    }
    public int PlayerGetB1()
    {
        return B1;
    }
    public int PlayerGetG2()
    {
        return G2;
    }
    public int PlayerGetR2()
    {
        return R2;
    }
    public int PlayerGetY2()
    {
        return Y2;
    }
    public int PlayerGetB2()
    {
        return B2;
    }
    public int PlayerGetG3()
    {
        return G3;
    }
    public int PlayerGetR3()
    {
        return R3;
    }
    public int PlayerGetY3()
    {
        return Y3;
    }
    public int PlayerGetB3()
    {
        return B3;
    }
    public int PlayerGetG4()
    {
        return G4;
    }
    public int PlayerGetR4()
    {
        return R4;
    }
    public int PlayerGetY4()
    {
        return Y4;
    }
    public int PlayerGetB4()
    {
        return B4;
    }

    public int PlayerGetWonder_G2()
    {
        return BoolToInt(Wonder_G2);
    }
    public int PlayerGetWonder_R2()
    {
        return BoolToInt(Wonder_R2);
    }
    public int PlayerGetWonder_Y2()
    {
        return BoolToInt(Wonder_Y2);
    }
    public int PlayerGetWonder_B2()
    {
        return BoolToInt(Wonder_B2);
    }
    public int PlayerGetWonder_G3()
    {
        return BoolToInt(Wonder_G3);
    }
    public int PlayerGetWonder_R3()
    {
        return BoolToInt(Wonder_R3);
    }
    public int PlayerGetWonder_Y3()
    {
        return BoolToInt(Wonder_Y3);
    }
    public int PlayerGetWonder_B3()
    {
        return BoolToInt(Wonder_B3);
    }
    public int PlayerGetWonder_G4()
    {
        return BoolToInt(Wonder_G4);
    }
    public int PlayerGetWonder_R4()
    {
        return BoolToInt(Wonder_R4);
    }
    public int PlayerGetWonder_Y4()
    {
        return BoolToInt(Wonder_Y4);
    }
    public int PlayerGetWonder_B4()
    {
        return BoolToInt(Wonder_B4);
    }
}
