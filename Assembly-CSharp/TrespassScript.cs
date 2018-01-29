using UnityEngine;

// Token: 0x020001E9 RID: 489
public class TrespassScript : MonoBehaviour {

  // Token: 0x060008C2 RID: 2242 RVA: 0x0009DED4 File Offset: 0x0009C2D4
  private void OnTriggerEnter(Collider other) {
    if (base.enabled && other.gameObject.layer == 13) {
      this.YandereObject = other.gameObject;
      this.Yandere = other.gameObject.GetComponent<YandereScript>();
      if (this.Yandere != null) {
        if (!this.Yandere.Trespassing) {
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Intrude);
        }
        this.Yandere.Trespassing = true;
      }
    }
  }

  // Token: 0x060008C3 RID: 2243 RVA: 0x0009DF59 File Offset: 0x0009C359
  private void OnTriggerExit(Collider other) {
    if (this.Yandere != null && other.gameObject == this.YandereObject) {
      this.Yandere.Trespassing = false;
    }
  }

  // Token: 0x040019EB RID: 6635
  public GameObject YandereObject;

  // Token: 0x040019EC RID: 6636
  public YandereScript Yandere;

  // Token: 0x040019ED RID: 6637
  public bool HideNotification;

  // Token: 0x040019EE RID: 6638
  public bool OffLimits;
}