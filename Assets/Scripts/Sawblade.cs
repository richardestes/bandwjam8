using UnityEngine;

public class Sawblade : MonoBehaviour
{
    private float initialZRotation;
    [SerializeField][Range(0.1f,3f)]
    private float _speed;

    private void Start()
    {
        initialZRotation = transform.rotation.z;
    }

    private void Update()
    {
        transform.localRotation.Set(0f, 0f, initialZRotation + _speed, 0f);
    }
}
