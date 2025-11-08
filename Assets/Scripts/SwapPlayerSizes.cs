using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPlayerSizes : MonoBehaviour
{
    public List<GameObject> playerSizes = new List<GameObject>();
    public int sizeIndex = 0;
    public CrossFadeImage blackCanvas;
    public Slider waterSlider;
    public float waterLevel;
    public Vector3 spawnPoint;

    private void Awake()
    {
        playerSizes[0].SetActive(true);
        playerSizes[1].SetActive(false);
        playerSizes[2].SetActive(false);

        if (blackCanvas.GetComponent<CanvasGroup>().alpha == 1)
        {
            StartCoroutine(blackCanvas.AnimateOut());
        }

        waterLevel = 0f;
        waterSlider.value = waterLevel;

        spawnPoint = transform.position;
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
            waterLevel = 1 / 3f;
        }
        else if (sizeIndex == 1)
        {
            playerSizes[1].SetActive(false);
            this.transform.position = pos;
            playerSizes[2].SetActive(true);
            sizeIndex++;
            waterLevel = (1 / 3f)*2;
        }
        else if (sizeIndex == 2)
        {
            playerSizes[2].SetActive(false);
            this.transform.position = pos;
            playerSizes[3].SetActive(true);
            waterLevel = (1 / 3f) * 3;
        }

        waterSlider.value = waterLevel;
    }

    public void ResetPlayer()
    {
        StartCoroutine(blackCanvas.AnimateIn());

        sizeIndex = 0;
        playerSizes[0].SetActive(true);
        playerSizes[1].SetActive(false);
        playerSizes[2].SetActive(false);
        playerSizes[3].SetActive(false);

        //GetComponentInChildren<Transform>().position = spawnPoint;
    }
}
