using Unity.Mathematics;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{

    public float RotationSpeed = 5f;
    private float _Rotation = 0;
    public Transform startPosition;
    
    void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            RotatePool();
        }
    }

    void RotatePool()
    {
        _Rotation = _Rotation + 90;
        transform.rotation = Quaternion.Euler(0, 0, _Rotation);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"player", other.gameObject);
        other.transform.position = startPosition.position;
    }

    
}
