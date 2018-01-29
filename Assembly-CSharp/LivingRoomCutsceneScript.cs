using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000126 RID: 294
public class LivingRoomCutsceneScript : MonoBehaviour {

  // Token: 0x060005A2 RID: 1442 RVA: 0x0004D220 File Offset: 0x0004B620
  private void Start() {
    this.YandereCosmetic.SetFemaleUniform();
    this.ID = 0;
    while (this.ID < this.YandereCosmetic.FemaleHair.Length) {
      GameObject gameObject = this.YandereCosmetic.FemaleHair[this.ID];
      if (gameObject != null) {
        gameObject.SetActive(false);
      }
      this.ID++;
    }
    this.ID = 0;
    while (this.ID < this.YandereCosmetic.TeacherHair.Length) {
      GameObject gameObject2 = this.YandereCosmetic.TeacherHair[this.ID];
      if (gameObject2 != null) {
        gameObject2.SetActive(false);
      }
      this.ID++;
    }
    this.ID = 0;
    while (this.ID < this.YandereCosmetic.FemaleAccessories.Length) {
      GameObject gameObject3 = this.YandereCosmetic.FemaleAccessories[this.ID];
      if (gameObject3 != null) {
        gameObject3.SetActive(false);
      }
      this.ID++;
    }
    this.ID = 0;
    while (this.ID < this.YandereCosmetic.TeacherAccessories.Length) {
      GameObject gameObject4 = this.YandereCosmetic.TeacherAccessories[this.ID];
      if (gameObject4 != null) {
        gameObject4.SetActive(false);
      }
      this.ID++;
    }
    this.ID = 0;
    this.YandereCosmetic.FemaleHair[1].SetActive(true);
    this.Subtitle.text = string.Empty;
    this.RightEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
    this.LeftEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
    this.RightEyeOrigin = this.RightEye.localPosition;
    this.LeftEyeOrigin = this.LeftEye.localPosition;
    this.EliminationPanel.alpha = 0f;
    this.Panel.alpha = 1f;
    this.ColorCorrection.saturation = 1f;
    this.Noise.intensityMultiplier = 0f;
    this.Obscurance.intensity = 0f;
    this.Vignette.enabled = false;
    this.Vignette.intensity = 1f;
    this.Vignette.blur = 1f;
    this.Vignette.chromaticAberration = 1f;
  }

