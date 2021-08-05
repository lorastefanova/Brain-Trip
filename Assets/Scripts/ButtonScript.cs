using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Function to play button sound
    public void PlaySound(string s)
    {
        AudioManager.instance.Play(s);
    }
}
