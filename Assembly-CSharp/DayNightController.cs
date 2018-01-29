using UnityEngine;

// Token: 0x0200007E RID: 126
public class DayNightController : MonoBehaviour {

  // Token: 0x060001F8 RID: 504 RVA: 0x000283A0 File Offset: 0x000267A0
  private void Initialize() {
    this.quarterDay = this.dayCycleLength * 0.25f;
    this.dawnTime = 0f;
    this.dayTime = this.dawnTime + this.quarterDay;
    this.duskTime = this.dayTime + this.quarterDay;
    this.nightTime = this.duskTime + this.quarterDay;
    Light component = base.GetComponent<Light>();
    if (component != null) {
      this.lightIntensity = component.intensity;
    }
  }

  // Token: 0x060001F9 RID: 505 RVA: 0x00028424 File Offset: 0x00026824
  private void Reset() {
    this.dayCycleLength = 120f;
    this.hoursPerDay = 24f;
    this.dawnTimeOffset = 3f;
    this.fullDark = new Color(0.1254902f, 0.109803922f, 0.180392161f);
    this.fullLight = new Color(0.992156863f, 0.972549f, 0.8745098f);
    this.dawnDuskFog = new Color(0.521568656f, 0.4862745f, 0.4f);
    this.dayFog = new Color(0.7058824f, 0.8156863f, 0.819607854f);
    this.nightFog = new Color(0.0470588244f, 0.05882353f, 0.356862754f);
    Skybox[] array = Resources.FindObjectsOfTypeAll<Skybox>();
    foreach (Skybox skybox in array) {
      if (skybox.name == "DawnDusk Skybox") {
        this.dawnDuskSkybox = skybox.material;
      } else if (skybox.name == "StarryNight Skybox") {
        this.nightSkybox = skybox.material;
      } else if (skybox.name == "Sunny2 Skybox") {
        this.daySkybox = skybox.material;
      }
    }
  }

  // Token: 0x060001FA RID: 506 RVA: 0x00028561 File Offset: 0x00026961
  private void Start() {
    this.Initialize();
  }

  // Token: 0x060001FB RID: 507 RVA: 0x0002856C File Offset: 0x0002696C
  private void Update() {
    if (this.currentCycleTime > this.nightTime && this.currentPhase == DayNightController.DayPhase.Dusk) {
      this.SetNight();
    } else if (this.currentCycleTime > this.duskTime && this.currentPhase == DayNightController.DayPhase.Day) {
      this.SetDusk();
    } else if (this.currentCycleTime > this.dayTime && this.currentPhase == DayNightController.DayPhase.Dawn) {
      this.SetDay();
    } else if (this.currentCycleTime > this.dawnTime && this.currentCycleTime < this.dayTime && this.currentPhase == DayNightController.DayPhase.Night) {
      this.SetDawn();
    }
    this.UpdateWorldTime();
    this.UpdateDaylight();
    this.UpdateFog();
    this.currentCycleTime += Time.deltaTime;
    this.currentCycleTime %= this.dayCycleLength;
  }

  // Token: 0x060001FC RID: 508 RVA: 0x0002865C File Offset: 0x00026A5C
  public void SetDawn() {
    RenderSettings.skybox = this.dawnDuskSkybox;
    Light component = base.GetComponent<Light>();
    if (component != null) {
      component.enabled = true;
    }
    this.currentPhase = DayNightController.DayPhase.Dawn;
  }

  // Token: 0x060001FD RID: 509 RVA: 0x00028698 File Offset: 0x00026A98
  public void SetDay() {
    RenderSettings.skybox = this.daySkybox;
    RenderSettings.ambientLight = this.fullLight;
    Light component = base.GetComponent<Light>();
    if (component != null) {
      component.intensity = this.lightIntensity;
    }
    this.currentPhase = DayNightController.DayPhase.Day;
  }

  // Token: 0x060001FE RID: 510 RVA: 0x000286E1 File Offset: 0x00026AE1
  public void SetDusk() {
    RenderSettings.skybox = this.dawnDuskSkybox;
    this.currentPhase = DayNightController.DayPhase.Dusk;
  }

  // Token: 0x060001FF RID: 511 RVA: 0x000286F8 File Offset: 0x00026AF8
  public void SetNight() {
    RenderSettings.skybox = this.nightSkybox;
    RenderSettings.ambientLight = this.fullDark;
    Light component = base.GetComponent<Light>();
    if (component != null) {
      component.enabled = false;
    }
    this.currentPhase = DayNightController.DayPhase.Night;
  }

