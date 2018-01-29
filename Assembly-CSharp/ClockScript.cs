using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class ClockScript : MonoBehaviour {

  // Token: 0x06000170 RID: 368 RVA: 0x00018188 File Offset: 0x00016588
  private void Start() {
    this.PeriodLabel.text = "BEFORE CLASS";
    this.PresentTime = this.StartHour * 60f;
    if (DateGlobals.Weekday == DayOfWeek.Sunday) {
      DateGlobals.Weekday = DayOfWeek.Monday;
    }
    if (SchoolGlobals.SchoolAtmosphere < 0.5f) {
      this.BloomEffect.bloomIntensity = 0.25f;
      this.BloomEffect.bloomThreshhold = 0.5f;
      this.Police.Darkness.enabled = true;
      this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, 1f);
      this.FadeIn = true;
      this.Timer = 5f;
    } else {
      this.BloomEffect.bloomIntensity = 10f;
      this.BloomEffect.bloomThreshhold = 0f;
    }
    this.BloomEffect.bloomThreshhold = 0f;
    this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
    this.MainLight.color = new Color(1f, 1f, 1f, 1f);
    RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
    RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
  }

  // Token: 0x06000171 RID: 369 RVA: 0x0001832C File Offset: 0x0001672C
  private void Update() {
    if (this.FadeIn && Time.deltaTime < 1f) {
      this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
      if (this.Police.Darkness.color.a == 0f) {
        this.Police.Darkness.enabled = false;
        this.FadeIn = false;
      }
    }
    if (this.PresentTime < 1080f) {
      if (this.Timer < 5f) {
        this.Timer += Time.deltaTime;
        this.BloomEffect.bloomIntensity -= Time.deltaTime * 9.75f;
        this.BloomEffect.bloomThreshhold += Time.deltaTime * 0.5f;
        if (this.BloomEffect.bloomThreshhold > 0.5f) {
          this.BloomEffect.bloomIntensity = 0.25f;
          this.BloomEffect.bloomThreshhold = 0.5f;
        }
      }
    } else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling) {
      this.Yandere.StudentManager.StopMoving();
      this.Police.Darkness.enabled = true;
      this.Police.FadeOut = true;
      this.StopTime = true;
    }
    if (!this.StopTime) {
      if (this.Period == 3) {
        this.PresentTime += Time.deltaTime * 0.0166666675f * this.TimeSpeed * 0.5f;
      } else {
        this.PresentTime += Time.deltaTime * 0.0166666675f * this.TimeSpeed;
      }
    }
    if (this.PresentTime > 1440f) {
      this.PresentTime -= 1440f;
    }
    this.HourTime = this.PresentTime / 60f;
    this.Hour = Mathf.Floor(this.PresentTime / 60f);
    this.Minute = Mathf.Floor((this.PresentTime / 60f - this.Hour) * 60f);
    if (this.Hour == 0f || this.Hour == 12f) {
      this.HourNumber = "12";
    } else if (this.Hour < 12f) {
      this.HourNumber = this.Hour.ToString("f0");
    } else {
      this.HourNumber = (this.Hour - 12f).ToString("f0");
    }
    if (this.Minute < 10f) {
      this.MinuteNumber = "0" + this.Minute.ToString("f0");
    } else {
      this.MinuteNumber = this.Minute.ToString("f0");
    }
    this.TimeText = this.HourNumber + ":" + this.MinuteNumber + ((this.Hour >= 12f) ? " PM" : " AM");
    this.TimeLabel.text = this.TimeText;
    this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Minute * 6f);
    this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Hour * 30f);
    if (this.HourTime < 8.5f) {
      if (this.Period < 1) {
        this.PeriodLabel.text = "BEFORE CLASS";
        this.DeactivateTrespassZones();
        this.Period++;
      }
    } else if (this.HourTime < 13f) {
      if (this.Period < 2) {
        this.PeriodLabel.text = "CLASS TIME";
        this.ActivateTrespassZones();
        this.Period++;
      }
    } else if (this.HourTime < 13.5f) {
      if (this.Period < 3) {
        this.PeriodLabel.text = "LUNCH TIME";
        this.DeactivateTrespassZones();
        this.Period++;
      }
    } else if (this.HourTime < 15.5f) {
      if (this.Period < 4) {
        this.PeriodLabel.text = "CLASS TIME";
        this.ActivateTrespassZones();
        this.Period++;
      }
    } else if (this.HourTime < 16f) {
      if (this.Period < 5) {
        this.PeriodLabel.text = "CLEANING TIME";
        this.ActivateTrespassZones();
        this.Period++;
      }
    } else if (this.Period < 6) {
      this.PeriodLabel.text = "AFTER SCHOOL";
      this.DeactivateTrespassZones();
      this.Period++;
    }
    this.Sun.eulerAngles = new Vector3(this.Sun.eulerAngles.x, this.Sun.eulerAngles.y, -45f + 90f * (this.PresentTime - 420f) / 660f);
    if ((this.Yandere.transform.position.y < 11f && this.Yandere.transform.position.x > -30f && this.Yandere.transform.position.z > -38f && this.Yandere.transform.position.x < -22f && this.Yandere.transform.position.z < -26f) || (this.Yandere.transform.position.y < 11f && this.Yandere.transform.position.x > 22f && this.Yandere.transform.position.z > -38f && this.Yandere.transform.position.x < 30f && this.Yandere.transform.position.z < -26f)) {
      this.AmbientLightDim -= Time.deltaTime;
      if (this.AmbientLightDim < 0.1f) {
        this.AmbientLightDim = 0.1f;
      }
    } else {
      this.AmbientLightDim += Time.deltaTime;
      if (this.AmbientLightDim > 0.75f) {
        this.AmbientLightDim = 0.75f;
      }
    }
    if (this.PresentTime > 930f) {
      this.DayProgress = (this.PresentTime - 930f) / 150f;
      this.MainLight.color = new Color(1f - 0.149019614f * this.DayProgress, 1f - 0.403921574f * this.DayProgress, 1f - 0.709803939f * this.DayProgress);
      RenderSettings.ambientLight = new Color(1f - 0.149019614f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.403921574f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.709803939f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress));
      this.SkyboxColor = new Color(1f - 0.149019614f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.403921574f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.709803939f * this.DayProgress - 0.5f * (1f - this.DayProgress));
      RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
    } else {
      RenderSettings.ambientLight = new Color(this.AmbientLightDim, this.AmbientLightDim, this.AmbientLightDim);
    }
    if (this.TimeSkip) {
      if (this.HalfwayTime == 0f) {
        this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
        this.Yandere.TimeSkipHeight = this.Yandere.transform.position.y;
        this.Yandere.Phone.SetActive(true);
        this.Yandere.TimeSkipping = true;
        this.Yandere.CanMove = false;
        this.Blur.enabled = true;
        if (this.Yandere.Armed) {
          this.Yandere.Unequip();
        }
      }
      if (Time.timeScale < 25f) {
        Time.timeScale += 1f;
      }
      this.Yandere.Character.GetComponent<Animation>()["f02_timeSkip_00"].speed = 1f / Time.timeScale;
      this.Blur.blurAmount = 0.92f * (Time.timeScale / 100f);
      if (this.PresentTime > this.TargetTime) {
        this.EndTimeSkip();
      }
      if (this.Yandere.CameraEffects.Streaks.color.a > 0f || this.Yandere.CameraEffects.MurderStreaks.color.a > 0f || this.Yandere.NearSenpai || Input.GetButtonDown("Start")) {
        this.EndTimeSkip();
      }
    }
  }

  // Token: 0x06000172 RID: 370 RVA: 0x00018E90 File Offset: 0x00017290
  public void EndTimeSkip() {
    this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
    this.Yandere.Phone.SetActive(false);
    this.Yandere.TimeSkipping = false;
    this.Blur.enabled = false;
    Time.timeScale = 1f;
    this.TimeSkip = false;
    this.HalfwayTime = 0f;
    if (!this.Yandere.Noticed && !this.Police.FadeOut) {
      this.Yandere.CanMove = true;
    }
  }

  // Token: 0x06000173 RID: 371 RVA: 0x00018F30 File Offset: 0x00017330
  private string GetWeekdayText(DayOfWeek weekday) {
    if (weekday == DayOfWeek.Sunday) {
      return "SUNDAY";
    }
    if (weekday == DayOfWeek.Monday) {
      return "MONDAY";
    }
    if (weekday == DayOfWeek.Tuesday) {
      return "TUESDAY";
    }
    if (weekday == DayOfWeek.Wednesday) {
      return "WEDNESDAY";
    }
    if (weekday == DayOfWeek.Thursday) {
      return "THURSDAY";
    }
    if (weekday == DayOfWeek.Friday) {
      return "FRIDAY";
    }
    return "SATURDAY";
  }

  // Token: 0x06000174 RID: 372 RVA: 0x00018F90 File Offset: 0x00017390
  private void ActivateTrespassZones() {
    this.SchoolBell.Play();
    foreach (Collider collider in this.TrespassZones) {
      collider.enabled = true;
    }
  }

  // Token: 0x06000175 RID: 373 RVA: 0x00018FD0 File Offset: 0x000173D0
  public void DeactivateTrespassZones() {
    this.Yandere.Trespassing = false;
    this.SchoolBell.Play();
    foreach (Collider collider in this.TrespassZones) {
      if (!collider.GetComponent<TrespassScript>().OffLimits) {
        collider.enabled = false;
      }
    }
  }

  // Token: 0x04000466 RID: 1126
  private string MinuteNumber = string.Empty;

  // Token: 0x04000467 RID: 1127
  private string HourNumber = string.Empty;

  // Token: 0x04000468 RID: 1128
  public Collider[] TrespassZones;

  // Token: 0x04000469 RID: 1129
  public StudentManagerScript StudentManager;

  // Token: 0x0400046A RID: 1130
  public YandereScript Yandere;

  // Token: 0x0400046B RID: 1131
  public PoliceScript Police;

  // Token: 0x0400046C RID: 1132
  public ClockScript Clock;

  // Token: 0x0400046D RID: 1133
  public Bloom BloomEffect;

  // Token: 0x0400046E RID: 1134
  public MotionBlur Blur;

  // Token: 0x0400046F RID: 1135
  public Transform PromptParent;

  // Token: 0x04000470 RID: 1136
  public Transform MinuteHand;

  // Token: 0x04000471 RID: 1137
  public Transform HourHand;

  // Token: 0x04000472 RID: 1138
  public Transform Sun;

  // Token: 0x04000473 RID: 1139
  public UILabel PeriodLabel;

  // Token: 0x04000474 RID: 1140
  public UILabel TimeLabel;

  // Token: 0x04000475 RID: 1141
  public UILabel DayLabel;

  // Token: 0x04000476 RID: 1142
  public Light MainLight;

  // Token: 0x04000477 RID: 1143
  public float HalfwayTime;

  // Token: 0x04000478 RID: 1144
  public float PresentTime;

  // Token: 0x04000479 RID: 1145
  public float TargetTime;

  // Token: 0x0400047A RID: 1146
  public float StartTime;

  // Token: 0x0400047B RID: 1147
  public float HourTime;

  // Token: 0x0400047C RID: 1148
  public float AmbientLightDim;

  // Token: 0x0400047D RID: 1149
  public float DayProgress;

  // Token: 0x0400047E RID: 1150
  public float StartHour;

  // Token: 0x0400047F RID: 1151
  public float TimeSpeed;

  // Token: 0x04000480 RID: 1152
  public float Minute;

  // Token: 0x04000481 RID: 1153
  public float Timer;

  // Token: 0x04000482 RID: 1154
  public float Hour;

  // Token: 0x04000483 RID: 1155
  public int Period;

  // Token: 0x04000484 RID: 1156
  public int ID;

  // Token: 0x04000485 RID: 1157
  public string TimeText = string.Empty;

  // Token: 0x04000486 RID: 1158
  public bool StopTime;

  // Token: 0x04000487 RID: 1159
  public bool TimeSkip;

  // Token: 0x04000488 RID: 1160
  public bool FadeIn;

  // Token: 0x04000489 RID: 1161
  public AudioSource SchoolBell;

  // Token: 0x0400048A RID: 1162
  public Color SkyboxColor;
}