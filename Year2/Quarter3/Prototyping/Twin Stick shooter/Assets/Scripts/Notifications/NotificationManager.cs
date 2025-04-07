using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class NotificationManager : MonoBehaviour
{
    [SerializeField]
    public AndroidNotifications androidNotifications;

    [SerializeField]
    public IOSNotifications iosNotifications;

    private void Start()
    {
#if UNITY_ANDROID
        androidNotifications.RequestAuthorization();
        androidNotifications.RegisterNotificationChannel();
#endif

#if UNITY_IOS
        StartCoroutine(iosNotifications.RequestAuthorization());
#endif
    }
}