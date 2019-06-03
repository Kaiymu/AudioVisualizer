using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamPrefab : MonoBehaviour {

    public int band;
    public float _startScale, _scaleMultiplier;
	
	void Update () {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
