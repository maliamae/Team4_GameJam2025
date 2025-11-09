using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwapPlayerSizes : MonoBehaviour
{
    public List<GameObject> playerSizes = new List<GameObject>();
    public int sizeIndex = 0;
    public CrossFadeImage blackCanvas;
    public Slider waterSlider;
    public float waterLevel;
    public Vector3 spawnPoint;
    public int sceneIndex;

    public Volume smallVol;
    public Volume medVol;
    public Volume largeVol;

    //public Volume globalVol;
    //public float focusDis;
    //public float focalLen;
    //public float aperature;
    //private DepthOfField dof;

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

        smallVol.gameObject.SetActive(true);
        medVol.gameObject.SetActive(false);
        largeVol.gameObject.SetActive(false);
        /*
        globalVol.profile.TryGet(out dof);

        dof.focusDistance.value = 0.3f;
        dof.focalLength.value = 28;
        dof.aperture.value = 11.5f;
        */
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

            smallVol.gameObject.SetActive(false);
            medVol.gameObject.SetActive(true);

            //aperature = 12.5f;
            //dof.aperture.value = 12.5f;
            //Debug.Log("Grow 1");
        }
        else if (sizeIndex == 1)
        {
            playerSizes[1].SetActive(false);
            this.transform.position = pos;
            playerSizes[2].SetActive(true);
            sizeIndex++;
            waterLevel = (1 / 3f)*2;

            medVol.gameObject.SetActive(false);
            largeVol.gameObject.SetActive(true);

            //aperature = 13.5f;
            //dof.aperture.value = 13.5f;
            //Debug.Log("Grow 2");
        }
        else if (sizeIndex == 2)
        {
            playerSizes[2].SetActive(false);
            this.transform.position = pos;
            playerSizes[3].SetActive(true);
            waterLevel = (1 / 3f) * 3;

            //aperature = 16f;
            //dof.aperture.value = 16f;
            //Debug.Log("Grow 3");
            SceneManager.LoadScene(sceneIndex);
        }

        waterSlider.value = waterLevel;

        //dof.aperture.value = aperature;
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
