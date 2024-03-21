using UnityEngine;
using UnityEngine.Events;

public class RefillStation : MonoBehaviour
{
    [SerializeField] UnityEvent Interact;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Interact.Invoke();

        }
    }



}
