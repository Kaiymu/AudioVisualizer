using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {

    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];

    private AudioSource _audioSource;

    void Start () {
        _audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        _GetSpectrumAudioSource();
        _MakeFrequencyBands();
    }

    private void _GetSpectrumAudioSource() {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void _MakeFrequencyBands() {
        int count = 0;

        for (int i = 0; i < freqBand.Length; i++) {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if(i == 7) {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++) {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }
}
