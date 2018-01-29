using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
public class RummageSpotScript : MonoBehaviour {

  // Token: 0x0600070D RID: 1805 RVA: 0x0006C1D8 File Offset: 0x0006A5D8
  private void Start() {
    if (this.ID == 1) {
      if (SchemeGlobals.GetSchemeStage(5) == 100) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        base.gameObject.SetActive(false);
      } else {
        if (SchemeGlobals.GetSchemeStage(5) > 4) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
        if (DateGlobals.Weekday == DayOfWeek.Friday && this.Clock.HourTime > 13.5f) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          base.gameObject.SetActive(false);
        }
      }
    }
  }

  // Token: 0x0600070E RID: 1806 RVA: 0x0006C28C File Offset: 0x0006A68C
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
      this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
      this.Yandere.RummageSpot = this;
      this.Yandere.Rummaging = true;
      this.Yandere.CanMove = false;
      this.Yandere.EmptyHands();
      component.Play();
    }
    if (this.Yandere.Rummaging) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position, Quaternion.identity);
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
      gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
    }
    if (this.Yandere.Noticed) {
      component.Stop();
    }
  }

  // Token: 0x0600070F RID: 1807 RVA: 0x0006C3B8 File Offset: 0x0006A7B8
  public void GetReward() {
    if (this.ID == 1) {
      if (this.Phase == 1) {
        SchemeGlobals.SetSchemeStage(5, 2);
        this.Schemes.UpdateInstructions();
        this.Yandere.Inventory.AnswerSheet = true;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.DoorGap.Prompt.enabled = true;
        this.Phase++;
      } else {
        SchemeGlobals.SetSchemeStage(5, 5);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.AnswerSheet = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        base.gameObject.SetActive(false);
        this.Phase++;
      }
    }
  }

  // Token: 0x040011E8 RID: 4584
  public GameObject AlarmDisc;

  // Token: 0x040011E9 RID: 4585
  public DoorGapScript DoorGap;

  // Token: 0x040011EA RID: 4586
  public SchemesScript Schemes;

  // Token: 0x040011EB RID: 4587
  public YandereScript Yandere;

  // Token: 0x040011EC RID: 4588
  public PromptScript Prompt;

  // Token: 0x040011ED RID: 4589
  public ClockScript Clock;

  // Token: 0x040011EE RID: 4590
  public Transform Target;

  // Token: 0x040011EF RID: 4591
  public int Phase;

  // Token: 0x040011F0 RID: 4592
  public int ID;
}