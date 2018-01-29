using UnityEngine;

// Token: 0x020001AD RID: 429
public class SettingsScript : MonoBehaviour {

  // Token: 0x06000780 RID: 1920 RVA: 0x00070B7C File Offset: 0x0006EF7C
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.QualityManager.ToggleExperiment();
    }
    if (Input.GetKeyDown(KeyCode.R)) {
      this.QualityManager.RimLight();
    }
    if (Input.GetKeyDown(KeyCode.B)) {
      if (!this.Background.activeInHierarchy) {
        OptionGlobals.DrawDistanceLimit = 500;
        OptionGlobals.DrawDistance = 500;
        this.CloudSystem.localScale = new Vector3(1000f, 1000f, 1000f);
        this.QualityManager.UpdateDrawDistance();
        this.Background.SetActive(true);
      } else {
        OptionGlobals.DrawDistanceLimit = 350;
        OptionGlobals.DrawDistance = 350;
        this.CloudSystem.localScale = new Vector3(500f, 500f, 500f);
        this.QualityManager.UpdateDrawDistance();
        this.Background.SetActive(false);
      }
    }
    if (this.InputManager.TappedUp) {
      this.Selected--;
      this.UpdateHighlight();
    } else if (this.InputManager.TappedDown) {
      this.Selected++;
      this.UpdateHighlight();
    }
    if (this.Selected == 1) {
      if (this.InputManager.TappedRight) {
        OptionGlobals.ParticleCount++;
        this.QualityManager.UpdateParticles();
        this.UpdateText();
      } else if (this.InputManager.TappedLeft) {
        OptionGlobals.ParticleCount--;
        this.QualityManager.UpdateParticles();
        this.UpdateText();
      }
    } else if (this.Selected == 2) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
        this.UpdateText();
        this.QualityManager.UpdateOutlines();
      }
    } else if (this.Selected == 3) {
      if (this.InputManager.TappedRight) {
        if (QualitySettings.antiAliasing > 0) {
          QualitySettings.antiAliasing *= 2;
        } else {
          QualitySettings.antiAliasing = 2;
        }
        this.UpdateText();
      } else if (this.InputManager.TappedLeft) {
        if (QualitySettings.antiAliasing > 0) {
          QualitySettings.antiAliasing /= 2;
        } else {
          QualitySettings.antiAliasing = 0;
        }
        this.UpdateText();
      }
    } else if (this.Selected == 4) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.DisablePostAliasing = !OptionGlobals.DisablePostAliasing;
        this.UpdateText();
        this.QualityManager.UpdatePostAliasing();
      }
    } else if (this.Selected == 5) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.DisableBloom = !OptionGlobals.DisableBloom;
        this.UpdateText();
        this.QualityManager.UpdateBloom();
      }
    } else if (this.Selected == 6) {
      if (this.InputManager.TappedRight) {
        OptionGlobals.LowDetailStudents--;
        this.QualityManager.UpdateLowDetailStudents();
        this.UpdateText();
      } else if (this.InputManager.TappedLeft) {
        OptionGlobals.LowDetailStudents++;
        this.QualityManager.UpdateLowDetailStudents();
        this.UpdateText();
      }
    } else if (this.Selected == 7) {
      if (this.InputManager.TappedRight) {
        OptionGlobals.DrawDistance += 10;
        this.QualityManager.UpdateDrawDistance();
        this.UpdateText();
      } else if (this.InputManager.TappedLeft) {
        OptionGlobals.DrawDistance -= 10;
        this.QualityManager.UpdateDrawDistance();
        this.UpdateText();
      }
    } else if (this.Selected == 8) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.Fog = !OptionGlobals.Fog;
        this.UpdateText();
        this.QualityManager.UpdateFog();
      }
    } else if (this.Selected == 9) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.DisableShadows = !OptionGlobals.DisableShadows;
        this.UpdateText();
        this.QualityManager.UpdateShadows();
      }
    } else if (this.Selected == 10) {
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        OptionGlobals.DisableFarAnimations = !OptionGlobals.DisableFarAnimations;
        this.UpdateText();
        this.QualityManager.UpdateAnims();
      }
    } else if (this.Selected == 11) {
      if (this.InputManager.TappedRight) {
        OptionGlobals.FPSIndex++;
      } else if (this.InputManager.TappedLeft) {
        OptionGlobals.FPSIndex--;
      }
      this.QualityManager.UpdateFPSIndex();
      this.UpdateText();
    }
    if (Input.GetButtonDown("B")) {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PauseScreen.ScreenBlur.enabled = true;
      this.PauseScreen.MainMenu.SetActive(true);
      this.PauseScreen.Sideways = false;
      this.PauseScreen.PressedB = true;
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000781 RID: 1921 RVA: 0x00071178 File Offset: 0x0006F578
  public void UpdateText() {
    if (OptionGlobals.ParticleCount == 3) {
      this.ParticleLabel.text = "High";
    } else if (OptionGlobals.ParticleCount == 2) {
      this.ParticleLabel.text = "Low";
    } else if (OptionGlobals.ParticleCount == 1) {
      this.ParticleLabel.text = "None";
    }
    this.FPSCapLabel.text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
    this.OutlinesLabel.text = ((!OptionGlobals.DisableOutlines) ? "On" : "Off");
    this.AliasingLabel.text = QualitySettings.antiAliasing + "x";
    this.PostAliasingLabel.text = ((!OptionGlobals.DisablePostAliasing) ? "On" : "Off");
    this.BloomLabel.text = ((!OptionGlobals.DisableBloom) ? "On" : "Off");
    this.LowDetailLabel.text = ((OptionGlobals.LowDetailStudents != 0) ? ((OptionGlobals.LowDetailStudents * 10).ToString() + "m") : "Off");
    this.DrawDistanceLabel.text = OptionGlobals.DrawDistance + "m";
    this.FogLabel.text = ((!OptionGlobals.Fog) ? "Off" : "On");
    this.ShadowsLabel.text = ((!OptionGlobals.DisableShadows) ? "On" : "Off");
    this.FarAnimsLabel.text = ((!OptionGlobals.DisableFarAnimations) ? "On" : "Off");
  }

  // Token: 0x06000782 RID: 1922 RVA: 0x0007134C File Offset: 0x0006F74C
  private void UpdateHighlight() {
    if (this.Selected == 0) {
      this.Selected = this.SelectionLimit;
    } else if (this.Selected > this.SelectionLimit) {
      this.Selected = 1;
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 455f - 75f * (float)this.Selected, this.Highlight.localPosition.z);
  }

  // Token: 0x04001307 RID: 4871
  public QualityManagerScript QualityManager;

  // Token: 0x04001308 RID: 4872
  public InputManagerScript InputManager;

  // Token: 0x04001309 RID: 4873
  public PauseScreenScript PauseScreen;

  // Token: 0x0400130A RID: 4874
  public PromptBarScript PromptBar;

  // Token: 0x0400130B RID: 4875
  public UILabel DrawDistanceLabel;

  // Token: 0x0400130C RID: 4876
  public UILabel PostAliasingLabel;

  // Token: 0x0400130D RID: 4877
  public UILabel LowDetailLabel;

  // Token: 0x0400130E RID: 4878
  public UILabel AliasingLabel;

  // Token: 0x0400130F RID: 4879
  public UILabel OutlinesLabel;

  // Token: 0x04001310 RID: 4880
  public UILabel ParticleLabel;

  // Token: 0x04001311 RID: 4881
  public UILabel BloomLabel;

  // Token: 0x04001312 RID: 4882
  public UILabel FogLabel;

  // Token: 0x04001313 RID: 4883
  public UILabel ShadowsLabel;

  // Token: 0x04001314 RID: 4884
  public UILabel FarAnimsLabel;

  // Token: 0x04001315 RID: 4885
  public UILabel FPSCapLabel;

  // Token: 0x04001316 RID: 4886
  public int SelectionLimit = 2;

  // Token: 0x04001317 RID: 4887
  public int Selected = 1;

  // Token: 0x04001318 RID: 4888
  public Transform CloudSystem;

  // Token: 0x04001319 RID: 4889
  public Transform Highlight;

  // Token: 0x0400131A RID: 4890
  public GameObject Background;
}