using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameMode
{
    public GameObject boardprefab;
    [HideInInspector] public GameObject instantinatedBoard;
    public string[] keysForNumbers;

    float Record;
    public string name;

    abstract public bool CheckoutCorrectId(Tile tile);
    abstract public bool CompleteLevel();
    abstract public void CalculateNextCorrectId(bool first=false);
    abstract public void RestartAllParameters();
    
    public void LoadTiles()
    {
        GameManager.ingamemanager.tiles = instantinatedBoard.GetComponents<Tile>();

    }

    public virtual void ShuffleArrayOfTiles()
    {
        System.Random rnd = new System.Random();

        for (int i = 0; i < 100; i++)
        {
            int a = rnd.Next(0, GameManager.ingamemanager.tiles.Length);
            int b;
            do
            {
                b = rnd.Next(0, GameManager.ingamemanager.tiles.Length);
            } while (a == b);

            Tile switcher = GameManager.ingamemanager.tiles[a];
            GameManager.ingamemanager.tiles[a] = GameManager.ingamemanager.tiles[b];
            GameManager.ingamemanager.tiles[b] = switcher;
        }

        for (int i = 0; i < GameManager.ingamemanager.tiles.Length; i++) {
            if (i < GameManager.ingamemanager.currentRound)
                GameManager.ingamemanager.tiles[i].ChangeId(GameManager.ingamemanager.initializer.CurGM.keysForNumbers[i+1]);
            else
                GameManager.ingamemanager.tiles[i].ChangeId("id10");
            }
    }

    public void SetRecord(float R)
    {
        Record = R;
    }

    public float GetRecord()
    {
        return Record;
    }
}
