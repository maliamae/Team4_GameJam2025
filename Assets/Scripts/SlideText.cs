using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideText : MonoBehaviour
{
    public Image textBox;
    public float startY;
    public float endY;
    public IEnumerator TextAnimateIn()
    {
        textBox.rectTransform.anchoredPosition = new Vector2(0f, startY);
        var tweener = textBox.rectTransform.DOAnchorPosY(endY, 1f);
        yield return tweener.WaitForCompletion();
        StartCoroutine(TextAnimateOut());
    }
    public IEnumerator TextAnimateOut()
    {
        var tweener = textBox.rectTransform.DOAnchorPosY(startY, 1f);
        yield return tweener.WaitForCompletion();
    }

    private void Awake()
    {
        StartCoroutine(TextAnimateIn());
    }
}
