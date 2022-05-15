using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionException : MonoBehaviour
{
    // Start is called before the first frame update
    private bool vientDeJouer;
    void Start()
    {
        vientDeJouer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool VientDeJouer
    {
        get => vientDeJouer;
        set => vientDeJouer = value;
    }
}
