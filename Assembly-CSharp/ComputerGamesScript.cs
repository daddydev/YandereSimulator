using UnityEngine;

// Token: 0x0200006E RID: 110
public class ComputerGamesScript : MonoBehaviour {

  // Token: 0x0600018D RID: 397 RVA: 0x0001AA38 File Offset: 0x00018E38
  private void Start() {
    this.GameWindow.gameObject.SetActive(false);
    this.DeactivateAllBenefits();
    this.OriginalColor = this.Yandere.PowerUp.color;
    if (ClubGlobals.Club == ClubType.Gaming) {
      this.EnableGames();
    } else {
      this.DisableGames();
    }
  }

  // Token: 0x0600018E RID: 398 RVA: 0x0001AA90 File Offset: 0x00018E90
  private void Update() {
    if (this.ShowWindow) {
      this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.InputManager.TappedUp) {
        this.Subject--;
        this.UpdateHighlight();
      } else if (this.InputManager.TappedDown) {
        this.Subject++;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A")) {
        this.ShowWindow = false;
        this.PlayGames();
        this.PromptBar.ClearButtons();
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = false;
      }
      if (Input.GetButtonDown("B")) {
        this.Yandere.CanMove = true;
        this.ShowWindow = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = false;
      }
    } else if (this.GameWindow.localScale.x > 0.1f) {
      this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    } else {
      this.GameWindow.localScale = Vector3.zero;
      this.GameWindow.gameObject.SetActive(false);
    }
    if (this.Gaming) {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(new Vector3(-25.155f, this.Chairs[this.GameID].transform.position.y, this.Chairs[this.GameID].transform.position.z));
      this.Timer += Time.deltaTime;
      if (this.Timer > 5f) {
        this.Yandere.PowerUp.transform.parent.gameObject.SetActive(true);
        this.Yandere.MyController.radius = 0.2f;
        this.Yandere.CanMove = true;
        this.Yandere.EmptyHands();
        this.Gaming = false;
        this.ActivateBenefit();
        this.EnableChairs();
      }
    } else if (this.Timer < 5f) {
      this.ID = 1;
      while (this.ID < this.ComputerGames.Length) {
        PromptScript promptScript = this.ComputerGames[this.ID];
        if (promptScript.Circle[0].fillAmount == 0f) {
          promptScript.Circle[0].fillAmount = 1f;
          this.GameID = this.ID;
          if (this.ID == 1) {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Confirm";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[4].text = "Select";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.IdleAnim);
            this.Yandere.CanMove = false;
            this.GameWindow.gameObject.SetActive(true);
            this.ShowWindow = true;
          } else {
            this.PlayGames();
          }
        }
        this.ID++;
      }
    }
    if (this.Yandere.PowerUp.gameObject.activeInHierarchy) {
      this.Timer += Time.deltaTime;
      this.Yandere.PowerUp.transform.localPosition = new Vector3(this.Yandere.PowerUp.transform.localPosition.x, this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime, this.Yandere.PowerUp.transform.localPosition.z);
      this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
      this.Yandere.PowerUp.transform.localEulerAngles = new Vector3(this.Yandere.PowerUp.transform.localEulerAngles.x, this.Yandere.PowerUp.transform.localEulerAngles.y + 180f, this.Yandere.PowerUp.transform.localEulerAngles.z);
      if (this.Yandere.PowerUp.color != new Color(1f, 1f, 1f, 1f)) {
        this.Yandere.PowerUp.color = this.OriginalColor;
      } else {
        this.Yandere.PowerUp.color = new Color(1f, 1f, 1f, 1f);
      }
      if (this.Timer > 6f) {
        this.Yandere.PowerUp.transform.parent.gameObject.SetActive(false);
        base.gameObject.SetActive(false);
      }
    }
  }

  // Token: 0x0600018F RID: 399 RVA: 0x0001B0F4 File Offset: 0x000194F4
  public void EnableGames() {
    for (int i = 1; i < this.ComputerGames.Length; i++) {
      this.ComputerGames[i].enabled = true;
    }
    base.gameObject.SetActive(true);
  }

  // Token: 0x06000190 RID: 400 RVA: 0x0001B134 File Offset: 0x00019534
  private void PlayGames() {
    this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_01");
    this.Yandere.MyController.radius = 0.1f;
    this.Yandere.CanMove = false;
    this.Gaming = true;
    this.DisableChairs();
    this.DisableGames();
  }

  // Token: 0x06000191 RID: 401 RVA: 0x0001B190 File Offset: 0x00019590
  public void DisableGames() {
    for (int i = 1; i < this.ComputerGames.Length; i++) {
      this.ComputerGames[i].enabled = false;
      this.ComputerGames[i].Hide();
    }
    if (!this.Gaming) {
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000192 RID: 402 RVA: 0x0001B1E8 File Offset: 0x000195E8
  private void EnableChairs() {
    for (int i = 1; i < this.Chairs.Length; i++) {
      this.Chairs[i].enabled = true;
    }
    base.gameObject.SetActive(true);
  }

  // Token: 0x06000193 RID: 403 RVA: 0x0001B228 File Offset: 0x00019628
  private void DisableChairs() {
    for (int i = 1; i < this.Chairs.Length; i++) {
      this.Chairs[i].enabled = false;
    }
  }

  // Token: 0x06000194 RID: 404 RVA: 0x0001B25C File Offset: 0x0001965C
  private void ActivateBenefit() {
    if (this.GameID == 1) {
      if (this.Subject == 1) {
        ClassGlobals.BiologyBonus = 1;
      } else if (this.Subject == 2) {
        ClassGlobals.ChemistryBonus = 1;
      } else if (this.Subject == 3) {
        ClassGlobals.LanguageBonus = 1;
      } else if (this.Subject == 4) {
        ClassGlobals.PsychologyBonus = 1;
      }
    } else if (this.GameID == 2) {
      ClassGlobals.PhysicalBonus = 1;
    } else if (this.GameID == 3) {
      PlayerGlobals.SeductionBonus = 1;
    } else if (this.GameID == 4) {
      PlayerGlobals.NumbnessBonus = 1;
    } else if (this.GameID == 5) {
      PlayerGlobals.SocialBonus = 1;
    } else if (this.GameID == 6) {
      PlayerGlobals.StealthBonus = 1;
    } else if (this.GameID == 7) {
      PlayerGlobals.SpeedBonus = 1;
    } else if (this.GameID == 8) {
      PlayerGlobals.EnlightenmentBonus = 1;
    }
    if (this.Poison != null) {
      this.Poison.Start();
    }
    this.StudentManager.UpdatePerception();
    this.Yandere.UpdateNumbness();
  }

  // Token: 0x06000195 RID: 405 RVA: 0x0001B3A0 File Offset: 0x000197A0
  private void DeactivateBenefit() {
    if (this.GameID == 1) {
      if (this.Subject == 1) {
        ClassGlobals.BiologyBonus = 0;
      } else if (this.Subject == 2) {
        ClassGlobals.ChemistryBonus = 0;
      } else if (this.Subject == 3) {
        ClassGlobals.LanguageBonus = 0;
      } else if (this.Subject == 4) {
        ClassGlobals.PsychologyBonus = 0;
      }
    } else if (this.GameID == 2) {
      ClassGlobals.PhysicalBonus = 0;
    } else if (this.GameID == 3) {
      PlayerGlobals.SeductionBonus = 0;
    } else if (this.GameID == 4) {
      PlayerGlobals.NumbnessBonus = 0;
    } else if (this.GameID == 5) {
      PlayerGlobals.SocialBonus = 0;
    } else if (this.GameID == 6) {
      PlayerGlobals.StealthBonus = 0;
    } else if (this.GameID == 7) {
      PlayerGlobals.SpeedBonus = 0;
    } else if (this.GameID == 8) {
      PlayerGlobals.EnlightenmentBonus = 0;
    }
    if (this.Poison != null) {
      this.Poison.Start();
    }
    this.StudentManager.UpdatePerception();
    this.Yandere.UpdateNumbness();
  }

  // Token: 0x06000196 RID: 406 RVA: 0x0001B4E4 File Offset: 0x000198E4
  public void DeactivateAllBenefits() {
    ClassGlobals.BiologyBonus = 0;
    ClassGlobals.ChemistryBonus = 0;
    ClassGlobals.LanguageBonus = 0;
    ClassGlobals.PsychologyBonus = 0;
    ClassGlobals.PhysicalBonus = 0;
    PlayerGlobals.SeductionBonus = 0;
    PlayerGlobals.NumbnessBonus = 0;
    PlayerGlobals.SocialBonus = 0;
    PlayerGlobals.StealthBonus = 0;
    PlayerGlobals.SpeedBonus = 0;
    PlayerGlobals.EnlightenmentBonus = 0;
    if (this.Poison != null) {
      this.Poison.Start();
    }
  }

  // Token: 0x06000197 RID: 407 RVA: 0x0001B550 File Offset: 0x00019950
  private void UpdateHighlight() {
    if (this.Subject < 1) {
      this.Subject = 4;
    } else if (this.Subject > 4) {
      this.Subject = 1;
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - (float)this.Subject * 100f, this.Highlight.localPosition.z);
  }

  // Token: 0x040004DE RID: 1246
  public PromptScript[] ComputerGames;

  // Token: 0x040004DF RID: 1247
  public Collider[] Chairs;

  // Token: 0x040004E0 RID: 1248
  public StudentManagerScript StudentManager;

  // Token: 0x040004E1 RID: 1249
  public InputManagerScript InputManager;

  // Token: 0x040004E2 RID: 1250
  public PromptBarScript PromptBar;

  // Token: 0x040004E3 RID: 1251
  public YandereScript Yandere;

  // Token: 0x040004E4 RID: 1252
  public PoisonScript Poison;

  // Token: 0x040004E5 RID: 1253
  public Quaternion targetRotation;

  // Token: 0x040004E6 RID: 1254
  public Transform GameWindow;

  // Token: 0x040004E7 RID: 1255
  public Transform MainCamera;

  // Token: 0x040004E8 RID: 1256
  public Transform Highlight;

  // Token: 0x040004E9 RID: 1257
  public bool ShowWindow;

  // Token: 0x040004EA RID: 1258
  public bool Gaming;

  // Token: 0x040004EB RID: 1259
  public float Timer;

  // Token: 0x040004EC RID: 1260
  public int Subject = 1;

  // Token: 0x040004ED RID: 1261
  public int GameID;

  // Token: 0x040004EE RID: 1262
  public int ID = 1;

  // Token: 0x040004EF RID: 1263
  public Color OriginalColor;
}