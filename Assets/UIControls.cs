using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageSequenceManager : MonoBehaviour
{
    public Image[] storyImages; // Array to hold all the image UI components for your story sequence
    public Button nextButton; // Reference to the button for triggering image transitions
    public float fadeTime = 1f; // Time taken for fade-in/out animations (adjust as needed)

    private int currentImageIndex = 0; // Keeps track of the current image index

    void Start()
    {
        // Ensure there are images assigned in the inspector
        if (storyImages.Length == 0)
        {
            Debug.LogError("No image UI components assigned to the script!");
            return;
        }

        // Fade in the first image automatically at start
        storyImages[currentImageIndex].color = new Color(storyImages[currentImageIndex].color.r, storyImages[currentImageIndex].color.g, storyImages[currentImageIndex].color.b, 1f); // Set opacity to fully visible
    }

    public void NextImageButtonClicked() // Function called when the button is clicked
    {
        if (currentImageIndex < storyImages.Length - 1) // Check if there's a next image
        {
            StartCoroutine(FadeAndChangeImage()); // Start coroutine for transition
        }
    }

    IEnumerator FadeAndChangeImage()
    {
        yield return StartCoroutine(FadeOutCurrentImage()); // Wait for current image to fade out

        currentImageIndex++; // Move to the next image index

        yield return StartCoroutine(FadeInCurrentImage()); // Wait for new image to fade in
    }

    IEnumerator FadeOutCurrentImage()
    {
        float startAlpha = storyImages[currentImageIndex].color.a; // Starting opacity
        float endAlpha = 0f; // Ending opacity (invisible)
        float timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            float lerpValue = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeTime);
            storyImages[currentImageIndex].color = new Color(storyImages[currentImageIndex].color.r, storyImages[currentImageIndex].color.g, storyImages[currentImageIndex].color.b, lerpValue);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeInCurrentImage()
    {
        float startAlpha = 0f; // Starting opacity (invisible)
        float endAlpha = 1f; // Ending opacity (fully visible)
        float timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            float lerpValue = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeTime);
            storyImages[currentImageIndex].color = new Color(storyImages[currentImageIndex].color.r, storyImages[currentImageIndex].color.g, storyImages[currentImageIndex].color.b, lerpValue);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
