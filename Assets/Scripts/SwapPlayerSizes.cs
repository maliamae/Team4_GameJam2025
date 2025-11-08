using System.Collections.Generic;
using UnityEngine;

public class SwapPlayerSizes : MonoBehaviour
{
    public List<GameObject> playerSizes = new List<GameObject>();
    private int sizeIndex = 0;
    public CrossFadeImage blackCanvas;

    private void Awake()
    {
        playerSizes[0].SetActive(true);
        playerSizes[1].SetActive(false);
        playerSizes[2].SetActive(false);
    }

    private void Update()
    {

    }

    public void SwapNextSize(Vector3 pos)
    {
        StartCoroutine(blackCanvas.AnimateIn());

        if (sizeIndex == 0)
        {
            playerSizes[0].SetActive(false);
            this.transform.position = pos;
            playerSizes[1].SetActive(true);
            sizeIndex++;
        }
        else if (sizeIndex == 1)
        {
            playerSizes[1].SetActive(false);
            this.transform.position = pos;
            playerSizes[2].SetActive(true);
            sizeIndex++;
        }
        else if (sizeIndex == 2)
        {
            playerSizes[2].SetActive(false);
            this.transform.position = pos;
            playerSizes[3].SetActive(true);
        }
    }
}
