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

    [SerializeField]
    private GameObject popEffect;

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
        PlayPopEffect();
        Destroy(gameObject);
    }

    protected void PlayPopEffect()
    {
        var effect = Instantiate(popEffect, transform.position, Quaternion.identity);
        Destroy(effect, EFFECT_TIME);
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timeTillExplosion -= Time.deltaTime;
            if (timeTillExplosion < 0)
            {
                Explode();
            }

            var scale = 1f - timeTillExplosion / startTimeTillExplosion;
            redCircleTransform.localScale = new Vector3(scale, scale, 1f);
        }
    }

    private void Explode()
    {
        gameEnded = true;
        PlayExplodeEffect();
        EndGame();
        Destroy(gameObject);
    }
}
