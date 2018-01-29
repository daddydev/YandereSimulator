using System;
using UnityEngine;

// Token: 0x02000180 RID: 384
public class OsanaThursdayAfterClassEventScript : MonoBehaviour {

  // Token: 0x040011C7 RID: 4551
  public StudentManagerScript StudentManager;

  // Token: 0x040011C8 RID: 4552
  public PhoneMinigameScript PhoneMinigame;

  // Token: 0x040011C9 RID: 4553
  public UILabel EventSubtitle;

  // Token: 0x040011CA RID: 4554
  public YandereScript Yandere;

  // Token: 0x040011CB RID: 4555
  public ClockScript Clock;

  // Token: 0x040011CC RID: 4556
  public StudentScript Rival;

  // Token: 0x040011CD RID: 4557
  public Transform Location;

  // Token: 0x040011CE RID: 4558
  public AudioClip[] SpeechClip;

  // Token: 0x040011CF RID: 4559
  public string[] SpeechText;

  // Token: 0x040011D0 RID: 4560
  public string[] EventAnim;

  // Token: 0x040011D1 RID: 4561
  public GameObject AlarmDisc;

  // Token: 0x040011D2 RID: 4562
  public GameObject VoiceClip;

  // Token: 0x040011D3 RID: 4563
  public float Distance;

  // Token: 0x040011D4 RID: 4564
  public float Scale;

  // Token: 0x040011D5 RID: 4565
  public float Timer;

  // Token: 0x040011D6 RID: 4566
  public DayOfWeek EventDay;

  // Token: 0x040011D7 RID: 4567
  public int Phase;

  // Token: 0x040011D8 RID: 4568
  public int Frame;

  // Token: 0x040011D9 RID: 4569
  public bool Sabotaged;

  // Token: 0x040011DA RID: 4570
  public Vector3 OriginalPosition;

  // Token: 0x040011DB RID: 4571
  public Vector3 OriginalRotation;
}