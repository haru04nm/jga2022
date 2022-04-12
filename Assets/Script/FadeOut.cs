using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    AudioSource audioSource;

    public bool IsFade;

    public double FadeOutSeconds = 1.0f;

    public static bool IsFadeOut;

    double FadeDeltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;

            if(FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;

                IsFadeOut = false;
            }

            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
        }
    }

    public bool FadeFlag
    {
        get
        {
            return IsFadeOut;
        }

        set
        {
            IsFadeOut = value;
        }
    }
}
