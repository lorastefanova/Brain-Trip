using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject loadingScreen; // Loading screen game object
    public Slider slider; // Slider
    public Text percent; // Text

    // Function to load levels
    public void LoadLevels(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    // Function to load asynchronously
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // Load asynchronous

        loadingScreen.SetActive(true); // Set the loading scene active 

        while (!operation.isDone) // While the operation is not done
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); // Set the progress

            slider.value = progress; // Set the slider to display the progress
            percent.text = progress * 100f + "%"; // Set the text to display progress in %

            yield return null;
        }
    }

    // Function to quit the application
    public void ButtonQuit()
    {
        Application.Quit(); // Quit the application
    }
}