using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveGameData
{
    public int health;
    public float[] postion;


    // constructor
    public SaveGameData(int health, Vector2 rubyPos)
    {
        this.postion = new float[2];
        this.health = health;
        this.postion[0] = rubyPos.x;
        this.postion[1] = rubyPos.y;
        Debug.Log("save pos: " + this.postion[0] + " pos: " + this.postion[1]);
    }

}
