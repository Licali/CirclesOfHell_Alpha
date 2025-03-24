using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 20;
    public List<Card> deck = new List<Card>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {

        }
    }

    public void InitializeDeck()
    {
        Card attackCard = new Card() { cardName = "Атака", attack = 5, defense = 0, description = "????? ?????", effect = Card.CardEffect.None};
        Card increaseCard = new Card() { cardName = "Инкризирующая", attack = 5, defense = 0, description = "????? ?????", effect = Card.CardEffect.IncreaseDamage };
        Card copyCard = new Card() { cardName = "Копирующая", attack = 5, defense = 0, description = "????? ?????", effect = Card.CardEffect.CopyCard };
        Card eatCard = new Card() { cardName = "Поедабетельная", attack = 5, defense = 0, description = "????? ?????", effect = Card.CardEffect.EatCard };
        Card skipTurnCard = new Card() { cardName = "Пропускательная", attack = 5, defense = 0, description = "????? ?????", effect = Card.CardEffect.SkipTurn };
        deck.Add(attackCard);
        deck.Add(increaseCard);
        deck.Add(copyCard);
        deck.Add(eatCard);
        deck.Add(skipTurnCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