  // Token: 0x060005A3 RID: 1443 RVA: 0x0004D4C4 File Offset: 0x0004B8C4
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Phase == 1) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f && Input.GetButtonDown("A")) {
          this.Timer = 0f;
          this.Phase++;
        }
      }
    } else if (this.Phase == 2) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if (this.Darkness.color.a == 1f) {
        base.transform.parent = this.LivingRoomCamera;
        base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
        base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        this.Vignette.enabled = true;
        this.Prologue.SetActive(false);
        this.Phase++;
      }
    } else if (this.Phase == 3) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
        if (this.Panel.alpha == 0f) {
          this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 0f;
          this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 0f;
          this.LivingRoomCamera.gameObject.GetComponent<Animation>().Play();
          this.Timer = 0f;
          this.Phase++;
        }
      }
    } else if (this.Phase == 4) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 10f) {
        base.transform.parent = this.FriendshipCamera;
        base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
        base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
        component.Play();
        this.Subtitle.text = this.Lines[0];
        this.Timer = 0f;
        this.Phase++;
      }
    } else if (this.Phase == 5) {
      if (Input.GetKeyDown(KeyCode.Space)) {
        this.Timer += 10f;
        component.time += 10f;
        this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 10f;
      }
      this.Timer += Time.deltaTime;
      if (this.Timer < 166f) {
        this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = component.time + this.AnimOffset;
        this.Rival.GetComponent<Animation>()["FriendshipRival"].time = component.time + this.AnimOffset;
      }
      if (this.ID < this.Times.Length && component.time > this.Times[this.ID]) {
        this.Subtitle.text = this.Lines[this.ID];
        this.ID++;
      }
      if (component.time > 54f) {
        this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime / 5f);
        component.volume = Mathf.MoveTowards(component.volume, 0.2f, Time.deltaTime * 0.1f / 5f);
        this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime * 4f / 5f);
        this.Vignette.blur = this.Vignette.intensity;
        this.Vignette.chromaticAberration = this.Vignette.intensity;
        this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 1f, Time.deltaTime / 5f);
        this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 0f, Time.deltaTime * 3f / 5f);
        this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 0f, Time.deltaTime * 3f / 5f);
        this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0f, Time.deltaTime * 0.01f / 5f);
        this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
        this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0f, Time.deltaTime);
      } else if (component.time > 42f) {
        if (!this.Jukebox.isPlaying) {
          this.Jukebox.Play();
        }
        this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 1f, Time.deltaTime / 10f);
        component.volume = Mathf.MoveTowards(component.volume, 0.1f, Time.deltaTime * 0.1f / 10f);
        this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 4f / 10f);
        this.Vignette.blur = this.Vignette.intensity;
        this.Vignette.chromaticAberration = this.Vignette.intensity;
        this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 0f, Time.deltaTime / 10f);
        this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 3f, Time.deltaTime * 3f / 10f);
        this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 3f, Time.deltaTime * 3f / 10f);
        this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, Time.deltaTime * 0.01f / 10f);
        this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
        if (component.time > 45f) {
          if (component.time > 54f) {
            this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
          } else {
            this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 1f, Time.deltaTime);
            if (Input.GetButtonDown("X")) {
              component.clip = this.RivalProtest;
              component.volume = 1f;
              component.Play();
              this.Jukebox.gameObject.SetActive(false);
              this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
              this.SubDarknessBG.color = new Color(this.SubDarknessBG.color.r, this.SubDarknessBG.color.g, this.SubDarknessBG.color.b, 1f);
              this.Phase++;
            }
          }
        }
      }
      if (this.Timer > 167f) {
        Animation component2 = this.Yandere.GetComponent<Animation>();
        component2["FriendshipYandere"].speed = -0.2f;
        component2.Play("FriendshipYandere");
        component2["FriendshipYandere"].time = component2["FriendshipYandere"].length;
        this.Subtitle.text = string.Empty;
        this.Phase = 10;
      }
    } else if (this.Phase == 6) {
      if (!component.isPlaying) {
        component.clip = this.DramaticBoom;
        component.Play();
        this.Subtitle.text = string.Empty;
        this.Phase++;
      }
    } else if (this.Phase == 7) {
      if (!component.isPlaying) {
        StudentGlobals.SetStudentKidnapped(32, false);
        StudentGlobals.SetStudentBroken(32, true);
        StudentGlobals.SetStudentKidnapped(7, true);
        StudentGlobals.SetStudentSanity(7, 100f);
        SchoolGlobals.KidnapVictim = 7;
        HomeGlobals.StartInBasement = true;
        SceneManager.LoadScene("CalendarScene");
      }
    } else if (this.Phase == 10) {
      this.SubDarkness.color = new Color(this.SubDarkness.color.r, this.SubDarkness.color.g, this.SubDarkness.color.b, Mathf.MoveTowards(this.SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
      if (this.SubDarkness.color.a == 1f) {
        StudentGlobals.SetStudentKidnapped(32, false);
        StudentGlobals.SetStudentBroken(32, true);
        SchoolGlobals.KidnapVictim = 0;
        SceneManager.LoadScene("CalendarScene");
      }
    }
    if (Input.GetKeyDown(KeyCode.Minus)) {
      Time.timeScale -= 1f;
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      Time.timeScale += 1f;
    }
    component.pitch = Time.timeScale;
  }

  // Token: 0x060005A4 RID: 1444 RVA: 0x0004E03C File Offset: 0x0004C43C
  private void LateUpdate() {
    if (this.Phase > 2) {
      base.transform.localPosition = new Vector3(-0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
      this.CutsceneCamera.position = new Vector3(this.CutsceneCamera.position.x + this.xOffset, this.CutsceneCamera.position.y, this.CutsceneCamera.position.z + this.zOffset);
      this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
      this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
      this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
      this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
    }
  }

  // Token: 0x04000D67 RID: 3431
  public ColorCorrectionCurves ColorCorrection;

  // Token: 0x04000D68 RID: 3432
  public CosmeticScript YandereCosmetic;

  // Token: 0x04000D69 RID: 3433
  public AmbientObscurance Obscurance;

  // Token: 0x04000D6A RID: 3434
  public Vignetting Vignette;

  // Token: 0x04000D6B RID: 3435
  public NoiseAndGrain Noise;

  // Token: 0x04000D6C RID: 3436
  public SkinnedMeshRenderer YandereRenderer;

  // Token: 0x04000D6D RID: 3437
  public Renderer RightEyeRenderer;

  // Token: 0x04000D6E RID: 3438
  public Renderer LeftEyeRenderer;

  // Token: 0x04000D6F RID: 3439
  public Transform FriendshipCamera;

  // Token: 0x04000D70 RID: 3440
  public Transform LivingRoomCamera;

  // Token: 0x04000D71 RID: 3441
  public Transform CutsceneCamera;

  // Token: 0x04000D72 RID: 3442
  public UIPanel EliminationPanel;

  // Token: 0x04000D73 RID: 3443
  public UISprite SubDarknessBG;

  // Token: 0x04000D74 RID: 3444
  public UISprite SubDarkness;

  // Token: 0x04000D75 RID: 3445
  public UISprite Darkness;

  // Token: 0x04000D76 RID: 3446
  public UILabel Subtitle;

  // Token: 0x04000D77 RID: 3447
  public UIPanel Panel;

  // Token: 0x04000D78 RID: 3448
  public Vector3 RightEyeOrigin;

  // Token: 0x04000D79 RID: 3449
  public Vector3 LeftEyeOrigin;

  // Token: 0x04000D7A RID: 3450
  public AudioClip DramaticBoom;

  // Token: 0x04000D7B RID: 3451
  public AudioClip RivalProtest;

  // Token: 0x04000D7C RID: 3452
  public AudioSource Jukebox;

  // Token: 0x04000D7D RID: 3453
  public GameObject Prologue;

  // Token: 0x04000D7E RID: 3454
  public GameObject Yandere;

  // Token: 0x04000D7F RID: 3455
  public GameObject Rival;

  // Token: 0x04000D80 RID: 3456
  public Transform RightEye;

  // Token: 0x04000D81 RID: 3457
  public Transform LeftEye;

  // Token: 0x04000D82 RID: 3458
  public float ShakeStrength;

  // Token: 0x04000D83 RID: 3459
  public float AnimOffset;

  // Token: 0x04000D84 RID: 3460
  public float EyeShrink;

  // Token: 0x04000D85 RID: 3461
  public float xOffset;

  // Token: 0x04000D86 RID: 3462
  public float zOffset;

  // Token: 0x04000D87 RID: 3463
  public float Timer;

  // Token: 0x04000D88 RID: 3464
  public string[] Lines;

  // Token: 0x04000D89 RID: 3465
  public float[] Times;

  // Token: 0x04000D8A RID: 3466
  public int Phase = 1;

  // Token: 0x04000D8B RID: 3467
  public int ID = 1;

  // Token: 0x04000D8C RID: 3468
  public Texture ZTR;

  // Token: 0x04000D8D RID: 3469
  public int ZTRID;
}