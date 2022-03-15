using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    public Image Player1HealthBar;
    public Image Player2HealthBar;

    public PokemonBase player1;
    public PokemonBase player2;


    void Awake()
    {
        Debug.Log(player1.name);
        Debug.Log(player2.name);
        var x = 0;
        while (Player2HealthBar.rectTransform.localScale.x <= 1)
        {
            Player2HealthBar.rectTransform.localScale = new Vector3(x + 1, 1, 1);
            //hope
        }

    }

    float calcPlayer1Health()
    {
        float percent = player1.currHP / player1.baseHP;

        return percent;
    }
    float calcPlayer2Health()
    {
        float percent = player2.currHP / player2.baseHP;

        return percent;
    }

    // Update is called once per frame
    void Update()
    {
        Player1HealthBar.rectTransform.localScale = new Vector3(calcPlayer1Health(), 1, 1);
        Player2HealthBar.rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
