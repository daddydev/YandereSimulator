using System;
using UnityEngine;

// Token: 0x0200017C RID: 380
public class OsanaFridayBeforeClassEvent2Script : MonoBehaviour {

  // Token: 0x04001199 RID: 4505
  public OsanaFridayBeforeClassEvent1Script OtherEvent;

  // Token: 0x0400119A RID: 4506
  public StudentManagerScript StudentManager;

  // Token: 0x0400119B RID: 4507
  public AudioSoftwareScript AudioSoftware;

  // Token: 0x0400119C RID: 4508
  public JukeboxScript Jukebox;

  // Token: 0x0400119D RID: 4509
  public UILabel EventSubtitle;

  // Token: 0x0400119E RID: 4510
  public YandereScript Yandere;

  // Token: 0x0400119F RID: 4511
  public ClockScript Clock;

  // Token: 0x040011A0 RID: 4512
  public SpyScript Spy;

  // Token: 0x040011A1 RID: 4513
  public StudentScript Ganguro;

  // Token: 0x040011A2 RID: 4514
  public StudentScript Rival;

  // Token: 0x040011A3 RID: 4515
  public Transform[] Location;

  // Token: 0x040011A4 RID: 4516
  public AudioClip[] SpeechClip;

  // Token: 0x040011A5 RID: 4517
  public string[] SpeechText;

  // Token: 0x040011A6 RID: 4518
  public float[] SpeechTime;

  // Token: 0x040011A7 RID: 4519
  public string[] EventAnim;

  // Token: 0x040011A8 RID: 4520
  public GameObject AlarmDisc;

  // Token: 0x040011A9 RID: 4521
  public GameObject VoiceClip;

  // Token: 0x040011AA RID: 4522
  public Quaternion targetRotation;

  // Token: 0x040011AB RID: 4523
  public float Distance;

  // Token: 0x040011AC RID: 4524
  public float Scale;

  // Token: 0x040011AD RID: 4525
  public float Timer;

  // Token: 0x040011AE RID: 4526
  public int SpeechPhase = 1;

  // Token: 0x040011AF RID: 4527
  public DayOfWeek EventDay;

  // Token: 0x040011B0 RID: 4528
  public int Phase;

  // Token: 0x040011B1 RID: 4529
  public int Frame;

  // Token: 0x040011B2 RID: 4530
  public Vector3 OriginalPosition;

  // Token: 0x040011B3 RID: 4531
  public Vector3 OriginalRotation;
}