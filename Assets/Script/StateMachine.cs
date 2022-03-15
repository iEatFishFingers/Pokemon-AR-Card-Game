using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Vuforia;

public class StateMachine : MonoBehaviour
{
    public GameObject Canvas;
    //the two lines below will be used for transforming the pokemons


    //the two lines below will be used for controlling the stats of the pokemon e.g health
    PokemonBase player1Stats; // user controlled player
    PokemonBase player2Stats;

    //ui stuff
    public TextMeshProUGUI Player1Name;
    public Text Player1HP;

    public Text Player2Name;
    public Text Player2HP;
    public Text DialogText;

    public Text playerAtt1;
    public Text playerAtt2;
    public Text playerAtt3;
    public Text playerAtt4;


    //gamestate 
    public enum GameState { Start, Player1Turn, Player2Turn, Won, Loss }
    public GameState state;

    bool Isp1Populated = false;



    void Start()
    {
        Canvas.gameObject.SetActive(false);
        DialogText.text = "Welcome to Pokemon AR";
        state = GameState.Start;
        Debug.Log("Game Started");


    }


    void Update()
    {
        Player1HP.text = player1Stats.currHP + "/" + player1Stats.baseHP;
        Player2HP.text = player2Stats.currHP + "/" + player2Stats.baseHP;
    }
    public void loadplayer1(PokemonBase stats)
    {
        player1Stats = stats;
        Isp1Populated = true;

        Player1Name.text = stats.name;
        Player1HP.text = stats.baseHP + "/" + stats.baseHP;
        playerAtt1.text = stats.Attack1Name;
        playerAtt2.text = stats.Attack2Name;
        playerAtt3.text = stats.Attack3Name;
        playerAtt4.text = stats.Attack4Name;

        Debug.Log("the pokemon that loaded is" + stats.name);
    }

    public void loadplayer2(PokemonBase stats)
    {
        player2Stats = stats;

        Player2Name.text = stats.name;
        Player2HP.text = stats.baseHP + "/" + stats.baseHP;
        Debug.Log("the pokemon that loaded is" + stats.name);
        BattleSetup();
    }



    void initPlayers(PokemonBase stats)
    {
        if (!Isp1Populated)
        {
            loadplayer1(stats);
        }
        else
        {
            loadplayer2(stats);
        }

        BattleSetup();
    }

    void BattleSetup()
    {
        //setup
        Canvas.gameObject.SetActive(true);
        state = GameState.Player1Turn;
        DialogText.text = "What will " + player1Stats.name + " do ?";
        Debug.Log("Battle Setup Successful");


    }

    public void whichplayer(int attack)
    {
        Debug.Log("Button pressed now");

        if (state == GameState.Player1Turn)
        {
            DialogText.text = "What will " + player2Stats.name + " do ?";
            player1turn(attack);
        }
        else if (state == GameState.Player2Turn)
        {
            DialogText.text = "What will " + player2Stats.name + " do ?";
            player2turn(attack);
        }
        Debug.Log(state);
    }

    void player1turn(int attack)
    {

        switch (attack)
        {
            case 1:
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack1Damage;
                break;
            case 2:
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack2Damage;
                break;
            case 3:
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack3Damage;
                break;
            case 4:
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack4Damage;
                break;
        }



        if (player2Stats.currHP <= 0)
        {
            Canvas.gameObject.SetActive(false);
            state = GameState.Won;
        }
        else
        {
            state = GameState.Player2Turn;
        }
        Debug.Log("Damage done and player 2 turn on next hit");
        Debug.Log(state);
        playerAttacks();
    }

    void player2turn(int attack)
    {


        switch (attack)
        {
            case 1:
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack1Damage;
                break;
            case 2:
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack2Damage;
                break;
            case 3:
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack3Damage;
                break;
            case 4:
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack4Damage;
                break;
        }

        if (player1Stats.currHP <= 0)
        {
            state = GameState.Loss;
            Canvas.gameObject.SetActive(false);
        }
        else
        {
            state = GameState.Player1Turn;
        }
        Debug.Log(state);
        playerAttacks();
    }

    void playerAttacks()
    {
        if (state == GameState.Player1Turn)
        {
            playerAtt1.text = player1Stats.Attack1Name;
            playerAtt2.text = player1Stats.Attack2Name;
            playerAtt3.text = player1Stats.Attack3Name;
            playerAtt4.text = player1Stats.Attack4Name;
        }
        else if (state == GameState.Player2Turn)
        {
            playerAtt1.text = player2Stats.Attack1Name;
            playerAtt2.text = player2Stats.Attack2Name;
            playerAtt3.text = player2Stats.Attack3Name;
            playerAtt4.text = player2Stats.Attack4Name;
        }
    }

}

