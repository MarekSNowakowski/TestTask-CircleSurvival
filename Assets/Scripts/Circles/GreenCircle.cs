using UnityEngine;

public class GreenCircle : Circle
{
    [SerializeField]
    private Vector2 explosionTimeRange;
    private float startTimeTillExplosion;
    private float timeTillExplosion;

    [SerializeField]
    private Transform redCircleTransform;

    [SerializeField, Range(1,99)]
    private float speedUpRate;

    private bool gameEnded = false;

    private void Start()
    {
        SetExplisionTimeLeft();
    }

    private void SetExplisionTimeLeft()
    {
        explosionTimeRange -= explosionTimeRange * Time.timeSinceLevelLoad /60f * speedUpRate /100f;
        startTimeTillExplosion = Random.Range(explosionTimeRange.x, explosionTimeRange.y);
        timeTillExplosion = startTimeTillExplosion;
    }

    public override void OnCircleClicked()
    {
        Destroy(gameObject);
    }

    private void Update()
    {  
        if(!gameEnded)
        {
            timeTillExplosion -= Time.deltaTime;
            if (timeTillExplosion < 0)
            {
                gameEnded = true;
                EndGame();
            }

            var scale = 1f - timeTillExplosion / startTimeTillExplosion;
            redCircleTransform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
