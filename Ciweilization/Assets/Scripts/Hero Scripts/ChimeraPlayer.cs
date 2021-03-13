using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeraPlayer : Player
{
    /* Build the given wonder for the player and build another wonders if triples. */
    public override void PlayerWBuild(string name)
    {
        //////////////////////////////////////////////  Level 2 buildings

        if (name == "Wonder_G2" && ciweilization.wonderG2 == false)
        {
            Wonder_G2 = true;
            G2 += 1;
            ciweilization.wonderG2 = true;
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
            PlayerDisplay("G3", G3, true);
            audioManager.Play("Wonder");
            if (G3 == 3)
            {
                PlayerWBuild("Wonder_G4");
            }
            PlayHeroPowerAudio();
            PlayerBuild(RandomBuilding(3));
            PlayerBuild(RandomBuilding(3));
            PlayerBuild(RandomBuilding(3));
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
            PlayHeroPowerAudio();
            PlayerBuild("G2");
            PlayerBuild("R2");  
            PlayerBuild("Y2");
            PlayerBuild("B2");
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
            PlayHeroPowerAudio();
            savedMoves += 1;
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
            PlayHeroPowerAudio();
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
        }
        else
        {
            Debug.Log("Cannot build wonder because it's already built.");
        }
    }
}
