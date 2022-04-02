using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Player player;

    public bool[] checkpoints;
    
    public SaveData()
    {
        player = new Player();
        checkpoints = null;
    }
}

[Serializable]
public class Player
{
    public Vector3 position;

    public int extraJumpValue;

    public Player()
    {
        position = new Vector3(50f, 1.5f, 0f);
        extraJumpValue = 0;
    }
}

