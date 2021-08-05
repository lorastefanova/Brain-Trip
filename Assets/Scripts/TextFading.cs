using System.Collections;
using UnityEngine;
using TMPro;

public class TextFading : MonoBehaviour
{
    private float zeroAlphaSec = 0.5f; // Zero alpha seconds
    private float fullAlphaSec = 1.5f; // Full alpha seconds

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextFadeOut()); // Text fade out 
    }

    // Text fading function
    private IEnumerator TextFadeOut()
    {
        TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>(); // Text
        Color originalColor = text.color; // Text colour

        yield return new WaitForSeconds(fullAlphaSec); // Wait for 1.5 seconds

        for (float t = 0.01f; t < zeroAlphaSec; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / zeroAlphaSec)); // Fade text
            yield return null;
        }
    }
}
