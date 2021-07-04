using UnityEngine;

public class BlackCircle : Circle
{
    [SerializeField]
    private Vector2 disappearTimeRange;
    private float timeTillDisappear;

    public override void OnCircleClicked()
    {
        PlayExplodeEffect();
        EndGame();
        Destroy(gameObject);
    }

    private void Start()
    {
        timeTillDisappear = Random.Range(disappearTimeRange.x, disappearTimeRange.y);
    }

    private void Update()
    {
        timeTillDisappear -= Time.deltaTime;
        if(timeTillDisappear < 0)
        {
            Destroy(gameObject);
        }
    }
}
