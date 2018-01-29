using UnityEngine;

// Token: 0x0200011C RID: 284
public class JukeboxScript : MonoBehaviour {

  // Token: 0x0600057F RID: 1407 RVA: 0x0004B424 File Offset: 0x00049824
  private void Start() {
    if (UnityEngine.Random.Range(0, 2) > 0) {
      this.FullSanities = this.AlternateFull;
      this.HalfSanities = this.AlternateHalf;
      this.NoSanities = this.AlternateNo;
    }
    if (!SchoolGlobals.SchoolAtmosphereSet) {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 1f;
    }
    int num;
    if (SchoolAtmosphere.Type == SchoolAtmosphereType.High) {
      num = 3;
    } else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium) {
      num = 2;
    } else {
      num = 1;
    }
    this.FullSanity.clip = this.FullSanities[num];
    this.HalfSanity.clip = this.HalfSanities[num];
    this.NoSanity.clip = this.NoSanities[num];
    this.FullSanity.Play();
    this.HalfSanity.Play();
    this.NoSanity.Play();
    this.Volume = 0.25f;
    this.Hitman.time = 26f;
  }

  // Token: 0x06000580 RID: 1408 RVA: 0x0004B518 File Offset: 0x00049918
  private void Update() {
    this.Timer += Time.deltaTime;
    if (!this.Yandere.PauseScreen.Show && !this.Yandere.EasterEggMenu.activeInHierarchy) {
      if (Input.GetKeyDown(KeyCode.M)) {
        if (this.Custom.isPlaying) {
          this.Egg = false;
          this.Custom.Stop();
        }
        if (this.Volume == 0f) {
          this.FadeSpeed = 1f;
          this.Volume = this.LastVolume;
        } else {
          this.LastVolume = this.Volume;
          this.FadeSpeed = 10f;
          this.Volume = 0f;
        }
      }
      if (Input.GetKeyDown(KeyCode.N) && this.Volume < 1f) {
        this.Volume += 0.1f;
      }
      if (Input.GetKeyDown(KeyCode.B) && this.Volume > 0f) {
        this.Volume -= 0.1f;
      }
    }
    if (!this.Egg) {
      if (this.Timer > 5f) {
        if (this.Yandere.Sanity >= 66.6666641f) {
          this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
          this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
          this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
        } else if (this.Yandere.Sanity >= 33.3333321f) {
          this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
          this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
          this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
        } else {
          this.FullSanity.volume = Mathf.MoveTowards(this.FullSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
          this.HalfSanity.volume = Mathf.MoveTowards(this.HalfSanity.volume, 0f, Time.deltaTime * this.FadeSpeed);
          this.NoSanity.volume = Mathf.MoveTowards(this.NoSanity.volume, this.Volume * this.Dip - this.ClubDip, Time.deltaTime * this.FadeSpeed);
        }
      }
    } else {
      this.AttackOnTitan.volume = Mathf.MoveTowards(this.AttackOnTitan.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Megalovania.volume = Mathf.MoveTowards(this.Megalovania.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.MissionMode.volume = Mathf.MoveTowards(this.MissionMode.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Skeletons.volume = Mathf.MoveTowards(this.Skeletons.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Metroid.volume = Mathf.MoveTowards(this.Metroid.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Nuclear.volume = Mathf.MoveTowards(this.Nuclear.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Slender.volume = Mathf.MoveTowards(this.Slender.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Sukeban.volume = Mathf.MoveTowards(this.Sukeban.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Custom.volume = Mathf.MoveTowards(this.Custom.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Hatred.volume = Mathf.MoveTowards(this.Hatred.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Hitman.volume = Mathf.MoveTowards(this.Hitman.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Touhou.volume = Mathf.MoveTowards(this.Touhou.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Falcon.volume = Mathf.MoveTowards(this.Falcon.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Demon.volume = Mathf.MoveTowards(this.Demon.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Ebola.volume = Mathf.MoveTowards(this.Ebola.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Ninja.volume = Mathf.MoveTowards(this.Ninja.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Punch.volume = Mathf.MoveTowards(this.Punch.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Galo.volume = Mathf.MoveTowards(this.Galo.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.Jojo.volume = Mathf.MoveTowards(this.Jojo.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
      this.DK.volume = Mathf.MoveTowards(this.DK.volume, this.Volume * this.Dip, Time.deltaTime * 10f);
    }
    if (!this.Yandere.PauseScreen.Show && !this.Yandere.Noticed && this.Yandere.CanMove && this.Yandere.EasterEggMenu.activeInHierarchy && !this.Egg) {
      if (Input.GetKeyDown(KeyCode.T)) {
        this.Egg = true;
        this.KillVolume();
        this.AttackOnTitan.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.P)) {
        this.Egg = true;
        this.KillVolume();
        this.Nuclear.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.H)) {
        this.Egg = true;
        this.KillVolume();
        this.Hatred.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.B)) {
        this.Egg = true;
        this.KillVolume();
        this.Sukeban.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)) {
        this.Egg = true;
        this.KillVolume();
        this.Slender.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.G)) {
        this.Egg = true;
        this.KillVolume();
        this.Galo.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.L)) {
        this.Egg = true;
        this.KillVolume();
        this.Hitman.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.S)) {
        this.Egg = true;
        this.KillVolume();
        this.Skeletons.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.K)) {
        this.Egg = true;
        this.KillVolume();
        this.DK.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.C)) {
        this.Egg = true;
        this.KillVolume();
        this.Touhou.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.F)) {
        this.Egg = true;
        this.KillVolume();
        this.Falcon.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.O)) {
        this.Egg = true;
        this.KillVolume();
        this.Punch.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.U)) {
        this.Egg = true;
        this.KillVolume();
        this.Megalovania.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.Q)) {
        this.Egg = true;
        this.KillVolume();
        this.Metroid.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.Y)) {
        this.Egg = true;
        this.KillVolume();
        this.Ninja.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha7)) {
        this.Egg = true;
        this.KillVolume();
        this.Ebola.enabled = true;
      } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
        this.Egg = true;
        this.KillVolume();
        this.Demon.enabled = true;
      }
    }
  }

  // Token: 0x06000581 RID: 1409 RVA: 0x0004BF98 File Offset: 0x0004A398
  public void KillVolume() {
    this.FullSanity.volume = 0f;
    this.HalfSanity.volume = 0f;
    this.NoSanity.volume = 0f;
    this.Volume = 0.5f;
  }

  // Token: 0x06000582 RID: 1410 RVA: 0x0004BFD8 File Offset: 0x0004A3D8
  public void GameOver() {
    this.AttackOnTitan.Stop();
    this.Megalovania.Stop();
    this.MissionMode.Stop();
    this.Skeletons.Stop();
    this.Metroid.Stop();
    this.Nuclear.Stop();
    this.Sukeban.Stop();
    this.Custom.Stop();
    this.Slender.Stop();
    this.Hatred.Stop();
    this.Hitman.Stop();
    this.Touhou.Stop();
    this.Falcon.Stop();
    this.Ebola.Stop();
    this.Punch.Stop();
    this.Ninja.Stop();
    this.Galo.Stop();
    this.DK.Stop();
    this.FullSanity.Stop();
    this.HalfSanity.Stop();
    this.NoSanity.Stop();
  }

  // Token: 0x06000583 RID: 1411 RVA: 0x0004C0CC File Offset: 0x0004A4CC
  public void PlayJojo() {
    this.Egg = true;
    this.KillVolume();
    this.Jojo.enabled = true;
  }

  // Token: 0x06000584 RID: 1412 RVA: 0x0004C0E7 File Offset: 0x0004A4E7
  public void PlayCustom() {
    this.Egg = true;
    this.KillVolume();
    this.Custom.enabled = true;
    this.Custom.Play();
  }

  // Token: 0x04000CFF RID: 3327
  public YandereScript Yandere;

  // Token: 0x04000D00 RID: 3328
  public AudioSource SFX;

  // Token: 0x04000D01 RID: 3329
  public AudioSource AttackOnTitan;

  // Token: 0x04000D02 RID: 3330
  public AudioSource Megalovania;

  // Token: 0x04000D03 RID: 3331
  public AudioSource MissionMode;

  // Token: 0x04000D04 RID: 3332
  public AudioSource Skeletons;

  // Token: 0x04000D05 RID: 3333
  public AudioSource Metroid;

  // Token: 0x04000D06 RID: 3334
  public AudioSource Nuclear;

  // Token: 0x04000D07 RID: 3335
  public AudioSource Slender;

  // Token: 0x04000D08 RID: 3336
  public AudioSource Sukeban;

  // Token: 0x04000D09 RID: 3337
  public AudioSource Custom;

  // Token: 0x04000D0A RID: 3338
  public AudioSource Hatred;

  // Token: 0x04000D0B RID: 3339
  public AudioSource Hitman;

  // Token: 0x04000D0C RID: 3340
  public AudioSource Touhou;

  // Token: 0x04000D0D RID: 3341
  public AudioSource Falcon;

  // Token: 0x04000D0E RID: 3342
  public AudioSource Ebola;

  // Token: 0x04000D0F RID: 3343
  public AudioSource Demon;

  // Token: 0x04000D10 RID: 3344
  public AudioSource Ninja;

  // Token: 0x04000D11 RID: 3345
  public AudioSource Punch;

  // Token: 0x04000D12 RID: 3346
  public AudioSource Galo;

  // Token: 0x04000D13 RID: 3347
  public AudioSource Jojo;

  // Token: 0x04000D14 RID: 3348
  public AudioSource DK;

  // Token: 0x04000D15 RID: 3349
  public AudioSource FullSanity;

  // Token: 0x04000D16 RID: 3350
  public AudioSource HalfSanity;

  // Token: 0x04000D17 RID: 3351
  public AudioSource NoSanity;

  // Token: 0x04000D18 RID: 3352
  public AudioSource Chase;

  // Token: 0x04000D19 RID: 3353
  public float LastVolume;

  // Token: 0x04000D1A RID: 3354
  public float FadeSpeed;

  // Token: 0x04000D1B RID: 3355
  public float ClubDip;

  // Token: 0x04000D1C RID: 3356
  public float Volume;

  // Token: 0x04000D1D RID: 3357
  public int Track;

  // Token: 0x04000D1E RID: 3358
  public float Timer;

  // Token: 0x04000D1F RID: 3359
  public float Dip = 1f;

  // Token: 0x04000D20 RID: 3360
  public bool Egg;

  // Token: 0x04000D21 RID: 3361
  public AudioClip[] FullSanities;

  // Token: 0x04000D22 RID: 3362
  public AudioClip[] HalfSanities;

  // Token: 0x04000D23 RID: 3363
  public AudioClip[] NoSanities;

  // Token: 0x04000D24 RID: 3364
  public AudioClip[] AlternateFull;

  // Token: 0x04000D25 RID: 3365
  public AudioClip[] AlternateHalf;

  // Token: 0x04000D26 RID: 3366
  public AudioClip[] AlternateNo;
}