using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarbarianPlayer : Player
{
    public override double CountMoves()
    {
        double count = defaultMoves + 0.25f; //Barbarian Hero Power

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

        //Adding saved moves and reseting saved moves to 0;
        count += savedMoves;
        savedMoves = 0f;

        //If in any case, the player has less than 1 move for a turn, it will have 1 move instead.
        if (count < 1f)
        {
            count = 1f;
        }

        return count;
    }
}
