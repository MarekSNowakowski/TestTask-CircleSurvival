using UnityEngine;

public class GreenCircle : Circle
{
    public override void OnCircleClicked()
    {
        Destroy(gameObject);
    }
}
