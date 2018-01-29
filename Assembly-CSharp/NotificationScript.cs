using UnityEngine;

// Token: 0x02000142 RID: 322
public class NotificationScript : MonoBehaviour {

  // Token: 0x06000602 RID: 1538 RVA: 0x00054F24 File Offset: 0x00053324
  private void Start() {
    if (MissionModeGlobals.MissionMode) {
      this.Icon[0].color = new Color(1f, 1f, 1f, 1f);
      this.Icon[1].color = new Color(1f, 1f, 1f, 1f);
      this.Label.color = new Color(1f, 1f, 1f, 1f);
    }
  }

  // Token: 0x06000603 RID: 1539 RVA: 0x00054FAC File Offset: 0x000533AC
  private void Update() {
    if (!this.Display) {
      this.Panel.alpha -= Time.deltaTime * ((this.NotificationManager.NotificationsSpawned <= this.ID + 2) ? 1f : 3f);
      if (this.Panel.alpha <= 0f) {
        UnityEngine.Object.Destroy(base.gameObject);
      }
    } else {
      this.Timer += Time.deltaTime;
      if (this.Timer > 4f) {
        this.Display = false;
      }
      if (this.NotificationManager.NotificationsSpawned > this.ID + 2) {
        this.Display = false;
      }
    }
  }

  // Token: 0x04000E71 RID: 3697
  public NotificationManagerScript NotificationManager;

  // Token: 0x04000E72 RID: 3698
  public UISprite[] Icon;

  // Token: 0x04000E73 RID: 3699
  public UIPanel Panel;

  // Token: 0x04000E74 RID: 3700
  public UILabel Label;

  // Token: 0x04000E75 RID: 3701
  public bool Display;

  // Token: 0x04000E76 RID: 3702
  public float Timer;

  // Token: 0x04000E77 RID: 3703
  public int ID;
}