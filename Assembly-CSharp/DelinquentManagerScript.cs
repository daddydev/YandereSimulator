using UnityEngine;

// Token: 0x02000081 RID: 129
public class DelinquentManagerScript : MonoBehaviour {

  // Token: 0x06000209 RID: 521 RVA: 0x00029D16 File Offset: 0x00028116
  private void Start() {
    this.Delinquents.SetActive(false);
    this.TimerMax = 15f;
    this.Timer = 15f;
    this.Phase++;
  }

  // Token: 0x0600020A RID: 522 RVA: 0x00029D48 File Offset: 0x00028148
  private void Update() {
    this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
    if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro) {
      AudioSource component = base.GetComponent<AudioSource>();
      component.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, this.Attacker.AggroClips.Length)];
      component.Play();
      this.Aggro = true;
    }
    if (this.Panel.activeInHierarchy && this.Clock.HourTime > this.NextTime[this.Phase]) {
      if (this.Phase == 3 && this.Clock.HourTime > 7.25f) {
        this.TimerMax = 75f;
        this.Timer = 75f;
        this.Phase++;
      } else if (this.Phase == 5 && this.Clock.HourTime > 8.5f) {
        this.TimerMax = 285f;
        this.Timer = 285f;
        this.Phase++;
      } else if (this.Phase == 7 && this.Clock.HourTime > 13.25f) {
        this.TimerMax = 15f;
        this.Timer = 15f;
        this.Phase++;
      } else if (this.Phase == 9 && this.Clock.HourTime > 13.5f) {
        this.TimerMax = 135f;
        this.Timer = 135f;
        this.Phase++;
      }
      if (this.Attacker == null) {
        this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
      }
      this.Circle.fillAmount = 1f - this.Timer / this.TimerMax;
      if (this.Timer <= 0f) {
        this.Delinquents.SetActive(!this.Delinquents.activeInHierarchy);
        if (this.Phase < 8) {
          this.Phase++;
        } else {
          this.Delinquents.SetActive(false);
          this.Panel.SetActive(false);
        }
      }
    }
  }

  // Token: 0x0600020B RID: 523 RVA: 0x00029FFC File Offset: 0x000283FC
  public void CheckTime() {
    if (this.Clock.HourTime < 13f) {
      this.Delinquents.SetActive(false);
      this.TimerMax = 15f;
      this.Timer = 15f;
      this.Phase = 6;
    } else if (this.Clock.HourTime < 15.5f) {
      this.Delinquents.SetActive(false);
      this.TimerMax = 15f;
      this.Timer = 15f;
      this.Phase = 8;
    }
  }

  // Token: 0x0600020C RID: 524 RVA: 0x0002A08A File Offset: 0x0002848A
  public void EasterEgg() {
    this.RapBeat.SetActive(true);
    this.Mirror.Limit++;
  }

  // Token: 0x040006EC RID: 1772
  public GameObject Delinquents;

  // Token: 0x040006ED RID: 1773
  public GameObject RapBeat;

  // Token: 0x040006EE RID: 1774
  public GameObject Panel;

  // Token: 0x040006EF RID: 1775
  public float[] NextTime;

  // Token: 0x040006F0 RID: 1776
  public DelinquentScript Attacker;

  // Token: 0x040006F1 RID: 1777
  public MirrorScript Mirror;

  // Token: 0x040006F2 RID: 1778
  public UILabel TimeLabel;

  // Token: 0x040006F3 RID: 1779
  public ClockScript Clock;

  // Token: 0x040006F4 RID: 1780
  public UISprite Circle;

  // Token: 0x040006F5 RID: 1781
  public float SpeechTimer;

  // Token: 0x040006F6 RID: 1782
  public float TimerMax;

  // Token: 0x040006F7 RID: 1783
  public float Timer;

  // Token: 0x040006F8 RID: 1784
  public bool Aggro;

  // Token: 0x040006F9 RID: 1785
  public int Phase = 1;
}