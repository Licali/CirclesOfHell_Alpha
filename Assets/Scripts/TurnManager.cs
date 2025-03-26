using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool isPLayerTurn = true;

    public static TurnManager Instance;

    [Header("Object links")]
    public Enemy enemy; // Ссылка на скрипт врага
    public Transform cardSpawnPoint; // Точка, где будут появляться новые карты

    [Header("Card prefabs")]
    public GameObject greenCardPrefab;
    public GameObject redCardPrefab;
    public GameObject blueCardPrefab;

    [Header("Card spawn settings")]
    public float spacing = 0.5f;

    [Header("Hand settings")]
    public int initialHandSize = 3;
    public List<CardController> handCards = new List<CardController>();
    public List<CardController> tableCards = new List<CardController>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EndTurn()
    {
        isPLayerTurn=!isPLayerTurn;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < initialHandSize; i++)
        {
            SpawnRandomCard();
        }
    }

    public void PlaceCardOnTable(CardController card)
    {
        if (handCards.Contains(card))
            handCards.Remove(card);

        if (!tableCards.Contains(card))
            tableCards.Add(card);

        RepositionCards();
    }

    public void CancelCardSelection(CardController card)
    {
        card.transform.position = card.initialPosition;
    }

    public void ProcessTurn()
    {
        int totalDamage = 0;
        foreach (CardController card in tableCards)
        {
            totalDamage += card.damage;
            Destroy(card.gameObject);
        }
        tableCards.Clear();

        enemy.ReceiveDamage(totalDamage);
        Debug.Log("Нанесено урона: " + totalDamage);

        if (enemy.health <= 0)
        {
            RoomTransitionManager.Instance.TransitionToNextRoom();

            for (int i = 0; i < 3; i++)
            {
                SpawnRandomCard();
            }
        }
        else
        {
            SpawnRandomCard();
        }
    }

    //public void SpawnRandomCard()
    //{
    //    int cardType = Random.Range(0, 3);
    //    GameObject prefabToSpawn = greenCardPrefab;
    //    int damageValue = 10;
    //    Color cardColor = Color.green;

    //    switch (cardType)
    //    {
    //        case 0:
    //            prefabToSpawn = greenCardPrefab;
    //            damageValue = 10;
    //            cardColor = Color.green;
    //            break;
    //        case 1:
    //            prefabToSpawn = redCardPrefab;
    //            damageValue = 15;
    //            cardColor = Color.red;
    //            break;
    //        case 2:
    //            prefabToSpawn = blueCardPrefab;
    //            damageValue = 5;
    //            cardColor = Color.blue;
    //            break;
    //    }

    //    GameObject newCardObj = Instantiate(prefabToSpawn, cardSpawnPoint.position, Quaternion.identity);
    //    CardController cardController = newCardObj.GetComponent<CardController>();
    //    cardController.damage = damageValue;
    //    cardController.cardColor = cardColor;

    //    Renderer rend = newCardObj.GetComponent<Renderer>();
    //    if (rend != null)
    //        rend.material.color = cardColor;

    //    handCards.Add(cardController);
    //    float spacing = 1.5f;
    //    cardController.initialPosition = cardSpawnPoint.position + new Vector3((handCards.Count - 1) * spacing, 0, 0);

    //    newCardObj.transform.position = cardController.initialPosition;
    //}

    public void SpawnRandomCard()
    {
        int cardType = Random.Range(0, 3);
        GameObject prefabToSpawn = greenCardPrefab;
        int damageValue = 10;
        Color cardColor = Color.green;

        switch (cardType)
        {
            case 0:
                prefabToSpawn = greenCardPrefab;
                damageValue = 10;
                cardColor = Color.green;
                break;
            case 1:
                prefabToSpawn = redCardPrefab;
                damageValue = 15;
                cardColor = Color.red;
                break;
            case 2:
                prefabToSpawn = blueCardPrefab;
                damageValue = 5;
                cardColor = Color.blue;
                break;
        }

        GameObject newCardObj = Instantiate(prefabToSpawn, cardSpawnPoint.position, Quaternion.identity);
        CardController cardController = newCardObj.GetComponent<CardController>();
        cardController.damage = damageValue;
        cardController.cardColor = cardColor;

        Renderer rend = newCardObj.GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = cardColor;

        handCards.Add(cardController);

        RepositionCards();
    }

    public void RepositionCards()
    {
        int count = handCards.Count;
        if (count == 0) return;

        float totalWidth = spacing * (count - 1);
        
        Vector3 startPos = cardSpawnPoint.position - new Vector3(totalWidth / 2f, 0, 0);

        for (int i = 0; i < count; i++)
        {
            Vector3 targetPos = startPos + new Vector3(i * spacing, 0, 0);
            handCards[i].transform.position = targetPos;
            handCards[i].initialPosition = targetPos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
