using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public List<Card> availableCards;

    public void PlayCatd(Card card, Player player, Enemy enemy)
    {
        enemy.ReceiveDamage(card.attack);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
