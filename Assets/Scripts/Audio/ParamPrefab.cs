using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamPrefab : MonoBehaviour {

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

    private Material _material;

    private void Start() {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update () {
        float fredOrBandBuffer = useBuffer ? AudioPeer.audioBandBuffer[band] : AudioPeer.audioBand[band];
        Color color = new Color(fredOrBandBuffer, fredOrBandBuffer, fredOrBandBuffer);
        _material.SetColor("_EmissionColor", color);

        transform.localScale = new Vector3(transform.localScale.x, (fredOrBandBuffer * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
