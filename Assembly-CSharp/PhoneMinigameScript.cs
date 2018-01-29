using UnityEngine;

// Token: 0x02000154 RID: 340
public class PhoneMinigameScript : MonoBehaviour {

  // Token: 0x0600063B RID: 1595 RVA: 0x0005982C File Offset: 0x00057C2C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.MainCamera.GetComponent<AudioListener>().enabled = true;
      this.Prompt.Yandere.gameObject.SetActive(false);
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(45f, 180f, 0f);
      this.Prompt.Yandere.MainCamera.transform.position = new Vector3(0.4f, 12.66666f, -29.2f);
      this.Prompt.Yandere.RPGCamera.enabled = false;
      this.SmartPhoneScreen = this.Event.Rival.SmartPhoneScreen;
      this.Smartphone = this.Event.Rival.SmartPhone.transform;
      this.PickpocketMinigame.PickpocketSpot = null;
      this.PickpocketMinigame.Show = true;
      this.OriginalRotation = this.Smartphone.eulerAngles;
      this.OriginalPosition = this.Smartphone.position;
      this.Tampering = true;
    }
    if (this.Tampering) {
      if (!this.PickpocketMinigame.Failure) {
        if (this.PickpocketMinigame.Progress == 1) {
          this.Smartphone.position = Vector3.Lerp(this.Smartphone.position, new Vector3(0.4f, this.Smartphone.position.y, this.Smartphone.position.z), Time.deltaTime * 10f);
        } else if (this.PickpocketMinigame.Progress == 2) {
          this.Smartphone.eulerAngles = Vector3.Lerp(this.Smartphone.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 10f);
        } else if (this.PickpocketMinigame.Progress == 3) {
          this.SmartPhoneScreen.material.mainTexture = this.AlarmOff;
        } else if (this.PickpocketMinigame.Progress == 4) {
          this.Smartphone.eulerAngles = Vector3.Lerp(this.Smartphone.eulerAngles, new Vector3(this.OriginalRotation.x, this.OriginalRotation.y, this.OriginalRotation.z), Time.deltaTime * 10f);
        } else if (!this.PickpocketMinigame.Show) {
          this.Smartphone.position = Vector3.Lerp(this.Smartphone.position, new Vector3(this.OriginalPosition.x, this.OriginalPosition.y, this.OriginalPosition.z), Time.deltaTime * 10f);
          this.Timer += Time.deltaTime;
          if ((double)this.Timer > 1.0) {
            this.Event.Sabotaged = true;
            this.End();
          }
        }
      } else {
        this.Prompt.Yandere.transform.position = new Vector3(0f, 12f, -28.5f);
        this.Event.Rival.transform.position = new Vector3(0f, 12f, -29.2f);
        this.Prompt.Yandere.Pickpocketing = true;
        this.Event.Rival.YandereVisible = true;
        this.Event.Rival.Distracted = false;
        this.Event.Rival.Alarm = 200f;
        this.End();
      }
    }
  }

  // Token: 0x0600063C RID: 1596 RVA: 0x00059C1C File Offset: 0x0005801C
  private void End() {
    this.Prompt.Yandere.MainCamera.GetComponent<AudioListener>().enabled = false;
    this.Prompt.Yandere.RPGCamera.enabled = true;
    this.Prompt.Yandere.gameObject.SetActive(true);
    this.Prompt.Yandere.CanMove = true;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Tampering = false;
    base.gameObject.SetActive(false);
  }

  // Token: 0x04000F28 RID: 3880
  public PickpocketMinigameScript PickpocketMinigame;

  // Token: 0x04000F29 RID: 3881
  public OsanaThursdayAfterClassEventScript Event;

  // Token: 0x04000F2A RID: 3882
  public Renderer SmartPhoneScreen;

  // Token: 0x04000F2B RID: 3883
  public Transform Smartphone;

  // Token: 0x04000F2C RID: 3884
  public PromptScript Prompt;

  // Token: 0x04000F2D RID: 3885
  public Texture AlarmOff;

  // Token: 0x04000F2E RID: 3886
  public bool Tampering;

  // Token: 0x04000F2F RID: 3887
  public float Timer;

  // Token: 0x04000F30 RID: 3888
  public Vector3 OriginalPosition;

  // Token: 0x04000F31 RID: 3889
  public Vector3 OriginalRotation;
}