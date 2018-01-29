using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
public class OsanaMondayBeforeClassEventScript : MonoBehaviour {

  // Token: 0x060006FB RID: 1787 RVA: 0x0006BDD0 File Offset: 0x0006A1D0
  private void Start() {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.Bentos[1].SetActive(false);
    this.Bentos[2].SetActive(false);
    if (DateGlobals.Weekday != DayOfWeek.Monday) {
      base.enabled = false;
    }
  }

  // Token: 0x040011B4 RID: 4532
  public StudentManagerScript StudentManager;

  // Token: 0x040011B5 RID: 4533
  public UILabel EventSubtitle;

  // Token: 0x040011B6 RID: 4534
  public YandereScript Yandere;

  // Token: 0x040011B7 RID: 4535
  public ClockScript Clock;

  // Token: 0x040011B8 RID: 4536
  public StudentScript Rival;

  // Token: 0x040011B9 RID: 4537
  public Transform Destination;

  // Token: 0x040011BA RID: 4538
  public AudioClip SpeechClip;

  // Token: 0x040011BB RID: 4539
  public string[] SpeechText;

  // Token: 0x040011BC RID: 4540
  public float[] SpeechTime;

  // Token: 0x040011BD RID: 4541
  public GameObject AlarmDisc;

  // Token: 0x040011BE RID: 4542
  public GameObject VoiceClip;

  // Token: 0x040011BF RID: 4543
  public GameObject[] Bentos;

  // Token: 0x040011C0 RID: 4544
  public bool EventActive;

  // Token: 0x040011C1 RID: 4545
  public float Distance;

  // Token: 0x040011C2 RID: 4546
  public float Scale;

  // Token: 0x040011C3 RID: 4547
  public float Timer;

  // Token: 0x040011C4 RID: 4548
  public int SpeechPhase = 1;

  // Token: 0x040011C5 RID: 4549
  public int Phase;

  // Token: 0x040011C6 RID: 4550
  public int Frame;
}