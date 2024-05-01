using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float interactDistance = 5f;
    [SerializeField] private TextMeshProUGUI pressE;

    private void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;
        pressE.enabled = false;
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 screenPointPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = mainCamera.ScreenPointToRay(screenPointPosition);

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.TryGetComponent<Interactable>(out var dd))
            {
                pressE.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Event");
                    dd.myEvent.Invoke();
                }
            }
            else
            {
                pressE.enabled = false;
            }
        }
        else
        {
            pressE.enabled = false;
        }
    }
}
