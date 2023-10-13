#if UNITY_EDITOR
using UnityEngine;
#endif
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField inputField;
    [SerializeField] private TMPro.TMP_Text highScoreText;

    void Start()
    {
        inputField.text = DataPersist.Instance.PlayerName ?? "";
        highScoreText.text = $"High Score: {DataPersist.Instance.PlayerHighScoreName} : {DataPersist.Instance.Score}";
    }

    public void StartGame()
    {
        DataPersist.Instance.PlayerName = inputField.text;
        DataPersist.Instance.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        DataPersist.Instance.PlayerName = inputField.text;
        DataPersist.Instance.Save();
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
        else
        {
            Application.Quit();

        }
    }

}
