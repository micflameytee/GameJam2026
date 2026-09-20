using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(EnemyCollider))]
public class Whirlpool : MonoBehaviour
{

    private float _Rotation = 0;
    
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
    
    
}
