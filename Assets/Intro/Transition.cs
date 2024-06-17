using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ImageFader : MonoBehaviour
{
    // Assignable in the Unity Editor
    public Image[] images;
    public XRSimpleInteractable remoteButton; // Assign the XRSimpleInteractable for the "A" button

    private int currentIndex = 0;
    private Image currentImage;

    void Start()
    {
        // Fade in the first image automatically
        currentImage = images[currentIndex];
        currentImage.canvasRenderer.SetAlpha(0f);
        currentImage.CrossFadeAlpha(1f, 1f, false);

        // Add a listener to the select entered event
        remoteButton.selectEntered.AddListener(OnButtonPressed);
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Fade out the current image
        currentImage.CrossFadeAlpha(0f, 1f, false);

        // Move to the next image
        currentIndex = (currentIndex + 1) % images.Length;
        currentImage = images[currentIndex];

        // Fade in the new image
        currentImage.canvasRenderer.SetAlpha(0f);
        currentImage.CrossFadeAlpha(1f, 1f, false);
    }
}