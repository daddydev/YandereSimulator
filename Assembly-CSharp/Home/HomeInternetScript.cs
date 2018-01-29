using UnityEngine;

// Token: 0x020000FA RID: 250
public class HomeInternetScript : MonoBehaviour {

  // Token: 0x060004ED RID: 1261 RVA: 0x00041BA0 File Offset: 0x0003FFA0
  private void Start() {
    this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, -180f, this.StudentPost1.localPosition.z);
    this.StudentPost2.localPosition = new Vector3(this.StudentPost2.localPosition.x, -365f, this.StudentPost2.localPosition.z);
    this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, -88f, this.YandereReply.localPosition.z);
    this.YanderePost.localPosition = new Vector3(this.YanderePost.localPosition.x, -2f, this.YanderePost.localPosition.z);
    for (int i = 1; i < 6; i++) {
      Transform transform = this.StudentReplies[i];
      transform.localPosition = new Vector3(transform.localPosition.x, -40f, transform.localPosition.z);
    }
    this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, -40f, this.LameReply.localPosition.z);
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.YanderePost.gameObject.SetActive(false);
    this.ChangeLabel.SetActive(false);
    this.ChangeIcon.SetActive(false);
    this.PostLabel.SetActive(false);
    this.PostIcon.SetActive(false);
    this.NewPostText.SetActive(false);
    this.BG.SetActive(false);
    if (!EventGlobals.Event2 || StudentGlobals.GetStudentExposed(7)) {
      this.WriteLabel.SetActive(false);
      this.WriteIcon.SetActive(false);
    }
    this.GetPortrait(1);
    this.StudentPost1Portrait.mainTexture = this.CurrentPortrait;
    this.GetPortrait(16);
    this.StudentPost2Portrait.mainTexture = this.CurrentPortrait;
    this.GetPortrait(6);
    this.LamePostPortrait.mainTexture = this.CurrentPortrait;
    this.ID = 1;
    while (this.ID < 6) {
      this.GetPortrait(1 + this.ID);
      this.Portraits[this.ID].mainTexture = this.CurrentPortrait;
      this.ID++;
    }
  }

  // Token: 0x060004EE RID: 1262 RVA: 0x00041E74 File Offset: 0x00040274
  private void Update() {
    if (!this.HomeYandere.CanMove && !this.PauseScreen.Show) {
      this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, (!this.ShowMenu) ? Vector3.zero : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.WritingPost) {
        this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
        this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * 10f);
        for (int i = 1; i < this.Highlights.Length; i++) {
          UISprite uisprite = this.Highlights[i];
          uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, Mathf.MoveTowards(uisprite.color.a, (!this.FadeOut) ? 1f : 0f, Time.deltaTime));
        }
        if (this.Highlights[this.Selected].color.a == 1f) {
          this.FadeOut = true;
        } else if (this.Highlights[this.Selected].color.a == 0f) {
          this.FadeOut = false;
        }
        if (!this.ShowMenu) {
          if (this.InputManager.TappedRight) {
            this.Selected++;
            this.UpdateHighlight();
          }
          if (this.InputManager.TappedLeft) {
            this.Selected--;
            this.UpdateHighlight();
          }
        } else {
          if (this.InputManager.TappedDown) {
            this.MenuSelected++;
            this.UpdateMenuHighlight();
          }
          if (this.InputManager.TappedUp) {
            this.MenuSelected--;
            this.UpdateMenuHighlight();
          }
        }
      } else {
        this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3(175f, -10f, 0f), Time.deltaTime * 10f);
        this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      if (!this.PostSequence) {
        if (Input.GetButtonDown("A") && this.WriteIcon.activeInHierarchy && !this.Posted) {
          if (!this.ShowMenu) {
            if (!this.WritingPost) {
              this.AcceptLabel.text = "Select";
              this.ChangeLabel.SetActive(true);
              this.ChangeIcon.SetActive(true);
              this.NewPostText.SetActive(true);
              this.BG.SetActive(true);
              this.WritingPost = true;
              this.Selected = 1;
              this.UpdateHighlight();
            } else if (this.Selected == 1) {
              this.PauseScreen.MainMenu.SetActive(false);
              this.PauseScreen.Panel.enabled = true;
              this.PauseScreen.Sideways = true;
              this.PauseScreen.Show = true;
              this.StudentInfoMenu.gameObject.SetActive(true);
              this.StudentInfoMenu.CyberBullying = true;
              base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "View Info";
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            } else if (this.Selected == 2) {
              this.MenuSelected = 1;
              this.UpdateMenuHighlight();
              this.ShowMenu = true;
              for (int j = 1; j < this.MenuLabels.Length; j++) {
                this.MenuLabels[j].text = this.Locations[j];
              }
            } else if (this.Selected == 3) {
              this.MenuSelected = 1;
              this.UpdateMenuHighlight();
              this.ShowMenu = true;
              for (int k = 1; k < this.MenuLabels.Length; k++) {
                this.MenuLabels[k].text = this.Actions[k];
              }
            }
          } else {
            if (this.Selected == 2) {
              this.Location = this.MenuSelected;
              this.PostLabels[2].text = this.Locations[this.MenuSelected];
              this.ShowMenu = false;
            } else if (this.Selected == 3) {
              this.Action = this.MenuSelected;
              this.PostLabels[3].text = this.Actions[this.MenuSelected];
              this.ShowMenu = false;
            }
            this.CheckForCompletion();
          }
        }
        if (Input.GetButtonDown("B")) {
          if (!this.ShowMenu) {
            if (!this.WritingPost) {
              this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
              this.HomeCamera.Target = this.HomeCamera.Targets[0];
              this.HomeYandere.CanMove = true;
              this.HomeWindow.Show = false;
              base.enabled = false;
            } else {
              this.AcceptLabel.text = "Write";
              this.ChangeLabel.SetActive(false);
              this.ChangeIcon.SetActive(false);
              this.PostLabel.SetActive(false);
              this.PostIcon.SetActive(false);
              this.ExitPost();
            }
          } else {
            this.ShowMenu = false;
          }
        }
        if (Input.GetButtonDown("X") && this.PostIcon.activeInHierarchy) {
          this.YanderePostLabel.text = string.Concat(new string[]
          {
            "Today, I saw ",
            this.PostLabels[1].text,
            " in ",
            this.PostLabels[2].text,
            ". She was ",
            this.PostLabels[3].text,
            "."
          });
          this.ExitPost();
          this.InternetPrompts.SetActive(false);
          this.ChangeLabel.SetActive(false);
          this.ChangeIcon.SetActive(false);
          this.WriteLabel.SetActive(false);
          this.WriteIcon.SetActive(false);
          this.PostLabel.SetActive(false);
          this.PostIcon.SetActive(false);
          this.PostSequence = true;
          this.Posted = true;
          if (this.Student == 7 && this.Location == 7 && this.Action == 9) {
            this.Success = true;
          }
        }
      }
      if (this.PostSequence) {
        if (Input.GetButtonDown("A")) {
          this.Timer += 2f;
        }
        this.Timer += Time.deltaTime;
        if (this.Timer > 1f && this.Timer < 3f) {
          this.YanderePost.gameObject.SetActive(true);
          this.YanderePost.transform.localPosition = new Vector3(this.YanderePost.transform.localPosition.x, Mathf.Lerp(this.YanderePost.transform.localPosition.y, -155f, Time.deltaTime * 10f), this.YanderePost.transform.localPosition.z);
          this.StudentPost1.transform.localPosition = new Vector3(this.StudentPost1.transform.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -365f, Time.deltaTime * 10f), this.StudentPost1.transform.localPosition.z);
          this.StudentPost2.transform.localPosition = new Vector3(this.StudentPost2.transform.localPosition.x, Mathf.Lerp(this.StudentPost2.transform.localPosition.y, -550f, Time.deltaTime * 10f), this.StudentPost2.transform.localPosition.z);
        }
        if (!this.Success) {
          if (this.Timer > 3f && this.Timer < 5f) {
            this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, Mathf.Lerp(this.LameReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), this.LameReply.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
            this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
          }
          if (this.Timer > 5f) {
            PlayerGlobals.Reputation -= 5f;
            this.InternetPrompts.SetActive(true);
            this.PostSequence = false;
          }
        } else {
          if (this.Timer > 3f && this.Timer < 5f) {
            Transform transform = this.StudentReplies[1];
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
            this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
          }
          if (this.Timer > 5f && this.Timer < 7f) {
            Transform transform2 = this.StudentReplies[2];
            transform2.localPosition = new Vector3(transform2.localPosition.x, Mathf.Lerp(transform2.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform2.localPosition.z);
            Transform transform3 = this.StudentReplies[1];
            transform3.localPosition = new Vector3(transform3.localPosition.x, Mathf.Lerp(transform3.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform3.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -185f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
            this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -465f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
          }
          if (this.Timer > 7f && this.Timer < 9f) {
            Transform transform4 = this.StudentReplies[3];
            transform4.localPosition = new Vector3(transform4.localPosition.x, Mathf.Lerp(transform4.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform4.localPosition.z);
            Transform transform5 = this.StudentReplies[2];
            transform5.localPosition = new Vector3(transform5.localPosition.x, Mathf.Lerp(transform5.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform5.localPosition.z);
            Transform transform6 = this.StudentReplies[1];
            transform6.localPosition = new Vector3(transform6.localPosition.x, Mathf.Lerp(transform6.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform6.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -233f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
            this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -510f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
          }
          if (this.Timer > 9f && this.Timer < 11f) {
            Transform transform7 = this.StudentReplies[4];
            transform7.localPosition = new Vector3(transform7.localPosition.x, Mathf.Lerp(transform7.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform7.localPosition.z);
            Transform transform8 = this.StudentReplies[3];
            transform8.localPosition = new Vector3(transform8.localPosition.x, Mathf.Lerp(transform8.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform8.localPosition.z);
            Transform transform9 = this.StudentReplies[2];
            transform9.localPosition = new Vector3(transform9.localPosition.x, Mathf.Lerp(transform9.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform9.localPosition.z);
            Transform transform10 = this.StudentReplies[1];
            transform10.localPosition = new Vector3(transform10.localPosition.x, Mathf.Lerp(transform10.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform10.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -281f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
            this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -560f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
          }
          if (this.Timer > 11f && this.Timer < 13f) {
            Transform transform11 = this.StudentReplies[5];
            transform11.localPosition = new Vector3(transform11.localPosition.x, Mathf.Lerp(transform11.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform11.localPosition.z);
            Transform transform12 = this.StudentReplies[4];
            transform12.localPosition = new Vector3(transform12.localPosition.x, Mathf.Lerp(transform12.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform12.localPosition.z);
            Transform transform13 = this.StudentReplies[3];
            transform13.localPosition = new Vector3(transform13.localPosition.x, Mathf.Lerp(transform13.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform13.localPosition.z);
            Transform transform14 = this.StudentReplies[2];
            transform14.localPosition = new Vector3(transform14.localPosition.x, Mathf.Lerp(transform14.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform14.localPosition.z);
            Transform transform15 = this.StudentReplies[1];
            transform15.localPosition = new Vector3(transform15.localPosition.x, Mathf.Lerp(transform15.transform.localPosition.y, -280f, Time.deltaTime * 10f), transform15.localPosition.z);
            this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -329f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          }
          if (this.Timer > 13f) {
            StudentGlobals.SetStudentExposed(7, true);
            StudentGlobals.SetStudentReputation(7, StudentGlobals.GetStudentReputation(7) - 50);
            this.InternetPrompts.SetActive(true);
            this.PostSequence = false;
          }
        }
      }
    }
    if (Input.GetKeyDown(KeyCode.Space)) {
      StudentGlobals.SetStudentExposed(7, false);
    }
  }

  // Token: 0x060004EF RID: 1263 RVA: 0x00043390 File Offset: 0x00041790
  private void ExitPost() {
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.NewPostText.SetActive(false);
    this.BG.SetActive(false);
    this.PostLabels[1].text = string.Empty;
    this.PostLabels[2].text = string.Empty;
    this.PostLabels[3].text = string.Empty;
    this.WritingPost = false;
  }

  // Token: 0x060004F0 RID: 1264 RVA: 0x0004341C File Offset: 0x0004181C
  private void UpdateHighlight() {
    if (this.Selected > 3) {
      this.Selected = 1;
    }
    if (this.Selected < 1) {
      this.Selected = 3;
    }
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.Highlights[this.Selected].enabled = true;
  }

  // Token: 0x060004F1 RID: 1265 RVA: 0x0004348C File Offset: 0x0004188C
  private void UpdateMenuHighlight() {
    if (this.MenuSelected > 10) {
      this.MenuSelected = 1;
    }
    if (this.MenuSelected < 1) {
      this.MenuSelected = 10;
    }
    this.MenuHighlight.transform.localPosition = new Vector3(this.MenuHighlight.transform.localPosition.x, 220f - 40f * (float)this.MenuSelected, this.MenuHighlight.transform.localPosition.z);
  }

  // Token: 0x060004F2 RID: 1266 RVA: 0x0004351C File Offset: 0x0004191C
  private void CheckForCompletion() {
    if (this.PostLabels[1].text != string.Empty && this.PostLabels[2].text != string.Empty && this.PostLabels[3].text != string.Empty) {
      this.PostLabel.SetActive(true);
      this.PostIcon.SetActive(true);
    }
  }

  // Token: 0x060004F3 RID: 1267 RVA: 0x00043598 File Offset: 0x00041998
  private void GetPortrait(int ID) {
    string url = string.Concat(new string[]
    {
      "file:///",
      Application.streamingAssetsPath,
      "/Portraits/Student_",
      ID.ToString(),
      ".png"
    });
    WWW www = new WWW(url);
    this.CurrentPortrait = www.texture;
  }

  // Token: 0x04000B36 RID: 2870
  public StudentInfoMenuScript StudentInfoMenu;

  // Token: 0x04000B37 RID: 2871
  public InputManagerScript InputManager;

  // Token: 0x04000B38 RID: 2872
  public PauseScreenScript PauseScreen;

  // Token: 0x04000B39 RID: 2873
  public PromptBarScript PromptBar;

  // Token: 0x04000B3A RID: 2874
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B3B RID: 2875
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B3C RID: 2876
  public HomeWindowScript HomeWindow;

  // Token: 0x04000B3D RID: 2877
  public UILabel YanderePostLabel;

  // Token: 0x04000B3E RID: 2878
  public UILabel AcceptLabel;

  // Token: 0x04000B3F RID: 2879
  public GameObject InternetPrompts;

  // Token: 0x04000B40 RID: 2880
  public GameObject NewPostText;

  // Token: 0x04000B41 RID: 2881
  public GameObject ChangeLabel;

  // Token: 0x04000B42 RID: 2882
  public GameObject ChangeIcon;

  // Token: 0x04000B43 RID: 2883
  public GameObject WriteLabel;

  // Token: 0x04000B44 RID: 2884
  public GameObject WriteIcon;

  // Token: 0x04000B45 RID: 2885
  public GameObject PostLabel;

  // Token: 0x04000B46 RID: 2886
  public GameObject PostIcon;

  // Token: 0x04000B47 RID: 2887
  public GameObject BG;

  // Token: 0x04000B48 RID: 2888
  public Transform MenuHighlight;

  // Token: 0x04000B49 RID: 2889
  public Transform StudentPost1;

  // Token: 0x04000B4A RID: 2890
  public Transform StudentPost2;

  // Token: 0x04000B4B RID: 2891
  public Transform YandereReply;

  // Token: 0x04000B4C RID: 2892
  public Transform YanderePost;

  // Token: 0x04000B4D RID: 2893
  public Transform LameReply;

  // Token: 0x04000B4E RID: 2894
  public Transform NewPost;

  // Token: 0x04000B4F RID: 2895
  public Transform Menu;

  // Token: 0x04000B50 RID: 2896
  public Transform[] StudentReplies;

  // Token: 0x04000B51 RID: 2897
  public UISprite[] Highlights;

  // Token: 0x04000B52 RID: 2898
  public UILabel[] PostLabels;

  // Token: 0x04000B53 RID: 2899
  public UILabel[] MenuLabels;

  // Token: 0x04000B54 RID: 2900
  public string[] Locations;

  // Token: 0x04000B55 RID: 2901
  public string[] Actions;

  // Token: 0x04000B56 RID: 2902
  public bool PostSequence;

  // Token: 0x04000B57 RID: 2903
  public bool WritingPost;

  // Token: 0x04000B58 RID: 2904
  public bool ShowMenu;

  // Token: 0x04000B59 RID: 2905
  public bool FadeOut;

  // Token: 0x04000B5A RID: 2906
  public bool Success;

  // Token: 0x04000B5B RID: 2907
  public bool Posted;

  // Token: 0x04000B5C RID: 2908
  public int MenuSelected = 1;

  // Token: 0x04000B5D RID: 2909
  public int Selected = 1;

  // Token: 0x04000B5E RID: 2910
  public int ID = 1;

  // Token: 0x04000B5F RID: 2911
  public int Location;

  // Token: 0x04000B60 RID: 2912
  public int Student;

  // Token: 0x04000B61 RID: 2913
  public int Action;

  // Token: 0x04000B62 RID: 2914
  public float Timer;

  // Token: 0x04000B63 RID: 2915
  public UITexture StudentPost1Portrait;

  // Token: 0x04000B64 RID: 2916
  public UITexture StudentPost2Portrait;

  // Token: 0x04000B65 RID: 2917
  public UITexture LamePostPortrait;

  // Token: 0x04000B66 RID: 2918
  public Texture CurrentPortrait;

  // Token: 0x04000B67 RID: 2919
  public UITexture[] Portraits;
}