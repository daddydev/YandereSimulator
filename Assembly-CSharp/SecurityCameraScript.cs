using UnityEngine;

// Token: 0x020001AA RID: 426
public class SecurityCameraScript : MonoBehaviour {

  // Token: 0x06000774 RID: 1908 RVA: 0x000702C0 File Offset: 0x0006E6C0
  private void Update() {
    this.Rotation += (float)this.Direction * 36f * Time.deltaTime;
    base.transform.parent.localEulerAngles = new Vector3(base.transform.parent.localEulerAngles.x, this.Rotation, base.transform.parent.localEulerAngles.z);
    if (this.Direction > 0) {
      if (this.Rotation > 86.5f) {
        this.Direction = -1;
      }
    } else if (this.Rotation < -86.5f) {
      this.Direction = 1;
    }
  }

  // Token: 0x06000775 RID: 1909 RVA: 0x00070378 File Offset: 0x0006E778
  private void OnTriggerStay(Collider other) {
    if (this.MissionMode.GameOverID == 0) {
      if (other.gameObject.layer == 13) {
        if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Dragging || this.Yandere.Carrying || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f)) {
          if (this.Yandere.Mask == null) {
            if (this.MissionMode.enabled) {
              this.MissionMode.GameOverID = 15;
              this.MissionMode.GameOver();
              this.MissionMode.Phase = 4;
              base.enabled = false;
            } else if (!this.SecuritySystem.Evidence) {
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
              this.SecuritySystem.Evidence = true;
            }
          } else if (!this.SecuritySystem.Evidence) {
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
            this.SecuritySystem.Masked = true;
          }
        }
      } else if (other.gameObject.layer == 11) {
        this.MissionMode.GameOverID = 15;
        this.MissionMode.GameOver();
        this.MissionMode.Phase = 4;
        base.enabled = false;
      }
    }
  }

  // Token: 0x040012E5 RID: 4837
  public SecuritySystemScript SecuritySystem;

  // Token: 0x040012E6 RID: 4838
  public MissionModeScript MissionMode;

  // Token: 0x040012E7 RID: 4839
  public YandereScript Yandere;

  // Token: 0x040012E8 RID: 4840
  public AudioSource MyAudio;

  // Token: 0x040012E9 RID: 4841
  public float Rotation;

  // Token: 0x040012EA RID: 4842
  public int Direction = 1;
}