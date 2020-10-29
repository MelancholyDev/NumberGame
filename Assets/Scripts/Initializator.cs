using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    public AbstractGameMode CurGM;
    [SerializeField] bool DevMode = true;

    public void IinitializeAndShow()
    {
        CurGM.instantinatedBoard = Instantiate(CurGM.boardprefab);
        GameManager.ingamemanager.tiles = CurGM.instantinatedBoard.GetComponentsInChildren<Tile>();
    }

}
