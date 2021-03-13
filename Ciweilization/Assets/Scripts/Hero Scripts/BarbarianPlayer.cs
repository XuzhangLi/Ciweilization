using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarbarianPlayer : Player
{
    public override double CountMoves()
    {
        double count = defaultMoves;
        count += 0.25f; //Barbarian Hero Power

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
}
