using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeCube : MonoBehaviour {

    public GameObject cubePrefab;
    public float maximumScale = 10f;
    public float maxColor = 1f;

    private List<GameObject> _sampleCubeList = new List<GameObject>(512);

	void Start () {
		for(int i = 0; i < 512; i++) {
            var o = Instantiate(cubePrefab);
            o.transform.position = transform.position;
            o.transform.parent = transform;
            o.name = "Cube " + i;
            transform.eulerAngles = new Vector3(0, -0.703125f * i, 0f);
            o.transform.position = Vector3.forward * 100;
            _sampleCubeList.Add(o);
        }
	}

    void Update() {
        if (_sampleCubeList == null)
            return;

        for (int i = 0; i < _sampleCubeList.Count; i++) {
            var sampleCube = _sampleCubeList[i];
            sampleCube.transform.localScale = new Vector3(1, (AudioPeer.samples[i] * maximumScale) + 2, 1);
            float baseColor = (AudioPeer.samples[i] * maxColor);
            float red = Mathf.Cos(baseColor);
            float green = Mathf.Sin(baseColor);
            float blue = Random.Range(0f, 1f) * baseColor;
            sampleCube.GetComponent<Renderer>().material.color = new Color(red, green, blue);
        }
    }
}
