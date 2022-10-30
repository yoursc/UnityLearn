using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Transform hourHand, minuteHand, secondHand;

    private void Awake()
    {
        DateTime now = DateTime.Now;
        float s = 6f * (now.Second + now.Millisecond * 0.001f);
        float m = 6f * (now.Minute + now.Second / 60f);
        float h = 30f * (now.Hour + now.Minute / 60f);

        secondHand.localRotation = Quaternion.Euler(s, 0, 0);
        minuteHand.localRotation = Quaternion.Euler(m, 0, 0);
        hourHand.localRotation = Quaternion.Euler(h, 0, 0);
    }

    void Update()
    {
        DateTime now = DateTime.Now;
        float s = 6f * (now.Second + now.Millisecond * 0.001f);
        float m = 6f * (now.Minute + now.Second / 60f);
        float h = 30f * (now.Hour + now.Minute / 60f);

        secondHand.localRotation = Quaternion.Euler(s, 0, 0);
        minuteHand.localRotation = Quaternion.Euler(m, 0, 0);
        hourHand.localRotation = Quaternion.Euler(h, 0, 0);
    }
}