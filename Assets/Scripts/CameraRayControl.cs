using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class CameraRayControl : MonoBehaviour
{
    public TextMeshProUGUI infoText; // Update the type to TextMeshProUGUI
    public float rayDistance = 50f; // Maximum distance for the raycast

    void Start()
    {
        if (infoText != null)
        {
            infoText.enabled = false; // Ensure the info text is hidden initially
        }
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("InfoSpot"))
            {
                DisplayInfo(hit.collider.gameObject.name); // Display info about the hotspot
            }
        }
        else
        {
            ResetInfo(); // Hide info text if no hotspot is detected
        }
    }

    void DisplayInfo(string hotspotName)
    {
        if (infoText != null)
        {
            infoText.enabled = true;
            infoText.text = "Try to get to the top to win the game";
        }
    }

    void ResetInfo()
    {
        if (infoText != null)
        {
            infoText.enabled = false;
        }
    }
}
