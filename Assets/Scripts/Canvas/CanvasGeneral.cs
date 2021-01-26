using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGeneral : MonoBehaviour
{
    [Header("Panel References")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject pausePanel;

    private void Awake() => Time.timeScale = 0f;

    public void StartGame() => Time.timeScale = 1f;

    public void PauseGame(GameObject gameObject)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void HideGameObject(GameObject gameObject) => gameObject.SetActive(false);
    
    public void UnhideGameObject(GameObject gameObject) => gameObject.SetActive(true);

    public void Quit() => Application.Quit();
}
