using UnityEngine;

// Token: 0x02000075 RID: 117
public class CounselorScript : MonoBehaviour {

  // Token: 0x060001B7 RID: 439 RVA: 0x000222BC File Offset: 0x000206BC
  private void Start() {
    this.CounselorWindow.localScale = Vector3.zero;
    this.CounselorWindow.gameObject.SetActive(false);
    this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, 0f);
  }

  // Token: 0x060001B8 RID: 440 RVA: 0x00022338 File Offset: 0x00020738
  private void Update() {
    if (this.Yandere.transform.position.x < base.transform.position.x) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    } else {
      this.Prompt.enabled = true;
    }
    Animation component = base.GetComponent<Animation>();
    AudioSource component2 = base.GetComponent<AudioSource>();
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Busy) {
        component.CrossFade("CounselorComputerAttention", 1f);
        this.ChinTimer = 0f;
        this.Yandere.TargetStudent = this.Student;
        int num = UnityEngine.Random.Range(1, 3);
        this.CounselorSubtitle.text = this.CounselorGreetingText[num];
        component2.clip = this.CounselorGreetingClips[num];
        component2.Play();
        this.StudentManager.DisablePrompts();
        this.CounselorWindow.gameObject.SetActive(true);
        this.LookAtPlayer = true;
        this.ShowWindow = true;
        this.Yandere.ShoulderCamera.OverShoulder = true;
        this.Yandere.WeaponMenu.KeyboardShow = false;
        this.Yandere.Obscurance.enabled = false;
        this.Yandere.WeaponMenu.Show = false;
        this.Yandere.YandereVision = false;
        this.Yandere.CanMove = false;
        this.Yandere.Talking = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.UpdateList();
      } else {
        this.CounselorSubtitle.text = this.CounselorBusyText;
        component2.clip = this.CounselorBusyClip;
        component2.Play();
      }
    }
    if (this.LookAtPlayer) {
      if (this.InputManager.TappedUp) {
        this.Selected--;
        if (this.Selected == 6) {
          this.Selected = 5;
        }
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown) {
        this.Selected++;
        if (this.Selected == 6) {
          this.Selected = 7;
        }
        this.UpdateHighlight();
      }
      if (this.ShowWindow) {
        if (Input.GetButtonDown("A")) {
          if (this.Selected == 7) {
            component.CrossFade("CounselorComputerLoop", 1f);
            this.Yandere.ShoulderCamera.OverShoulder = false;
            this.StudentManager.EnablePrompts();
            this.Yandere.TargetStudent = null;
            this.LookAtPlayer = false;
            this.ShowWindow = false;
            this.CounselorSubtitle.text = this.CounselorFarewellText;
            component2.clip = this.CounselorFarewellClip;
            component2.Play();
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
          } else if (this.Labels[this.Selected].color.a == 1f) {
            if (this.Selected == 1) {
              SchemeGlobals.SetSchemeStage(1, 100);
              this.Schemes.UpdateInstructions();
            } else if (this.Selected == 2) {
              SchemeGlobals.SetSchemeStage(2, 100);
              this.Schemes.UpdateInstructions();
            } else if (this.Selected == 3) {
              SchemeGlobals.SetSchemeStage(3, 100);
              this.Schemes.UpdateInstructions();
            } else if (this.Selected == 4) {
              SchemeGlobals.SetSchemeStage(4, 100);
              this.Schemes.UpdateInstructions();
            } else if (this.Selected == 5) {
              SchemeGlobals.SetSchemeStage(5, 7);
              this.Schemes.UpdateInstructions();
            }
            this.CounselorSubtitle.text = this.CounselorReportText[this.Selected];
            component2.clip = this.CounselorReportClips[this.Selected];
            component2.Play();
            this.ShowWindow = false;
            this.Angry = true;
            this.LectureID = this.Selected;
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.Busy = true;
          }
        }
      } else {
        if (Input.GetButtonDown("A")) {
          component2.Stop();
        }
        if (!component2.isPlaying) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 0.5f) {
            component.CrossFade("CounselorComputerLoop", 1f);
            this.Yandere.ShoulderCamera.OverShoulder = false;
            this.StudentManager.EnablePrompts();
            this.Yandere.TargetStudent = null;
            this.LookAtPlayer = false;
            this.Angry = false;
            this.UpdateList();
          }
        }
      }
    } else {
      this.ChinTimer += Time.deltaTime;
      if (this.ChinTimer > 10f) {
        component.CrossFade("CounselorComputerChin");
        if (component["CounselorComputerChin"].time > component["CounselorComputerChin"].length) {
          component.CrossFade("CounselorComputerLoop");
          this.ChinTimer = 0f;
        }
      }
    }
    if (this.ShowWindow) {
      this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    } else if (this.CounselorWindow.localScale.x > 0.1f) {
      this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    } else {
      this.CounselorWindow.localScale = Vector3.zero;
      this.CounselorWindow.gameObject.SetActive(false);
    }
    if (this.Lecturing) {
      this.Chibi.localPosition = new Vector3(this.Chibi.localPosition.x, Mathf.Lerp(this.Chibi.localPosition.y, 250f + (float)StudentGlobals.ExpelProgress * -100f, Time.deltaTime * 2f), this.Chibi.localPosition.z);
      if (this.LecturePhase == 1) {
        this.LectureLabel.text = this.LectureIntro[this.LectureID];
        this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0f, Time.deltaTime));
        if (this.EndOfDayDarkness.color.a == 0f) {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          if (Input.GetButtonDown("A")) {
            this.LecturePhase++;
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
          }
        }
      } else if (this.LecturePhase == 2) {
        this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, Mathf.MoveTowards(this.LectureLabel.color.a, 0f, Time.deltaTime));
        if (this.LectureLabel.color.a == 0f) {
          this.LectureSubtitle.text = this.CounselorLectureText[this.LectureID];
          component2.clip = this.CounselorLectureClips[this.LectureID];
          component2.Play();
          this.LecturePhase++;
        }
      } else if (this.LecturePhase == 3) {
        if (!component2.isPlaying || Input.GetButtonDown("A")) {
          this.LectureSubtitle.text = this.RivalText[this.LectureID];
          component2.clip = this.RivalClips[this.LectureID];
          component2.Play();
          this.LecturePhase++;
        }
      } else if (this.LecturePhase == 4) {
        if (!component2.isPlaying || Input.GetButtonDown("A")) {
          this.LectureSubtitle.text = string.Empty;
          if (StudentGlobals.ExpelProgress < 5) {
            this.LecturePhase++;
          } else {
            this.LecturePhase = 7;
            this.ExpelTimer = 11f;
          }
        }
      } else if (this.LecturePhase == 5) {
        this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 1f, Time.deltaTime));
        this.ExpelTimer += Time.deltaTime;
        if (this.ExpelTimer > 2f) {
          StudentGlobals.ExpelProgress++;
          this.LecturePhase++;
        }
      } else if (this.LecturePhase == 6) {
        this.ExpelTimer += Time.deltaTime;
        if (this.ExpelTimer > 4f) {
          this.LecturePhase++;
        }
      } else if (this.LecturePhase == 7) {
        this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 0f, Time.deltaTime));
        this.ExpelTimer += Time.deltaTime;
        if (this.ExpelTimer > 6f) {
          if (StudentGlobals.ExpelProgress == 5 && !StudentGlobals.GetStudentExpelled(7)) {
            StudentGlobals.SetStudentExpelled(7, true);
            this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 0f);
            this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, 0f);
            this.LecturePhase = 2;
            this.ExpelTimer = 0f;
            this.LectureID = 6;
          } else if (this.LectureID < 6) {
            this.EndOfDay.enabled = true;
            this.EndOfDay.Phase++;
            this.EndOfDay.UpdateScene();
            base.enabled = false;
          } else {
            this.EndOfDay.gameObject.SetActive(false);
            this.EndOfDay.Phase = 1;
            this.CutsceneManager.Phase++;
            this.Lecturing = false;
            this.LectureID = 0;
          }
        }
      }
    }
    if (!component2.isPlaying) {
      this.CounselorSubtitle.text = string.Empty;
    }
  }

  // Token: 0x060001B9 RID: 441 RVA: 0x00022FD0 File Offset: 0x000213D0
  private void UpdateList() {
    for (int i = 1; i < this.Labels.Length; i++) {
      UILabel uilabel = this.Labels[i];
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
    }
    if (SchemeGlobals.GetSchemeStage(1) == 2) {
      UILabel uilabel2 = this.Labels[1];
      uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
    }
    if (SchemeGlobals.GetSchemeStage(2) == 3) {
      UILabel uilabel3 = this.Labels[2];
      uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
    }
    if (SchemeGlobals.GetSchemeStage(3) == 4) {
      UILabel uilabel4 = this.Labels[3];
      uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 1f);
    }
    if (SchemeGlobals.GetSchemeStage(4) == 5) {
      UILabel uilabel5 = this.Labels[4];
      uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 1f);
    }
    if (SchemeGlobals.GetSchemeStage(5) == 6) {
      UILabel uilabel6 = this.Labels[5];
      uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
    }
  }

  // Token: 0x060001BA RID: 442 RVA: 0x000231F0 File Offset: 0x000215F0
  private void UpdateHighlight() {
    if (this.Selected < 1) {
      this.Selected = 7;
    } else if (this.Selected > 7) {
      this.Selected = 1;
    }
    this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 200f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
  }

  // Token: 0x060001BB RID: 443 RVA: 0x00023280 File Offset: 0x00021680
  private void LateUpdate() {
    if (this.Angry) {
      this.Anger = Mathf.Lerp(this.Anger, 100f, Time.deltaTime);
      this.Face.SetBlendShapeWeight(1, this.Anger);
      this.Face.SetBlendShapeWeight(5, this.Anger);
      this.Face.SetBlendShapeWeight(9, this.Anger);
    } else {
      this.Anger = Mathf.Lerp(this.Anger, 0f, Time.deltaTime);
      this.Face.SetBlendShapeWeight(1, this.Anger);
      this.Face.SetBlendShapeWeight(5, this.Anger);
      this.Face.SetBlendShapeWeight(9, this.Anger);
    }
    this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, (!this.LookAtPlayer) ? this.Default.position : this.Yandere.Head.position, Time.deltaTime * 2f);
    this.Head.LookAt(this.LookAtTarget);
  }

  // Token: 0x040005D7 RID: 1495
  public CutsceneManagerScript CutsceneManager;

  // Token: 0x040005D8 RID: 1496
  public StudentManagerScript StudentManager;

  // Token: 0x040005D9 RID: 1497
  public InputManagerScript InputManager;

  // Token: 0x040005DA RID: 1498
  public PromptBarScript PromptBar;

  // Token: 0x040005DB RID: 1499
  public EndOfDayScript EndOfDay;

  // Token: 0x040005DC RID: 1500
  public SubtitleScript Subtitle;

  // Token: 0x040005DD RID: 1501
  public SchemesScript Schemes;

  // Token: 0x040005DE RID: 1502
  public StudentScript Student;

  // Token: 0x040005DF RID: 1503
  public YandereScript Yandere;

  // Token: 0x040005E0 RID: 1504
  public PromptScript Prompt;

  // Token: 0x040005E1 RID: 1505
  public AudioClip[] CounselorGreetingClips;

  // Token: 0x040005E2 RID: 1506
  public AudioClip[] CounselorLectureClips;

  // Token: 0x040005E3 RID: 1507
  public AudioClip[] CounselorReportClips;

  // Token: 0x040005E4 RID: 1508
  public AudioClip[] RivalClips;

  // Token: 0x040005E5 RID: 1509
  public AudioClip CounselorFarewellClip;

  // Token: 0x040005E6 RID: 1510
  public readonly string CounselorFarewellText = "Don't misbehave.";

  // Token: 0x040005E7 RID: 1511
  public AudioClip CounselorBusyClip;

  // Token: 0x040005E8 RID: 1512
  public readonly string CounselorBusyText = "I'm sorry, I've got my hands full for the rest of today. I won't be available until tomorrow.";

  // Token: 0x040005E9 RID: 1513
  public readonly string[] CounselorGreetingText = new string[]
  {
    string.Empty,
    "What can I help you with?",
    "Can I help you?"
  };

  // Token: 0x040005EA RID: 1514
  public readonly string[] CounselorLectureText = new string[]
  {
    string.Empty,
    "Your \"after-school activities\" are completely unacceptable. You should not be conducting yourself in such a manner. This kind of behavior could cause a scandal! You could run the school's reputation into the ground!",
    "May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?",
    "I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!",
    "May I see your phone for a moment? ...what is THIS?! Would you care to explain why something like this is on your phone?",
    "Obviously, we need to have a long talk about the kind of behavior that will not tolerated at this school!",
    "That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!"
  };

  // Token: 0x040005EB RID: 1515
  public readonly string[] CounselorReportText = new string[]
  {
    string.Empty,
    "This is...! Thank you for bringing this to my attention. This kind of conduct will definitely harm the school's reputation. I'll have to have a word with her later today.",
    "Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.",
    "That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.",
    "That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.",
    "That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act."
  };

  // Token: 0x040005EC RID: 1516
  public readonly string[] LectureIntro = new string[]
  {
    string.Empty,
    "The guidance counselor asks Kokona to visit her office after school ends...",
    "The guidance counselor asks Kokona to visit her office after school ends...",
    "The guidance counselor asks Kokona to visit her office after school ends...",
    "The guidance counselor asks Kokona to visit her office after school ends...",
    "The guidance counselor asks Kokona to visit her office after school ends..."
  };

  // Token: 0x040005ED RID: 1517
  public readonly string[] RivalText = new string[]
  {
    string.Empty,
    "It...it's not what you think...I was just...um...",
    "No! I'm not the one who did this! I would never steal from anyone!",
    "Huh? I don't smoke! I don't know why something like this was in my bag!",
    "What?! I've never taken any pictures like that! How did this get on my phone?!",
    "I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my desk!",
    "No! Please! Don't do this!"
  };

  // Token: 0x040005EE RID: 1518
  public UILabel[] Labels;

  // Token: 0x040005EF RID: 1519
  public Transform CounselorWindow;

  // Token: 0x040005F0 RID: 1520
  public Transform Highlight;

  // Token: 0x040005F1 RID: 1521
  public Transform Chibi;

  // Token: 0x040005F2 RID: 1522
  public SkinnedMeshRenderer Face;

  // Token: 0x040005F3 RID: 1523
  public UILabel CounselorSubtitle;

  // Token: 0x040005F4 RID: 1524
  public UISprite EndOfDayDarkness;

  // Token: 0x040005F5 RID: 1525
  public UILabel LectureSubtitle;

  // Token: 0x040005F6 RID: 1526
  public UISprite ExpelProgress;

  // Token: 0x040005F7 RID: 1527
  public UILabel LectureLabel;

  // Token: 0x040005F8 RID: 1528
  public bool ShowWindow;

  // Token: 0x040005F9 RID: 1529
  public bool Lecturing;

  // Token: 0x040005FA RID: 1530
  public bool Angry;

  // Token: 0x040005FB RID: 1531
  public bool Busy;

  // Token: 0x040005FC RID: 1532
  public int Selected = 1;

  // Token: 0x040005FD RID: 1533
  public int LecturePhase = 1;

  // Token: 0x040005FE RID: 1534
  public int LectureID = 5;

  // Token: 0x040005FF RID: 1535
  public float Anger;

  // Token: 0x04000600 RID: 1536
  public float ExpelTimer;

  // Token: 0x04000601 RID: 1537
  public float ChinTimer;

  // Token: 0x04000602 RID: 1538
  public float Timer;

  // Token: 0x04000603 RID: 1539
  public Vector3 LookAtTarget;

  // Token: 0x04000604 RID: 1540
  public bool LookAtPlayer;

  // Token: 0x04000605 RID: 1541
  public Transform Default;

  // Token: 0x04000606 RID: 1542
  public Transform Head;
}