using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerHealthText;
    public Text enemyHealthText;
    public Player player;
    public Enemy enemy;

    public void UpdateHealth(int playerHealth, int enemyHealth)
    {
        playerHealthText.text = "YOUR HP: " + playerHealth;
        playerHealthText.color = new Color(0, 255, 0);
        enemyHealthText.text = "ENEMY HP: " + enemyHealth;
        enemyHealthText.color = new Color(255, 0, 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealth(player.health, enemy.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
