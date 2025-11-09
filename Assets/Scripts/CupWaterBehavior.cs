using UnityEngine;

public class CupWaterBehavior : WaterBehavior
{
    public GameObject fallenCup;
    protected override void OnDestroy()
    {
        base.OnDestroy();
        this.transform.parent.gameObject.SetActive(false);
        fallenCup.SetActive(true);
    }
}
