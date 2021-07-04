using UnityEngine;

/// <summary>
/// On click shoot ray in touch position looking for a circle
/// </summary>
public class InputController : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private bool gameOver = false;

    private const string CIRCLE_TAG = "Circle";
    private const float RAY_DISTANCE = 10f;

    private void Update()
    {
        if (!gameOver && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit, RAY_DISTANCE))
            {
                //Check tag, than try to get Circle component
                if(hit.collider.gameObject.CompareTag(CIRCLE_TAG) &&
                    hit.collider.gameObject.TryGetComponent(out Circle circle))
                {
                    circle.OnCircleClicked();
                }
            }
        }
    }

    public void BlockShooting()
    {
        gameOver = true;
    }
}
