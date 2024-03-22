using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour

{
    [SerializeField] Color targetColor;
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeSpeed;
    [SerializeField] float duration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            var currentColor = fadeImage.color;
            currentColor = Color.Lerp(currentColor, targetColor, fadeSpeed * Time.deltaTime);
            fadeImage.color = currentColor;

            // Count down fade duration
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            // Once duration is done, set back to transparent
            SetTargetColorToTransparent();
            duration = 0;
        }
    }

    [ContextMenu("Set Red")]
    public void SetTargetColorToRed()
    {
        targetColor = Color.red;
        targetColor.a = 0.25f;

    }

    [ContextMenu("Set Transparent")]
    public void SetTargetColorToTransparent()
    {
        targetColor = Color.red;
        targetColor.a = 0;
    }

    public void DamageFlash(float time)
    {
        duration = time;
        SetTargetColorToRed();
    }
}
