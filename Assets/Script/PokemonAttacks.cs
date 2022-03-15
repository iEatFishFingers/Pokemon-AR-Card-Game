using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PokemonAttacks : MonoBehaviour
{
    public string Attack1Name;

    public float Attack1Damage;

    public float Attack1Points;

    public enum AttackType
    {

        Grass,
        Fire,
        Earth,
        Water,
        Electric,
        Air,
        Fighting

    }

    public AttackType PokemonAttackType;

    public string Attack2Name;

    public float Attack2Damage;

    public float Attack2Points;

    public AttackType Pokemon2AttackType;

    public string Attack3Name;

    public float Attack3Damage;

    public float Attack3Points;


    public AttackType PokemonAttack3Type;

    public string Attack4Name;

    public float Attack4Damage;

    public float Attack4Points;

    public AttackType PokemonAttack4Type;
}



