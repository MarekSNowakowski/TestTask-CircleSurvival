using UnityEngine;

public class GreenCircle : Circle
{
    [SerializeField]
    private Vector2 explosionTimeRange;
    private float startTimeTillExplosion;
    private float timeTillExplosion;

    [SerializeField]
    private Transform redCircleTransform;

    private bool gameEnded = false;

    private void Start()
    {
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
