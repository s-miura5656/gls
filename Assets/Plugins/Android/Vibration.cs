using UnityEngine;
using System.Collections;
using System.Timers;

public static class Vibration
{
    private static bool isvibrate = false; 

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long milliseconds)
    {
        if (isAndroid()) {

            if (!isvibrate)
            {
                vibrator.Call("vibrate", milliseconds);
                isvibrate = true;

                Timer timer = new Timer(milliseconds);

                timer.Elapsed += (sender, e) =>
                {
                    isvibrate = false;
                    timer.Stop();
                };

                timer.Start();
            }
        }
        else
            Handheld.Vibrate();
    }

    private static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true;
#else
        return false;
#endif
    }
}