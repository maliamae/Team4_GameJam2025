using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public Material noGlowMat;
    protected virtual void OnDestroy()
    {
        GetComponentInParent<MeshRenderer>().material = noGlowMat;
    }

}
