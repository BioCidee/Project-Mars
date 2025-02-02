using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Part")]
    [SerializeField] private GameObject optionPart;

    private enum nameOfScene {
        GameScene,
        GameOverScene,
        MainMenuScene,
        CreditScene,
    }

    public void OnPlayButtonClick() {
        SceneManager.LoadScene(nameOfScene.GameScene.ToString());
    }
    public void OpenOptionPart() {
        if (optionPart == null)
            Debug.LogWarning("There is no Option part, but you try to open it");

        optionPart.SetActive(true);
    }

    public void CloseOptionPart() {
        if (optionPart == null)
            Debug.LogWarning("There is no Option part, but you try to close it");

        optionPart.SetActive(false);
    }

    public void OnCreditButtonClick() {
        SceneManager.LoadScene(nameOfScene.GameScene.ToString());
    }

    public void OnLeaveButtonClick() {
        // Peut être faire une page en mode "etes vous sur ? "
        Application.Quit();
    }

    public void OnTryAgainButtonIsClick() {
        SceneManager.LoadScene(nameOfScene.GameScene.ToString());
    }
}
