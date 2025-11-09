using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideText : MonoBehaviour
{
    public Image textBox;
    public float startY;
    public float endY;
    public float stayDuration;
    public GameObject nextText;
    public float playDelay;


    public IEnumerator TextAnimateIn()
    {
        yield return new WaitForSeconds(playDelay);
        textBox.rectTransform.anchoredPosition = new Vector2(0f, startY);
        var tweener = textBox.rectTransform.DOAnchorPosY(endY, 1f);
        yield return tweener.WaitForCompletion();
        yield return new WaitForSeconds(stayDuration);
        StartCoroutine(TextAnimateOut());
    }
    public IEnumerator TextAnimateOut()
    {
        var tweener = textBox.rectTransform.DOAnchorPosY(startY, 1f);
        yield return tweener.WaitForCompletion();

        if (nextText != null)
        {
            nextText.SetActive(true);
        }
        else
        {
            yield return null;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(TextAnimateIn());
    }
}
