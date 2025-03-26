using System.Collections;
using UnityEngine;

public class RoomTransitionManager : MonoBehaviour
{
    [Header("Objects links")]
    public Transform player;
    public Transform cameraPosition;
    public GameObject enemy;

    [Header("Rooms")]
    public Transform[] roomCenters;
    public Transform trainingRoomCenter;
    private int currentRoomIndex = 0;

    [Header("Room swap settings")]
    public float transitionDuration = 2f;
    public Vector3 cameraOffset = new Vector3 (0, 5, -10);
    public float enemyDistanceFromPlayer = 2f;

    public void TransitionToNextRoom()
    {
        Transform nextRoomCenter = null;
        if (roomCenters != null && roomCenters.Length > 0 && currentRoomIndex <= roomCenters.Length - 1)
        {
            Debug.Log($"{currentRoomIndex} писюн");
            nextRoomCenter = roomCenters[currentRoomIndex];
            currentRoomIndex++;
        }
        else
        {
            
            // Если следующей комнаты нет, переходим в тренировочную комнату
            nextRoomCenter = trainingRoomCenter;
            Debug.Log($"{currentRoomIndex} ф6");
            currentRoomIndex = 0; // Можно сбросить индекс для нового цикла переходов
        }

        StartCoroutine(MoveToNextRoom(nextRoomCenter));
    }

    public IEnumerator MoveToNextRoom(Transform nextRoomCenter)
    {
        Vector3 startPlayerPos = player.position;
        Vector3 targetPlayerPos = nextRoomCenter.position;
        Vector3 startCameraPos = cameraPosition.position;
        Vector3 targetCameraPos = targetPlayerPos + cameraOffset;

        float elapsed = 0f;
        while (elapsed < transitionDuration) {
            elapsed += Time.deltaTime;

            float t = elapsed / transitionDuration;

            player.position = Vector3.Lerp(startPlayerPos, targetPlayerPos, t);
            cameraPosition.position = Vector3.Lerp(startCameraPos, targetCameraPos, t);

            yield return null;
        }
        player.position = targetPlayerPos;
        cameraPosition.position = targetCameraPos;

        Vector3 enemyPosition = player.position + player.forward * enemyDistanceFromPlayer;
        enemy.transform.position = enemyPosition;

        enemy.SetActive(true);
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
