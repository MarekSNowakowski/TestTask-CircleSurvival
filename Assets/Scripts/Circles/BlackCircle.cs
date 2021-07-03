using UnityEngine;

public class BlackCircle : Circle
{
    public override void OnCircleClicked()
    {
        EndGame();
    }
}
