using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int sceneIndex;
    public void PlayClick()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