  // Token: 0x06000200 RID: 512 RVA: 0x0002873C File Offset: 0x00026B3C
  private void UpdateDaylight() {
    if (this.currentPhase == DayNightController.DayPhase.Dawn) {
      float num = this.currentCycleTime - this.dawnTime;
      RenderSettings.ambientLight = Color.Lerp(this.fullDark, this.fullLight, num / this.quarterDay);
      Light component = base.GetComponent<Light>();
      if (component != null) {
        component.intensity = this.lightIntensity * (num / this.quarterDay);
      }
    } else if (this.currentPhase == DayNightController.DayPhase.Dusk) {
      float num2 = this.currentCycleTime - this.duskTime;
      RenderSettings.ambientLight = Color.Lerp(this.fullLight, this.fullDark, num2 / this.quarterDay);
      Light component2 = base.GetComponent<Light>();
      if (component2 != null) {
        component2.intensity = this.lightIntensity * ((this.quarterDay - num2) / this.quarterDay);
      }
    }
    base.transform.Rotate(Vector3.up * (Time.deltaTime / this.dayCycleLength * 360f), Space.Self);
  }

  // Token: 0x06000201 RID: 513 RVA: 0x00028840 File Offset: 0x00026C40
  private void UpdateFog() {
    if (this.currentPhase == DayNightController.DayPhase.Dawn) {
      float num = this.currentCycleTime - this.dawnTime;
      RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.dayFog, num / this.quarterDay);
    } else if (this.currentPhase == DayNightController.DayPhase.Day) {
      float num2 = this.currentCycleTime - this.dayTime;
      RenderSettings.fogColor = Color.Lerp(this.dayFog, this.dawnDuskFog, num2 / this.quarterDay);
    } else if (this.currentPhase == DayNightController.DayPhase.Dusk) {
      float num3 = this.currentCycleTime - this.duskTime;
      RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.nightFog, num3 / this.quarterDay);
    } else if (this.currentPhase == DayNightController.DayPhase.Night) {
      float num4 = this.currentCycleTime - this.nightTime;
      RenderSettings.fogColor = Color.Lerp(this.nightFog, this.dawnDuskFog, num4 / this.quarterDay);
    }
  }

  // Token: 0x06000202 RID: 514 RVA: 0x0002893B File Offset: 0x00026D3B
  private void UpdateWorldTime() {
    this.worldTimeHour = (int)((Mathf.Ceil(this.currentCycleTime / this.dayCycleLength * this.hoursPerDay) + this.dawnTimeOffset) % this.hoursPerDay) + 1;
  }

  // Token: 0x040006B7 RID: 1719
  public float dayCycleLength;

  // Token: 0x040006B8 RID: 1720
  public float currentCycleTime;

  // Token: 0x040006B9 RID: 1721
  public DayNightController.DayPhase currentPhase;

  // Token: 0x040006BA RID: 1722
  public float hoursPerDay;

  // Token: 0x040006BB RID: 1723
  public float dawnTimeOffset;

  // Token: 0x040006BC RID: 1724
  public int worldTimeHour;

  // Token: 0x040006BD RID: 1725
  public Color fullLight;

  // Token: 0x040006BE RID: 1726
  public Color fullDark;

  // Token: 0x040006BF RID: 1727
  public Material dawnDuskSkybox;

  // Token: 0x040006C0 RID: 1728
  public Color dawnDuskFog;

  // Token: 0x040006C1 RID: 1729
  public Material daySkybox;

  // Token: 0x040006C2 RID: 1730
  public Color dayFog;

  // Token: 0x040006C3 RID: 1731
  public Material nightSkybox;

  // Token: 0x040006C4 RID: 1732
  public Color nightFog;

  // Token: 0x040006C5 RID: 1733
  private float dawnTime;

  // Token: 0x040006C6 RID: 1734
  private float dayTime;

  // Token: 0x040006C7 RID: 1735
  private float duskTime;

  // Token: 0x040006C8 RID: 1736
  private float nightTime;

  // Token: 0x040006C9 RID: 1737
  private float quarterDay;

  // Token: 0x040006CA RID: 1738
  private float lightIntensity;

  // Token: 0x0200007F RID: 127
  public enum DayPhase {

    // Token: 0x040006CC RID: 1740
    Night,

    // Token: 0x040006CD RID: 1741
    Dawn,

    // Token: 0x040006CE RID: 1742
    Day,

    // Token: 0x040006CF RID: 1743
    Dusk
  }
}