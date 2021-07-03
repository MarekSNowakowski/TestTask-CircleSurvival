using UnityEngine;

public class BlackCircle : Circle
{
    public override void OnCircleClicked()
    {
        Time.timeScale = 0;
    }
}
