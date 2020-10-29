using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode4x4 : AbstractGameMode
{
    int correctid;

    public GameMode4x4()
    {
        keysForNumbers = new string[17] { "id10", "id11", "id12", "id13", "id14", "id15",
                    "id16", "id17", "id18", "id19", "id0A10", "id0B11", "id0C12",
                    "id0D13", "id0E14", "id0F15", "id0G16"};
 
        boardprefab = (GameObject)Resources.Load("Prefab/Board4x4");
        correctid = 1;

        name = "4x4";
    }

    public override void CalculateNextCorrectId(bool first = false)
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
        else return false;
    }

    public override bool CompleteLevel()
    {
        if (correctid == 17 | correctid > GameManager.ingamemanager.currentRound)
        {
            ShuffleArrayOfTiles();
            correctid = 1;
            return true;
        }
        else return false;

    }

    public override void RestartAllParameters()
    {
        GameManager.ingamemanager.RestartAllParameters(1000);
    }
}

