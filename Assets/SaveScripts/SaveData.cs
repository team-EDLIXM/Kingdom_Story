using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Player player;

    public bool[] checkpoints;

    public bool[] isBossesAlive;
    
    public bool isNewGame;

    public int KeyCount;

   // public bool dryadAreAlive;
    
    //public bool finalBossAreAlive;
    public SaveData()
    {
        player = new Player();
        checkpoints = Array.Empty<bool>();
        isBossesAlive = Array.Empty<bool>();
        isNewGame = true;
        KeyCount = 0;
    }
}

[Serializable]
public class Player
{
    public Vector3 position;

    public int extraJumpValue;

    public bool FireballUnlocked;

    public Player()
    {
        position = new Vector3(50f, 1.5f, 0f);
        extraJumpValue = 0;
        FireballUnlocked = false;
    }
}

