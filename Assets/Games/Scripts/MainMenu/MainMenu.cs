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
        optionPart.SetActive(true);
    }

    public void OnCreditButtonClick() {
        SceneManager.LoadScene(nameOfScene.GameScene.ToString());
    }

    public void CloseOptionPart() {
        optionPart.SetActive(false);
    }

    public void OnLeaveButtonClick() {
        // Peut être faire une page en mode "etes vous sur ? "
        Application.Quit();
    }
}
