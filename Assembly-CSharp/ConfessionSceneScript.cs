using UnityEngine;

// Token: 0x02000070 RID: 112
public class ConfessionSceneScript : MonoBehaviour {

  // Token: 0x0600019D RID: 413 RVA: 0x0001C934 File Offset: 0x0001AD34
  private void Update() {
    if (this.Phase == 1) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
      this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
      if (this.Darkness.color.a == 1f) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 1f) {
          this.BloomEffect.bloomIntensity = 1f;
          this.BloomEffect.bloomThreshhold = 0f;
          this.BloomEffect.bloomBlurIterations = 1;
          this.Suitor = this.StudentManager.Students[13];
          this.Rival = this.StudentManager.Students[7];
          this.Rival.transform.position = this.RivalSpot.position;
          this.Rival.transform.eulerAngles = this.RivalSpot.eulerAngles;
          this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
          this.Suitor.transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
          this.Suitor.transform.position = this.StudentManager.SuitorConfessionSpot.position;
          this.Suitor.Character.GetComponent<Animation>().Play(this.Suitor.IdleAnim);
          var emission = this.MythBlossoms.emission;
          emission.rateOverTime = 100f;
          this.HeartBeatCamera.SetActive(false);
          this.ConfessionBG.SetActive(true);
          base.GetComponent<AudioSource>().Play();
          this.MainCamera.position = this.CameraDestinations[1].position;
          this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
          this.Timer = 0f;
          this.Phase++;
        }
      }
    } else if (this.Phase == 2) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      if (this.Darkness.color.a == 0f) {
        if (!this.ShowLabel) {
          this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 0f, Time.deltaTime));
          if (this.Label.color.a == 0f) {
            if (this.TextPhase < 5) {
              this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
              this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
              if (this.TextPhase == 4 && !this.Kissing) {
                ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
                emission.enabled = true;
                emission.rateOverTime = 10f;
                this.Suitor.Hearts.Play();
                ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
                emission2.enabled = true;
                emission2.rateOverTime = 10f;
                this.Rival.Hearts.Play();
                this.Suitor.Character.transform.localScale = new Vector3(1f, 1f, 1f);
                this.Suitor.Character.GetComponent<Animation>().Play("kiss_00");
                this.Suitor.transform.position = this.KissSpot.position;
                this.Rival.Character.GetComponent<Animation>()[this.Rival.ShyAnim].weight = 0f;
                this.Rival.Character.GetComponent<Animation>().Play("f02_kiss_00");
                this.Kissing = true;
              }
              this.Label.text = this.Text[this.TextPhase];
              this.ShowLabel = true;
            } else {
              this.Phase++;
            }
          }
        } else {
          this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 1f, Time.deltaTime));
          if (this.Label.color.a == 1f) {
            if (!this.PromptBar.Show) {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Continue";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
            if (Input.GetButtonDown("A")) {
              this.TextPhase++;
              this.ShowLabel = false;
            }
          }
        }
      }
    } else if (this.Phase == 3) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if (this.Darkness.color.a == 1f) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 1f) {
          DatingGlobals.SuitorProgress = 2;
          this.Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.ConfessionBG.SetActive(false);
          this.Yandere.FixCamera();
          this.Phase++;
        }
      }
    } else {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
      if (this.Darkness.color.a == 0f) {
        this.Yandere.RPGCamera.enabled = true;
        this.Yandere.CanMove = true;
        this.HeartBeatCamera.SetActive(true);
        var emission = MythBlossoms.emission;
        emission.rateOverTime = 20f;
        this.Clock.StopTime = false;
        base.enabled = false;
        this.Suitor.CoupleID = 7;
        this.Rival.CoupleID = 13;
      }
    }
    if (this.Kissing) {
      Animation component = this.Suitor.Character.GetComponent<Animation>();
      if (component["kiss_00"].time >= component["kiss_00"].length) {
        component.CrossFade(this.Suitor.IdleAnim);
        this.Rival.Character.GetComponent<Animation>().CrossFade(this.Rival.IdleAnim);
        this.Kissing = false;
      }
    }
  }

  // Token: 0x0400051C RID: 1308
  public Transform[] CameraDestinations;

  // Token: 0x0400051D RID: 1309
  public StudentManagerScript StudentManager;

  // Token: 0x0400051E RID: 1310
  public PromptBarScript PromptBar;

  // Token: 0x0400051F RID: 1311
  public JukeboxScript Jukebox;

  // Token: 0x04000520 RID: 1312
  public YandereScript Yandere;

  // Token: 0x04000521 RID: 1313
  public ClockScript Clock;

  // Token: 0x04000522 RID: 1314
  public Bloom BloomEffect;

  // Token: 0x04000523 RID: 1315
  public StudentScript Suitor;

  // Token: 0x04000524 RID: 1316
  public StudentScript Rival;

  // Token: 0x04000525 RID: 1317
  public ParticleSystem MythBlossoms;

  // Token: 0x04000526 RID: 1318
  public GameObject HeartBeatCamera;

  // Token: 0x04000527 RID: 1319
  public GameObject ConfessionBG;

  // Token: 0x04000528 RID: 1320
  public Transform MainCamera;

  // Token: 0x04000529 RID: 1321
  public Transform RivalSpot;

  // Token: 0x0400052A RID: 1322
  public Transform KissSpot;

  // Token: 0x0400052B RID: 1323
  public string[] Text;

  // Token: 0x0400052C RID: 1324
  public UISprite Darkness;

  // Token: 0x0400052D RID: 1325
  public UILabel Label;

  // Token: 0x0400052E RID: 1326
  public UIPanel Panel;

  // Token: 0x0400052F RID: 1327
  public bool ShowLabel;

  // Token: 0x04000530 RID: 1328
  public bool Kissing;

  // Token: 0x04000531 RID: 1329
  public int TextPhase = 1;

  // Token: 0x04000532 RID: 1330
  public int Phase = 1;

  // Token: 0x04000533 RID: 1331
  public float Timer;
}