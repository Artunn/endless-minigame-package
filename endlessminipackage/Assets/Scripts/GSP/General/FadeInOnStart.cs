using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnStart : MonoBehaviour
{
    public float duration, delay;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FadeInOutCanvas>().FadeInCanvas(duration, delay);  
    }
}
