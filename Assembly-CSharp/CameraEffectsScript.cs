using UnityEngine;

// Token: 0x02000059 RID: 89
public class CameraEffectsScript : MonoBehaviour {

  // Token: 0x06000141 RID: 321 RVA: 0x00015560 File Offset: 0x00013960
  private void Start() {
    this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 0f);
    this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 0f);
  }

  // Token: 0x06000142 RID: 322 RVA: 0x0001560C File Offset: 0x00013A0C
  private void Update() {
    if (this.Streaks.color.a > 0f) {
      this.AlarmBloom.bloomIntensity -= Time.deltaTime;
      this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, this.Streaks.color.a - Time.deltaTime);
      if (this.Streaks.color.a <= 0f) {
        this.AlarmBloom.enabled = false;
      }
    }
    if (this.MurderStreaks.color.a > 0f) {
      this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, this.MurderStreaks.color.a - Time.deltaTime);
    }
    this.EffectStrength = 1f - this.Yandere.Sanity * 0.01f;
    this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.EffectStrength * 5f, Time.deltaTime);
    this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.EffectStrength, Time.deltaTime);
    this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.EffectStrength * 5f, Time.deltaTime);
  }

  // Token: 0x06000143 RID: 323 RVA: 0x000157FC File Offset: 0x00013BFC
  public void Alarm() {
    this.AlarmBloom.bloomIntensity = 1f;
    this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
    this.AlarmBloom.enabled = true;
    this.Yandere.Jukebox.SFX.PlayOneShot(this.Noticed);
  }

  // Token: 0x06000144 RID: 324 RVA: 0x00015890 File Offset: 0x00013C90
  public void MurderWitnessed() {
    this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
    this.Yandere.Jukebox.SFX.PlayOneShot((!this.Yandere.Noticed) ? this.MurderNoticed : this.SenpaiNoticed);
  }

  // Token: 0x06000145 RID: 325 RVA: 0x00015921 File Offset: 0x00013D21
  public void DisableCamera() {
    if (!this.OneCamera) {
      this.OneCamera = true;
    } else {
      this.OneCamera = false;
    }
  }

  // Token: 0x040003FB RID: 1019
  public YandereScript Yandere;

  // Token: 0x040003FC RID: 1020
  public Vignetting Vignette;

  // Token: 0x040003FD RID: 1021
  public UITexture MurderStreaks;

  // Token: 0x040003FE RID: 1022
  public UITexture Streaks;

  // Token: 0x040003FF RID: 1023
  public Bloom AlarmBloom;

  // Token: 0x04000400 RID: 1024
  public float EffectStrength;

  // Token: 0x04000401 RID: 1025
  public Bloom QualityBloom;

  // Token: 0x04000402 RID: 1026
  public Vignetting QualityVignetting;

  // Token: 0x04000403 RID: 1027
  public AntialiasingAsPostEffect QualityAntialiasingAsPostEffect;

  // Token: 0x04000404 RID: 1028
  public bool OneCamera;

  // Token: 0x04000405 RID: 1029
  public AudioClip MurderNoticed;

  // Token: 0x04000406 RID: 1030
  public AudioClip SenpaiNoticed;

  // Token: 0x04000407 RID: 1031
  public AudioClip Noticed;
}