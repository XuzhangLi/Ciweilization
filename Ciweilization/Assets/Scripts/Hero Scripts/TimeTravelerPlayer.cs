using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelerPlayer : Player
{
    private bool tookExtraTurn = false;

    // Update is called once per frame
    protected override void Update()
    {
        if (photonView.isMine && ciweilization.activePlayerNumber == playerNumber)
        {
            if (ciweilization.disconnectPanelOn == false)
            {
                GetHeroPowerClick(); 
            }
        }
    }

    void GetHeroPowerClick()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HeroPower();
        }
    }

    /* Count the number of moves the player should get in the current season.*/
    public override double CountMoves()
    {
        if (tookExtraTurn == true)
        {
            tookExtraTurn = false;
            return 0f;
        }

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

        return count;
    }

    void HeroPower()
    {
        PlayHeroPowerAudio();
        moves = CountMoves();
        tookExtraTurn = true;
    }
}
