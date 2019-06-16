using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {

    public static float[] samples;
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];

    private float[] _bufferDecrease = new float[8];
    private AudioSource _audioSource;

    private void Start () {
        samples = new float[AudioManager.Instance.hertz];
        _audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        _GetSpectrumAudioSource();
        _MakeFrequencyBands();
        _BandBuffer();
    }

    private void _GetSpectrumAudioSource() {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void _BandBuffer() {
        for(int i = 0; i < 8; ++i) {
            if (freqBand[i] > bandBuffer[i]) {
                bandBuffer[i] = freqBand[i];
                _bufferDecrease[i] = 0.005f;
            }

            if (freqBand[i] < bandBuffer[i]) {
                bandBuffer[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f;
            }
        }
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
