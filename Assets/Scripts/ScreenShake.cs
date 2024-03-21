
using Cinemachine;
using UnityEngine;
public class ScreenShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;


    float shakeTime = 0;
    float shakeIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            // Start shake
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeIntensity;

            // Decrease time of shake
            shakeTime -= Time.deltaTime;
        }

        if (shakeTime <= 0)
        {
            // Reset shake
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            shakeTime = 0;
        }
    }

    public void Shake(float time, float intensity)
    {
        shakeTime = time;
        shakeIntensity = intensity;
    }

}
