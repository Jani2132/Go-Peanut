using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPControl : MonoBehaviour
{
    PostProcessVolume PV;
    Vignette vignette;
    MotionBlur MB;
    AmbientOcclusion AB;
    Bloom bloom;
    DepthOfField DOF;
    ColorGrading CG;

    public bool fxOn;

    // Start is called before the first frame update
    void Start()
    {
        fxOn = true;

        vignette.enabled.Override(true);
        MB.enabled.Override(true);
        AB.enabled.Override(true);
        bloom.enabled.Override(true);
        DOF.enabled.Override(true);
        CG.enabled.Override(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1) && fxOn)
        {
            vignette.enabled.Override(false);
            MB.enabled.Override(false);
            AB.enabled.Override(false);
            bloom.enabled.Override(false);
            DOF.enabled.Override(false);
            CG.enabled.Override(false);
        }
        else
            fxOn = true;
        vignette.enabled.Override(true);
        MB.enabled.Override(true);
        AB.enabled.Override(true);
        bloom.enabled.Override(true);
        DOF.enabled.Override(true);
        CG.enabled.Override(true);
    }
}
