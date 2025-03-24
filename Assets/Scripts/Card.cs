using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public int attack;
    public int target;
    public string description;
    public int defense;
    public enum CardEffect { None, SkipTurn, CopyCard, EatCard, IncreaseDamage}
    public CardEffect effect;
}
