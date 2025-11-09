using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneChange : MonoBehaviour
{
    public int sceneIndex;
    public CanvasGroup blackScreen;
    public Canvas videoCanvas;
    public VideoPlayer player;

    //public GameObject buttonImage;
    public void PlayClick()
    {
        StartCoroutine(OpenGame());
    }

    public IEnumerator OpenGame()
    {
        //Destroy(buttonImage);

        var tweener = blackScreen.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
        yield return new WaitForSeconds(1.5f);

        videoCanvas.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        yield return new WaitForSeconds(13f);
        
        SceneManager.LoadScene(sceneIndex);
    }
}
