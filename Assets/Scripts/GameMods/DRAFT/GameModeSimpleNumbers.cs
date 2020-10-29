using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSimpleNumbers : AbstractGameMode
{
    List<int> correctids;
    int[] SimpleNumers = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
    int[] ComplicatedNumbers = {4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28, 30, 32, 33, 34, 35, 36,
        38, 39, 40, 42, 44, 45, 46, 48, 49, 50, 51, 52, 54, 55, 56, 57, 58, 60, 62, 63, 64, 65, 66, 70, 72, 74, 75, 76, 77,
        78, 80, 81, 82, 84, 85, 86, 87, 88, 90, 91, 92, 93, 94, 95, 96, 98, 99};

    public GameModeSimpleNumbers()
    {
        
    }
    public override void CalculateNextCorrectId(bool first = false)
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckoutCorrectId(Tile tile)
    {
        for (int i = 0; i < correctids.Count; i++)
            if (correctids[i] == tile._id)
            {
                correctids[i] = 0;

                correctids.Remove(correctids[i]);

                return true;
            }

        return false;
        
        throw new System.NotImplementedException();
    }

    /*
    public int[] DeleteElement(int[] arr, int j)
    {
        int[] a = new int[arr.Length];

        for (int i = 0; i < j; i++)
            a[i] = arr[i];

        for (int i = j + 1; i < arr.Length; i++)
            a[i - 1] = arr[i];

        return a;
    }   
    */

    public override bool CompleteLevel()
    {
        if (correctids.Count == 0)
            return true;

        return false;
        throw new System.NotImplementedException();
    }
    
    public override void RestartAllParameters()
    {
        throw new System.NotImplementedException();
    }

    public new void ShuffleArrayOfTiles()
    {
        System.Random rnd = new System.Random();

        int N;

        if (name == "s4x4")
            N = 8;
        else 
            N = rnd.Next(4, 5);

        for (int i = 0; i < N; i++)
            correctids.Add(SimpleNumers[rnd.Next(0, SimpleNumers.Length)]);

        List<int> IDS = correctids;

        for (int i = N; i < GameManager.ingamemanager.tiles.Length; i++)
            IDS.Add(ComplicatedNumbers[rnd.Next(0, ComplicatedNumbers.Length)]);

        for (int i = 0; i < 100; i++)
        {
            int a = rnd.Next(0, IDS.Count);
            int b;
            do
            {
                b = rnd.Next(0, IDS.Count);
            } while (a == b);

            int switcher = IDS[a];
            IDS[a] = IDS[b];
            IDS[b] = switcher;
        }

        for (int i = 0; i < GameManager.ingamemanager.tiles.Length; i++)
                GameManager.ingamemanager.tiles[i].ChangeId("id1" + IDS[i]);

        Debug.Log("___ARRAY_IS_SHUFFLED___");
    }
}
