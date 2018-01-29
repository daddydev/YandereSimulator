using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001C6 RID: 454
public class StudentInfoMenuScript : MonoBehaviour {

  // Token: 0x060007DE RID: 2014 RVA: 0x00078DBC File Offset: 0x000771BC
  private void Start() {
    for (int i = 1; i < 101; i++) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StudentPortrait, base.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.PortraitGrid;
      gameObject.transform.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, 0f);
      gameObject.transform.localEulerAngles = Vector3.zero;
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      this.StudentPortraits[i] = gameObject.GetComponent<StudentPortraitScript>();
      this.Column++;
      if (this.Column > 4) {
        this.Column = 0;
        this.Row++;
      }
    }
    this.Column = 0;
    this.Row = 0;
    if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt")) {
      string a = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
      if (a == "1") {
        this.CustomPortraits = true;
      }
    }
  }

  // Token: 0x060007DF RID: 2015 RVA: 0x00078F04 File Offset: 0x00077304
  private void Update() {
    if (Input.GetButtonDown("A") && this.PromptBar.Label[0].text != string.Empty && (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)) {
      this.StudentInfo.gameObject.SetActive(true);
      this.StudentInfo.UpdateInfo(this.StudentID);
      this.StudentInfo.Topics.SetActive(false);
      base.gameObject.SetActive(false);
      this.PromptBar.ClearButtons();
      if (this.Gossiping) {
        this.PromptBar.Label[0].text = "Gossip";
      }
      if (this.Distracting) {
        this.PromptBar.Label[0].text = "Distract";
      }
      if (this.CyberBullying) {
        this.PromptBar.Label[0].text = "Accept";
      }
      if (this.MatchMaking) {
        this.PromptBar.Label[0].text = "Match";
      }
      if (this.Targeting) {
        this.PromptBar.Label[0].text = "Kill";
      }
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.Label[3].text = "Interests";
      this.PromptBar.UpdateButtons();
    }
    if (Input.GetButtonDown("B")) {
      if (this.Gossiping || this.Distracting || this.MatchMaking || this.Targeting) {
        if (this.Targeting) {
          this.PauseScreen.Yandere.RPGCamera.enabled = true;
        }
        this.PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
        this.PauseScreen.Yandere.TalkTimer = 2f;
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.Show = false;
        base.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.Distracting = false;
        this.MatchMaking = false;
        this.Gossiping = false;
        this.Targeting = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else if (this.CyberBullying) {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.Show = false;
        base.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      } else {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.PressedB = true;
        base.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
    }
    float t = Time.unscaledDeltaTime * 10f;
    float num = (float)((this.Row % 2 != 0) ? ((this.Row - 1) / 2) : (this.Row / 2));
    float b = 320f * num;
    this.PortraitGrid.localPosition = new Vector3(this.PortraitGrid.localPosition.x, Mathf.Lerp(this.PortraitGrid.localPosition.y, b, t), this.PortraitGrid.localPosition.z);
    this.Scrollbar.localPosition = new Vector3(this.Scrollbar.localPosition.x, Mathf.Lerp(this.Scrollbar.localPosition.y, 175f - 350f * (this.PortraitGrid.localPosition.y / 2880f), t), this.Scrollbar.localPosition.z);
    if (this.InputManager.TappedUp) {
      this.Row--;
      if (this.Row < 0) {
        this.Row = this.Rows - 1;
      }
      this.UpdateHighlight();
    }
    if (this.InputManager.TappedDown) {
      this.Row++;
      if (this.Row > this.Rows - 1) {
        this.Row = 0;
      }
      this.UpdateHighlight();
    }
    if (this.InputManager.TappedRight) {
      this.Column++;
      if (this.Column > this.Columns - 1) {
        this.Column = 0;
      }
      this.UpdateHighlight();
    }
    if (this.InputManager.TappedLeft) {
      this.Column--;
      if (this.Column < 0) {
        this.Column = this.Columns - 1;
      }
      this.UpdateHighlight();
    }
  }

  // Token: 0x060007E0 RID: 2016 RVA: 0x00079478 File Offset: 0x00077878
  public void UpdateHighlight() {
    this.StudentID = 1 + (this.Column + this.Row * this.Columns);
    if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97) {
      this.PromptBar.Label[0].text = "View Info";
      this.PromptBar.UpdateButtons();
    } else {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Gossiping && (this.StudentID == 1 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.JSON.Students[this.StudentID].Club == ClubType.Sports || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97)) {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.CyberBullying && (this.JSON.Students[this.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97)) {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Distracting && (this.StudentID == 0 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97)) {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.MatchMaking && (this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97)) {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Targeting && (this.StudentID == 1 || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97)) {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, this.Highlight.localPosition.z);
    this.UpdateNameLabel();
  }

  // Token: 0x060007E1 RID: 2017 RVA: 0x00079788 File Offset: 0x00077B88
  private void UpdateNameLabel() {
    if (StudentGlobals.GetStudentPhotographed(this.StudentID)) {
      this.NameLabel.text = this.JSON.Students[this.StudentID].Name;
    } else {
      this.NameLabel.text = "Unknown";
    }
  }

  // Token: 0x060007E2 RID: 2018 RVA: 0x000797DC File Offset: 0x00077BDC
  public IEnumerator UpdatePortraits() {
    for (int ID = 1; ID < 101; ID++) {
      if (ID == 0) {
        this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
      } else if (!this.PortraitLoaded[ID]) {
        if (ID < 98) {
          if (StudentGlobals.GetStudentPhotographed(ID)) {
            string path = string.Concat(new string[]
            {
              "file:///",
              Application.streamingAssetsPath,
              "/Portraits/Student_",
              ID.ToString(),
              ".png"
            });
            WWW www = new WWW(path);
            yield return www;
            if (www.error == null) {
              if (!StudentGlobals.GetStudentReplaced(ID)) {
                if (!this.CustomPortraits) {
                  this.StudentPortraits[ID].Portrait.mainTexture = ((ID >= 33 && ID <= 85) ? this.BlankPortrait : www.texture);
                } else {
                  this.StudentPortraits[ID].Portrait.mainTexture = www.texture;
                }
              } else {
                this.StudentPortraits[ID].Portrait.mainTexture = this.BlankPortrait;
              }
            } else {
              this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
            }
            this.PortraitLoaded[ID] = true;
          } else {
            this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
          }
        } else if (ID == 98) {
          this.StudentPortraits[ID].Portrait.mainTexture = this.Counselor;
        } else if (ID == 99) {
          this.StudentPortraits[ID].Portrait.mainTexture = this.Headmaster;
        } else if (ID == 100) {
          this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
        }
      }
      if (PlayerGlobals.GetStudentPantyShot(this.JSON.Students[ID].Name)) {
        this.StudentPortraits[ID].Panties.SetActive(true);
      }
      this.StudentPortraits[ID].Friend.SetActive(PlayerGlobals.GetStudentFriend(ID));
      if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID)) {
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      }
      if (SceneManager.GetActiveScene().name == "SchoolScene" && this.StudentManager.Students[ID] != null && this.StudentManager.Students[ID].Tranquil) {
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      }
      if (StudentGlobals.GetStudentArrested(ID)) {
        this.StudentPortraits[ID].PrisonBars.SetActive(true);
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      }
    }
    yield break;
  }

  // Token: 0x04001428 RID: 5160
  public StudentManagerScript StudentManager;

  // Token: 0x04001429 RID: 5161
  public InputManagerScript InputManager;

  // Token: 0x0400142A RID: 5162
  public PauseScreenScript PauseScreen;

  // Token: 0x0400142B RID: 5163
  public StudentInfoScript StudentInfo;

  // Token: 0x0400142C RID: 5164
  public PromptBarScript PromptBar;

  // Token: 0x0400142D RID: 5165
  public JsonScript JSON;

  // Token: 0x0400142E RID: 5166
  public GameObject StudentPortrait;

  // Token: 0x0400142F RID: 5167
  public Texture UnknownPortrait;

  // Token: 0x04001430 RID: 5168
  public Texture BlankPortrait;

  // Token: 0x04001431 RID: 5169
  public Texture Headmaster;

  // Token: 0x04001432 RID: 5170
  public Texture Counselor;

  // Token: 0x04001433 RID: 5171
  public Texture InfoChan;

  // Token: 0x04001434 RID: 5172
  public Transform PortraitGrid;

  // Token: 0x04001435 RID: 5173
  public Transform Highlight;

  // Token: 0x04001436 RID: 5174
  public Transform Scrollbar;

  // Token: 0x04001437 RID: 5175
  public StudentPortraitScript[] StudentPortraits;

  // Token: 0x04001438 RID: 5176
  public bool[] PortraitLoaded;

  // Token: 0x04001439 RID: 5177
  public UISprite[] DeathShadows;

  // Token: 0x0400143A RID: 5178
  public UISprite[] Friends;

  // Token: 0x0400143B RID: 5179
  public UISprite[] Panties;

  // Token: 0x0400143C RID: 5180
  public UITexture[] PrisonBars;

  // Token: 0x0400143D RID: 5181
  public UITexture[] Portraits;

  // Token: 0x0400143E RID: 5182
  public UILabel NameLabel;

  // Token: 0x0400143F RID: 5183
  public bool CustomPortraits;

  // Token: 0x04001440 RID: 5184
  public bool CyberBullying;

  // Token: 0x04001441 RID: 5185
  public bool MatchMaking;

  // Token: 0x04001442 RID: 5186
  public bool Distracting;

  // Token: 0x04001443 RID: 5187
  public bool Gossiping;

  // Token: 0x04001444 RID: 5188
  public bool Targeting;

  // Token: 0x04001445 RID: 5189
  public int[] SetSizes;

  // Token: 0x04001446 RID: 5190
  public int StudentID;

  // Token: 0x04001447 RID: 5191
  public int Column;

  // Token: 0x04001448 RID: 5192
  public int Row;

  // Token: 0x04001449 RID: 5193
  public int Set;

  // Token: 0x0400144A RID: 5194
  public int Columns;

  // Token: 0x0400144B RID: 5195
  public int Rows;
}