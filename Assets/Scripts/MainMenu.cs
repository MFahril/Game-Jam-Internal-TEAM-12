using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    void OnPlayButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
