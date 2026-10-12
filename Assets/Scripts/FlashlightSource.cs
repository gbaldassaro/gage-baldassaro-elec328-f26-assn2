using UnityEngine;

public class FlashlightSource : MonoBehaviour
{
    [SerializeField] private float innerAngle;
    [SerializeField] private float outerAngle;

    void Update()
    {
        Shader.SetGlobalVector("_Light_Direction", transform.forward);
        Shader.SetGlobalVector("_Light_Position", transform.position);
        Shader.SetGlobalFloat("_Inner_Angle", innerAngle);
        Shader.SetGlobalFloat("_Outer_Angle", outerAngle);
    }
}
