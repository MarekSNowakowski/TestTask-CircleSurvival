using UnityEngine;

/// <summary>
/// On click shoot ray in touch position looking for a circle
/// </summary>
[RequireComponent(typeof(Camera))]
public class InputController : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit hit;
    private Ray ray;

    private const string CIRCLE_TAG = "Circle";

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit,100f))
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

}
