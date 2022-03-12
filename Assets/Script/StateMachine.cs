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

    public GameObject[] listofPokemon;

    public GameObject player1;

    public GameObject player2;

    //the two lines below will be used for controlling the stats of the pokemon e.g health
    public PokemonBase player1Stats; // user controlled player
    public PokemonBase player2Stats;

    //ui stuff
    public TextMeshProUGUI Player1Name;
    public Text Player1HP;

    public Text Player2Name;
    public Text Player2HP;
    public Text DialogText;

    //gamestate 
    public enum GameState { Start, Player1Turn, Player2Turn, Won, Loss }
    public GameState state;




    void Start()
    {
        Canvas.gameObject.SetActive(false);
        DialogText.text = "Welcome to Pokemon AR";
        state = GameState.Start;
        initPlayers();
        Debug.Log("Game Started");


    }


    void Update()
    {
        // Player1HP.text = player1Stats.currHP + "/" + player1Stats.baseHP;
        // Player2HP.text = player2Stats.currHP + "/" + player2Stats.baseHP;
    }

    void initPlayers()
    {
        Debug.Log("now scanning for first pokemon");
        for (int i = 0; i < listofPokemon.Length - 1; i++)
        {

            var imageTarget = listofPokemon[i];
            var trackable = imageTarget.GetComponent<TargetStatus>();
            var status = trackable.Status;
            Debug.Log("the status of" + listofPokemon[i].gameObject.name + status);

        }

        //scan the first can and that would be player one player one 


        // scan the second and be named player 2 


        // start the fight sequence
        Debug.Log("Init pokemons successfull");
        BattleSetup();

    }

    void BattleSetup()
    {
        //setup
        Player1Name.text = player1Stats.name;
        Player1HP.text = player1Stats.currHP + "/" + player1Stats.baseHP;
        Player2Name.text = player2Stats.name;
        Player2HP.text = player2Stats.currHP + "/" + player2Stats.baseHP;
        state = GameState.Player1Turn;
        DialogText.text = "What will " + player1Stats.name + " do ?";
        Debug.Log("Battle Setup Successful");

    }

    public void whichplayer()
    {
        Debug.Log("Button pressed now");
        DialogText.text = "button pressed";
        if (state == GameState.Player1Turn)
        {
            player1turn();
        }
        if (state == GameState.Player2Turn)
        {
            player2turn();
        }
    }

    void player1turn()
    {
        player2Stats.currHP = player2Stats.currHP - (player2Stats.currDEF - player1Stats.currATK);

        if (player2Stats.currHP <= 0)
        {
            state = GameState.Won;
        }
        else
        {
            state = GameState.Player2Turn;
        }
        Debug.Log("Damage done and player 2 turn on next hit");
    }

    void player2turn()
    {
        player1Stats.currHP = player1Stats.currHP - (player1Stats.currDEF - player2Stats.currATK);

        if (player2Stats.currHP <= 0)
        {
            state = GameState.Loss;
        }
        else
        {
            state = GameState.Player1Turn;
        }
    }
}
