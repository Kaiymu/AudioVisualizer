using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamPrefab : MonoBehaviour {

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
	
	void Update () {
        float fredOrBandBuffer = useBuffer ? AudioPeer.bandBuffer[band] : AudioPeer.freqBand[band];
        transform.localScale = new Vector3(transform.localScale.x, (fredOrBandBuffer * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
