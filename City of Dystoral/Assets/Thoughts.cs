using UnityEngine;
using TMPro;

public class Thoughts : MonoBehaviour
{
    public TextMeshProUGUI textToFade; // Reference to the text object to fade in and out
    public float fadeDuration = 1.0f; // How long the fade in/out animation should take
    public float waitDuration = 5.0f; // How long to wait before starting the fade in animation

    private bool isFadingIn = false; // Is the text currently fading in?
    private bool isFadingOut = false; // Is the text currently fading out?
    private float fadeInTimer = 0.0f; // Timer for the fade in animation
    private float fadeOutTimer = 0.0f; // Timer for the fade out animation

    private void Start()
    {
        // Set the initial alpha value of the text to zero
        Color textColor = textToFade.color;
        textColor.a = 0.0f;
        textToFade.color = textColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start the fade out animation when the object collides with the trigger
        isFadingIn = false;
        isFadingOut = true;
    }

    private void Update()
    {
        if (!isFadingIn && !isFadingOut)
        {
            // Wait for the specified amount of time before starting the fade in animation
            waitDuration -= Time.deltaTime;
            if (waitDuration <= 0.0f)
            {
                isFadingIn = true;
            }
        }
        else if (isFadingIn)
        {
            // Fade in the text over the specified duration
            fadeInTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, fadeInTimer / fadeDuration);
            Color textColor = textToFade.color;
            textColor.a = alpha;
            textToFade.color = textColor;

            // Stop fading in once the text is fully visible
            if (fadeInTimer >= fadeDuration)
            {
                isFadingIn = false;
            }
        }
        else if (isFadingOut)
        {
            // Fade out the text over the specified duration
            fadeOutTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, fadeOutTimer / fadeDuration);
            Color textColor = textToFade.color;
            textColor.a = alpha;
            textToFade.color = textColor;

            // Destroy the object once the fade out animation is complete
            if (fadeOutTimer >= fadeDuration)
            {
                Destroy(gameObject);
            }
        }
    }
}
