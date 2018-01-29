using UnityEngine;

// Token: 0x020001BE RID: 446
public class SpyScript : MonoBehaviour {

  // Token: 0x060007C2 RID: 1986 RVA: 0x00076F04 File Offset: 0x00075304
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_spying_00");
      this.Yandere.CanMove = false;
      this.Phase++;
    }
    if (this.Phase == 1) {
      Quaternion b = Quaternion.LookRotation(this.SpyTarget.transform.position - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, b, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.SpySpot.position);
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        if (this.Yandere.Inventory.DirectionalMic) {
          this.PromptBar.Label[0].text = "Record";
          this.CanRecord = true;
        }
        this.PromptBar.Label[1].text = "Stop";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.Yandere.MainCamera.enabled = false;
        this.SpyCamera.SetActive(true);
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      if (this.CanRecord && Input.GetButtonDown("A")) {
        this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_spyRecord_00");
        this.Yandere.Microphone.SetActive(true);
        this.Recording = true;
      }
      if (Input.GetButtonDown("B")) {
        this.End();
      }
    }
  }

  // Token: 0x060007C3 RID: 1987 RVA: 0x00077100 File Offset: 0x00075500
  public void End() {
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Yandere.Microphone.SetActive(false);
    this.Yandere.MainCamera.enabled = true;
    this.Yandere.CanMove = true;
    this.SpyCamera.SetActive(false);
    this.Timer = 0f;
    this.Phase = 0;
  }

  // Token: 0x040013E6 RID: 5094
  public PromptBarScript PromptBar;

  // Token: 0x040013E7 RID: 5095
  public YandereScript Yandere;

  // Token: 0x040013E8 RID: 5096
  public PromptScript Prompt;

  // Token: 0x040013E9 RID: 5097
  public GameObject SpyCamera;

  // Token: 0x040013EA RID: 5098
  public Transform SpyTarget;

  // Token: 0x040013EB RID: 5099
  public Transform SpySpot;

  // Token: 0x040013EC RID: 5100
  public float Timer;

  // Token: 0x040013ED RID: 5101
  public bool CanRecord;

  // Token: 0x040013EE RID: 5102
  public bool Recording;

  // Token: 0x040013EF RID: 5103
  public int Phase;
}