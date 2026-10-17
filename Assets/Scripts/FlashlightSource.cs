using UnityEngine;

public class FlashlightSource : MonoBehaviour
{
    [SerializeField] private float innerAngle;
    [SerializeField] private float outerAngle;

    [SerializeField] private AudioSource music;

    [SerializeField] private float musicFadeTime;
    private float elapsedFadeTime;

    private bool active;

    void Start()
    {
        active = true;
        music.volume = 0.0f;
        elapsedFadeTime = 0.0f;
    }

    void Update()
    {
        if (active)
        {
            if (!music.isPlaying)
            {
                music.Play();
            }
            Shader.SetGlobalVector("_Light_Direction", transform.forward);
            Shader.SetGlobalVector("_Light_Position", transform.position);
            if (music.volume < 1.0f)
            {
                // music.volume = elapsedFadeTime / musicFadeTime;
                // elapsedFadeTime += Time.deltaTime;
                music.volume += Time.deltaTime / musicFadeTime;
            }
            else
            {
                music.volume = 1.0f;
            }
        }
        else
        {
            Shader.SetGlobalVector("_Light_Direction", Vector3.down);
            Shader.SetGlobalVector("_Light_Position", new Vector3(0.0f, -10.0f, 0.0f));
            if (music.volume > 0.0f)
            {
                // music.volume = 1.0f - (elapsedFadeTime / musicFadeTime);
                // elapsedFadeTime += Time.deltaTime;
                music.volume -= Time.deltaTime / musicFadeTime;
            }
            else
            {
                music.volume = 0.0f;
            }
        }
        
        Shader.SetGlobalFloat("_Inner_Angle", innerAngle);
        Shader.SetGlobalFloat("_Outer_Angle", outerAngle);
    }

    public void ToggleActivate()
    {
        Debug.Log("Hello");
        active = !active;
        GetComponent<Light>().enabled = active;
    }
}
