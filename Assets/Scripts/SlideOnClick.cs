using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideOnClick : MonoBehaviour
{
    public GameObject imageContainer; // Reference to the empty GameObject containing the image
    public Button leftButton;
    public Button rightButton;
    private Button activeButton;

    // Define the target positions for left and right
    public Vector3 leftTargetPosition = new Vector3(-50f, 0f, 0f);
    public Vector3 rightTargetPosition = new Vector3(50f, 0f, 0f);

    private void Start()
    {
        if (imageContainer != null && leftButton != null && rightButton != null)
        {
            leftButton.onClick.AddListener(MoveImageLeft);
            rightButton.onClick.AddListener(MoveImageRight);

            // Set the initial active button
            activeButton = leftButton;
        }
    }

    public void MoveImageLeft()
    {
        MoveImage(leftTargetPosition);
        ToggleButtonVisibility(rightButton, leftButton);
    }

    public void MoveImageRight()
    {
        MoveImage(rightTargetPosition);
        ToggleButtonVisibility(leftButton, rightButton);
    }

    private void MoveImage(Vector3 destination)
    {
        StartCoroutine(SlideImage(imageContainer.transform.localPosition, destination));
    }

    private IEnumerator SlideImage(Vector3 startingPosition, Vector3 destination)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f) // Use a fixed duration or adjust as needed
        {
            imageContainer.transform.localPosition = Vector3.Lerp(startingPosition, destination, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly the destination
        imageContainer.transform.localPosition = destination;
    }

    private IEnumerator FadeButton(CanvasGroup canvasGroup, float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha value is exactly the target
        canvasGroup.alpha = targetAlpha;
    }

    private void ToggleButtonVisibility(Button showButton, Button hideButton)
    {
        // Fade out the clicked button
        StartCoroutine(FadeButton(hideButton.GetComponent<CanvasGroup>(), 0f, 0.25f));

        // Fade in the other button
        StartCoroutine(FadeButton(showButton.GetComponent<CanvasGroup>(), 1f, 0.25f));

        // Update the active button
        activeButton = showButton;
    }
}
