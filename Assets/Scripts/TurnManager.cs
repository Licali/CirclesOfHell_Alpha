using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool isPLayerTurn = true;

    public void EndTurn()
    {
        isPLayerTurn=!isPLayerTurn;
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
