using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    Gyroscope m_Gyro;
    Compass m_Compass;
    Vector3 cameraOffset = Vector3.zero;
    Quaternion correctedPhoneOrientation;
    Quaternion verticalRotationCorrection;
    Quaternion horizontalRotationCorrection;
    Quaternion inGameOrientation;

    float verticalOffsetAngle = -90f;
    float horizontalOffsetAngle = 0f;
    float slerpValue = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        m_Gyro = Input.gyro;
        m_Compass = Input.compass;
        m_Gyro.enabled = true;
        m_Compass.enabled = true;
    }
    void Update()
    {
        GyroModifyCamera(); 
    }
    void GyroModifyCamera()
    {
        correctedPhoneOrientation = new Quaternion(m_Gyro.attitude.x, m_Gyro.attitude.y, -m_Gyro.attitude.z, -m_Gyro.attitude.w);
        verticalRotationCorrection = Quaternion.AngleAxis(verticalOffsetAngle, Vector3.left);
        horizontalRotationCorrection = Quaternion.AngleAxis(horizontalOffsetAngle, Vector3.up);
        inGameOrientation = horizontalRotationCorrection * verticalRotationCorrection * correctedPhoneOrientation;
        transform.rotation = Quaternion.Slerp(transform.rotation, inGameOrientation, slerpValue);
    }
}
