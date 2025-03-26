using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int attackPower = 3;

    

    //public void ReceiveDamage(int damage)
    //{
    //    health -= damage;

    //    Debug.Log("Враг получил урон: " + damage + ". Осталось HP: " + health);
    //    if (health <= 0)
    //    {
    //        Debug.Log("Враг побеждён!");

    //    }
    //}

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        Debug.Log("Враг получил урон: " + damage + ". Осталось HP: " + health);

        UIManager.Instance.UpdateHealth(Player.Instance.health, health);

        if (health <= 0)
        {
            Debug.Log("Враг побежден!");
            //call method to change room
            
        }
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
