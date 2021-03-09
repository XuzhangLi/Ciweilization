using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarbarianPlayer : Player
{

    /* Count the number of moves the player should get in the current season.*/
    public override double CountMoves()
    {
        double count = 1.25f;

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

        return count;
    }
}
