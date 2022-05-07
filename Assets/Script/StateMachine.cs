using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class StateMachine : MonoBehaviour
{
    public static StateMachine SM;

    public GameObject Canvas;
    public GameObject RestartButton;
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

    public Image Player1HealthBar;
    public Image Player2HealthBar;

    //gamestate 
    public enum GameState { Start, Player1Turn, Player2Turn, Player1Won, Player2Won }
    public GameState state;

    bool Isp1Populated = false;

    public Animator Lucario;
    public Dictionary<string, float> cliptime;

    public void GetClipTimes()
    {
        AnimationClip[] Clips = Lucario.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in Clips)
            if (!cliptime.ContainsKey(clip.name))
            {
                cliptime.Add(clip.name, clip.length);
                Debug.Log(clip.name);
            }

    }


    void Start()
    {
        Canvas.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        DialogText.text = "Welcome to Pokemon AR";
        state = GameState.Start;
        Debug.Log("Game Started");


    }

    void Update()
    {
        if (state == GameState.Player1Turn || state == GameState.Player2Turn)
        {
            healthBarMovement();
            HpColorChange();
        }

    }

    public void reset()
    {
        player1Stats.currATK = player1Stats.baseHP;
        player1Stats.currDEF = player1Stats.baseDEF;
        player1Stats.currHP = player1Stats.baseHP;
        player1Stats.currHP = player1Stats.baseHP;
        player1Stats.currMP = player1Stats.baseMP;


        player2Stats.currATK = player2Stats.baseHP;
        player2Stats.currDEF = player2Stats.baseDEF;
        player2Stats.currHP = player2Stats.baseHP;
        player2Stats.currHP = player2Stats.baseHP;
        player2Stats.currMP = player2Stats.baseMP;
        RestartButton.gameObject.SetActive(false);
        BattleSetup();

    }

    float calcPlayer1Health()
    {
        float percent = player1Stats.currHP / player1Stats.baseHP;

        return percent;
    }

    float calcPlayer2Health()
    {
        float percent = player2Stats.currHP / player2Stats.baseHP;

        return percent;
    }

    void HpColorChange()
    {

        if (calcPlayer1Health() <= 0.5 && calcPlayer1Health() > 0.2)
        {
            Player1HealthBar.color = new Color(254, 161, 0, 1);
        }
        else if (calcPlayer1Health() <= 0.2)
        {
            Player1HealthBar.color = new Color(254, 9, 0, 1);
        }

        if (calcPlayer2Health() <= 0.5 && calcPlayer2Health() > 0.2)
        {
            Player2HealthBar.color = new Color(254, 161, 0, 1);
        }
        else if (calcPlayer2Health() <= 0.2)
        {
            Player2HealthBar.color = new Color(254, 9, 0, 1);
        }

    }

    void healthBarMovement()
    {

        Player1HealthBar.rectTransform.localScale = new Vector3(calcPlayer1Health(), 1, 1);
        Player2HealthBar.rectTransform.localScale = new Vector3(calcPlayer2Health(), 1, 1);
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
        Isp1Populated = true;

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
            DialogText.text = "What will " + player2Stats.name + " do in response to " + player1Stats.name + "' attack?!";
            Debug.Log("Player 1 turn lauching attack");
            player1turn(attack);

        }
        else if (state == GameState.Player2Turn)
        {
            DialogText.text = "What will " + player2Stats.name + " do in response to " + player1Stats.name + "' attack?!";
            player2turn(attack);
        }
        Debug.Log(state);
    }

    void player1turn(int attack)
    {

        switch (attack)
        {
            case 1:
                //AnimationHandler.AH.run();
                //Attack(player1Stats.Attack1Name);
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack1Damage;
                Debug.Log(player1Stats.Attack1Name);
                Attack(player1Stats.Attack1Name);
                Debug.Log(player1Stats.Attack1Damage + " Damage Done ");
                Debug.Log(player2Stats.name + "'s current hp is " + player2Stats.currHP);
                break;
            case 2:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player1Stats.Attack2Name);
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack2Damage;
                Attack(player1Stats.Attack2Name);
                Debug.Log(player1Stats.Attack2Damage + " Damage Done ");
                Debug.Log(player2Stats.name + "'s current hp is " + player2Stats.currHP);
                break;
            case 3:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player1Stats.Attack3Name);
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack3Damage;
                Attack(player1Stats.Attack3Name);
                Debug.Log(player1Stats.Attack3Damage + " Damage Done ");
                Debug.Log(player2Stats.name + "'s current hp is " + player2Stats.currHP);
                break;
            case 4:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player1Stats.Attack4Name);
                player2Stats.currHP = player2Stats.currHP - player1Stats.Attack4Damage;
                Attack(player1Stats.Attack4Name);
                Debug.Log(player1Stats.Attack4Damage + " Damage Done ");
                Debug.Log(player2Stats.name + "'s current hp is " + player2Stats.currHP);
                break;
        }



        checkIfPlayersWon();
        Debug.Log("It is now player 2's turn");
        state = GameState.Player2Turn;
        playerAttacks();
    }

    void checkIfPlayersWon()
    {
        if (player1Stats.currHP <= 0)
        {
            Canvas.gameObject.SetActive(false);
            state = GameState.Player2Won;
            finishSeq();
        }

        if (player2Stats.currHP <= 0)
        {
            Canvas.gameObject.SetActive(false);
            state = GameState.Player1Won;
            finishSeq();
        }
    }

    void finishSeq()
    {
        // show the button
        //add a possible animation
        Debug.Log("....animation....");
        Debug.Log("Would you like to play again with the same characters press the button");
        RestartButton.gameObject.SetActive(true);
    }

    void player2turn(int attack)
    {


        switch (attack)
        {
            case 1:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player2Stats.Attack1Name);
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack1Damage;
                Debug.Log(player2Stats.Attack1Damage + " Damage Done ");
                Debug.Log(player1Stats.name + "'s current hp is " + player1Stats.currHP);
                break;
            case 2:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player2Stats.Attack2Name);
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack2Damage;
                Debug.Log(player2Stats.Attack2Damage + " Damage Done ");
                Debug.Log(player1Stats.name + "'s current hp is " + player1Stats.currHP);
                break;
            case 3:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player1Stats.Attack3Name);
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack3Damage;
                Debug.Log(player2Stats.Attack3Damage + " Damage Done ");
                Debug.Log(player1Stats.name + "'s current hp is " + player1Stats.currHP);
                break;
            case 4:
                //AnimationHandler.AH.run();
                //AnimationHandler.AH.Attack(player2Stats.Attack4Name);
                player1Stats.currHP = player1Stats.currHP - player2Stats.Attack4Damage;
                Debug.Log(player2Stats.Attack4Damage + " Damage Done ");
                Debug.Log(player1Stats.name + "'s current hp is " + player1Stats.currHP);
                break;
        }

        checkIfPlayersWon();
        Debug.Log("It is now player 1's turn");
        state = GameState.Player1Turn;
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
            DialogText.text = "What will " + player1Stats.name + " do ?";
        }

        if (state == GameState.Player2Turn)
        {
            playerAtt1.text = player2Stats.Attack1Name;
            playerAtt2.text = player2Stats.Attack2Name;
            playerAtt3.text = player2Stats.Attack3Name;
            playerAtt4.text = player2Stats.Attack4Name;
            DialogText.text = "What will " + player2Stats.name + " do ?";
        }
        Debug.Log(state);
    }

    public void Attack(string attack)
    {
        Canvas.gameObject.SetActive(false);
        StartCoroutine(AttackAnimation(attack)); Debug.Log("attack launched");

    }

    IEnumerator AttackAnimation(string attack)
    {
        //set anim to true
        Lucario.SetBool(attack, true); Debug.Log("attack set to true");
        yield return new WaitForSeconds(4); Debug.Log("animation under way");
        Lucario.SetBool(attack, false); Debug.Log("animation off");
        Canvas.gameObject.SetActive(true);

    }
}

