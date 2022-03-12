using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemonBase : MonoBehaviour
{
    public string name;
    public float baseHP;
    public float currHP;
    public float baseMP;
    public float currMP;


    public enum Type
    {

        Grass,
        Fire,
        Earth,
        Water,
        Electric,
        Air,
        Fighting

    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        SuperRare,
        Legendary

    }

    public Type PokemonType;
    public Rarity rarity;
    public float baseATK;
    public float currATK;
    public float baseDEF;
    public float currDEF;


}
