using System;
using UnityEngine;

// Token: 0x0200017B RID: 379
public class OsanaFridayBeforeClassEvent1Script : MonoBehaviour {

  // Token: 0x060006F7 RID: 1783 RVA: 0x0006BD6F File Offset: 0x0006A16F
  private void Start() {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday != this.EventDay) {
      base.enabled = false;
    }
    this.Yoogle.SetActive(false);
  }

  // Token: 0x04001184 RID: 4484
  public OsanaFridayBeforeClassEvent2Script OtherEvent;

  // Token: 0x04001185 RID: 4485
  public StudentManagerScript StudentManager;

  // Token: 0x04001186 RID: 4486
  public UILabel EventSubtitle;

  // Token: 0x04001187 RID: 4487
  public YandereScript Yandere;

  // Token: 0x04001188 RID: 4488
  public ClockScript Clock;

  // Token: 0x04001189 RID: 4489
  public StudentScript Rival;

  // Token: 0x0400118A RID: 4490
  public Transform Location;

  // Token: 0x0400118B RID: 4491
  public AudioClip[] SpeechClip;

  // Token: 0x0400118C RID: 4492
  public string[] SpeechText;

  // Token: 0x0400118D RID: 4493
  public string EventAnim;

  // Token: 0x0400118E RID: 4494
  public GameObject AlarmDisc;

  // Token: 0x0400118F RID: 4495
  public GameObject VoiceClip;

  // Token: 0x04001190 RID: 4496
  public GameObject Yoogle;

  // Token: 0x04001191 RID: 4497
  public float Distance;

  // Token: 0x04001192 RID: 4498
  public float Scale;

  // Token: 0x04001193 RID: 4499
  public float Timer;

  // Token: 0x04001194 RID: 4500
  public DayOfWeek EventDay;

  // Token: 0x04001195 RID: 4501
  public int Phase;

  // Token: 0x04001196 RID: 4502
  public int Frame;

  // Token: 0x04001197 RID: 4503
  public Vector3 OriginalPosition;

  // Token: 0x04001198 RID: 4504
  public Vector3 OriginalRotation;
}