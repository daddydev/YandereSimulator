using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200014E RID: 334
public class PauseScreenScript : MonoBehaviour {

  // Token: 0x06000625 RID: 1573 RVA: 0x00056B14 File Offset: 0x00054F14
  private void Start() {
    StudentGlobals.SetStudentPhotographed(0, true);
    StudentGlobals.SetStudentPhotographed(1, true);
    base.transform.localPosition = new Vector3(1350f, 0f, 0f);
    base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
    base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, 0f);
    this.StudentInfoMenu.gameObject.SetActive(false);
    this.PhotoGallery.gameObject.SetActive(false);
    this.FavorMenu.gameObject.SetActive(false);
    this.MusicMenu.gameObject.SetActive(false);
    this.PassTime.gameObject.SetActive(false);
    this.Settings.gameObject.SetActive(false);
    this.Stats.gameObject.SetActive(false);
    this.LoadingScreen.SetActive(false);
    this.SchemesMenu.SetActive(false);
    this.ServiceMenu.SetActive(false);
    this.StudentInfo.SetActive(false);
    this.DropsMenu.SetActive(false);
    this.MainMenu.SetActive(true);
    if (SceneManager.GetActiveScene().name == "SchoolScene") {
      this.Schemes.UpdateInstructions();
    } else {
      this.MissionModeIcons.SetActive(false);
      UISprite uisprite = this.PhoneIcons[5];
      uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
      UISprite uisprite2 = this.PhoneIcons[8];
      uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
    }
    if (MissionModeGlobals.MissionMode) {
      UISprite uisprite3 = this.PhoneIcons[10];
      uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 1f);
    }
    this.UpdateSelection();
    this.CorrectingTime = false;
  }

  // Token: 0x06000626 RID: 1574 RVA: 0x00056D94 File Offset: 0x00055194
  private void Update() {
    this.Speed = Time.unscaledDeltaTime * 10f;
    if (!this.Police.FadeOut) {
      if (!this.Show) {
        base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1350f, 50f, 0f), this.Speed);
        base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
        base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
        if (base.transform.localPosition.x > 1349f && this.Panel.enabled) {
          this.Panel.enabled = false;
        }
        if (this.CorrectingTime && Time.timeScale < 0.9f) {
          Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, this.Speed);
          if (Time.timeScale > 0.9f) {
            this.CorrectingTime = false;
            Time.timeScale = 1f;
          }
        }
        if (Input.GetButtonDown("Start")) {
          if (!this.Home) {
            if (!this.Yandere.Shutter.Snapping && !this.Yandere.TimeSkipping && !this.Yandere.Talking && !this.Yandere.Noticed && !this.Yandere.InClass && !this.Yandere.Struggling && !this.Yandere.Won && !this.Yandere.Dismembering && !this.Yandere.Attacked && this.Yandere.CanMove && Time.timeScale > 0f) {
              this.Yandere.StopAiming();
              this.PromptParent.localScale = Vector3.zero;
              this.Yandere.Obscurance.enabled = false;
              this.Yandere.YandereVision = false;
              this.ScreenBlur.enabled = true;
              this.Yandere.YandereTimer = 0f;
              this.Yandere.Mopping = false;
              this.Panel.enabled = true;
              this.Sideways = false;
              this.Show = true;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Accept";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Choose";
              this.PromptBar.Label[5].text = "Choose";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              UISprite uisprite = this.PhoneIcons[3];
              if (!this.Yandere.CanMove || this.Yandere.Dragging || (this.Police.Corpses - this.Police.HiddenCorpses > 0 && !this.Police.SuicideScene && !this.Police.PoisonScene)) {
                uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
              } else {
                uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 1f);
              }
            }
          } else if (this.HomeCamera.Destination == this.HomeCamera.Destinations[0]) {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Accept";
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.HomeYandere.CanMove = false;
            UISprite uisprite2 = this.PhoneIcons[3];
            uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
            this.Panel.enabled = true;
            this.Sideways = false;
            this.Show = true;
          }
        }
      } else {
        if (!this.EggsChecked) {
          float num = 99999f;
          for (int i = 0; i < this.Eggs.Length; i++) {
            if (this.Eggs[i] != null) {
              float num2 = Vector3.Distance(this.Yandere.transform.position, this.Eggs[i].position);
              if (num2 < num) {
                num = num2;
              }
            }
          }
          if (num < 5f) {
            this.Wifi.spriteName = "5Bars";
          } else if (num < 10f) {
            this.Wifi.spriteName = "4Bars";
          } else if (num < 15f) {
            this.Wifi.spriteName = "3Bars";
          } else if (num < 20f) {
            this.Wifi.spriteName = "2Bars";
          } else if (num < 25f) {
            this.Wifi.spriteName = "1Bars";
          } else {
            this.Wifi.spriteName = "0Bars";
          }
          this.EggsChecked = true;
        }
        if (!this.Home) {
          Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, this.Speed);
          this.RPGCamera.enabled = false;
        }
        if (this.Quitting) {
          base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
          base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, -1200f, 0f), this.Speed);
        } else if (!this.Sideways) {
          base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
          base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 50f, 0f), this.Speed);
          base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
        } else {
          base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), this.Speed);
          base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 14f, 0f), this.Speed);
          base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 90f, this.Speed));
        }
        if (this.MainMenu.activeInHierarchy && !this.Quitting) {
          if (this.InputManager.TappedUp || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            this.Row--;
            this.UpdateSelection();
          }
          if (this.InputManager.TappedDown || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            this.Row++;
            this.UpdateSelection();
          }
          if (this.InputManager.TappedRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            this.Column++;
            this.UpdateSelection();
          }
          if (this.InputManager.TappedLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            this.Column--;
            this.UpdateSelection();
          }
          for (int j = 1; j < this.PhoneIcons.Length; j++) {
            if (this.PhoneIcons[j] != null) {
              Vector3 b = (this.Selected == j) ? new Vector3(1.5f, 1.5f, 1.5f) : new Vector3(1f, 1f, 1f);
              this.PhoneIcons[j].transform.localScale = Vector3.Lerp(this.PhoneIcons[j].transform.localScale, b, this.Speed);
            }
          }
          if (Input.GetButtonDown("A")) {
            this.PressedA = true;
            if (this.PhoneIcons[this.Selected].color.a == 1f) {
              if (this.Selected == 1) {
                this.MainMenu.SetActive(false);
                this.LoadingScreen.SetActive(true);
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Choose";
                this.PromptBar.Label[5].text = "Choose";
                this.PromptBar.UpdateButtons();
                base.StartCoroutine(this.PhotoGallery.GetPhotos());
              } else if (this.Selected == 2) {
                this.TaskList.gameObject.SetActive(true);
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Choose";
                this.PromptBar.UpdateButtons();
                this.TaskList.UpdateTaskList();
                base.StartCoroutine(this.TaskList.UpdateTaskInfo());
              } else if (this.Selected == 3) {
                if (this.PhoneIcons[3].color.a == 1f && this.Yandere.CanMove && !this.Yandere.Dragging) {
                  for (int k = 0; k < this.Yandere.ArmedAnims.Length; k++) {
                    this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[k]].weight = 0f;
                  }
                  this.MainMenu.SetActive(false);
                  this.PromptBar.ClearButtons();
                  this.PromptBar.Label[0].text = "Begin";
                  this.PromptBar.Label[1].text = "Back";
                  this.PromptBar.Label[4].text = "Adjust";
                  this.PromptBar.Label[5].text = "Choose";
                  this.PromptBar.UpdateButtons();
                  this.PassTime.gameObject.SetActive(true);
                  this.PassTime.GetCurrentTime();
                }
              } else if (this.Selected == 4) {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Exit";
                this.PromptBar.UpdateButtons();
                this.Stats.gameObject.SetActive(true);
                this.Stats.UpdateStats();
                this.MainMenu.SetActive(false);
                this.Sideways = true;
              } else if (this.Selected == 5) {
                if (this.PhoneIcons[5].color.a == 1f) {
                  this.PromptBar.ClearButtons();
                  this.PromptBar.Label[0].text = "Accept";
                  this.PromptBar.Label[1].text = "Exit";
                  this.PromptBar.Label[5].text = "Choose";
                  this.PromptBar.UpdateButtons();
                  this.FavorMenu.gameObject.SetActive(true);
                  this.FavorMenu.gameObject.GetComponent<AudioSource>().Play();
                  this.MainMenu.SetActive(false);
                  this.Sideways = true;
                }
              } else if (this.Selected == 6) {
                this.StudentInfoMenu.gameObject.SetActive(true);
                base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "View Info";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              } else if (this.Selected != 7) {
                if (this.Selected == 8) {
                  this.Settings.gameObject.SetActive(true);
                  this.ScreenBlur.enabled = false;
                  this.Settings.UpdateText();
                  this.MainMenu.SetActive(false);
                  this.PromptBar.ClearButtons();
                  this.PromptBar.Label[1].text = "Back";
                  this.PromptBar.Label[4].text = "Choose";
                  this.PromptBar.Label[5].text = "Change";
                  this.PromptBar.UpdateButtons();
                  this.PromptBar.Show = true;
                } else if (this.Selected != 9) {
                  if (this.Selected == 10) {
                    if (!MissionModeGlobals.MissionMode) {
                      this.MusicMenu.gameObject.SetActive(true);
                      this.Settings.UpdateText();
                      this.MainMenu.SetActive(false);
                      this.PromptBar.ClearButtons();
                      this.PromptBar.Label[0].text = "Play";
                      this.PromptBar.Label[1].text = "Back";
                      this.PromptBar.Label[4].text = "Choose";
                      this.PromptBar.UpdateButtons();
                      this.PromptBar.Show = true;
                    } else {
                      this.PhoneIcons[this.Selected].transform.localScale = new Vector3(1f, 1f, 1f);
                      this.MissionMode.ChangeMusic();
                    }
                  } else if (this.Selected == 11) {
                    this.PromptBar.ClearButtons();
                    this.PromptBar.Show = false;
                    this.Quitting = true;
                  } else if (this.Selected == 12) {
                  }
                }
              }
            }
          }
          if (!this.PressedB && (Input.GetButtonDown("Start") || Input.GetButtonDown("B"))) {
            this.ExitPhone();
          }
          if (Input.GetButtonUp("B")) {
            this.PressedB = false;
          }
        }
        if (!this.PressedA) {
          if (this.PassTime.gameObject.activeInHierarchy) {
            if (Input.GetButtonDown("A")) {
              if (this.Yandere.PickUp != null) {
                this.Yandere.PickUp.Drop();
              }
              this.Yandere.Unequip();
              this.ScreenBlur.enabled = false;
              this.RPGCamera.enabled = true;
              this.PassTime.gameObject.SetActive(false);
              this.MainMenu.SetActive(true);
              this.PromptBar.Show = false;
              this.Show = false;
              this.Clock.TargetTime = (float)this.PassTime.TargetTime;
              this.Clock.TimeSkip = true;
              Time.timeScale = 1f;
            }
            if (Input.GetButtonDown("B")) {
              this.MainMenu.SetActive(true);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Accept";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Choose";
              this.PromptBar.Label[5].text = "Choose";
              this.PromptBar.UpdateButtons();
              this.PassTime.gameObject.SetActive(false);
            }
          }
          if (this.Quitting) {
            if (Input.GetButtonDown("A")) {
              SceneManager.LoadScene("TitleScene");
            }
            if (Input.GetButtonDown("B")) {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Accept";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Choose";
              this.PromptBar.Label[5].text = "Choose";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Quitting = false;
              if (this.BypassPhone) {
                base.transform.localPosition = new Vector3(1350f, 0f, 0f);
                this.ExitPhone();
              }
            }
          }
        }
        if (Input.GetButtonUp("A")) {
          this.PressedA = false;
        }
      }
    }
  }

  // Token: 0x06000627 RID: 1575 RVA: 0x00058114 File Offset: 0x00056514
  public void JumpToQuit() {
    if (!this.Police.FadeOut && !this.Clock.TimeSkip && !this.Yandere.Noticed) {
      base.transform.localPosition = new Vector3(0f, -1200f, 0f);
      this.Yandere.YandereVision = false;
      if (!this.Yandere.Talking && !this.Yandere.Dismembering) {
        this.RPGCamera.enabled = false;
        this.Yandere.StopAiming();
      }
      this.ScreenBlur.enabled = true;
      this.Panel.enabled = true;
      this.BypassPhone = true;
      this.Quitting = true;
      this.Show = true;
    }
  }

  // Token: 0x06000628 RID: 1576 RVA: 0x000581E0 File Offset: 0x000565E0
  private void ExitPhone() {
    if (!this.Home) {
      this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
      this.ScreenBlur.enabled = false;
      this.CorrectingTime = true;
      if (!this.Yandere.Talking && !this.Yandere.Dismembering) {
        this.RPGCamera.enabled = true;
      }
      if (this.Yandere.Laughing) {
        this.Yandere.GetComponent<AudioSource>().volume = 1f;
      }
    } else {
      this.HomeYandere.CanMove = true;
    }
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.BypassPhone = false;
    this.EggsChecked = false;
    this.PressedA = false;
    this.Show = false;
  }

  // Token: 0x06000629 RID: 1577 RVA: 0x000582C0 File Offset: 0x000566C0
  private void UpdateSelection() {
    if (this.Row < 0) {
      this.Row = 3;
    } else if (this.Row > 3) {
      this.Row = 0;
    }
    if (this.Column < 1) {
      this.Column = 3;
    } else if (this.Column > 3) {
      this.Column = 1;
    }
    this.Selected = this.Row * 3 + this.Column;
    this.SelectionLabel.text = this.SelectionNames[this.Selected];
  }

  // Token: 0x04000EBD RID: 3773
  public StudentInfoMenuScript StudentInfoMenu;

  // Token: 0x04000EBE RID: 3774
  public InputManagerScript InputManager;

  // Token: 0x04000EBF RID: 3775
  public PhotoGalleryScript PhotoGallery;

  // Token: 0x04000EC0 RID: 3776
  public HomeYandereScript HomeYandere;

  // Token: 0x04000EC1 RID: 3777
  public MissionModeScript MissionMode;

  // Token: 0x04000EC2 RID: 3778
  public HomeCameraScript HomeCamera;

  // Token: 0x04000EC3 RID: 3779
  public FavorMenuScript FavorMenu;

  // Token: 0x04000EC4 RID: 3780
  public MusicMenuScript MusicMenu;

  // Token: 0x04000EC5 RID: 3781
  public PromptBarScript PromptBar;

  // Token: 0x04000EC6 RID: 3782
  public PassTimeScript PassTime;

  // Token: 0x04000EC7 RID: 3783
  public SettingsScript Settings;

  // Token: 0x04000EC8 RID: 3784
  public TaskListScript TaskList;

  // Token: 0x04000EC9 RID: 3785
  public SchemesScript Schemes;

  // Token: 0x04000ECA RID: 3786
  public YandereScript Yandere;

  // Token: 0x04000ECB RID: 3787
  public RPG_Camera RPGCamera;

  // Token: 0x04000ECC RID: 3788
  public PoliceScript Police;

  // Token: 0x04000ECD RID: 3789
  public ClockScript Clock;

  // Token: 0x04000ECE RID: 3790
  public StatsScript Stats;

  // Token: 0x04000ECF RID: 3791
  public Blur ScreenBlur;

  // Token: 0x04000ED0 RID: 3792
  public UILabel SelectionLabel;

  // Token: 0x04000ED1 RID: 3793
  public UIPanel Panel;

  // Token: 0x04000ED2 RID: 3794
  public UISprite Wifi;

  // Token: 0x04000ED3 RID: 3795
  public GameObject MissionModeIcons;

  // Token: 0x04000ED4 RID: 3796
  public GameObject LoadingScreen;

  // Token: 0x04000ED5 RID: 3797
  public GameObject SchemesMenu;

  // Token: 0x04000ED6 RID: 3798
  public GameObject ServiceMenu;

  // Token: 0x04000ED7 RID: 3799
  public GameObject StudentInfo;

  // Token: 0x04000ED8 RID: 3800
  public GameObject DropsMenu;

  // Token: 0x04000ED9 RID: 3801
  public GameObject MainMenu;

  // Token: 0x04000EDA RID: 3802
  public Transform PromptParent;

  // Token: 0x04000EDB RID: 3803
  public string[] SelectionNames;

  // Token: 0x04000EDC RID: 3804
  public UISprite[] PhoneIcons;

  // Token: 0x04000EDD RID: 3805
  public Transform[] Eggs;

  // Token: 0x04000EDE RID: 3806
  public int Selected = 1;

  // Token: 0x04000EDF RID: 3807
  public float Speed;

  // Token: 0x04000EE0 RID: 3808
  public bool CorrectingTime;

  // Token: 0x04000EE1 RID: 3809
  public bool BypassPhone;

  // Token: 0x04000EE2 RID: 3810
  public bool EggsChecked;

  // Token: 0x04000EE3 RID: 3811
  public bool PressedA;

  // Token: 0x04000EE4 RID: 3812
  public bool PressedB;

  // Token: 0x04000EE5 RID: 3813
  public bool Quitting;

  // Token: 0x04000EE6 RID: 3814
  public bool Sideways;

  // Token: 0x04000EE7 RID: 3815
  public bool Home;

  // Token: 0x04000EE8 RID: 3816
  public bool Show;

  // Token: 0x04000EE9 RID: 3817
  public int Row = 1;

  // Token: 0x04000EEA RID: 3818
  public int Column = 2;
}