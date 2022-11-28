using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPCONTROLLER : MonoBehaviour
{
    public PostProcessVolume PV;
    public MotionBlur MB;
    public AmbientOcclusion AB;
    public Bloom bloom;
    public DepthOfField DOF;
    public ColorGrading CG;

    public bool fxOn;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PV.profile.TryGetSettings(out bloom);
        PV.profile.TryGetSettings(out MB);
        PV.profile.TryGetSettings(out AB);
        PV.profile.TryGetSettings(out DOF);
        PV.profile.TryGetSettings(out CG);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1) && fxOn)
        {
            MB.enabled.Override(false);
            AB.enabled.Override(false);
            bloom.enabled.Override(false);
            DOF.enabled.Override(false);
            CG.enabled.Override(false);
            fxOn = false;
        }

        if (Input.GetKey(KeyCode.F2 ) && !fxOn)
        {
            MB.enabled.Override(true);
            AB.enabled.Override(true);
            bloom.enabled.Override(true);
            DOF.enabled.Override(true);
            CG.enabled.Override(true);
            fxOn = true;
        }
    }
}
