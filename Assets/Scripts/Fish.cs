using UnityEngine;

public class Fish : MonoBehaviour
{
    private float period;
    private float amplitude;
    private float startY;

    void Start()
    {
        period = Random.Range(0.0f, 1.0f);
        amplitude = Random.Range(0.0f, 0.5f);
        startY = this.transform.localPosition.y;

        float phase = Random.Range(0.0f, 3.0f);
        GetComponent<MeshRenderer>().materials[0].SetFloat("_Phase", phase);
        GetComponent<MeshRenderer>().materials[1].SetFloat("_Phase", phase);
        GetComponent<MeshRenderer>().materials[2].SetFloat("_Phase", phase);
        GetComponent<MeshRenderer>().materials[3].SetFloat("_Phase", phase);
    }

    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 
                                                    startY + amplitude * Mathf.Sin(period * Time.time),
                                                    this.transform.localPosition.z);
    }
}
