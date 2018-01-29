using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000100 RID: 256
public class HomePrisonerScript : MonoBehaviour {

  // Token: 0x06000508 RID: 1288 RVA: 0x00044F44 File Offset: 0x00043344
  private void Start() {
    this.Sanity = StudentGlobals.GetStudentSanity(SchoolGlobals.KidnapVictim);
    this.SanityLabel.text = "Sanity: " + this.Sanity.ToString() + "%";
    this.Prisoner.Sanity = this.Sanity;
    this.Subtitle.text = string.Empty;
    if (this.Sanity == 100f) {
      this.BanterText = this.FullSanityBanterText;
      this.Banter = this.FullSanityBanter;
    } else if (this.Sanity >= 50f) {
      this.BanterText = this.HighSanityBanterText;
      this.Banter = this.HighSanityBanter;
    } else if (this.Sanity == 0f) {
      this.BanterText = this.NoSanityBanterText;
      this.Banter = this.NoSanityBanter;
    } else {
      this.BanterText = this.LowSanityBanterText;
      this.Banter = this.LowSanityBanter;
    }
    if (this.Sanity < 100f) {
      this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
    }
    if (!HomeGlobals.Night) {
      UILabel uilabel = this.OptionLabels[2];
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
      if (HomeGlobals.LateForSchool) {
        UILabel uilabel2 = this.OptionLabels[1];
        uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
      }
      if (DateGlobals.Weekday == DayOfWeek.Friday) {
        UILabel uilabel3 = this.OptionLabels[3];
        uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
        UILabel uilabel4 = this.OptionLabels[4];
        uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
      }
    } else {
      UILabel uilabel5 = this.OptionLabels[1];
      uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
      UILabel uilabel6 = this.OptionLabels[3];
      uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0.5f);
      UILabel uilabel7 = this.OptionLabels[4];
      uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0.5f);
    }
    if (this.Sanity > 0f) {
      this.OptionLabels[5].text = "?????";
      UILabel uilabel8 = this.OptionLabels[5];
      uilabel8.color = new Color(uilabel8.color.r, uilabel8.color.g, uilabel8.color.b, 0.5f);
    } else {
      this.OptionLabels[5].text = "Bring to School";
      UILabel uilabel9 = this.OptionLabels[1];
      uilabel9.color = new Color(uilabel9.color.r, uilabel9.color.g, uilabel9.color.b, 0.5f);
      UILabel uilabel10 = this.OptionLabels[2];
      uilabel10.color = new Color(uilabel10.color.r, uilabel10.color.g, uilabel10.color.b, 0.5f);
      UILabel uilabel11 = this.OptionLabels[3];
      uilabel11.color = new Color(uilabel11.color.r, uilabel11.color.g, uilabel11.color.b, 0.5f);
      UILabel uilabel12 = this.OptionLabels[4];
      uilabel12.color = new Color(uilabel12.color.r, uilabel12.color.g, uilabel12.color.b, 0.5f);
      UILabel uilabel13 = this.OptionLabels[5];
      uilabel13.color = new Color(uilabel13.color.r, uilabel13.color.g, uilabel13.color.b, 1f);
      if (HomeGlobals.Night) {
        uilabel13.color = new Color(uilabel13.color.r, uilabel13.color.g, uilabel13.color.b, 0.5f);
      }
    }
    this.UpdateDesc();
    if (SchoolGlobals.KidnapVictim == 0) {
      base.enabled = false;
    }
  }

  // Token: 0x06000509 RID: 1289 RVA: 0x000454FC File Offset: 0x000438FC
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (Vector3.Distance(this.HomeYandere.transform.position, this.Prisoner.transform.position) < 2f && this.HomeYandere.CanMove) {
      this.BanterTimer += Time.deltaTime;
      if (this.BanterTimer > 5f && !this.Bantering) {
        this.Bantering = true;
        if (this.BanterID < this.Banter.Length - 1) {
          this.BanterID++;
          this.Subtitle.text = this.BanterText[this.BanterID];
          component.clip = this.Banter[this.BanterID];
          component.Play();
        }
      }
    }
    if (this.Bantering && !component.isPlaying) {
      this.Subtitle.text = string.Empty;
      this.Bantering = false;
      this.BanterTimer = 0f;
    }
    if (!this.HomeYandere.CanMove && (this.HomeCamera.Destination == this.HomeCamera.Destinations[10] || this.HomeCamera.Destination == this.TortureDestination)) {
      if (this.InputManager.TappedDown) {
        this.ID++;
        if (this.ID > 5) {
          this.ID = 1;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 465f - (float)this.ID * 40f, this.Highlight.localPosition.z);
        this.UpdateDesc();
      }
      if (this.InputManager.TappedUp) {
        this.ID--;
        if (this.ID < 1) {
          this.ID = 5;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 465f - (float)this.ID * 40f, this.Highlight.localPosition.z);
        this.UpdateDesc();
      }
      if (Input.GetKeyDown(KeyCode.X)) {
        this.Sanity -= 10f;
        if (this.Sanity < 0f) {
          this.Sanity = 100f;
        }
        StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity);
        this.SanityLabel.text = "Sanity: " + this.Sanity.ToString("f0") + "%";
        this.Prisoner.UpdateSanity();
      }
      if (!this.ZoomIn) {
        if (Input.GetButtonDown("A") && this.OptionLabels[this.ID].color.a == 1f) {
          if (this.Sanity > 0f) {
            if (this.Sanity == 100f) {
              this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_01");
            } else if (this.Sanity >= 50f) {
              this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_02");
            } else {
              this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapSurrender_00");
              this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, 0f, 1f);
              this.TortureTarget.localPosition = new Vector3(this.TortureTarget.localPosition.x, 1.1f, this.TortureTarget.localPosition.z);
            }
            this.HomeCamera.Destination = this.TortureDestination;
            this.HomeCamera.Target = this.TortureTarget;
            this.HomeCamera.Torturing = true;
            this.Prisoner.Tortured = true;
            this.Prisoner.RightEyeRotOrigin.x = -6f;
            this.Prisoner.LeftEyeRotOrigin.x = 6f;
            this.ZoomIn = true;
          } else {
            this.Darkness.FadeOut = true;
          }
          this.HomeWindow.Show = false;
          this.HomeCamera.PromptBar.ClearButtons();
          this.HomeCamera.PromptBar.Show = false;
          this.Jukebox.volume -= 0.5f;
        }
        if (Input.GetButtonDown("B")) {
          this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
          this.HomeCamera.Target = this.HomeCamera.Targets[0];
          this.HomeCamera.PromptBar.ClearButtons();
          this.HomeCamera.PromptBar.Show = false;
          this.HomeYandere.CanMove = true;
          this.HomeYandere.gameObject.SetActive(true);
          this.HomeWindow.Show = false;
        }
      } else {
        this.TortureDestination.Translate(Vector3.forward * (Time.deltaTime * 0.02f));
        this.Jukebox.volume -= Time.deltaTime * 0.05f;
        this.Timer += Time.deltaTime;
        if (this.Sanity >= 50f) {
          this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, this.TortureDestination.localPosition.y + Time.deltaTime * 0.05f, this.TortureDestination.localPosition.z);
          if (this.Sanity == 100f) {
            if (this.Timer > 2f && !this.PlayedAudio) {
              component.clip = this.FirstTorture;
              this.PlayedAudio = true;
              component.Play();
            }
          } else if (this.Timer > 1.5f && !this.PlayedAudio) {
            component.clip = this.Over50Torture;
            this.PlayedAudio = true;
            component.Play();
          }
        } else if (this.Timer > 5f && !this.PlayedAudio) {
          component.clip = this.Under50Torture;
          this.PlayedAudio = true;
          component.Play();
        }
        if (this.Timer > 10f && this.Darkness.Sprite.color.a != 1f) {
          this.Darkness.enabled = false;
          this.Darkness.Sprite.color = new Color(this.Darkness.Sprite.color.r, this.Darkness.Sprite.color.g, this.Darkness.Sprite.color.b, 1f);
          component.clip = this.TortureHit;
          component.Play();
        }
        if (this.Timer > 15f) {
          if (this.ID == 1) {
            Time.timeScale = 1f;
            this.NowLoading.SetActive(true);
            HomeGlobals.LateForSchool = true;
            SceneManager.LoadScene("SchoolScene");
            StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 2.5f);
          } else if (this.ID == 2) {
            SceneManager.LoadScene("CalendarScene");
            StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 10f);
            PlayerGlobals.Reputation -= 20f;
          } else if (this.ID == 3) {
            HomeGlobals.Night = true;
            SceneManager.LoadScene("HomeScene");
            StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 30f);
            PlayerGlobals.Reputation -= 20f;
          } else if (this.ID == 4) {
            SceneManager.LoadScene("CalendarScene");
            StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 45f);
            PlayerGlobals.Reputation -= 20f;
          }
          if (StudentGlobals.GetStudentSanity(SchoolGlobals.KidnapVictim) < 0f) {
            StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, 0f);
          }
        }
      }
    }
  }

  // Token: 0x0600050A RID: 1290 RVA: 0x00045DC4 File Offset: 0x000441C4
  public void UpdateDesc() {
    this.HomeCamera.PromptBar.Label[0].text = "Accept";
    this.DescLabel.text = this.Descriptions[this.ID];
    if (!HomeGlobals.Night) {
      if (HomeGlobals.LateForSchool && this.ID == 1) {
        this.DescLabel.text = "This option is unavailable if you are late for school.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
      if (this.ID == 2) {
        this.DescLabel.text = "This option is unavailable in the daytime.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
      if (DateGlobals.Weekday == DayOfWeek.Friday && (this.ID == 3 || this.ID == 4)) {
        this.DescLabel.text = "This option is unavailable on Friday.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
    } else if (this.ID != 2) {
      this.DescLabel.text = "This option is unavailable at nighttime.";
      this.HomeCamera.PromptBar.Label[0].text = string.Empty;
    }
    if (this.ID == 5) {
      if (this.Sanity > 0f) {
        this.DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
      }
      if (HomeGlobals.Night) {
        this.DescLabel.text = "This option is unavailable at nighttime.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
    }
    this.HomeCamera.PromptBar.UpdateButtons();
  }

  // Token: 0x04000BCA RID: 3018
  public InputManagerScript InputManager;

  // Token: 0x04000BCB RID: 3019
  public HomePrisonerChanScript Prisoner;

  // Token: 0x04000BCC RID: 3020
  public HomeYandereScript HomeYandere;

  // Token: 0x04000BCD RID: 3021
  public HomeCameraScript HomeCamera;

  // Token: 0x04000BCE RID: 3022
  public HomeWindowScript HomeWindow;

  // Token: 0x04000BCF RID: 3023
  public HomeDarknessScript Darkness;

  // Token: 0x04000BD0 RID: 3024
  public UILabel[] OptionLabels;

  // Token: 0x04000BD1 RID: 3025
  public string[] Descriptions;

  // Token: 0x04000BD2 RID: 3026
  public Transform TortureDestination;

  // Token: 0x04000BD3 RID: 3027
  public Transform TortureTarget;

  // Token: 0x04000BD4 RID: 3028
  public GameObject NowLoading;

  // Token: 0x04000BD5 RID: 3029
  public Transform Highlight;

  // Token: 0x04000BD6 RID: 3030
  public AudioSource Jukebox;

  // Token: 0x04000BD7 RID: 3031
  public UILabel SanityLabel;

  // Token: 0x04000BD8 RID: 3032
  public UILabel DescLabel;

  // Token: 0x04000BD9 RID: 3033
  public UILabel Subtitle;

  // Token: 0x04000BDA RID: 3034
  public bool PlayedAudio;

  // Token: 0x04000BDB RID: 3035
  public bool ZoomIn;

  // Token: 0x04000BDC RID: 3036
  public float Sanity = 100f;

  // Token: 0x04000BDD RID: 3037
  public float Timer;

  // Token: 0x04000BDE RID: 3038
  public int ID = 1;

  // Token: 0x04000BDF RID: 3039
  public AudioClip FirstTorture;

  // Token: 0x04000BE0 RID: 3040
  public AudioClip Under50Torture;

  // Token: 0x04000BE1 RID: 3041
  public AudioClip Over50Torture;

  // Token: 0x04000BE2 RID: 3042
  public AudioClip TortureHit;

  // Token: 0x04000BE3 RID: 3043
  public string[] FullSanityBanterText;

  // Token: 0x04000BE4 RID: 3044
  public string[] HighSanityBanterText;

  // Token: 0x04000BE5 RID: 3045
  public string[] LowSanityBanterText;

  // Token: 0x04000BE6 RID: 3046
  public string[] NoSanityBanterText;

  // Token: 0x04000BE7 RID: 3047
  public string[] BanterText;

  // Token: 0x04000BE8 RID: 3048
  public AudioClip[] FullSanityBanter;

  // Token: 0x04000BE9 RID: 3049
  public AudioClip[] HighSanityBanter;

  // Token: 0x04000BEA RID: 3050
  public AudioClip[] LowSanityBanter;

  // Token: 0x04000BEB RID: 3051
  public AudioClip[] NoSanityBanter;

  // Token: 0x04000BEC RID: 3052
  public AudioClip[] Banter;

  // Token: 0x04000BED RID: 3053
  public float BanterTimer;

  // Token: 0x04000BEE RID: 3054
  public bool Bantering;

  // Token: 0x04000BEF RID: 3055
  public int BanterID;
}