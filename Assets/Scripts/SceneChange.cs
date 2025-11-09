using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int sceneIndex;
    public CanvasGroup blackScreen;
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
        
        SceneManager.LoadScene(sceneIndex);
    }
}
