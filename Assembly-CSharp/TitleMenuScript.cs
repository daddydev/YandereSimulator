using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001DD RID: 477
public class TitleMenuScript : MonoBehaviour {

  // Token: 0x06000895 RID: 2197 RVA: 0x0009ABF4 File Offset: 0x00098FF4
  private void Awake() {
    Animation component = this.Yandere.GetComponent<Animation>();
    component["f02_yanderePose_00"].layer = 1;
    component.Blend("f02_yanderePose_00");
    component["f02_fist_00"].layer = 2;
    component.Blend("f02_fist_00");
  }

  // Token: 0x06000896 RID: 2198 RVA: 0x0009AC48 File Offset: 0x00099048
  private void Start() {
    if (GameGlobals.LoveSick) {
      this.LoveSick = true;
    }
    this.PromptBar.Label[0].text = "Confirm";
    this.PromptBar.Label[1].text = string.Empty;
    this.PromptBar.UpdateButtons();
    this.MediumColor = this.MediumSprites[0].color;
    this.LightColor = this.LightSprites[0].color;
    this.DarkColor = this.DarkSprites[0].color;
    if (!this.LoveSick) {
      base.transform.position = new Vector3(base.transform.position.x, 1.2f, base.transform.position.z);
      this.LoveSickLogo.SetActive(false);
      this.LoveSickMusic.volume = 0f;
      this.Grayscale.enabled = false;
      this.SSAO.enabled = false;
      this.Sun.SetActive(true);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
      this.TurnCute();
      RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
      RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    } else {
      base.transform.position = new Vector3(base.transform.position.x, 101.2f, base.transform.position.z);
      this.Sun.SetActive(false);
      this.SSAO.enabled = true;
      this.FadeSpeed = 0.2f;
      this.Darkness.color = new Color(0f, 0f, 0f, 1f);
      this.TurnLoveSick();
    }
    Time.timeScale = 1f;
    if (this.JSON.Students[33].Name != "Reserved") {
      if (Application.CanStreamedLevelBeLoaded("FunScene")) {
        SceneManager.LoadScene("FunScene");
      } else if (Application.CanStreamedLevelBeLoaded("MoreFunScene")) {
        SceneManager.LoadScene("MoreFunScene");
      } else {
        Application.Quit();
      }
    }
  }

