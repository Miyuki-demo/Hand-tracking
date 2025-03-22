using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;
public class VideoPassthroughManager : MonoBehaviour
{

    void Start()
    {
        PXR_Manager.EnableVideoSeeThrough = true;
    }
    void Update()
    {
        
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }
}
