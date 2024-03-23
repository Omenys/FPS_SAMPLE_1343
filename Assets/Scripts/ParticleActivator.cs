using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {

        ps = FindObjectOfType<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Emit()
    {

        ps.Play();

    }
}
