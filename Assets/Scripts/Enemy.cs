using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int attackPower = 3;

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {

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
