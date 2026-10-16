using UnityEngine;

public class FishSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(0, Time.time * rotationSpeed, 0);
    }
}
