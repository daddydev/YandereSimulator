using UnityEngine;

// Token: 0x02000141 RID: 321
public class NotificationManagerScript : MonoBehaviour {

  // Token: 0x060005FE RID: 1534 RVA: 0x00054C00 File Offset: 0x00053000
  private void Awake() {
    this.NotificationMessages = new NotificationTypeAndStringDictionary
    {
      {
        NotificationType.Bloody,
        "Visibly Bloody"
      },
      {
        NotificationType.Body,
        "Near Body"
      },
      {
        NotificationType.Insane,
        "Visibly Insane"
      },
      {
        NotificationType.Armed,
        "Visibly Armed"
      },
      {
        NotificationType.Lewd,
        "Visibly Lewd"
      },
      {
        NotificationType.Intrude,
        "Intruding"
      },
      {
        NotificationType.Late,
        "Late For Class"
      },
      {
        NotificationType.Info,
        "Learned New Info"
      },
      {
        NotificationType.Topic,
        "Learned New Topic"
      },
      {
        NotificationType.Opinion,
        "Learned Opinion"
      },
      {
        NotificationType.Complete,
        "Mission Complete"
      },
      {
        NotificationType.Exfiltrate,
        "Leave School"
      },
      {
        NotificationType.Evidence,
        "Evidence Recorded"
      },
      {
        NotificationType.ClassSoon,
        "Class Begins Soon"
      },
      {
        NotificationType.ClassNow,
        "Class Begins Now"
      }
    };
  }

  // Token: 0x060005FF RID: 1535 RVA: 0x00054CD4 File Offset: 0x000530D4
  private void Update() {
    if (this.NotificationParent.localPosition.y > 0.001f + -0.049f * (float)this.NotificationsSpawned) {
      this.NotificationParent.localPosition = new Vector3(this.NotificationParent.localPosition.x, Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float)this.NotificationsSpawned, Time.deltaTime * 10f), this.NotificationParent.localPosition.z);
    }
    if (this.Phase == 1) {
      if (this.Clock.HourTime > 8.4f) {
        this.DisplayNotification(NotificationType.ClassSoon);
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      if (this.Clock.HourTime > 8.5f) {
        this.DisplayNotification(NotificationType.ClassNow);
        this.Phase++;
      }
    } else if (this.Phase == 3) {
      if (this.Clock.HourTime > 13.4f) {
        this.DisplayNotification(NotificationType.ClassSoon);
        this.Phase++;
      }
    } else if (this.Phase == 4 && this.Clock.HourTime > 13.5f) {
      this.DisplayNotification(NotificationType.ClassNow);
      this.Phase++;
    }
  }

  // Token: 0x06000600 RID: 1536 RVA: 0x00054E60 File Offset: 0x00053260
  public void DisplayNotification(NotificationType Type) {
    if (!this.Yandere.Egg) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Notification);
      NotificationScript component = gameObject.GetComponent<NotificationScript>();
      gameObject.transform.parent = this.NotificationParent;
      gameObject.transform.localPosition = new Vector3(0f, 0.60275f + 0.049f * (float)this.NotificationsSpawned, 0f);
      gameObject.transform.localEulerAngles = Vector3.zero;
      component.NotificationManager = this;
      string text;
      bool flag = this.NotificationMessages.TryGetValue(Type, out text);
      component.Label.text = text;
      this.NotificationsSpawned++;
      component.ID = this.NotificationsSpawned;
    }
  }

  // Token: 0x04000E69 RID: 3689
  public YandereScript Yandere;

  // Token: 0x04000E6A RID: 3690
  public Transform NotificationSpawnPoint;

  // Token: 0x04000E6B RID: 3691
  public Transform NotificationParent;

  // Token: 0x04000E6C RID: 3692
  public GameObject Notification;

  // Token: 0x04000E6D RID: 3693
  public int NotificationsSpawned;

  // Token: 0x04000E6E RID: 3694
  public int Phase = 1;

  // Token: 0x04000E6F RID: 3695
  public ClockScript Clock;

  // Token: 0x04000E70 RID: 3696
  private NotificationTypeAndStringDictionary NotificationMessages;
}