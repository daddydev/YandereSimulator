using UnityEngine;

// Token: 0x020001A6 RID: 422
public class SchemesScript : MonoBehaviour {

  // Token: 0x0600076A RID: 1898 RVA: 0x0006FB00 File Offset: 0x0006DF00
  private void Start() {
    for (int i = 1; i < this.SchemeNames.Length; i++) {
      if (!SchemeGlobals.GetSchemeStatus(i)) {
        this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
        this.SchemeNameLabels[i].text = this.SchemeNames[i];
      }
    }
  }

  // Token: 0x0600076B RID: 1899 RVA: 0x0006FB5C File Offset: 0x0006DF5C
  private void Update() {
    if (this.InputManager.TappedUp) {
      this.ID--;
      if (this.ID < 1) {
        this.ID = this.SchemeNames.Length - 1;
      }
      this.UpdateSchemeInfo();
    }
    if (this.InputManager.TappedDown) {
      this.ID++;
      if (this.ID > this.SchemeNames.Length - 1) {
        this.ID = 1;
      }
      this.UpdateSchemeInfo();
    }
    if (Input.GetButtonDown("A")) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.PromptBar.Label[0].text != string.Empty) {
        if (!SchemeGlobals.GetSchemeUnlocked(this.ID)) {
          if (PlayerGlobals.PantyShots >= this.SchemeCosts[this.ID]) {
            PlayerGlobals.PantyShots -= this.SchemeCosts[this.ID];
            SchemeGlobals.SetSchemeUnlocked(this.ID, true);
            SchemeGlobals.CurrentScheme = this.ID;
            if (SchemeGlobals.GetSchemeStage(this.ID) == 0) {
              SchemeGlobals.SetSchemeStage(this.ID, 1);
            }
            this.UpdateInstructions();
            this.UpdateSchemeList();
            this.UpdateSchemeInfo();
            component.clip = this.InfoPurchase;
            component.Play();
          }
        } else {
          if (SchemeGlobals.CurrentScheme == this.ID) {
            SchemeGlobals.CurrentScheme = 0;
          } else {
            SchemeGlobals.CurrentScheme = this.ID;
          }
          this.UpdateSchemeInfo();
          this.UpdateInstructions();
        }
      } else if (SchemeGlobals.GetSchemeStage(this.ID) != 100 && PlayerGlobals.PantyShots < this.SchemeCosts[this.ID]) {
        component.clip = this.InfoAfford;
        component.Play();
      }
    }
    if (Input.GetButtonDown("B")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.FavorMenu.SetActive(true);
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600076C RID: 1900 RVA: 0x0006FDB0 File Offset: 0x0006E1B0
  public void UpdateSchemeList() {
    for (int i = 1; i < this.SchemeNames.Length; i++) {
      if (SchemeGlobals.GetSchemeStage(i) == 100) {
        UILabel uilabel = this.SchemeNameLabels[i];
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
        this.Exclamations[i].enabled = false;
        this.SchemeCostLabels[i].text = string.Empty;
      } else {
        this.SchemeCostLabels[i].text = (SchemeGlobals.GetSchemeUnlocked(i) ? string.Empty : this.SchemeCosts[i].ToString());
        if (SchemeGlobals.GetSchemeStage(i) > SchemeGlobals.GetSchemePreviousStage(i)) {
          SchemeGlobals.SetSchemePreviousStage(i, SchemeGlobals.GetSchemeStage(i));
          this.Exclamations[i].enabled = true;
        } else {
          this.Exclamations[i].enabled = false;
        }
      }
    }
  }

  // Token: 0x0600076D RID: 1901 RVA: 0x0006FEC4 File Offset: 0x0006E2C4
  public void UpdateSchemeInfo() {
    if (SchemeGlobals.GetSchemeStage(this.ID) != 100) {
      if (!SchemeGlobals.GetSchemeUnlocked(this.ID)) {
        this.Arrow.gameObject.SetActive(false);
        this.PromptBar.Label[0].text = ((PlayerGlobals.PantyShots < this.SchemeCosts[this.ID]) ? string.Empty : "Purchase");
        this.PromptBar.UpdateButtons();
      } else if (SchemeGlobals.CurrentScheme == this.ID) {
        this.Arrow.gameObject.SetActive(true);
        this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, -17f - 28f * (float)SchemeGlobals.GetSchemeStage(this.ID), this.Arrow.localPosition.z);
        this.PromptBar.Label[0].text = "Stop Tracking";
        this.PromptBar.UpdateButtons();
      } else {
        this.Arrow.gameObject.SetActive(false);
        this.PromptBar.Label[0].text = "Start Tracking";
        this.PromptBar.UpdateButtons();
      }
    } else {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
    this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID];
    this.SchemeDesc.text = this.SchemeDescs[this.ID];
    if (SchemeGlobals.GetSchemeStage(this.ID) == 100) {
      this.SchemeInstructions.text = "This scheme is no longer available.";
    } else {
      this.SchemeInstructions.text = (SchemeGlobals.GetSchemeUnlocked(this.ID) ? this.SchemeSteps[this.ID] : ("Skills Required:\n" + this.SchemeSkills[this.ID]));
    }
    this.UpdatePantyCount();
  }

  // Token: 0x0600076E RID: 1902 RVA: 0x00070128 File Offset: 0x0006E528
  public void UpdatePantyCount() {
    this.PantyCount.text = PlayerGlobals.PantyShots.ToString();
  }

  // Token: 0x0600076F RID: 1903 RVA: 0x00070154 File Offset: 0x0006E554
  public void UpdateInstructions() {
    this.Steps = this.SchemeSteps[SchemeGlobals.CurrentScheme].Split(new char[]
    {
      '\n'
    });
    if (SchemeGlobals.CurrentScheme > 0) {
      if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 100) {
        this.HUDIcon.SetActive(true);
        this.HUDInstructions.text = this.Steps[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) - 1].ToString();
      } else {
        this.Arrow.gameObject.SetActive(false);
        this.HUDIcon.gameObject.SetActive(false);
        this.HUDInstructions.text = string.Empty;
        SchemeGlobals.CurrentScheme = 0;
      }
    } else {
      this.HUDIcon.SetActive(false);
      this.HUDInstructions.text = string.Empty;
    }
  }

  // Token: 0x040012C5 RID: 4805
  public InputManagerScript InputManager;

  // Token: 0x040012C6 RID: 4806
  public PromptBarScript PromptBar;

  // Token: 0x040012C7 RID: 4807
  public GameObject FavorMenu;

  // Token: 0x040012C8 RID: 4808
  public Transform Highlight;

  // Token: 0x040012C9 RID: 4809
  public Transform Arrow;

  // Token: 0x040012CA RID: 4810
  public UILabel SchemeInstructions;

  // Token: 0x040012CB RID: 4811
  public UITexture SchemeIcon;

  // Token: 0x040012CC RID: 4812
  public UILabel PantyCount;

  // Token: 0x040012CD RID: 4813
  public UILabel SchemeDesc;

  // Token: 0x040012CE RID: 4814
  public UILabel[] SchemeDeadlineLabels;

  // Token: 0x040012CF RID: 4815
  public UILabel[] SchemeCostLabels;

  // Token: 0x040012D0 RID: 4816
  public UILabel[] SchemeNameLabels;

  // Token: 0x040012D1 RID: 4817
  public UISprite[] Exclamations;

  // Token: 0x040012D2 RID: 4818
  public Texture[] SchemeIcons;

  // Token: 0x040012D3 RID: 4819
  public int[] SchemeCosts;

  // Token: 0x040012D4 RID: 4820
  public string[] SchemeDeadlines;

  // Token: 0x040012D5 RID: 4821
  public string[] SchemeSkills;

  // Token: 0x040012D6 RID: 4822
  public string[] SchemeDescs;

  // Token: 0x040012D7 RID: 4823
  public string[] SchemeNames;

  // Token: 0x040012D8 RID: 4824
  public string[] SchemeSteps;

  // Token: 0x040012D9 RID: 4825
  public int ID = 1;

  // Token: 0x040012DA RID: 4826
  public string[] Steps;

  // Token: 0x040012DB RID: 4827
  public AudioClip InfoPurchase;

  // Token: 0x040012DC RID: 4828
  public AudioClip InfoAfford;

  // Token: 0x040012DD RID: 4829
  public GameObject HUDIcon;

  // Token: 0x040012DE RID: 4830
  public UILabel HUDInstructions;
}