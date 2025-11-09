using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OutroSequence : MonoBehaviour
{
    public CrossFadeImage blackScreen;
    public Image inTank;
    public Image credits;

    public GameObject endText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        StartCoroutine(PlaySequence());
    }

    public IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(.25f);
        StartCoroutine(blackScreen.AnimateIn());
        yield return new WaitForSeconds(1f);
        inTank.gameObject.SetActive(true);
        endText.SetActive(true);
        yield return new WaitForSeconds(4f);
        StartCoroutine(blackScreen.AnimateIn());
        yield return new WaitForSeconds(1f);
        inTank.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }
}
