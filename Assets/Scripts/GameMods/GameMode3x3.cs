using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode3x3 : AbstractGameMode
{
    int correctid;
    public GameMode3x3()
    {
        keysForNumbers = new string[10] {"id10", "id11", "id12", "id13", "id14", "id15",
            "id16", "id17", "id18", "id19" };
        boardprefab =(GameObject) Resources.Load("Prefab/Board3x3");
        correctid = 1;

        name = "3x3";
        timer = 30;
    }

    public override void CalculateNextCorrectId(bool first=false)
    {
        if (first)
            correctid = 1;
        else
            correctid++;
    }

    public override bool CheckoutCorrectId(Tile tile)
    {
        if (correctid == tile._id)
        {
            CalculateNextCorrectId();
            return true;
        }
        return false;
    }

    public override bool CompleteLevel()
    {
        if (correctid == 10 | correctid > GameManager.ingamemanager.currentRound)
        {
            ShuffleArrayOfTiles();
            correctid = 1;
            return true;
        }
        return false;

    }

   
}
