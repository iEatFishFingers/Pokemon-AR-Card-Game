using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameObject player1; // user controlled player
    public GameObject player2; // either ai or the second user controlled player
   
    public enum GameState { Start, Player1Turn, Player2Turn, Won, Loss}
    public GameState state;


    void Start()
    {
        state = GameState.Start;
        initPlayers();
        
    }

   
    void Update()
    {
        
    }

    void initPlayers()
    {
        //scan the first card which will then be name as player 1 

        // scan the second and be named player 2 

        // start the fight sequence
        BattleSetup();

    }

    void BattleSetup()
    {
        //setup
        state = GameState.Player1Turn;
    }
}
