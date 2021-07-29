using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class mobileNotification : MonoBehaviour
{
    // Start is called before the first frame update
    string t;
    int countTime;
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",

        };

        int hr = saveTime_notification.convertH_s(saveTime_notification.get_Hour());
        int mr = saveTime_notification.get_Minute();
        int Tr = hr + mr;

        int hs = saveTime_notification.convertH_s(saveTime_notification.get_timeHour());
        int ms = saveTime_notification.get_timeMinute();
        int Ts = hs + ms;

        if(Tr <  Ts){
            countTime = Ts - Tr;
        }
        else{
            int day = 24;
            countTime = (saveTime_notification.convertH_s(day) - Tr) + Ts;
        }
        t = "<-_-> set :" ;

        AndroidNotificationCenter.RegisterNotificationChannel(channel); 

        var notification = new AndroidNotification();
        notification.Title = "สวัสดี";
        notification.Text = " คุณสามารถเข้าเล่นเกม";
        notification.FireTime = System.DateTime.Now.AddMinutes(countTime);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
