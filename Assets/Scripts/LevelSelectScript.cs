using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public Button[] levelButtons; // Doors

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelUnlocked", 1); // Reached level

        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