  // Token: 0x06000897 RID: 2199 RVA: 0x0009AEF0 File Offset: 0x000992F0
  private void Update() {
    if (this.LoveSick) {
      this.Timer += Time.deltaTime * 0.001f;
      if (base.transform.position.z > -18f) {
        this.LateTimer = Mathf.Lerp(this.LateTimer, this.Timer, Time.deltaTime);
        this.RotationY = Mathf.Lerp(this.RotationY, -22.5f, Time.deltaTime * this.LateTimer);
      }
      this.RotationZ = Mathf.Lerp(this.RotationZ, 22.5f, Time.deltaTime * this.Timer);
      base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.33333f, 101.45f, -16.5f), Time.deltaTime * this.Timer);
      base.transform.eulerAngles = new Vector3(0f, this.RotationY, this.RotationZ);
      if (!this.Turning) {
        if (base.transform.position.z > -17f) {
          this.LoveSickYandere.CrossFade("f02_edgyTurn_00");
          this.VictimHead.parent = this.RightHand;
          this.Turning = true;
        }
      } else if (this.LoveSickYandere["f02_edgyTurn_00"].time >= this.LoveSickYandere["f02_edgyTurn_00"].length) {
        this.LoveSickYandere.CrossFade("f02_edgyOverShoulder_00");
      }
    }
    if (!this.Sponsors.Show && !this.SaveFiles.Show) {
      this.InputTimer += Time.deltaTime;
      if (this.InputTimer > 1f) {
        if (this.InputManager.TappedDown) {
          this.Selected = ((this.Selected >= this.SelectionCount - 1) ? 0 : (this.Selected + 1));
        }
        if (this.InputManager.TappedUp) {
          this.Selected = ((this.Selected <= 0) ? (this.SelectionCount - 1) : (this.Selected - 1));
        }
        bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown;
        if (flag) {
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 225f - 75f * (float)this.Selected, this.Highlight.localPosition.z);
        }
        if (Input.GetButtonDown("A")) {
          if (this.Selected == 0 || this.Selected == 3 || this.Selected == 6 || this.Selected == 8) {
            this.Darkness.color = new Color(0f, 0f, 0f, this.Darkness.color.a);
            this.InputTimer = -10f;
            this.FadeOut = true;
            this.Fading = true;
          }
          if (this.Selected == 2) {
            if (!this.LoveSick) {
              this.Darkness.color = new Color(1f, 1f, 1f, this.Darkness.color.a);
            }
            this.InputTimer = -10f;
            this.FadeOut = true;
            this.Fading = true;
          }
          if (this.Selected == 4) {
            this.PromptBar.Label[0].text = "Visit";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.UpdateButtons();
            this.Sponsors.Show = true;
          }
          if (!this.LoveSick) {
            this.TurnCute();
          }
        }
        if (Input.GetKeyDown("l")) {
          GameGlobals.LoveSick = !GameGlobals.LoveSick;
          SceneManager.LoadScene("TitleScene");
        }
        if (!this.LoveSick) {
          if (Input.GetKeyDown(KeyCode.Space)) {
            this.Timer = 10f;
          }
          this.Timer += Time.deltaTime;
          if (this.Timer > 10f) {
            this.TurnDark();
          }
          if (this.Timer > 11f) {
            this.TurnCute();
          }
        }
      }
    } else {
      if (this.Sponsors.Show) {
        int sponsorIndex = this.Sponsors.GetSponsorIndex();
        if (this.Sponsors.SponsorHasWebsite(sponsorIndex)) {
          this.PromptBar.Label[0].text = "Visit";
          this.PromptBar.UpdateButtons();
        } else {
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.UpdateButtons();
        }
      } else if (this.SaveFiles.Show) {
        if (this.SaveFiles.SaveDatas[this.SaveFiles.ID].EmptyFile.activeInHierarchy) {
          this.PromptBar.Label[0].text = "Create New";
          this.PromptBar.Label[2].text = string.Empty;
          this.PromptBar.UpdateButtons();
        } else {
          this.PromptBar.Label[0].text = "Load";
          this.PromptBar.Label[2].text = "Delete";
          this.PromptBar.UpdateButtons();
        }
      }
      if (Input.GetButtonDown("B")) {
        this.SaveFiles.Show = false;
        this.Sponsors.Show = false;
        this.PromptBar.Label[0].text = "Confirm";
        this.PromptBar.Label[1].text = string.Empty;
        this.PromptBar.Label[2].text = string.Empty;
        this.PromptBar.UpdateButtons();
      }
    }
    if (this.Fading) {
      if (!this.FadeOut) {
        if (this.Darkness.color.a > 0f) {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime * this.FadeSpeed);
          if (this.Darkness.color.a <= 0f) {
            this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
            this.Fading = false;
          }
        }
      } else if (this.Darkness.color.a < 1f) {
        MissionModeGlobals.MissionMode = false;
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
        if (this.Darkness.color.a >= 1f) {
          if (this.Selected == 0) {
            SceneManager.LoadScene("CalendarScene");
          } else if (this.Selected == 1) {
            SceneManager.LoadScene("CalendarScene");
          } else if (this.Selected == 2) {
            Globals.DeleteAll();
            if (this.LoveSick) {
              GameGlobals.LoveSick = true;
            }
            SceneManager.LoadScene("SenpaiScene");
          } else if (this.Selected == 3) {
            SceneManager.LoadScene("MissionModeScene");
          } else if (this.Selected == 6) {
            SceneManager.LoadScene("CreditsScene");
          } else if (this.Selected == 8) {
            Application.Quit();
          }
        }
        this.LoveSickMusic.volume -= Time.deltaTime;
        this.CuteMusic.volume -= Time.deltaTime;
      }
    }
    if (this.Timer < 10f) {
      Animation component = this.Yandere.GetComponent<Animation>();
      component["f02_yanderePose_00"].weight = 0f;
      component["f02_fist_00"].weight = 0f;
    }
    if (Input.GetKeyDown(KeyCode.Minus)) {
      Time.timeScale -= 1f;
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      Time.timeScale += 1f;
    }
  }

  // Token: 0x06000898 RID: 2200 RVA: 0x0009B848 File Offset: 0x00099C48
  private void LateUpdate() {
    if (this.Knife.activeInHierarchy) {
      foreach (Transform transform in this.Spine) {
        transform.transform.localEulerAngles = new Vector3(transform.transform.localEulerAngles.x + 5f, transform.transform.localEulerAngles.y, transform.transform.localEulerAngles.z);
      }
      Transform transform2 = this.Arm[0];
      transform2.transform.localEulerAngles = new Vector3(transform2.transform.localEulerAngles.x, transform2.transform.localEulerAngles.y, transform2.transform.localEulerAngles.z - 15f);
      Transform transform3 = this.Arm[1];
      transform3.transform.localEulerAngles = new Vector3(transform3.transform.localEulerAngles.x, transform3.transform.localEulerAngles.y, transform3.transform.localEulerAngles.z + 15f);
    }
  }

  // Token: 0x06000899 RID: 2201 RVA: 0x0009B998 File Offset: 0x00099D98
  private void TurnDark() {
    GameObjectUtils.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 14);
    Animation component = this.Yandere.GetComponent<Animation>();
    component["f02_yanderePose_00"].weight = 1f;
    component["f02_fist_00"].weight = 1f;
    component.Play("f02_fist_00");
    Renderer renderer = this.YandereEye[0];
    renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    Renderer renderer2 = this.YandereEye[1];
    renderer2.material.color = new Color(renderer2.material.color.r, renderer2.material.color.g, renderer2.material.color.b, 1f);
    this.ColorCorrection.enabled = true;
    this.BloodProjector.SetActive(true);
    this.BloodCamera.SetActive(true);
    this.Knife.SetActive(true);
    this.CuteMusic.volume = 0f;
    this.DarkMusic.volume = 1f;
    RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, 1f);
    RenderSettings.skybox = this.DarkSkybox;
    RenderSettings.fog = true;
    foreach (UISprite uisprite in this.MediumSprites) {
      uisprite.color = new Color(1f, 0f, 0f, uisprite.color.a);
    }
    foreach (UISprite uisprite2 in this.LightSprites) {
      uisprite2.color = new Color(0f, 0f, 0f, uisprite2.color.a);
    }
    foreach (UISprite uisprite3 in this.DarkSprites) {
      uisprite3.color = new Color(0f, 0f, 0f, uisprite3.color.a);
    }
    foreach (UILabel uilabel in this.ColoredLabels) {
      uilabel.color = new Color(0f, 0f, 0f, uilabel.color.a);
    }
    this.SimulatorLabel.color = new Color(1f, 0f, 0f, 1f);
  }

  // Token: 0x0600089A RID: 2202 RVA: 0x0009BCAC File Offset: 0x0009A0AC
  private void TurnCute() {
    GameObjectUtils.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 9);
    Animation component = this.Yandere.GetComponent<Animation>();
    component["f02_yanderePose_00"].weight = 0f;
    component["f02_fist_00"].weight = 0f;
    component.Stop("f02_fist_00");
    Renderer renderer = this.YandereEye[0];
    renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0f);
    Renderer renderer2 = this.YandereEye[1];
    renderer2.material.color = new Color(renderer2.material.color.r, renderer2.material.color.g, renderer2.material.color.b, 0f);
    this.ColorCorrection.enabled = false;
    this.BloodProjector.SetActive(false);
    this.BloodCamera.SetActive(false);
    this.Knife.SetActive(false);
    this.CuteMusic.volume = 1f;
    this.DarkMusic.volume = 0f;
    this.Timer = 0f;
    RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
    RenderSettings.skybox = this.CuteSkybox;
    RenderSettings.fog = false;
    foreach (UISprite uisprite in this.MediumSprites) {
      uisprite.color = new Color(this.MediumColor.r, this.MediumColor.g, this.MediumColor.b, uisprite.color.a);
    }
    foreach (UISprite uisprite2 in this.LightSprites) {
      uisprite2.color = new Color(this.LightColor.r, this.LightColor.g, this.LightColor.b, uisprite2.color.a);
    }
    foreach (UISprite uisprite3 in this.DarkSprites) {
      uisprite3.color = new Color(this.DarkColor.r, this.DarkColor.g, this.DarkColor.b, uisprite3.color.a);
    }
    foreach (UILabel uilabel in this.ColoredLabels) {
      uilabel.color = new Color(1f, 1f, 1f, uilabel.color.a);
    }
    this.SimulatorLabel.color = this.MediumColor;
  }

  // Token: 0x0600089B RID: 2203 RVA: 0x0009BFEC File Offset: 0x0009A3EC
  private void TurnLoveSick() {
    RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
    this.CuteMusic.volume = 0f;
    this.DarkMusic.volume = 0f;
    this.LoveSickMusic.volume = 1f;
    foreach (UISprite uisprite in this.MediumSprites) {
      uisprite.color = new Color(0f, 0f, 0f, uisprite.color.a);
    }
    foreach (UISprite uisprite2 in this.LightSprites) {
      uisprite2.color = new Color(1f, 0f, 0f, uisprite2.color.a);
    }
    foreach (UISprite uisprite3 in this.DarkSprites) {
      uisprite3.color = new Color(1f, 0f, 0f, uisprite3.color.a);
    }
    foreach (UILabel uilabel in this.ColoredLabels) {
      uilabel.color = new Color(1f, 0f, 0f, uilabel.color.a);
    }
    this.LoveSickLogo.SetActive(true);
    this.Logo.SetActive(false);
  }

  // Token: 0x0400195B RID: 6491
  public ColorCorrectionCurves ColorCorrection;

  // Token: 0x0400195C RID: 6492
  public InputManagerScript InputManager;

  // Token: 0x0400195D RID: 6493
  public TitleSaveFilesScript SaveFiles;

  // Token: 0x0400195E RID: 6494
  public SelectiveGrayscale Grayscale;

  // Token: 0x0400195F RID: 6495
  public TitleSponsorScript Sponsors;

  // Token: 0x04001960 RID: 6496
  public PromptBarScript PromptBar;

  // Token: 0x04001961 RID: 6497
  public SSAOEffect SSAO;

  // Token: 0x04001962 RID: 6498
  public JsonScript JSON;

  // Token: 0x04001963 RID: 6499
  public UISprite[] MediumSprites;

  // Token: 0x04001964 RID: 6500
  public UISprite[] LightSprites;

  // Token: 0x04001965 RID: 6501
  public UISprite[] DarkSprites;

  // Token: 0x04001966 RID: 6502
  public UILabel SimulatorLabel;

  // Token: 0x04001967 RID: 6503
  public UILabel[] ColoredLabels;

  // Token: 0x04001968 RID: 6504
  public Color MediumColor;

  // Token: 0x04001969 RID: 6505
  public Color LightColor;

  // Token: 0x0400196A RID: 6506
  public Color DarkColor;

  // Token: 0x0400196B RID: 6507
  public Transform VictimHead;

  // Token: 0x0400196C RID: 6508
  public Transform RightHand;

  // Token: 0x0400196D RID: 6509
  public Transform TwintailL;

  // Token: 0x0400196E RID: 6510
  public Transform TwintailR;

  // Token: 0x0400196F RID: 6511
  public Animation LoveSickYandere;

  // Token: 0x04001970 RID: 6512
  public GameObject BloodProjector;

  // Token: 0x04001971 RID: 6513
  public GameObject LoveSickLogo;

  // Token: 0x04001972 RID: 6514
  public GameObject BloodCamera;

  // Token: 0x04001973 RID: 6515
  public GameObject Yandere;

  // Token: 0x04001974 RID: 6516
  public GameObject Knife;

  // Token: 0x04001975 RID: 6517
  public GameObject Logo;

  // Token: 0x04001976 RID: 6518
  public GameObject Sun;

  // Token: 0x04001977 RID: 6519
  public AudioSource LoveSickMusic;

  // Token: 0x04001978 RID: 6520
  public AudioSource CuteMusic;

  // Token: 0x04001979 RID: 6521
  public AudioSource DarkMusic;

  // Token: 0x0400197A RID: 6522
  public Renderer[] YandereEye;

  // Token: 0x0400197B RID: 6523
  public Material CuteSkybox;

  // Token: 0x0400197C RID: 6524
  public Material DarkSkybox;

  // Token: 0x0400197D RID: 6525
  public Transform Highlight;

  // Token: 0x0400197E RID: 6526
  public Transform[] Spine;

  // Token: 0x0400197F RID: 6527
  public Transform[] Arm;

  // Token: 0x04001980 RID: 6528
  public UISprite Darkness;

  // Token: 0x04001981 RID: 6529
  public Vector3 PermaPositionL;

  // Token: 0x04001982 RID: 6530
  public Vector3 PermaPositionR;

  // Token: 0x04001983 RID: 6531
  public bool LoveSick;

  // Token: 0x04001984 RID: 6532
  public bool FadeOut;

  // Token: 0x04001985 RID: 6533
  public bool Turning;

  // Token: 0x04001986 RID: 6534
  public bool Fading = true;

  // Token: 0x04001987 RID: 6535
  private int SelectionCount = 9;

  // Token: 0x04001988 RID: 6536
  public int Selected;

  // Token: 0x04001989 RID: 6537
  public float InputTimer;

  // Token: 0x0400198A RID: 6538
  public float FadeSpeed = 1f;

  // Token: 0x0400198B RID: 6539
  public float LateTimer;

  // Token: 0x0400198C RID: 6540
  public float RotationY;

  // Token: 0x0400198D RID: 6541
  public float RotationZ;

  // Token: 0x0400198E RID: 6542
  public float Volume;

  // Token: 0x0400198F RID: 6543
  public float Timer;
}