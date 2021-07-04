using System;
using UnityEngine;

public class CircleFactory : MonoBehaviour
{
    [SerializeField]
    private CircleProbabilityPair[] circleProbabilityPairs;
    /// <summary>
    /// Spawn rate at the begining of the game in circles per seconds
    /// </summary>
    [SerializeField, Range(0.1f,4)]
    private float circleSpawnRate;
    private float currentCircleSpawnRate;
    [SerializeField]
    private float speedUpRate;

    private Vector2 spawnAreaMin;
    private Vector2 spawnAreaMax;

    private float timeToNextSpawn;

    private bool spawning = true;

    private void Start()
    {
        SetCameraBounds();

        currentCircleSpawnRate = circleSpawnRate;
    }

    private void Update()
    {
        if(spawning)
        {
            timeToNextSpawn -= Time.deltaTime;
            if (timeToNextSpawn < 0)
            {
                SpawnCircle();
                timeToNextSpawn = 1 / currentCircleSpawnRate;
            }
        }
    }

    private void SetCameraBounds()
    {
        float boundsOffset = 1f;
        Vector2 boundsValue = GetCameraBounds();

        spawnAreaMin = new Vector2(Camera.main.transform.position.x - boundsValue.x + boundsOffset,
            Camera.main.transform.position.y - boundsValue.y + boundsOffset);
        spawnAreaMax = new Vector2(Camera.main.transform.position.x + boundsValue.x - boundsOffset,
            Camera.main.transform.position.y + boundsValue.y - boundsOffset);
    }

    private Vector2 GetCameraBounds()
    {
        return new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize);
    }

    private void SpawnCircle()
    {
        Vector2 spawnPosition = DrawPosition();
        if (spawnPosition != default)
        {
            Instantiate(DrawCircle(), spawnPosition, Quaternion.identity, transform);
        }
    }

    private GameObject DrawCircle()
    {
        float probabilityPool = 0f;

        foreach (CircleProbabilityPair pair in circleProbabilityPairs)
        {
            probabilityPool += pair.probability;
        }

        var randomNumber = UnityEngine.Random.Range(0, probabilityPool);
        probabilityPool = 0f;

        foreach (CircleProbabilityPair pair in circleProbabilityPairs)
        {
            probabilityPool += pair.probability;
            if (randomNumber < probabilityPool)
            {
                return pair.circlePrefab;
            }
        }
        Debug.LogWarning("Drawing circle failed");
        return null;
    }

    private int tries;
    private readonly int maxTries = 100;
    private readonly float overflowCooldownTime = 2f;

    private Vector2 DrawPosition()
    {
        Vector2 spawnPosition;
        tries = 0;
        do
        {
            spawnPosition = new Vector2(UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            tries++;
            if(tries > maxTries)
            {
                //In case there is no space left on screen
                timeToNextSpawn = overflowCooldownTime;
                return default;
            }
        }
        while (IsOccupied(spawnPosition));
        return spawnPosition;
    }

    private const string CIRCLE_TAG = "Circle";
    private const float RAY_RADIUS = 0.5f;
    private const float RAY_DISTANCE = 10f;

    private bool IsOccupied(Vector3 rayPosition)
    {
        rayPosition.z = -10f;
        Ray ray = new Ray(rayPosition, Vector3.forward);

        if (Physics.SphereCast(ray, RAY_RADIUS, out RaycastHit hit, RAY_DISTANCE))
        {
            if (hit.collider.gameObject.CompareTag(CIRCLE_TAG))
            {
                return true;
            }
        }
        return false;
    }
}

[Serializable]
public class CircleProbabilityPair
{
    public GameObject circlePrefab;
    [Range(1,100)]
    public int probability;
}