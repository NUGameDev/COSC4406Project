using UnityEngine;
using System.Collections;

/// <summary>
/// Defines default behaviour of an obstacle in the game world. 
/// 
/// This default obstacle behaviour does damage on contact and attempts to give chase to the player. 
/// 
/// Defines thisngs such as obstacle health, vulnerability to puffer charge, and damage given to player. 
/// </summary>
public  class ObstacleBehaviour : MonoBehaviour {
    /// <summary>
    /// Enum representing the current aggro state of the obstacle, if present
    /// </summary>
    public enum AggroState
    {
        Idle,
        Aggro,
        Reset
    }
    public bool hasAggro = false;
    public bool canChase = false;

    public int health = 100;
    public int damageDone = 25;
    


    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// update method called once per frame. 
    /// </summary>
    void Update()
    {

    }

    

   
}
