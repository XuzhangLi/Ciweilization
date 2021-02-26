using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public Text PlayerNameText;

    public int playerNumber = 0;

    private int G1, G2, G3, G4, R1, R2, R3, R4, Y1, Y2, Y3, Y4, B1, B2, B3, B4;

    private bool Wonder_G1, Wonder_G2, Wonder_G3, Wonder_G4, Wonder_R1, Wonder_R2, Wonder_R3, Wonder_R4,
        Wonder_Y1, Wonder_Y2, Wonder_Y3, Wonder_Y4, Wonder_B1, Wonder_B2, Wonder_B3, Wonder_B4;

    private AudioManager audioManager;

    public GameObject heroObj;

    public GameObject testEmptyObj;

    public double moves;

    public float xOffset = 0.5f;
    public float yOffset = -0.03f;
    public float zOffset = -0.03f;

    [HideInInspector] public Ciweilization ciweilization;

    public GameObject[] level1Prefabs;
    public GameObject[] level2Prefabs;
    public GameObject[] level3Prefabs;
    public GameObject[] level4Prefabs;

    public GameObject[] level1Pos;
    public GameObject[] level2Pos;
    public GameObject[] level3Pos;
    public GameObject[] level4Pos;
    public GameObject heroPos;

    public bool startEnergy = false;

    // Start is called before the first frame update
    void Start()
    {
        moves = 0;

        G1 = G2 = G3 = G4 = R1 = R2 = R3 = R4 = Y1 = Y2 = Y3 = Y4 = B1 = B2 = B3 = B4 = 0;

        Wonder_G1 = Wonder_G2 = Wonder_G3 = Wonder_G4 = Wonder_R1 = Wonder_R2 = Wonder_R3 = Wonder_R4
    = Wonder_Y1 = Wonder_Y2 = Wonder_Y3 = Wonder_Y4 = Wonder_B1 = Wonder_B2 = Wonder_B3 = Wonder_B4 = false;

        audioManager = FindObjectOfType<AudioManager>();

        ciweilization = FindObjectOfType<Ciweilization>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerBuild(string name)
    {
        ////////////////////////////////////////////// Level 1 buildings
        if (name == "G1")
        {
            G1 += 1;
            Debug.Log("Successfully Built.");
            audioManager.Play("Coin");
            //instantiate a G1 object
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
            Debug.Log("Successfully Built.");
            audioManager.Play("Coin");
            //instantiate a G1 object
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
            Debug.Log("Successfully Built.");
            audioManager.Play("Coin");
            //instantiate a G1 object
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
            Debug.Log("Successfully Built.");
            audioManager.Play("Coin");
            //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G1 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G4 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G4 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G4 object
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
                Debug.Log("Successfully Built.");
                audioManager.Play("Coin");
                //instantiate a G4 object
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

    public void PlayerWBuild(string name)
    {
        //////////////////////////////////////////////  Level 2 buildings

        if (name == "Wonder_G2" && ciweilization.wonderG2 == false)
        {
            Wonder_G2 = true;
            G2 += 1;
            ciweilization.wonderG2 = true;
            //instantiate a G1 object
            PlayerDisplay("G2", G2, true);
            audioManager.Play("Wonder");
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
            //instantiate a G1 object
            PlayerDisplay("R2", R2, true);
            audioManager.Play("Wonder");
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
            //instantiate a G1 object
            PlayerDisplay("Y2", Y2, true);
            audioManager.Play("Wonder");
            if (Y2 == 3)
            {
                PlayerWBuild("Wonder_Y3");
            }
        }
        else if (name == "Wonder_B2" && ciweilization.wonderB2 == false)
        {
            Wonder_B2 = true;
            B2 += 1;
            ciweilization.wonderB2 = true;
            //instantiate a G1 object
            PlayerDisplay("B2", B2, true);
            audioManager.Play("Wonder");
            if (B2 == 3)
            {
                PlayerWBuild("Wonder_B3");
            }
        }

        //////////////////////////////////////////////  Level 3 buildings

        else if (name == "Wonder_G3" && ciweilization.wonderG3 == false)
        {
            Wonder_G3 = true;
            G3 += 1;
            ciweilization.wonderG3 = true;
            //instantiate a G1 object
            PlayerDisplay("G3", G3, true);
            audioManager.Play("Wonder");
            if (G3 == 3)
            {
                PlayerWBuild("Wonder_G4");
            }
        }
        else if (name == "Wonder_R3" && ciweilization.wonderR3 == false)
        {
            Wonder_R3 = true;
            R3 += 1;
            ciweilization.wonderR3 = true;
            //instantiate a G1 object
            PlayerDisplay("R3", R3, true);
            audioManager.Play("Wonder");
            if (R3 == 3)
            {
                PlayerWBuild("Wonder_R4");
            }
        }
        else if (name == "Wonder_Y3" && ciweilization.wonderY3 == false)
        {
            Wonder_Y3 = true;
            Y3 += 1;
            ciweilization.wonderY3 = true;
            //instantiate a G1 object
            PlayerDisplay("Y3", Y3, true);
            audioManager.Play("Wonder");
            if (Y3 == 3)
            {
                PlayerWBuild("Wonder_Y4");
            }
        }
        else if (name == "Wonder_B3" && ciweilization.wonderB3 == false)
        {
            Wonder_B3 = true;
            B3 += 1;
            ciweilization.wonderB3 = true;
            //instantiate a G1 object
            PlayerDisplay("B3", B3, true);
            audioManager.Play("Wonder");
            if (B3 == 3)
            {
                PlayerWBuild("Wonder_B4");
            }
        }

        //////////////////////////////////////////////  Level 4 buildings

        else if (name == "Wonder_G4" && ciweilization.wonderG4 == false)
        {
            Wonder_G4 = true;
            G4 += 1;
            ciweilization.wonderG4 = true;
            //instantiate a G4 object
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

        }
        else if (name == "Wonder_R4" && ciweilization.wonderR4 == false)
        {
            Wonder_R4 = true;
            R4 += 1;
            ciweilization.wonderR4 = true;
            //instantiate a G4 object
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
        }
        else if (name == "Wonder_Y4" && ciweilization.wonderY4 == false)
        {
            Wonder_Y4 = true;
            Y4 += 1;
            ciweilization.wonderY4 = true;
            //instantiate a G4 object
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
        }
        else if (name == "Wonder_B4" && ciweilization.wonderB4 == false)
        {
            Wonder_B4 = true;
            B4 += 1;
            ciweilization.wonderB4 = true;
            //instantiate a G4 object
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
        }
        else
        {
            Debug.Log("Cannot build wonder because it's already built.");
        }
    }

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

    //public void CountPlayerMoves()
    void EndGameWhenTurnEnds()
    {
        audioManager.Play("Win");
        Debug.Log("You have reached the victory condition. The game ends by the end of the turn.");
    }

    /* Instantiate a building for the player. */
    void PlayerDisplay(string name, int num, bool isWonder)
    {
        Quaternion quat = Quaternion.identity;
        GameObject building;

        if (isWonder == false)
        {
            /////////////////////////////////// Level 1 Building Displays
            if (name == "G1")
            {
                building = Instantiate(level1Prefabs[0], new Vector3(level1Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "R1")
            {
                building = Instantiate(level1Prefabs[1], new Vector3(level1Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "Y1")
            {
                building = Instantiate(level1Prefabs[2], new Vector3(level1Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "B1")
            {
                building = Instantiate(level1Prefabs[3], new Vector3(level1Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level1Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level1Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }

            /////////////////////////////////// Level 2 Building Displays
            else if (name == "G2")
            {
                building = Instantiate(level2Prefabs[0], new Vector3(level2Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "R2")
            {
                building = Instantiate(level2Prefabs[1], new Vector3(level2Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "Y2")
            {
                building = Instantiate(level2Prefabs[2], new Vector3(level2Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "B2")
            {
                building = Instantiate(level2Prefabs[3], new Vector3(level2Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }

            /////////////////////////////////// Level 3 Building Displays
            else if (name == "G3")
            {
                building = Instantiate(level3Prefabs[0], new Vector3(level3Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "R3")
            {
                building = Instantiate(level3Prefabs[1], new Vector3(level3Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "Y3")
            {
                building = Instantiate(level3Prefabs[2], new Vector3(level3Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "B3")
            {
                building = Instantiate(level3Prefabs[3], new Vector3(level3Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }

            /////////////////////////////////// Level 4 Building Displays
            else if (name == "G4")
            {
                building = Instantiate(level4Prefabs[0], new Vector3(level4Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "R4")
            {
                building = Instantiate(level4Prefabs[1], new Vector3(level4Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "Y4")
            {
                building = Instantiate(level4Prefabs[2], new Vector3(level4Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
            else if (name == "B4")
            {
                building = Instantiate(level4Prefabs[3], new Vector3(level4Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                ChangeTagForPlayer(building);
            }
        }

        ///////////////////////////////////////////////// Wonders
        else if (isWonder == true)
        {
            /////////////////////////////////// Level 2 Wonder Displays

            if (name == "G2")
            {
                building = Instantiate(level2Prefabs[4], new Vector3(level2Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "R2")
            {
                building = Instantiate(level2Prefabs[5], new Vector3(level2Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "Y2")
            {
                building = Instantiate(level2Prefabs[6], new Vector3(level2Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "B2")
            {
                building = Instantiate(level2Prefabs[7], new Vector3(level2Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level2Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level2Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }

            /////////////////////////////////// Level 3 Wonder Displays
            else if (name == "G3")
            {
                building = Instantiate(level3Prefabs[4], new Vector3(level3Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "R3")
            {
                building = Instantiate(level3Prefabs[5], new Vector3(level3Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "Y3")
            {
                building = Instantiate(level3Prefabs[6], new Vector3(level3Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "B3")
            {
                building = Instantiate(level3Prefabs[7], new Vector3(level3Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level3Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level3Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }

            /////////////////////////////////// Level 4 Wonder Displays
            else if (name == "G4")
            {
                building = Instantiate(level4Prefabs[4], new Vector3(level4Pos[0].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[0].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[0].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "R4")
            {
                building = Instantiate(level4Prefabs[5], new Vector3(level4Pos[1].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[1].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[1].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "Y4")
            {
                building = Instantiate(level4Prefabs[6], new Vector3(level4Pos[2].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[2].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[2].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
            else if (name == "B4")
            {
                building = Instantiate(level4Prefabs[7], new Vector3(level4Pos[3].transform.position.x + (num - 1) * xOffset,
                                                  level4Pos[3].transform.position.y + (num - 1) * yOffset,
                                                  level4Pos[3].transform.position.z + (num - 1) * zOffset),
                                      quat, this.gameObject.transform);
                
            }
        }
    }

    private void ChangeTagForPlayer(GameObject obj)
    {
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
