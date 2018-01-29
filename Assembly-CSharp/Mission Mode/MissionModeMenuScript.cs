using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000002 RID: 2
public class MissionModeMenuScript : MonoBehaviour {

  // Token: 0x06000002 RID: 2 RVA: 0x000020D4 File Offset: 0x000004D4
  private void Start() {
    this.NemesisPortrait.transform.parent.localScale = Vector3.zero;
    this.CustomMissionWindow.transform.localScale = Vector3.zero;
    this.LoadMissionWindow.transform.localScale = Vector3.zero;
    this.MissionWindow.transform.localScale = Vector3.zero;
    this.Options.transform.localPosition = new Vector3(-700f, this.Options.transform.localPosition.y, this.Options.transform.localPosition.z);
    this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, 0f);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 0f);
    Time.timeScale = 1f;
    this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
    this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
    this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
    for (int i = 1; i < 6; i++) {
      Transform transform = this.Option[i].transform;
      transform.localPosition = new Vector3(-800f, transform.localPosition.y, transform.localPosition.z);
    }
    for (int j = 1; j < this.Objectives.Length; j++) {
      this.Objectives[j].localScale = Vector3.zero;
    }
    for (int k = 1; k < this.NemesisObjectives.Length; k++) {
      this.NemesisObjectives[k].localScale = Vector3.zero;
    }
    for (int l = 1; l < this.CustomObjectives.Length; l++) {
      if (this.CustomObjectives[l] != null) {
        this.CustomObjectives[l].alpha = 0.5f;
      }
    }
    if (!OptionGlobals.HighPopulation) {
      this.CustomPopulationLabel.text = "High School Population: Off";
      this.PopulationLabel.text = "High School Population: Off";
    } else {
      this.CustomPopulationLabel.text = "High School Population: On";
      this.PopulationLabel.text = "High School Population: On";
    }
  }

  // Token: 0x06000003 RID: 3 RVA: 0x00002440 File Offset: 0x00000840
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Phase == 1) {
      this.Speed += Time.deltaTime;
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime / 3f));
      if (this.Speed > 1f) {
        this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, Mathf.MoveTowards(this.Header.color.a, 1f, Time.deltaTime));
        if (this.Speed > 3f) {
          if (!this.InfoSpoke[0]) {
            component.PlayOneShot(this.InfoLines[0]);
            this.InfoSpoke[0] = true;
          }
          this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
          Transform transform = this.Option[1];
          transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, 0f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
          if ((double)this.Speed > 3.25) {
            Transform transform2 = this.Option[2];
            transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, 0f, Time.deltaTime * 10f), transform2.localPosition.y, transform2.localPosition.z);
            if (this.Speed > 3.5f) {
              Transform transform3 = this.Option[3];
              transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, 0f, Time.deltaTime * 10f), transform3.localPosition.y, transform3.localPosition.z);
              if ((double)this.Speed > 3.75) {
                Transform transform4 = this.Option[4];
                transform4.localPosition = new Vector3(Mathf.Lerp(transform4.localPosition.x, 0f, Time.deltaTime * 10f), transform4.localPosition.y, transform4.localPosition.z);
                if (this.Speed > 4f) {
                  Transform transform5 = this.Option[5];
                  transform5.localPosition = new Vector3(Mathf.Lerp(transform5.localPosition.x, 0f, Time.deltaTime * 10f), transform5.localPosition.y, transform5.localPosition.z);
                  if (this.Speed > 5f) {
                    this.PromptBar.Label[0].text = "Accept";
                    this.PromptBar.Label[4].text = "Choose";
                    this.PromptBar.UpdateButtons();
                    this.PromptBar.Show = true;
                    this.Phase++;
                  }
                }
              }
            }
          }
        }
      }
      if (Input.GetButtonDown("A")) {
        if (!this.InfoSpoke[0]) {
          component.PlayOneShot(this.InfoLines[0]);
          this.InfoSpoke[0] = true;
        }
        this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, 180f, this.InfoChan.localEulerAngles.z);
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 2f);
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
        this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 1f);
        this.Rotation = 0f;
        for (int i = 1; i < 6; i++) {
          Transform transform6 = this.Option[i];
          transform6.localPosition = new Vector3(0f, transform6.localPosition.y, transform6.localPosition.z);
        }
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -700f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      if (this.InputManager.TappedUp) {
        this.Selected--;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown) {
        this.Selected++;
        this.UpdateHighlight();
      }
      this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, Mathf.Lerp(this.Highlight.transform.localPosition.y, 150f - 50f * (float)this.Selected, Time.deltaTime * 10f), this.Highlight.transform.localPosition.z);
      this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, Mathf.MoveTowards(this.Highlight.color.a, 1f, Time.deltaTime));
      for (int j = 1; j < 6; j++) {
        if (j != this.Selected) {
          Transform transform7 = this.Option[j];
          transform7.localPosition = new Vector3(Mathf.Lerp(transform7.transform.localPosition.x, 0f, Time.deltaTime * 10f), transform7.localPosition.y, transform7.localPosition.z);
        }
      }
      Transform transform8 = this.Option[this.Selected];
      transform8.localPosition = new Vector3(Mathf.Lerp(transform8.transform.localPosition.x, 50f, Time.deltaTime * 10f), transform8.localPosition.y, transform8.localPosition.z);
      if (Input.GetButtonDown("A")) {
        if (!this.InfoSpoke[this.Selected]) {
          component.PlayOneShot(this.InfoLines[this.Selected]);
          this.InfoSpoke[this.Selected] = true;
        }
        if (this.Selected == 1) {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Accept";
          this.PromptBar.Label[1].text = "Return";
          this.PromptBar.Label[2].text = "Generate";
          this.PromptBar.Label[3].text = "Population";
          this.PromptBar.Label[4].text = "Nemesis";
          this.PromptBar.Label[5].text = "Change Difficulty";
          this.PromptBar.UpdateButtons();
          for (int k = 1; k < this.Conditions.Length; k++) {
            this.Conditions[k] = 0;
          }
          if (this.TargetID == 0) {
            this.ChooseTarget();
          }
          this.RequiredClothingID = 0;
          this.RequiredDisposalID = 0;
          this.RequiredWeaponID = 0;
          this.NemesisDifficulty = 0;
          this.Difficulty = 1;
          this.UpdateNemesisDifficulty();
          this.UpdateDifficultyLabel();
          this.Phase++;
        } else if (this.Selected == 2) {
          this.Difficulty = 1;
          this.Phase = 5;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Toggle";
          this.PromptBar.Label[1].text = "Return";
          this.PromptBar.Label[2].text = "Change";
          this.PromptBar.Label[3].text = "Population";
          this.PromptBar.Label[4].text = "Selection";
          this.PromptBar.Label[5].text = "Selection";
          this.PromptBar.UpdateButtons();
          this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
          this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
          this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
          this.UpdateObjectiveHighlight();
          this.UpdateDifficultyLabel();
          this.RequiredClothingID = 1;
          this.RequiredDisposalID = 1;
          this.RequiredWeaponID = 1;
          this.TargetID = 2;
          this.ChooseTarget();
          this.CalculateMissionID();
        } else if (this.Selected == 3) {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Confirm";
          this.PromptBar.Label[1].text = "Back";
          this.PromptBar.UpdateButtons();
          this.Phase = 6;
        } else if (this.Selected == 5) {
          this.PromptBar.Show = false;
          this.Phase = 4;
          this.Speed = 0f;
        }
      }
    } else if (this.Phase == 3) {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (this.InputManager.TappedLeft) {
        this.Difficulty--;
        this.UpdateDifficulty();
      }
      if (this.InputManager.TappedRight) {
        this.Difficulty++;
        this.UpdateDifficulty();
      }
      if (this.InputManager.TappedUp) {
        this.NemesisDifficulty--;
        this.UpdateNemesisDifficulty();
      }
      if (this.InputManager.TappedDown) {
        this.NemesisDifficulty++;
        this.UpdateNemesisDifficulty();
      }
      for (int l = 1; l < this.Objectives.Length; l++) {
        Transform transform9 = this.Objectives[l];
        transform9.localScale = Vector3.Lerp(transform9.localScale, (l <= this.Difficulty) ? Vector3.one : Vector3.zero, Time.deltaTime * 10f);
      }
      if (this.NemesisDifficulty == 0) {
        this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else {
        this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      if (this.NemesisDifficulty == 1) {
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 2) {
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 3) {
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 4) {
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      if (Input.GetButtonDown("A")) {
        this.StartMission();
      } else if (Input.GetButtonDown("B")) {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.TargetID = 0;
        this.Phase--;
      } else if (Input.GetButtonDown("X")) {
        this.ChooseTarget();
        if (this.Difficulty > 1) {
          int difficulty = this.Difficulty;
          this.Difficulty = 1;
          while (this.Difficulty < difficulty) {
            this.Difficulty++;
            this.PickNewCondition();
          }
        }
      } else if (Input.GetButtonDown("Y")) {
        this.UpdatePopulation();
      }
    } else if (this.Phase == 4) {
      this.Speed += Time.deltaTime;
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 0f, Time.deltaTime * this.Speed), this.InfoChan.localEulerAngles.z);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
      Transform parent = this.Option[1].parent;
      parent.localPosition = new Vector3(parent.localPosition.x - this.Speed * 1000f * Time.deltaTime, parent.localPosition.y, parent.localPosition.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - this.Speed * Time.deltaTime);
      this.Jukebox.GetComponent<AudioSource>().volume -= Time.deltaTime;
      this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, this.Header.color.a - Time.deltaTime);
      if (this.Darkness.color.a == 1f) {
        if (this.TargetID == 0) {
          SceneManager.LoadScene("TitleScene");
        } else {
          this.NowLoading.SetActive(true);
          SceneManager.LoadScene("SchoolScene");
        }
      }
    } else if (this.Phase == 5) {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (this.InputManager.TappedUp) {
        this.Row--;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedDown) {
        this.Row++;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedRight) {
        this.Column++;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedLeft) {
        this.Column--;
        this.UpdateObjectiveHighlight();
      }
      if (Input.GetButtonDown("A")) {
        if (this.CustomSelected == 1) {
          this.TargetID++;
          this.ChooseTarget();
        } else if (this.CustomSelected == 6) {
          for (int m = 1; m < this.Conditions.Length; m++) {
            this.Conditions[m] = 0;
          }
          int num = 2;
          for (int n = 2; n < this.CustomObjectives.Length; n++) {
            if (this.CustomObjectives[n] != null && this.CustomObjectives[n].alpha == 1f) {
              if (n < 6) {
                this.Conditions[num] = n - 1;
              } else if (n < 12) {
                this.Conditions[num] = n - 2;
              } else {
                this.Conditions[num] = n - 3;
              }
              num++;
            }
          }
          this.StartMission();
        } else if (this.CustomSelected == 12) {
          this.NemesisDifficulty++;
          this.UpdateNemesisDifficulty();
        }
        if (this.PromptBar.Label[0].text == "Toggle") {
          if (this.CustomObjectives[this.CustomSelected].alpha == 0.5f) {
            if (this.Difficulty < 10) {
              this.Difficulty++;
              this.UpdateDifficultyLabel();
              this.CustomObjectives[this.CustomSelected].alpha = 1f;
            }
          } else {
            this.Difficulty--;
            this.UpdateDifficultyLabel();
            this.CustomObjectives[this.CustomSelected].alpha = 0.5f;
          }
        }
        this.CalculateMissionID();
      } else if (Input.GetButtonDown("B")) {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        for (int num2 = 1; num2 < this.CustomObjectives.Length; num2++) {
          if (this.CustomObjectives[num2] != null) {
            this.CustomObjectives[num2].alpha = 0.5f;
          }
        }
        this.NemesisDifficulty = 0;
        this.UpdateNemesisDifficulty();
        this.Difficulty = 1;
        this.TargetID = 0;
        this.Phase = 2;
      } else if (Input.GetButtonDown("X")) {
        if (this.CustomSelected == 1) {
          this.TargetID--;
          this.ChooseTarget();
          this.CalculateMissionID();
        } else if (this.CustomSelected == 2) {
          this.RequiredWeaponID++;
          if (this.RequiredWeaponID == 11) {
            this.RequiredWeaponID++;
          }
          if (this.RequiredWeaponID > this.WeaponNames.Length - 1) {
            this.RequiredWeaponID = 1;
          }
          this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
        } else if (this.CustomSelected == 3) {
          this.RequiredClothingID++;
          if (this.RequiredClothingID > this.ClothingNames.Length - 1) {
            this.RequiredClothingID = 1;
          }
          this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
        } else if (this.CustomSelected == 4) {
          this.RequiredDisposalID++;
          if (this.RequiredDisposalID > this.DisposalNames.Length - 1) {
            this.RequiredDisposalID = 1;
          }
          this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
        } else if (this.CustomSelected == 12) {
          this.NemesisDifficulty--;
          this.UpdateNemesisDifficulty();
        }
        this.CalculateMissionID();
      } else if (Input.GetButtonDown("Y")) {
        this.UpdatePopulation();
        this.CalculateMissionID();
      }
      if (this.NemesisDifficulty == 0) {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 1) {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 2) {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 3) {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      } else if (this.NemesisDifficulty == 4) {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      this.MissionIDLabel.gameObject.GetComponent<UIInput>().value = this.MissionID;
    } else if (this.Phase == 6) {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (!Input.anyKey) {
        this.MissionIDString = this.LoadMissionLabel.text;
        if (this.MissionIDString.Length < 19) {
          this.ErrorLabel.text = "A Mission ID must be 19 numbers long.";
        } else if (this.MissionIDString[0] != '-') {
          this.GetNumbers();
          if (this.TargetNumber == 0) {
            this.ErrorLabel.text = "Invalid Mission ID (No target specified)";
          } else if (this.TargetNumber == 1) {
            this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Senpai)";
          } else if (this.TargetNumber == 33) {
            this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Osana...yet.)";
          } else if ((this.PopulationNumber == 0 && this.TargetNumber > 32) || (this.PopulationNumber == 0 && this.TargetNumber < 86)) {
            this.ErrorLabel.text = "Invalid Mission ID (Population too low)";
          } else if (this.WeaponNumber == 11) {
            this.ErrorLabel.text = "Invalid Mission ID (Weapon does not apply to Mission Mode)";
          } else if (this.WeaponNumber > 14) {
            this.ErrorLabel.text = "Invalid Mission ID (Weapon does not exist)";
          } else if (this.ClothingNumber > 5) {
            this.ErrorLabel.text = "Invalid Mission ID (Clothing does not exist)";
          } else if (this.DisposalNumber > 3) {
            this.ErrorLabel.text = "Invalid Mission ID (Disposal method does not exist)";
          } else if (this.NemesisNumber > 4) {
            this.ErrorLabel.text = "Invalid Mission ID (Nemesis level too high)";
          } else if (this.Condition5Number > 1 || this.Condition6Number > 1 || this.Condition7Number > 1 || this.Condition8Number > 1 || this.Condition9Number > 1 || this.Condition10Number > 1 || this.Condition11Number > 1 || this.Condition12Number > 1 || this.Condition13Number > 1 || this.Condition14Number > 1 || this.Condition15Number > 1) {
            this.ErrorLabel.text = "Invalid Mission ID (One of those conditions should be 1 or 0)";
          } else {
            this.ErrorLabel.text = "Valid Mission ID!";
          }
        } else {
          this.ErrorLabel.text = "Invalid Mission ID (Cannot be negative number)";
        }
      } else if (Input.GetButtonDown("A")) {
        if (this.ErrorLabel.text == "Valid Mission ID!") {
          Debug.Log("Target ID is: " + this.TargetNumber.ToString() + " and Weapon ID is: " + this.WeaponNumber.ToString());
          this.TargetID = this.TargetNumber;
          this.Difficulty = 1;
          if (this.WeaponNumber > 0) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 2;
            this.CustomObjectives[2].alpha = 1f;
            this.RequiredWeaponID = this.WeaponNumber;
            this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
          } else {
            this.CustomObjectives[2].alpha = 0.5f;
            this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
          }
          if (this.ClothingNumber > 0) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 3;
            this.CustomObjectives[3].alpha = 1f;
            this.RequiredClothingID = this.ClothingNumber;
            this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
          } else {
            this.CustomObjectives[3].alpha = 0.5f;
            this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
          }
          if (this.DisposalNumber > 0) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 4;
            this.CustomObjectives[4].alpha = 1f;
            this.RequiredDisposalID = this.DisposalNumber;
            this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
          } else {
            this.CustomObjectives[4].alpha = 0.5f;
            this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
          }
          if (this.Difficulty < 10 && this.Condition5Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 5;
            this.CustomObjectives[5].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition6Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 6;
            this.CustomObjectives[7].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition7Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 7;
            this.CustomObjectives[8].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition8Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 8;
            this.CustomObjectives[9].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition9Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 9;
            this.CustomObjectives[10].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition10Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 10;
            this.CustomObjectives[11].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition11Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 11;
            this.CustomObjectives[13].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition12Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 12;
            this.CustomObjectives[14].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition13Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 13;
            this.CustomObjectives[15].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition14Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 14;
            this.CustomObjectives[16].alpha = 1f;
          }
          if (this.Difficulty < 10 && this.Condition15Number == 1) {
            this.Difficulty++;
            this.Conditions[this.Difficulty] = 15;
            this.CustomObjectives[17].alpha = 1f;
          }
          this.NemesisDifficulty = this.NemesisNumber;
          SchoolGlobals.Population = this.PopulationNumber;
          this.Phase = 5;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Toggle";
          this.PromptBar.Label[1].text = "Return";
          this.PromptBar.Label[2].text = "Change";
          this.PromptBar.Label[3].text = "Population";
          this.PromptBar.Label[4].text = "Selection";
          this.PromptBar.Label[5].text = "Selection";
          this.PromptBar.UpdateButtons();
          this.UpdateObjectiveHighlight();
          this.UpdateNemesisDifficulty();
          this.UpdateDifficultyLabel();
          this.CalculateMissionID();
          this.ChooseTarget();
        }
      } else if (Input.GetButtonDown("B")) {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.TargetID = 0;
        this.Phase = 2;
      }
    }
  }

  // Token: 0x06000004 RID: 4 RVA: 0x00005300 File Offset: 0x00003700
  private void GetNumbers() {
    this.TargetNumber = (int)char.GetNumericValue(this.MissionIDString[0]) * 10 + (int)char.GetNumericValue(this.MissionIDString[1]);
    this.WeaponNumber = (int)char.GetNumericValue(this.MissionIDString[2]) * 10 + (int)char.GetNumericValue(this.MissionIDString[3]);
    this.ClothingNumber = (int)char.GetNumericValue(this.MissionIDString[4]);
    this.DisposalNumber = (int)char.GetNumericValue(this.MissionIDString[5]);
    this.Condition5Number = (int)char.GetNumericValue(this.MissionIDString[6]);
    this.Condition6Number = (int)char.GetNumericValue(this.MissionIDString[7]);
    this.Condition7Number = (int)char.GetNumericValue(this.MissionIDString[8]);
    this.Condition8Number = (int)char.GetNumericValue(this.MissionIDString[9]);
    this.Condition9Number = (int)char.GetNumericValue(this.MissionIDString[10]);
    this.Condition10Number = (int)char.GetNumericValue(this.MissionIDString[11]);
    this.Condition11Number = (int)char.GetNumericValue(this.MissionIDString[12]);
    this.Condition12Number = (int)char.GetNumericValue(this.MissionIDString[13]);
    this.Condition13Number = (int)char.GetNumericValue(this.MissionIDString[14]);
    this.Condition14Number = (int)char.GetNumericValue(this.MissionIDString[15]);
    this.Condition15Number = (int)char.GetNumericValue(this.MissionIDString[16]);
    this.NemesisNumber = (int)char.GetNumericValue(this.MissionIDString[17]);
    this.PopulationNumber = (int)char.GetNumericValue(this.MissionIDString[18]);
  }

  // Token: 0x06000005 RID: 5 RVA: 0x000054DC File Offset: 0x000038DC
  private void LateUpdate() {
    if (this.Speed > 3f) {
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * (this.Speed - 3f));
    }
    this.Neck.transform.localEulerAngles = new Vector3(this.Neck.transform.localEulerAngles.x + this.Rotation, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
  }

  // Token: 0x06000006 RID: 6 RVA: 0x00005585 File Offset: 0x00003985
  private void UpdateHighlight() {
    if (this.Selected == 0) {
      this.Selected = 5;
    } else if (this.Selected == 6) {
      this.Selected = 1;
    }
  }

  // Token: 0x06000007 RID: 7 RVA: 0x000055B4 File Offset: 0x000039B4
  private void ChooseTarget() {
    if (this.Phase != 5) {
      this.TargetID = (OptionGlobals.HighPopulation ? UnityEngine.Random.Range(2, 90) : UnityEngine.Random.Range(2, 33));
    } else if (!OptionGlobals.HighPopulation) {
      if (this.TargetID < 86) {
        if (this.TargetID == 85) {
          this.TargetID = 32;
        } else if (this.TargetID > 32) {
          this.TargetID = 86;
        } else if (this.TargetID < 2) {
          this.TargetID = 89;
        }
      } else if (this.TargetID > 89) {
        this.TargetID = 2;
      } else if (this.TargetID < 86) {
        this.TargetID = 32;
      }
    } else if (this.TargetID > 89) {
      this.TargetID = 2;
    } else if (this.TargetID < 2) {
      this.TargetID = 89;
    }
    string url = string.Concat(new object[]
    {
      "file:///",
      Application.streamingAssetsPath,
      "/Portraits/Student_",
      this.TargetID,
      ".png"
    });
    WWW www = new WWW(url);
    if (this.TargetID > 32 && this.TargetID < 86) {
      this.TargetPortrait.mainTexture = this.BlankPortrait;
    } else {
      this.TargetPortrait.mainTexture = www.texture;
    }
    this.CustomTargetPortrait.mainTexture = this.TargetPortrait.mainTexture;
    if (this.JSON.Students[this.TargetID].Name == "Random" || this.JSON.Students[this.TargetID].Name == "Unknown") {
      this.TargetName = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
    } else {
      this.TargetName = this.JSON.Students[this.TargetID].Name;
    }
    this.CustomDescs[1].text = "Kill " + this.TargetName + ".";
    this.Descs[1].text = "Kill " + this.TargetName + ".";
    if (this.TargetID == 33) {
      if (this.Phase == 5) {
        this.TargetID += ((!Input.GetButtonDown("A")) ? -1 : 1);
      }
      this.ChooseTarget();
    }
  }

  // Token: 0x06000008 RID: 8 RVA: 0x00005898 File Offset: 0x00003C98
  private void UpdateDifficulty() {
    if (this.Difficulty < 1) {
      this.Difficulty = 1;
    } else if (this.Difficulty > 10) {
      this.Difficulty = 10;
    }
    if (this.InputManager.TappedRight) {
      this.PickNewCondition();
    } else {
      this.ErasePreviousCondition();
    }
  }

  // Token: 0x06000009 RID: 9 RVA: 0x000058F4 File Offset: 0x00003CF4
  private void UpdateDifficultyLabel() {
    this.CustomDifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
    this.DifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
    string text = "Kill " + this.TargetName + ".";
    string text2 = string.Empty;
    string text3 = string.Empty;
    string text4 = string.Empty;
    if (this.RequiredWeaponID == 0) {
      text2 = "You can kill the target with any weapon.";
    } else {
      text2 = "You must kill the target with a " + this.WeaponNames[this.RequiredWeaponID];
    }
    if (this.RequiredClothingID == 0) {
      text3 = "You can kill the target wearing any clothing.";
    } else {
      text3 = "You must kill the target while wearing " + this.ClothingNames[this.RequiredClothingID];
    }
    if (this.RequiredDisposalID == 0) {
      text4 = "It is not necessary to dispose of the target's corpse.";
    } else {
      text4 = "You must dispose of the target's corpse by " + this.DisposalNames[this.RequiredDisposalID];
    }
    this.DescriptionLabel.text = string.Concat(new string[]
    {
      text,
      "\n\n",
      text2,
      "\n\n",
      text3,
      "\n\n",
      text4
    });
  }

  // Token: 0x0600000A RID: 10 RVA: 0x00005A40 File Offset: 0x00003E40
  private void UpdateNemesisDifficulty() {
    if (this.NemesisDifficulty < 0) {
      this.NemesisDifficulty = 4;
    } else if (this.NemesisDifficulty > 4) {
      this.NemesisDifficulty = 0;
    }
    if (this.NemesisDifficulty == 0) {
      this.CustomNemesisLabel.text = "Nemesis: Off";
      this.NemesisLabel.text = "Nemesis: Off";
    } else {
      this.CustomNemesisLabel.text = "Nemesis: On";
      this.NemesisLabel.text = "Nemesis: On";
      this.NemesisPortrait.mainTexture = ((this.NemesisDifficulty <= 2) ? this.NemesisGraphic : this.BlankPortrait);
    }
  }

  // Token: 0x0600000B RID: 11 RVA: 0x00005AF0 File Offset: 0x00003EF0
  private void PickNewCondition() {
    int num = UnityEngine.Random.Range(1, this.ConditionDescs.Length);
    this.Conditions[this.Difficulty] = num;
    this.Descs[this.Difficulty].text = this.ConditionDescs[num];
    this.Icons[this.Difficulty].mainTexture = this.ConditionIcons[num];
    bool flag = false;
    for (int i = 2; i < this.Difficulty; i++) {
      if (num == this.Conditions[i]) {
        flag = true;
      }
    }
    if (flag) {
      this.PickNewCondition();
    } else if (num > 3) {
      this.Descs[this.Difficulty].text = this.ConditionDescs[num];
    } else if (num == 1) {
      this.RequiredWeaponID = 11;
      while (this.RequiredWeaponID == 11) {
        this.RequiredWeaponID = UnityEngine.Random.Range(1, this.WeaponNames.Length);
      }
      this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.WeaponNames[this.RequiredWeaponID];
    } else if (num == 2) {
      this.RequiredClothingID = UnityEngine.Random.Range(1, this.ClothingNames.Length);
      this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.ClothingNames[this.RequiredClothingID];
    } else if (num == 3) {
      this.RequiredDisposalID = UnityEngine.Random.Range(1, this.DisposalNames.Length);
      this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.DisposalNames[this.RequiredDisposalID];
    }
    this.UpdateDifficultyLabel();
  }

  // Token: 0x0600000C RID: 12 RVA: 0x00005CBC File Offset: 0x000040BC
  private void ErasePreviousCondition() {
    if (this.Conditions[this.Difficulty + 1] == 1) {
      this.RequiredWeaponID = 0;
    } else if (this.Conditions[this.Difficulty + 1] == 2) {
      this.RequiredClothingID = 0;
    } else if (this.Conditions[this.Difficulty + 1] == 3) {
      this.RequiredDisposalID = 0;
    }
    this.Conditions[this.Difficulty + 1] = 0;
    this.UpdateDifficultyLabel();
  }

  // Token: 0x0600000D RID: 13 RVA: 0x00005D40 File Offset: 0x00004140
  public void UpdateGraphics() {
    if (MissionModeGlobals.MissionTarget < 33) {
      string url = string.Concat(new string[]
      {
        "file:///",
        Application.streamingAssetsPath,
        "/Portraits/Student_",
        MissionModeGlobals.MissionTarget.ToString(),
        ".png"
      });
      WWW www = new WWW(url);
      this.Icons[1].mainTexture = www.texture;
      this.TargetName = this.JSON.Students[MissionModeGlobals.MissionTarget].Name;
    } else {
      this.TargetPortrait.mainTexture = this.BlankPortrait;
      this.TargetName = MissionModeGlobals.MissionTargetName;
    }
    this.Descs[1].text = "Kill " + this.TargetName + ".";
    for (int i = 2; i < this.Objectives.Length; i++) {
      this.Objectives[i].gameObject.SetActive(false);
    }
    if (MissionModeGlobals.MissionDifficulty > 1) {
      for (int j = 2; j < MissionModeGlobals.MissionDifficulty + 1; j++) {
        this.Objectives[j].gameObject.SetActive(true);
        this.Icons[j].mainTexture = this.ConditionIcons[MissionModeGlobals.GetMissionCondition(j)];
        if (MissionModeGlobals.GetMissionCondition(j) > 3) {
          this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)];
        } else if (MissionModeGlobals.GetMissionCondition(j) == 1) {
          this.RequiredWeaponID = 11;
          while (this.RequiredWeaponID == 11) {
            this.RequiredWeaponID = UnityEngine.Random.Range(1, this.WeaponNames.Length);
          }
          this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.WeaponNames[MissionModeGlobals.MissionRequiredWeapon];
        } else if (MissionModeGlobals.GetMissionCondition(j) == 2) {
          this.RequiredClothingID = UnityEngine.Random.Range(0, this.ClothingNames.Length);
          this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.ClothingNames[MissionModeGlobals.MissionRequiredClothing];
        } else if (MissionModeGlobals.GetMissionCondition(j) == 3) {
          this.RequiredDisposalID = UnityEngine.Random.Range(1, this.DisposalNames.Length);
          this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.DisposalNames[MissionModeGlobals.MissionRequiredDisposal];
        }
      }
    }
  }

  // Token: 0x0600000E RID: 14 RVA: 0x00005FE4 File Offset: 0x000043E4
  private void UpdatePopulation() {
    if (!OptionGlobals.HighPopulation) {
      this.CustomPopulationLabel.text = "High School Population: On";
      this.PopulationLabel.text = "High School Population: On";
      OptionGlobals.HighPopulation = true;
    } else {
      this.CustomPopulationLabel.text = "High School Population: Off";
      this.PopulationLabel.text = "High School Population: Off";
      OptionGlobals.HighPopulation = false;
      if (this.TargetID > 32 && this.TargetID < 86) {
        this.ChooseTarget();
      }
    }
  }

  // Token: 0x0600000F RID: 15 RVA: 0x0000606C File Offset: 0x0000446C
  private void UpdateObjectiveHighlight() {
    if (this.Row < 1) {
      this.Row = 6;
    } else if (this.Row > 6) {
      this.Row = 1;
    } else if (this.Column < 1) {
      this.Column = 3;
    } else if (this.Column > 3) {
      this.Column = 1;
    }
    if (this.Row == 6 && this.Column == 3) {
      this.Column = 1;
    }
    int num = 0;
    if (this.Row == 6) {
      num = 75;
    }
    this.PromptBar.Label[2].text = (((this.Column != 1 || this.Row >= 5) && (this.Column != 2 || this.Row != 6)) ? string.Empty : "Change");
    this.ObjectiveHighlight.localPosition = new Vector3(-1050f + 650f * (float)this.Column, 450f - 150f * (float)this.Row - (float)num, this.ObjectiveHighlight.localPosition.z);
    this.CustomSelected = this.Row + (this.Column - 1) * 6;
    if (this.CustomSelected == 1 || this.CustomSelected == 12) {
      this.PromptBar.Label[0].text = "Forward";
    } else if (this.CustomSelected == 6) {
      this.PromptBar.Label[0].text = "Start";
    } else {
      this.PromptBar.Label[0].text = "Toggle";
    }
    if (this.CustomSelected == 1 || this.CustomSelected == 12) {
      this.PromptBar.Label[2].text = "Backward";
    } else if (this.CustomSelected > 4) {
      this.PromptBar.Label[2].text = string.Empty;
    } else {
      this.PromptBar.Label[2].text = "Change";
    }
    this.PromptBar.UpdateButtons();
  }

  // Token: 0x06000010 RID: 16 RVA: 0x000062AC File Offset: 0x000046AC
  private void CalculateMissionID() {
    this.TargetString = ((this.TargetID >= 10) ? string.Empty : "0") + this.TargetID.ToString();
    if (this.CustomObjectives[2].alpha == 1f) {
      this.WeaponString = ((this.RequiredWeaponID >= 10) ? string.Empty : "0") + this.RequiredWeaponID.ToString();
    } else {
      this.WeaponString = "00";
    }
    this.ClothingString = ((this.CustomObjectives[3].alpha != 1f) ? "0" : this.RequiredClothingID.ToString());
    this.DisposalString = ((this.CustomObjectives[4].alpha != 1f) ? "0" : this.RequiredDisposalID.ToString());
    for (int i = 1; i < this.CustomObjectives.Length; i++) {
      if (this.CustomObjectives[i] != null) {
        this.ConditionString[i] = ((this.CustomObjectives[i].alpha != 1f) ? "0" : "1");
      }
    }
    this.MissionID = string.Concat(new string[]
    {
      this.TargetString,
      this.WeaponString,
      this.ClothingString,
      this.DisposalString,
      this.ConditionString[5],
      this.ConditionString[6],
      this.ConditionString[7],
      this.ConditionString[8],
      this.ConditionString[9],
      this.ConditionString[10],
      this.ConditionString[11],
      this.ConditionString[12],
      this.ConditionString[13],
      this.ConditionString[14],
      this.ConditionString[15],
      this.ConditionString[16],
      this.ConditionString[17],
      this.NemesisDifficulty.ToString(),
      ((!OptionGlobals.HighPopulation) ? 0 : 1).ToString()
    });
    this.MissionIDLabel.text = this.MissionID;
  }

  // Token: 0x06000011 RID: 17 RVA: 0x0000653C File Offset: 0x0000493C
  private void StartMission() {
    base.GetComponent<AudioSource>().PlayOneShot(this.InfoLines[6]);
    bool highPopulation = OptionGlobals.HighPopulation;
    Globals.DeleteAll();
    SchoolGlobals.SchoolAtmosphere = 1f - (float)this.Difficulty * 0.1f;
    MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
    MissionModeGlobals.MissionTargetName = this.TargetName;
    MissionModeGlobals.MissionDifficulty = this.Difficulty;
    OptionGlobals.HighPopulation = highPopulation;
    MissionModeGlobals.MissionTarget = this.TargetID;
    SchoolGlobals.SchoolAtmosphereSet = true;
    MissionModeGlobals.MissionMode = true;
    ClassGlobals.BiologyGrade = 1;
    ClassGlobals.ChemistryGrade = 1;
    ClassGlobals.LanguageGrade = 1;
    ClassGlobals.PhysicalGrade = 1;
    ClassGlobals.PsychologyGrade = 1;
    if (this.Difficulty > 1) {
      for (int i = 2; i < this.Difficulty + 1; i++) {
        if (this.Conditions[i] == 1) {
          MissionModeGlobals.MissionRequiredWeapon = this.RequiredWeaponID;
        } else if (this.Conditions[i] == 2) {
          MissionModeGlobals.MissionRequiredClothing = this.RequiredClothingID;
        } else if (this.Conditions[i] == 3) {
          MissionModeGlobals.MissionRequiredDisposal = this.RequiredDisposalID;
        }
        MissionModeGlobals.SetMissionCondition(i, this.Conditions[i]);
      }
    }
    this.PromptBar.Show = false;
    this.Speed = 0f;
    this.Phase = 4;
  }

  // Token: 0x04000001 RID: 1
  public StudentManagerScript StudentManager;

  // Token: 0x04000002 RID: 2
  public InputManagerScript InputManager;

  // Token: 0x04000003 RID: 3
  public PromptBarScript PromptBar;

  // Token: 0x04000004 RID: 4
  public JsonScript JSON;

  // Token: 0x04000005 RID: 5
  public UITexture CustomTargetPortrait;

  // Token: 0x04000006 RID: 6
  public UILabel CustomDifficultyLabel;

  // Token: 0x04000007 RID: 7
  public UILabel CustomPopulationLabel;

  // Token: 0x04000008 RID: 8
  public UILabel CustomNemesisLabel;

  // Token: 0x04000009 RID: 9
  public UITexture NemesisPortrait;

  // Token: 0x0400000A RID: 10
  public UITexture TargetPortrait;

  // Token: 0x0400000B RID: 11
  public UILabel LoadMissionLabel;

  // Token: 0x0400000C RID: 12
  public UILabel DescriptionLabel;

  // Token: 0x0400000D RID: 13
  public UILabel DifficultyLabel;

  // Token: 0x0400000E RID: 14
  public UILabel PopulationLabel;

  // Token: 0x0400000F RID: 15
  public UILabel NemesisLabel;

  // Token: 0x04000010 RID: 16
  public UILabel ErrorLabel;

  // Token: 0x04000011 RID: 17
  public UILabel Header;

  // Token: 0x04000012 RID: 18
  public UISprite Highlight;

  // Token: 0x04000013 RID: 19
  public UISprite Darkness;

  // Token: 0x04000014 RID: 20
  public Transform CustomMissionWindow;

  // Token: 0x04000015 RID: 21
  public Transform ObjectiveHighlight;

  // Token: 0x04000016 RID: 22
  public Transform LoadMissionWindow;

  // Token: 0x04000017 RID: 23
  public Transform MissionWindow;

  // Token: 0x04000018 RID: 24
  public Transform InfoChan;

  // Token: 0x04000019 RID: 25
  public Transform Options;

  // Token: 0x0400001A RID: 26
  public Transform Neck;

  // Token: 0x0400001B RID: 27
  public GameObject NowLoading;

  // Token: 0x0400001C RID: 28
  public string[] ConditionDescs;

  // Token: 0x0400001D RID: 29
  public int[] Conditions;

  // Token: 0x0400001E RID: 30
  public string[] ClothingNames;

  // Token: 0x0400001F RID: 31
  public string[] DisposalNames;

  // Token: 0x04000020 RID: 32
  public string[] WeaponNames;

  // Token: 0x04000021 RID: 33
  public int RequiredClothingID;

  // Token: 0x04000022 RID: 34
  public int RequiredDisposalID;

  // Token: 0x04000023 RID: 35
  public int RequiredWeaponID;

  // Token: 0x04000024 RID: 36
  public Transform[] CustomNemesisObjectives;

  // Token: 0x04000025 RID: 37
  public Transform[] NemesisObjectives;

  // Token: 0x04000026 RID: 38
  public UIPanel[] CustomObjectives;

  // Token: 0x04000027 RID: 39
  public Texture[] ConditionIcons;

  // Token: 0x04000028 RID: 40
  public Transform[] Objectives;

  // Token: 0x04000029 RID: 41
  public Transform[] Option;

  // Token: 0x0400002A RID: 42
  public UITexture[] Icons;

  // Token: 0x0400002B RID: 43
  public UILabel[] CustomDescs;

  // Token: 0x0400002C RID: 44
  public UILabel[] Descs;

  // Token: 0x0400002D RID: 45
  public Texture NemesisGraphic;

  // Token: 0x0400002E RID: 46
  public Texture BlankPortrait;

  // Token: 0x0400002F RID: 47
  public string MissionIDString = string.Empty;

  // Token: 0x04000030 RID: 48
  public string TargetName = string.Empty;

  // Token: 0x04000031 RID: 49
  public int NemesisDifficulty;

  // Token: 0x04000032 RID: 50
  public int CustomSelected = 1;

  // Token: 0x04000033 RID: 51
  public int Difficulty = 1;

  // Token: 0x04000034 RID: 52
  public int Selected = 1;

  // Token: 0x04000035 RID: 53
  public int TargetID;

  // Token: 0x04000036 RID: 54
  public int Phase;

  // Token: 0x04000037 RID: 55
  public int Column = 1;

  // Token: 0x04000038 RID: 56
  public int Row = 1;

  // Token: 0x04000039 RID: 57
  public float Rotation;

  // Token: 0x0400003A RID: 58
  public float Speed;

  // Token: 0x0400003B RID: 59
  public float Timer;

  // Token: 0x0400003C RID: 60
  public AudioSource Jukebox;

  // Token: 0x0400003D RID: 61
  public AudioClip[] InfoLines;

  // Token: 0x0400003E RID: 62
  public bool[] InfoSpoke;

  // Token: 0x0400003F RID: 63
  public int TargetNumber;

  // Token: 0x04000040 RID: 64
  public int WeaponNumber;

  // Token: 0x04000041 RID: 65
  public int ClothingNumber;

  // Token: 0x04000042 RID: 66
  public int DisposalNumber;

  // Token: 0x04000043 RID: 67
  public int NemesisNumber;

  // Token: 0x04000044 RID: 68
  public int PopulationNumber;

  // Token: 0x04000045 RID: 69
  public int Condition5Number;

  // Token: 0x04000046 RID: 70
  public int Condition6Number;

  // Token: 0x04000047 RID: 71
  public int Condition7Number;

  // Token: 0x04000048 RID: 72
  public int Condition8Number;

  // Token: 0x04000049 RID: 73
  public int Condition9Number;

  // Token: 0x0400004A RID: 74
  public int Condition10Number;

  // Token: 0x0400004B RID: 75
  public int Condition11Number;

  // Token: 0x0400004C RID: 76
  public int Condition12Number;

  // Token: 0x0400004D RID: 77
  public int Condition13Number;

  // Token: 0x0400004E RID: 78
  public int Condition14Number;

  // Token: 0x0400004F RID: 79
  public int Condition15Number;

  // Token: 0x04000050 RID: 80
  public string TargetString = string.Empty;

  // Token: 0x04000051 RID: 81
  public string WeaponString = string.Empty;

  // Token: 0x04000052 RID: 82
  public string ClothingString = string.Empty;

  // Token: 0x04000053 RID: 83
  public string DisposalString = string.Empty;

  // Token: 0x04000054 RID: 84
  public string MissionID = string.Empty;

  // Token: 0x04000055 RID: 85
  public string[] ConditionString;

  // Token: 0x04000056 RID: 86
  public UILabel MissionIDLabel;
}