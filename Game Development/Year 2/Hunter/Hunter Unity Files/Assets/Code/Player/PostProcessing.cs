using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette vignette;
    private LensDistortion lensDistortion;
    private PlayerController pc;

    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out lensDistortion);
        vignette.smoothness.value = 0.6f;
        lensDistortion.intensity.value = 0f;
        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.slowTimer > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            vignette.smoothness.value = 2f;
            lensDistortion.intensity.value = -50f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || pc.slowTimer <= 0)
        {
            vignette.smoothness.value = 0.6f;
            lensDistortion.intensity.value = 0f;


        }
    }
}
