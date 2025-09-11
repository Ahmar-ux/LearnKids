using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For optional button

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneName; // Name of the scene to load

    [Header("UI Settings")]
    public Button loadButton; // Optional UI Button that triggers scene load

    void Start()
    {
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadScene);
        }
        else
        {
            Debug.Log("No UI button assigned. You can still use keyboard or mouse input.");
        }
    }

    void Update()
    {
        // Old input system controls
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is empty!");
        }
    }
}
