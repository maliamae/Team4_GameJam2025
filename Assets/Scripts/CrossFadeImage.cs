using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CrossFadeImage : MonoBehaviour
{
    public CanvasGroup crossFade;

    public IEnumerator AnimateIn()
    {
        var tweener = crossFade.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
        yield return new WaitForSeconds(.5f);
        StartCoroutine(AnimateOut());
    }
     public IEnumerator AnimateOut()
    {
        var tweener = crossFade.DOFade(0f, 1f);
        yield return tweener.WaitForCompletion();
    }
}
