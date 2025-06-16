using UnityEngine;

public class AccelerometerGravity : MonoBehaviour
{
    public float gravityScale = 9.81f;

    void FixedUpdate()
    {
        Physics.gravity = new Vector3(0, -gravityScale, 0);

        Vector3 tilt = Input.acceleration;
        Physics.gravity = new Vector3(tilt.x, tilt.y, tilt.z) * gravityScale;
    }
}
