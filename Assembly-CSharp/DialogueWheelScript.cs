using UnityEngine;

// Token: 0x02000089 RID: 137
public class DialogueWheelScript : MonoBehaviour {

  // Token: 0x06000223 RID: 547 RVA: 0x0002C124 File Offset: 0x0002A524
  private void Start() {
    this.Interaction.localScale = new Vector3(1f, 1f, 1f);
    this.Favors.localScale = Vector3.zero;
    this.Club.localScale = Vector3.zero;
    this.Love.localScale = Vector3.zero;
    base.transform.localScale = Vector3.zero;
  }

  // Token: 0x06000224 RID: 548 RVA: 0x0002C190 File Offset: 0x0002A590
  private void Update() {
    if (!this.Show) {
      if (base.transform.localScale.x > 0.1f) {
        base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.Panel.enabled) {
        base.transform.localScale = Vector3.zero;
        this.Panel.enabled = false;
      }
    } else {
      if (this.ClubLeader) {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.AskingFavor) {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.Matchmaking) {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      } else {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Mouse X");
      this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Mouse Y");
      if (this.MouseDelta.x > 11f) {
        this.MouseDelta.x = 11f;
      } else if (this.MouseDelta.x < -11f) {
        this.MouseDelta.x = -11f;
      }
      if (this.MouseDelta.y > 11f) {
        this.MouseDelta.y = 11f;
      } else if (this.MouseDelta.y < -11f) {
        this.MouseDelta.y = -11f;
      }
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (!this.AskingFavor && !this.Matchmaking) {
        if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) {
          this.Selected = 0;
        }
        if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > 10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f)) {
          this.Selected = 1;
        }
        if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y > 0f && this.MouseDelta.x > 10f)) {
          this.Selected = 2;
        }
        if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < 0f && this.MouseDelta.x > 10f)) {
          this.Selected = 3;
        }
        if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < -10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f)) {
          this.Selected = 4;
        }
        if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < 0f && this.MouseDelta.x < -10f)) {
          this.Selected = 5;
        }
        if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y > 0f && this.MouseDelta.x < -10f)) {
          this.Selected = 6;
        }
        if (!this.ClubLeader) {
          if (this.Selected == 5) {
            this.CenterLabel.text = (PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID) ? "Love" : this.Text[this.Selected]);
          } else {
            this.CenterLabel.text = this.Text[this.Selected];
          }
        } else {
          this.CenterLabel.text = this.ClubText[this.Selected];
        }
      } else {
        if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) {
          this.Selected = 0;
        }
        if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > 10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f)) {
          this.Selected = 1;
        }
        if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < 10f && this.MouseDelta.y > -10f && this.MouseDelta.x > 10f)) {
          this.Selected = 2;
        }
        if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < -10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f)) {
          this.Selected = 3;
        }
        if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < 10f && this.MouseDelta.y > -10f && this.MouseDelta.x < -10f)) {
          this.Selected = 4;
        }
        if (this.Selected < this.FavorText.Length) {
          this.CenterLabel.text = ((!this.AskingFavor) ? this.LoveText[this.Selected] : this.FavorText[this.Selected]);
        }
      }
      if (!this.ClubLeader) {
        for (int i = 1; i < 7; i++) {
          Transform transform = this.Segment[i].transform;
          transform.localScale = Vector3.Lerp(transform.localScale, (this.Selected != i) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
        }
      } else {
        for (int j = 1; j < 7; j++) {
          Transform transform2 = this.ClubSegment[j].transform;
          transform2.localScale = Vector3.Lerp(transform2.localScale, (this.Selected != j) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
        }
      }
      if (!this.Matchmaking) {
        for (int k = 1; k < 5; k++) {
          Transform transform3 = this.FavorSegment[k].transform;
          transform3.localScale = Vector3.Lerp(transform3.localScale, (this.Selected != k) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
        }
      } else {
        for (int l = 1; l < 5; l++) {
          Transform transform4 = this.LoveSegment[l].transform;
          transform4.localScale = Vector3.Lerp(transform4.localScale, (this.Selected != l) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
        }
      }
      if (Input.GetButtonDown("A")) {
        if (this.ClubLeader) {
          if (this.Selected != 0 && this.ClubShadow[this.Selected].color.a == 0f) {
            if (this.Selected == 1) {
              this.Impatience.fillAmount = 0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubInfo;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = 1;
              this.Show = false;
            }
            if (this.Selected == 2) {
              this.Impatience.fillAmount = 0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Show = false;
              this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
              if (ClubGlobals.GetQuitClub(this.Yandere.TargetStudent.Club)) {
                this.Yandere.TargetStudent.ClubPhase = 4;
              } else if (ClubGlobals.Club != ClubType.None) {
                this.Yandere.TargetStudent.ClubPhase = 5;
              } else if (this.ClubManager.ClubGrudge) {
                this.Yandere.TargetStudent.ClubPhase = 6;
              } else {
                this.Yandere.TargetStudent.ClubPhase = 1;
              }
            }
            if (this.Selected == 3) {
              this.Impatience.fillAmount = 0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = 1;
              this.Show = false;
            }
            if (this.Selected == 4) {
              this.Impatience.fillAmount = 0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubBye;
              this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[(int)this.Yandere.TargetStudent.Club].length;
              this.Show = false;
            }
            if (this.Selected == 5) {
              this.Impatience.fillAmount = 0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              if (this.Clock.HourTime < 17f) {
                this.Yandere.TargetStudent.ClubPhase = 4;
              } else if (this.Clock.HourTime > 17.5f) {
                this.Yandere.TargetStudent.ClubPhase = 5;
              } else {
                this.Yandere.TargetStudent.ClubPhase = 1;
              }
              this.Show = false;
            }
            if (this.Selected == 6) {
            }
          }
        } else if (this.AskingFavor) {
          if (this.Selected != 0) {
            if (this.Selected < this.FavorShadow.Length && this.FavorShadow[this.Selected] != null && this.FavorShadow[this.Selected].color.a == 0f) {
              if (this.Selected == 1) {
                this.Impatience.fillAmount = 0f;
                this.Yandere.Interaction = YandereInteractionType.FollowMe;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
              if (this.Selected == 2) {
                this.Impatience.fillAmount = 0f;
                this.Yandere.Interaction = YandereInteractionType.GoAway;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
              if (this.Selected == 4) {
                this.PauseScreen.StudentInfoMenu.Distracting = true;
                this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
                this.PauseScreen.StudentInfoMenu.Column = 0;
                this.PauseScreen.StudentInfoMenu.Row = 0;
                this.PauseScreen.StudentInfoMenu.UpdateHighlight();
                base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
                this.PauseScreen.MainMenu.SetActive(false);
                this.PauseScreen.Panel.enabled = true;
                this.PauseScreen.Sideways = true;
                this.PauseScreen.Show = true;
                Time.timeScale = 0f;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Cancel";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.Impatience.fillAmount = 0f;
                this.Yandere.Interaction = YandereInteractionType.DistractThem;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
            }
            if (this.Selected == 3) {
              this.AskingFavor = false;
            }
          }
        } else if (this.Matchmaking) {
          if (this.Selected != 0) {
            if (this.Selected < this.LoveShadow.Length && this.LoveShadow[this.Selected] != null && this.LoveShadow[this.Selected].color.a == 0f) {
              if (this.Selected == 1) {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Select";
                this.PromptBar.Label[4].text = "Change";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.AppearanceWindow.gameObject.SetActive(true);
                this.AppearanceWindow.Show = true;
                this.Show = false;
              }
              if (this.Selected == 2) {
                this.Impatience.fillAmount = 0f;
                this.Yandere.Interaction = YandereInteractionType.Court;
                this.Yandere.TalkTimer = 5f;
                this.Show = false;
              }
              if (this.Selected == 4) {
                this.Impatience.fillAmount = 0f;
                this.Yandere.Interaction = YandereInteractionType.Confess;
                this.Yandere.TalkTimer = 5f;
                this.Show = false;
              }
            }
            if (this.Selected == 3) {
              this.Matchmaking = false;
            }
          }
        } else if (this.Selected != 0 && this.Shadow[this.Selected].color.a == 0f) {
          if (this.Selected == 1) {
            this.Impatience.fillAmount = 0f;
            this.Yandere.Interaction = YandereInteractionType.Apologizing;
            this.Yandere.TalkTimer = 3f;
            this.Show = false;
          }
          if (this.Selected == 2) {
            this.Impatience.fillAmount = 0f;
            this.Yandere.Interaction = YandereInteractionType.Compliment;
            this.Yandere.TalkTimer = 3f;
            this.Show = false;
          }
          if (this.Selected == 3) {
            this.PauseScreen.StudentInfoMenu.Gossiping = true;
            this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.PauseScreen.StudentInfoMenu.Column = 0;
            this.PauseScreen.StudentInfoMenu.Row = 0;
            this.PauseScreen.StudentInfoMenu.UpdateHighlight();
            base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
            this.PauseScreen.MainMenu.SetActive(false);
            this.PauseScreen.Panel.enabled = true;
            this.PauseScreen.Sideways = true;
            this.PauseScreen.Show = true;
            Time.timeScale = 0f;
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = string.Empty;
            this.PromptBar.Label[1].text = "Cancel";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.Impatience.fillAmount = 0f;
            this.Yandere.Interaction = YandereInteractionType.Gossip;
            this.Yandere.TalkTimer = 3f;
            this.Show = false;
          }
          if (this.Selected == 4) {
            this.Impatience.fillAmount = 0f;
            this.Yandere.Interaction = YandereInteractionType.Bye;
            this.Yandere.TalkTimer = 2f;
            this.Show = false;
          }
          if (this.Selected == 5) {
            if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID)) {
              this.CheckTaskCompletion();
              if (this.Yandere.TargetStudent.TaskPhase == 0) {
                this.Impatience.fillAmount = 0f;
                this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
                this.Yandere.TargetStudent.TalkTimer = 100f;
                this.Yandere.TargetStudent.TaskPhase = 1;
              } else {
                this.Impatience.fillAmount = 0f;
                this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
                this.Yandere.TargetStudent.TalkTimer = 100f;
              }
              this.Show = false;
            } else if (this.Yandere.LoveManager.SuitorProgress == 0) {
              this.PauseScreen.StudentInfoMenu.MatchMaking = true;
              this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
              this.PauseScreen.StudentInfoMenu.Column = 0;
              this.PauseScreen.StudentInfoMenu.Row = 0;
              this.PauseScreen.StudentInfoMenu.UpdateHighlight();
              base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
              this.PauseScreen.MainMenu.SetActive(false);
              this.PauseScreen.Panel.enabled = true;
              this.PauseScreen.Sideways = true;
              this.PauseScreen.Show = true;
              Time.timeScale = 0f;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "View Info";
              this.PromptBar.Label[1].text = "Cancel";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Impatience.fillAmount = 0f;
              this.Yandere.Interaction = YandereInteractionType.NamingCrush;
              this.Yandere.TalkTimer = 3f;
              this.Show = false;
            } else {
              this.Matchmaking = true;
            }
          }
          if (this.Selected == 6) {
            this.AskingFavor = true;
          }
        }
      }
    }
    this.PreviousPosition = Input.mousePosition;
  }

  // Token: 0x06000225 RID: 549 RVA: 0x0002D9A0 File Offset: 0x0002BDA0
  public void HideShadows() {
    this.TaskIcon.spriteName = ((!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID)) ? "Task" : "Heart");
    this.Impatience.fillAmount = 0f;
    for (int i = 1; i < 7; i++) {
      UISprite uisprite = this.Shadow[i];
      uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
    }
    for (int j = 1; j < 5; j++) {
      UISprite uisprite2 = this.FavorShadow[j];
      uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
    }
    for (int k = 1; k < 7; k++) {
      UISprite uisprite3 = this.ClubShadow[k];
      uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0f);
    }
    for (int l = 1; l < 5; l++) {
      UISprite uisprite4 = this.LoveShadow[l];
      uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0f);
    }
    if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite5 = this.Shadow[1];
      uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.Complimented || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite6 = this.Shadow[2];
      uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.Gossiped || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite7 = this.Shadow[3];
      uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.75f);
    }
    if (this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.33333f || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite8 = this.Shadow[3];
      uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.75f);
      UISprite uisprite9 = this.Shadow[5];
      uisprite9.color = new Color(uisprite9.color.r, uisprite9.color.g, uisprite9.color.b, 0.75f);
      UISprite uisprite10 = this.Shadow[6];
      uisprite10.color = new Color(uisprite10.color.r, uisprite10.color.g, uisprite10.color.b, 0.75f);
    } else if (this.Reputation.Reputation < -33.33333f) {
      UISprite uisprite11 = this.Shadow[3];
      uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite12 = this.Shadow[5];
      uisprite12.color = new Color(uisprite12.color.r, uisprite12.color.g, uisprite12.color.b, 0.75f);
    } else if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID)) {
      if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13 && this.Yandere.TargetStudent.StudentID != 14 && this.Yandere.TargetStudent.StudentID != 15 && this.Yandere.TargetStudent.StudentID != 32 && this.Yandere.TargetStudent.StudentID != 33) {
        UISprite uisprite13 = this.Shadow[5];
        uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 0.75f);
      } else {
        if (this.Yandere.TargetStudent.TaskPhase > 0 && this.Yandere.TargetStudent.TaskPhase < 5) {
          UISprite uisprite14 = this.Shadow[5];
          uisprite14.color = new Color(uisprite14.color.r, uisprite14.color.g, uisprite14.color.b, 0.75f);
        }
        if (this.Yandere.TargetStudent.StudentID == 32) {
          if (this.Clock.Period != 3 || this.Yandere.TargetStudent.DistanceToDestination > 1f) {
            UISprite uisprite15 = this.Shadow[5];
            uisprite15.color = new Color(uisprite15.color.r, uisprite15.color.g, uisprite15.color.b, 0.75f);
          } else if (TaskGlobals.GetTaskStatus(32) == 1 && this.Yandere.Inventory.Cigs) {
            UISprite uisprite16 = this.Shadow[5];
            uisprite16.color = new Color(uisprite16.color.r, uisprite16.color.g, uisprite16.color.b, 0f);
          }
        }
      }
    } else if (this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13) {
      UISprite uisprite17 = this.Shadow[5];
      uisprite17.color = new Color(uisprite17.color.r, uisprite17.color.g, uisprite17.color.b, 0.75f);
    } else if (!this.Yandere.TargetStudent.Male && this.LoveManager.SuitorProgress == 0) {
      UISprite uisprite18 = this.Shadow[5];
      uisprite18.color = new Color(uisprite18.color.r, uisprite18.color.g, uisprite18.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council) {
      UISprite uisprite19 = this.Shadow[6];
      uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 0.75f);
    } else {
      if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID)) {
        UISprite uisprite20 = this.Shadow[6];
        uisprite20.color = new Color(uisprite20.color.r, uisprite20.color.g, uisprite20.color.b, 0.75f);
      }
      if ((this.Yandere.TargetStudent.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 3) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4) {
        UISprite uisprite21 = this.Shadow[6];
        uisprite21.color = new Color(uisprite21.color.r, uisprite21.color.g, uisprite21.color.b, 0f);
      }
    }
    if (ClubGlobals.Club == this.Yandere.TargetStudent.Club) {
      UISprite uisprite22 = this.ClubShadow[1];
      uisprite22.color = new Color(uisprite22.color.r, uisprite22.color.g, uisprite22.color.b, 0.75f);
      UISprite uisprite23 = this.ClubShadow[2];
      uisprite23.color = new Color(uisprite23.color.r, uisprite23.color.g, uisprite23.color.b, 0.75f);
    }
    if (this.Yandere.ClubAttire || this.Yandere.Mask != null || this.Yandere.Gloves != null || this.Yandere.Container != null) {
      UISprite uisprite24 = this.ClubShadow[3];
      uisprite24.color = new Color(uisprite24.color.r, uisprite24.color.g, uisprite24.color.b, 0.75f);
    }
    if (ClubGlobals.Club != this.Yandere.TargetStudent.Club) {
      UISprite uisprite25 = this.ClubShadow[2];
      uisprite25.color = new Color(uisprite25.color.r, uisprite25.color.g, uisprite25.color.b, 0f);
      UISprite uisprite26 = this.ClubShadow[3];
      uisprite26.color = new Color(uisprite26.color.r, uisprite26.color.g, uisprite26.color.b, 0.75f);
      UISprite uisprite27 = this.ClubShadow[5];
      uisprite27.color = new Color(uisprite27.color.r, uisprite27.color.g, uisprite27.color.b, 0.75f);
    }
    UISprite uisprite28 = this.ClubShadow[6];
    uisprite28.color = new Color(uisprite28.color.r, uisprite28.color.g, uisprite28.color.b, 0.75f);
    if (this.Yandere.Followers > 0) {
      UISprite uisprite29 = this.FavorShadow[1];
      uisprite29.color = new Color(uisprite29.color.r, uisprite29.color.g, uisprite29.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.DistanceToDestination > 0.5f) {
      UISprite uisprite30 = this.FavorShadow[2];
      uisprite30.color = new Color(uisprite30.color.r, uisprite30.color.g, uisprite30.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Male) {
      UISprite uisprite31 = this.LoveShadow[1];
      uisprite31.color = new Color(uisprite31.color.r, uisprite31.color.g, uisprite31.color.b, 0.75f);
    }
    if (this.DatingMinigame == null || !this.Yandere.Inventory.Headset || (this.Yandere.TargetStudent.Male && !this.LoveManager.RivalWaiting) || this.LoveManager.Courted) {
      UISprite uisprite32 = this.LoveShadow[2];
      uisprite32.color = new Color(uisprite32.color.r, uisprite32.color.g, uisprite32.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Male || !this.Yandere.Inventory.Rose || this.Yandere.TargetStudent.Rose) {
      UISprite uisprite33 = this.LoveShadow[4];
      uisprite33.color = new Color(uisprite33.color.r, uisprite33.color.g, uisprite33.color.b, 0.75f);
    }
  }

  // Token: 0x06000226 RID: 550 RVA: 0x0002E8A4 File Offset: 0x0002CCA4
  private void CheckTaskCompletion() {
    if (TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) == 2 && this.Yandere.TargetStudent.StudentID == 32) {
      this.Yandere.Inventory.Cigs = false;
    }
  }

  // Token: 0x06000227 RID: 551 RVA: 0x0002E8F4 File Offset: 0x0002CCF4
  public void End() {
    if (this.Yandere.TargetStudent != null) {
      if (this.Yandere.TargetStudent.Pestered >= 10) {
        this.Yandere.TargetStudent.Ignoring = true;
      }
      if (!this.Pestered) {
        this.Yandere.Subtitle.Label.text = string.Empty;
      }
      this.Yandere.TargetStudent.Interaction = StudentInteractionType.Idle;
      this.Yandere.TargetStudent.WaitTimer = 1f;
      if (this.Yandere.TargetStudent.enabled) {
        this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
        this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
        if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Patrol) {
          this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.StudentManager.Patrols.List[this.Yandere.TargetStudent.StudentID].GetChild(this.Yandere.TargetStudent.PatrolID);
          this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.CurrentDestination;
        }
      }
      this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
      this.Yandere.TargetStudent.Waiting = true;
      this.Yandere.TargetStudent = null;
    }
    this.AskingFavor = false;
    this.Matchmaking = false;
    this.ClubLeader = false;
    this.Pestered = false;
    this.Show = false;
  }

  // Token: 0x0400075C RID: 1884
  public AppearanceWindowScript AppearanceWindow;

  // Token: 0x0400075D RID: 1885
  public ClubManagerScript ClubManager;

  // Token: 0x0400075E RID: 1886
  public LoveManagerScript LoveManager;

  // Token: 0x0400075F RID: 1887
  public PauseScreenScript PauseScreen;

  // Token: 0x04000760 RID: 1888
  public TaskManagerScript TaskManager;

  // Token: 0x04000761 RID: 1889
  public ReputationScript Reputation;

  // Token: 0x04000762 RID: 1890
  public ClubWindowScript ClubWindow;

  // Token: 0x04000763 RID: 1891
  public TaskWindowScript TaskWindow;

  // Token: 0x04000764 RID: 1892
  public PromptBarScript PromptBar;

  // Token: 0x04000765 RID: 1893
  public YandereScript Yandere;

  // Token: 0x04000766 RID: 1894
  public ClockScript Clock;

  // Token: 0x04000767 RID: 1895
  public UIPanel Panel;

  // Token: 0x04000768 RID: 1896
  public GameObject DatingMinigame;

  // Token: 0x04000769 RID: 1897
  public Transform Interaction;

  // Token: 0x0400076A RID: 1898
  public Transform Favors;

  // Token: 0x0400076B RID: 1899
  public Transform Club;

  // Token: 0x0400076C RID: 1900
  public Transform Love;

  // Token: 0x0400076D RID: 1901
  public UISprite TaskIcon;

  // Token: 0x0400076E RID: 1902
  public UISprite Impatience;

  // Token: 0x0400076F RID: 1903
  public UILabel CenterLabel;

  // Token: 0x04000770 RID: 1904
  public UISprite[] Segment;

  // Token: 0x04000771 RID: 1905
  public UISprite[] Shadow;

  // Token: 0x04000772 RID: 1906
  public string[] Text;

  // Token: 0x04000773 RID: 1907
  public UISprite[] FavorSegment;

  // Token: 0x04000774 RID: 1908
  public UISprite[] FavorShadow;

  // Token: 0x04000775 RID: 1909
  public UISprite[] ClubSegment;

  // Token: 0x04000776 RID: 1910
  public UISprite[] ClubShadow;

  // Token: 0x04000777 RID: 1911
  public UISprite[] LoveSegment;

  // Token: 0x04000778 RID: 1912
  public UISprite[] LoveShadow;

  // Token: 0x04000779 RID: 1913
  public string[] FavorText;

  // Token: 0x0400077A RID: 1914
  public string[] ClubText;

  // Token: 0x0400077B RID: 1915
  public string[] LoveText;

  // Token: 0x0400077C RID: 1916
  public int Selected;

  // Token: 0x0400077D RID: 1917
  public int Victim;

  // Token: 0x0400077E RID: 1918
  public bool AskingFavor;

  // Token: 0x0400077F RID: 1919
  public bool Matchmaking;

  // Token: 0x04000780 RID: 1920
  public bool ClubLeader;

  // Token: 0x04000781 RID: 1921
  public bool Pestered;

  // Token: 0x04000782 RID: 1922
  public bool Show;

  // Token: 0x04000783 RID: 1923
  public Vector3 PreviousPosition;

  // Token: 0x04000784 RID: 1924
  public Vector2 MouseDelta;
}