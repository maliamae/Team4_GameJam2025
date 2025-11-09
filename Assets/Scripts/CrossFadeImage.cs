using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.InputSystem;

public class CrossFadeImage : MonoBehaviour
{
    public CanvasGroup crossFade;
    //public GameObject player;
    public PlayerInput playerIn;
    

    public IEnumerator AnimateIn()
    {
        if (playerIn != null)
        {
            playerIn.actions.Disable();
        }
        
        var tweener = crossFade.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
        yield return new WaitForSeconds(.5f);
        StartCoroutine(AnimateOut());
    }
     public IEnumerator AnimateOut()
    {
        var tweener = crossFade.DOFade(0f, 1f);
        yield return tweener.WaitForCompletion();

        if (playerIn != null)
        {
            playerIn.actions.Enable();
        }

    }
}
