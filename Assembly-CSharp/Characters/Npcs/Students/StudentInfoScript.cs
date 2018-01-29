using System.IO;
using UnityEngine;

// Token: 0x020001C7 RID: 455
public class StudentInfoScript : MonoBehaviour {

  // Token: 0x060007E4 RID: 2020 RVA: 0x00079CCC File Offset: 0x000780CC
  private void Start() {
    this.Topics.SetActive(false);
    if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt")) {
      string a = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
      if (a == "1") {
        this.CustomPortraits = true;
      }
    }
  }

  // Token: 0x060007E5 RID: 2021 RVA: 0x00079D2C File Offset: 0x0007812C
  public void UpdateInfo(int ID) {
    StudentJson studentJson = this.JSON.Students[ID];
    this.NameLabel.text = studentJson.Name;
    if (StudentGlobals.GetStudentReputation(ID) < 0) {
      this.ReputationLabel.text = StudentGlobals.GetStudentReputation(ID).ToString();
    } else if (StudentGlobals.GetStudentReputation(ID) > 0) {
      this.ReputationLabel.text = "+" + StudentGlobals.GetStudentReputation(ID).ToString();
    } else {
      this.ReputationLabel.text = "0";
    }
    this.ReputationBar.localPosition = new Vector3((float)StudentGlobals.GetStudentReputation(ID) * 0.96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    if (this.ReputationBar.localPosition.x > 96f) {
      this.ReputationBar.localPosition = new Vector3(96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    }
    if (this.ReputationBar.localPosition.x < -96f) {
      this.ReputationBar.localPosition = new Vector3(-96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    }
    this.PersonaLabel.text = Persona.PersonaNames[studentJson.Persona];
    if (studentJson.Persona == PersonaType.Strict && studentJson.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID)) {
      this.PersonaLabel.text = "Friendly but Strict";
    }
    if (studentJson.Crush == 0) {
      this.CrushLabel.text = "None";
    } else if (studentJson.Crush == 99) {
      this.CrushLabel.text = "?????";
    } else {
      this.CrushLabel.text = this.JSON.Students[studentJson.Crush].Name;
    }
    if (studentJson.Club < ClubType.Teacher) {
      this.OccupationLabel.text = "Club";
    } else {
      this.OccupationLabel.text = "Occupation";
    }
    if (studentJson.Club < ClubType.Teacher) {
      this.ClubLabel.text = Club.ClubNames[studentJson.Club];
    } else {
      this.ClubLabel.text = Club.TeacherClubNames[studentJson.Class];
    }
    if (ClubGlobals.GetClubClosed(studentJson.Club)) {
      this.ClubLabel.text = "No Club";
    }
    this.StrengthLabel.text = StudentInfoScript.StrengthStrings[studentJson.Strength];
    AudioSource component = base.GetComponent<AudioSource>();
    this.Static.SetActive(false);
    component.volume = 0f;
    if (ID < 98) {
      string url = string.Concat(new string[]
      {
        "file:///",
        Application.streamingAssetsPath,
        "/Portraits/Student_",
        ID.ToString(),
        ".png"
      });
      WWW www = new WWW(url);
      if (!StudentGlobals.GetStudentReplaced(ID)) {
        if (!this.CustomPortraits) {
          this.Portrait.mainTexture = ((ID >= 33 && ID <= 85) ? this.BlankPortrait : www.texture);
        } else {
          this.Portrait.mainTexture = www.texture;
        }
      } else {
        this.Portrait.mainTexture = this.BlankPortrait;
      }
    } else if (ID == 98) {
      this.Portrait.mainTexture = this.GuidanceCounselor;
    } else if (ID == 99) {
      this.Portrait.mainTexture = this.Headmaster;
    } else if (ID == 100) {
      this.Portrait.mainTexture = this.InfoChan;
      this.Static.SetActive(true);
      if (!this.StudentInfoMenu.Gossiping && !this.StudentInfoMenu.Distracting && !this.StudentInfoMenu.CyberBullying) {
        component.enabled = true;
        component.volume = 1f;
        component.Play();
      }
    }
    this.UpdateAdditionalInfo(ID);
    this.CurrentStudent = ID;
  }

  // Token: 0x060007E6 RID: 2022 RVA: 0x0007A1D4 File Offset: 0x000785D4
  private void Update() {
    if (Input.GetButtonDown("A")) {
      if (this.StudentInfoMenu.Gossiping) {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.Gossiping = false;
        base.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else if (this.StudentInfoMenu.Distracting) {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.Distracting = false;
        base.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else if (this.StudentInfoMenu.CyberBullying) {
        this.HomeInternet.PostLabels[1].text = this.JSON.Students[this.CurrentStudent].Name;
        this.HomeInternet.Student = this.CurrentStudent;
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.StudentInfoMenu.CyberBullying = false;
        base.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else if (this.StudentInfoMenu.MatchMaking) {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.MatchMaking = false;
        base.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else if (this.StudentInfoMenu.Targeting) {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.Yandere.TargetStudent.HuntTarget = this.StudentManager.Students[this.CurrentStudent];
        this.Yandere.TargetStudent.GoCommitMurder();
        this.Yandere.RPGCamera.enabled = true;
        this.Yandere.TargetStudent = null;
        this.StudentInfoMenu.Targeting = false;
        base.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
    }
    if (Input.GetButtonDown("B")) {
      this.Topics.SetActive(false);
      base.GetComponent<AudioSource>().Stop();
      if (this.Shutter != null) {
        if (!this.Shutter.PhotoIcons.activeInHierarchy) {
          this.Back = true;
        }
      } else {
        this.Back = true;
      }
      if (this.Back) {
        this.StudentInfoMenu.gameObject.SetActive(true);
        base.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "View Info";
        if (!this.StudentInfoMenu.Gossiping) {
          this.PromptBar.Label[1].text = "Back";
        }
        this.PromptBar.UpdateButtons();
        this.Back = false;
      }
    }
    if (Input.GetButtonDown("Y") && this.PromptBar.Button[3].enabled) {
      if (!this.Topics.activeInHierarchy) {
        this.PromptBar.Label[3].text = "Basic Info";
        this.PromptBar.UpdateButtons();
        this.Topics.SetActive(true);
        this.UpdateTopics();
      } else {
        this.PromptBar.Label[3].text = "Interests";
        this.PromptBar.UpdateButtons();
        this.Topics.SetActive(false);
      }
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      StudentGlobals.SetStudentReputation(this.CurrentStudent, StudentGlobals.GetStudentReputation(this.CurrentStudent) + 10);
      this.UpdateInfo(this.CurrentStudent);
    }
    if (Input.GetKeyDown(KeyCode.Minus)) {
      StudentGlobals.SetStudentReputation(this.CurrentStudent, StudentGlobals.GetStudentReputation(this.CurrentStudent) - 10);
      this.UpdateInfo(this.CurrentStudent);
    }
  }

  // Token: 0x060007E7 RID: 2023 RVA: 0x0007A6C8 File Offset: 0x00078AC8
  private void UpdateAdditionalInfo(int ID) {
    if (ID == 7) {
      this.Strings[1] = ((!EventGlobals.Event1) ? "?????" : "May be a victim of domestic abuse.");
      this.Strings[2] = ((!EventGlobals.Event2) ? "?????" : "May be engaging in compensated dating in Shisuta Town.");
      this.InfoLabel.text = this.Strings[1] + "\n\n" + this.Strings[2];
    } else if (!StudentGlobals.GetStudentReplaced(ID)) {
      if (this.JSON.Students[ID].Info == string.Empty) {
        this.InfoLabel.text = "No additional information is available at this time.";
      } else {
        this.InfoLabel.text = this.JSON.Students[ID].Info;
      }
    } else {
      this.InfoLabel.text = "No additional information is available at this time.";
    }
  }

  // Token: 0x060007E8 RID: 2024 RVA: 0x0007A7BC File Offset: 0x00078BBC
  private void UpdateTopics() {
    for (int i = 1; i < this.TopicIcons.Length; i++) {
      this.TopicIcons[i].spriteName = (ConversationGlobals.GetTopicDiscovered(i) ? i : 0).ToString();
    }
    for (int j = 1; j <= 25; j++) {
      UISprite uisprite = this.TopicOpinionIcons[j];
      if (!ConversationGlobals.GetTopicLearnedByStudent(j, this.CurrentStudent)) {
        uisprite.spriteName = "Unknown";
      } else {
        int[] topics = this.JSON.Topics[this.CurrentStudent].Topics;
        uisprite.spriteName = this.OpinionSpriteNames[topics[j]];
      }
    }
  }

  // Token: 0x0400144C RID: 5196
  public StudentInfoMenuScript StudentInfoMenu;

  // Token: 0x0400144D RID: 5197
  public StudentManagerScript StudentManager;

  // Token: 0x0400144E RID: 5198
  public DialogueWheelScript DialogueWheel;

  // Token: 0x0400144F RID: 5199
  public HomeInternetScript HomeInternet;

  // Token: 0x04001450 RID: 5200
  public TopicManagerScript TopicManager;

  // Token: 0x04001451 RID: 5201
  public PromptBarScript PromptBar;

  // Token: 0x04001452 RID: 5202
  public ShutterScript Shutter;

  // Token: 0x04001453 RID: 5203
  public YandereScript Yandere;

  // Token: 0x04001454 RID: 5204
  public JsonScript JSON;

  // Token: 0x04001455 RID: 5205
  public Texture GuidanceCounselor;

  // Token: 0x04001456 RID: 5206
  public Texture DefaultPortrait;

  // Token: 0x04001457 RID: 5207
  public Texture BlankPortrait;

  // Token: 0x04001458 RID: 5208
  public Texture Headmaster;

  // Token: 0x04001459 RID: 5209
  public Texture InfoChan;

  // Token: 0x0400145A RID: 5210
  public Transform ReputationBar;

  // Token: 0x0400145B RID: 5211
  public GameObject Static;

  // Token: 0x0400145C RID: 5212
  public GameObject Topics;

  // Token: 0x0400145D RID: 5213
  public UILabel OccupationLabel;

  // Token: 0x0400145E RID: 5214
  public UILabel ReputationLabel;

  // Token: 0x0400145F RID: 5215
  public UILabel StrengthLabel;

  // Token: 0x04001460 RID: 5216
  public UILabel PersonaLabel;

  // Token: 0x04001461 RID: 5217
  public UILabel CrushLabel;

  // Token: 0x04001462 RID: 5218
  public UILabel ClubLabel;

  // Token: 0x04001463 RID: 5219
  public UILabel InfoLabel;

  // Token: 0x04001464 RID: 5220
  public UILabel NameLabel;

  // Token: 0x04001465 RID: 5221
  public UITexture Portrait;

  // Token: 0x04001466 RID: 5222
  public string[] OpinionSpriteNames;

  // Token: 0x04001467 RID: 5223
  public string[] Strings;

  // Token: 0x04001468 RID: 5224
  public int CurrentStudent;

  // Token: 0x04001469 RID: 5225
  public bool CustomPortraits;

  // Token: 0x0400146A RID: 5226
  public bool Back;

  // Token: 0x0400146B RID: 5227
  public UISprite[] TopicIcons;

  // Token: 0x0400146C RID: 5228
  public UISprite[] TopicOpinionIcons;

  // Token: 0x0400146D RID: 5229
  private static readonly IntAndStringDictionary StrengthStrings = new IntAndStringDictionary
  {
    {
      0,
      "Incapable"
    },
    {
      1,
      "Very Weak"
    },
    {
      2,
      "Weak"
    },
    {
      3,
      "Strong"
    },
    {
      4,
      "Very Strong"
    },
    {
      5,
      "Martial Arts Master"
    },
    {
      6,
      "Extensive Training"
    },
    {
      7,
      "Carries Pepper Spray"
    },
    {
      99,
      "?????"
    }
  };
}