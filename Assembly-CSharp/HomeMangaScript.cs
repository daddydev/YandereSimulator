using UnityEngine;

// Token: 0x020000FC RID: 252
public class HomeMangaScript : MonoBehaviour {

  // Token: 0x060004F8 RID: 1272 RVA: 0x000436DC File Offset: 0x00041ADC
  private void Start() {
    this.UpdateCurrentLabel();
    for (int i = 0; i < this.TotalManga; i++) {
      if (CollectibleGlobals.GetMangaCollected(i + 1)) {
        this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MangaModels[i], new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
      } else {
        this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MysteryManga, new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
      }
      this.NewManga.transform.parent = this.MangaParent;
      this.NewManga.GetComponent<HomeMangaBookScript>().Manga = this;
      this.NewManga.GetComponent<HomeMangaBookScript>().ID = i;
      this.NewManga.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
      this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, this.MangaParent.transform.localEulerAngles.y + 360f / (float)this.TotalManga, this.MangaParent.transform.localEulerAngles.z);
      this.MangaList[i] = this.NewManga;
    }
    this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, 0f, this.MangaParent.transform.localEulerAngles.z);
    this.MangaParent.transform.localPosition = new Vector3(this.MangaParent.transform.localPosition.x, this.MangaParent.transform.localPosition.y, 1.8f);
    this.UpdateMangaLabels();
    this.MangaParent.transform.localScale = Vector3.zero;
    this.MangaParent.gameObject.SetActive(false);
  }

  // Token: 0x060004F9 RID: 1273 RVA: 0x00043970 File Offset: 0x00041D70
  private void Update() {
    if (this.HomeWindow.Show) {
      if (!this.AreYouSure.activeInHierarchy) {
        this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.MangaParent.gameObject.SetActive(true);
        if (this.InputManager.TappedRight) {
          this.DestinationReached = false;
          this.TargetRotation += 360f / (float)this.TotalManga;
          this.Selected++;
          if (this.Selected > this.TotalManga - 1) {
            this.Selected = 0;
          }
          this.UpdateMangaLabels();
          this.UpdateCurrentLabel();
        }
        if (this.InputManager.TappedLeft) {
          this.DestinationReached = false;
          this.TargetRotation -= 360f / (float)this.TotalManga;
          this.Selected--;
          if (this.Selected < 0) {
            this.Selected = this.TotalManga - 1;
          }
          this.UpdateMangaLabels();
          this.UpdateCurrentLabel();
        }
        this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
        this.MangaParent.localEulerAngles = new Vector3(this.MangaParent.localEulerAngles.x, this.Rotation, this.MangaParent.localEulerAngles.z);
        if (Input.GetButtonDown("A") && this.ReadButtonGroup.activeInHierarchy) {
          this.MangaGroup.SetActive(false);
          this.AreYouSure.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
          PlayerGlobals.Seduction++;
          PlayerGlobals.Numbness++;
          PlayerGlobals.Enlightenment++;
          if (PlayerGlobals.Seduction > 5) {
            PlayerGlobals.Seduction = 0;
            PlayerGlobals.Numbness = 0;
            PlayerGlobals.Enlightenment = 0;
          }
          this.UpdateCurrentLabel();
          this.UpdateMangaLabels();
        }
        if (Input.GetButtonDown("B")) {
          this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
          this.HomeCamera.Target = this.HomeCamera.Targets[0];
          this.HomeYandere.CanMove = true;
          this.HomeWindow.Show = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
          for (int i = 0; i < this.TotalManga; i++) {
            CollectibleGlobals.SetMangaCollected(i + 1, true);
          }
        }
      } else {
        if (Input.GetButtonDown("A")) {
          if (this.Selected < 5) {
            PlayerGlobals.Seduction++;
          } else if (this.Selected < 10) {
            PlayerGlobals.Numbness++;
          } else {
            PlayerGlobals.Enlightenment++;
          }
          HomeGlobals.LateForSchool = true;
          this.AreYouSure.SetActive(false);
          this.Darkness.FadeOut = true;
        }
        if (Input.GetButtonDown("B")) {
          this.MangaGroup.SetActive(true);
          this.AreYouSure.SetActive(false);
        }
      }
    } else {
      this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, Vector3.zero, Time.deltaTime * 10f);
      if (this.MangaParent.localScale.x < 0.01f) {
        this.MangaParent.gameObject.SetActive(false);
      }
    }
  }

  // Token: 0x060004FA RID: 1274 RVA: 0x00043D24 File Offset: 0x00042124
  private void UpdateMangaLabels() {
    if (this.Selected < 5) {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Seduction == this.Selected);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1)) {
        if (PlayerGlobals.Seduction > this.Selected) {
          this.RequiredLabel.text = "You have already read this manga.";
        } else {
          this.RequiredLabel.text = "Required Seduction Level: " + this.Selected.ToString();
        }
      } else {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    } else if (this.Selected < 10) {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Numbness == this.Selected - 5);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1)) {
        if (PlayerGlobals.Numbness > this.Selected - 5) {
          this.RequiredLabel.text = "You have already read this manga.";
        } else {
          this.RequiredLabel.text = "Required Numbness Level: " + (this.Selected - 5).ToString();
        }
      } else {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    } else {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Enlightenment == this.Selected - 10);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1)) {
        if (PlayerGlobals.Enlightenment > this.Selected - 10) {
          this.RequiredLabel.text = "You have already read this manga.";
        } else {
          this.RequiredLabel.text = "Required Enlightenment Level: " + (this.Selected - 10).ToString();
        }
      } else {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    }
    if (CollectibleGlobals.GetMangaCollected(this.Selected + 1)) {
      this.MangaNameLabel.text = this.MangaNames[this.Selected];
      this.MangaDescLabel.text = this.MangaDescs[this.Selected];
      this.MangaBuffLabel.text = this.MangaBuffs[this.Selected];
    } else {
      this.MangaNameLabel.text = "?????";
      this.MangaDescLabel.text = "?????";
      this.MangaBuffLabel.text = "?????";
    }
  }

  // Token: 0x060004FB RID: 1275 RVA: 0x00043FBC File Offset: 0x000423BC
  private void UpdateCurrentLabel() {
    if (this.Selected < 5) {
      this.Title = HomeMangaScript.SeductionStrings[PlayerGlobals.Seduction];
      this.CurrentLabel.text = string.Concat(new string[]
      {
        "Current Seduction Level: ",
        PlayerGlobals.Seduction.ToString(),
        " (",
        this.Title,
        ")"
      });
    } else if (this.Selected < 10) {
      this.Title = HomeMangaScript.NumbnessStrings[PlayerGlobals.Numbness];
      this.CurrentLabel.text = string.Concat(new string[]
      {
        "Current Numbness Level: ",
        PlayerGlobals.Numbness.ToString(),
        " (",
        this.Title,
        ")"
      });
    } else {
      this.Title = HomeMangaScript.EnlightenmentStrings[PlayerGlobals.Enlightenment];
      this.CurrentLabel.text = string.Concat(new string[]
      {
        "Current Enlightenment Level: ",
        PlayerGlobals.Enlightenment.ToString(),
        " (",
        this.Title,
        ")"
      });
    }
  }

  // Token: 0x04000B6B RID: 2923
  private static readonly string[] SeductionStrings = new string[]
  {
    "Innocent",
    "Flirty",
    "Charming",
    "Sensual",
    "Seductive",
    "Succubus"
  };

  // Token: 0x04000B6C RID: 2924
  private static readonly string[] NumbnessStrings = new string[]
  {
    "Stoic",
    "Somber",
    "Detatched",
    "Unemotional",
    "Desensitized",
    "Dead Inside"
  };

  // Token: 0x04000B6D RID: 2925
  private static readonly string[] EnlightenmentStrings = new string[]
  {
    "Asleep",
    "Awoken",
    "Mindful",
    "Informed",
    "Eyes Open",
    "Omniscient"
  };

  // Token: 0x04000B6E RID: 2926
  public InputManagerScript InputManager;

  // Token: 0x04000B6F RID: 2927
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B70 RID: 2928
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B71 RID: 2929
  public HomeWindowScript HomeWindow;

  // Token: 0x04000B72 RID: 2930
  public HomeDarknessScript Darkness;

  // Token: 0x04000B73 RID: 2931
  private GameObject NewManga;

  // Token: 0x04000B74 RID: 2932
  public GameObject ReadButtonGroup;

  // Token: 0x04000B75 RID: 2933
  public GameObject MysteryManga;

  // Token: 0x04000B76 RID: 2934
  public GameObject AreYouSure;

  // Token: 0x04000B77 RID: 2935
  public GameObject MangaGroup;

  // Token: 0x04000B78 RID: 2936
  public GameObject[] MangaList;

  // Token: 0x04000B79 RID: 2937
  public UILabel MangaNameLabel;

  // Token: 0x04000B7A RID: 2938
  public UILabel MangaDescLabel;

  // Token: 0x04000B7B RID: 2939
  public UILabel MangaBuffLabel;

  // Token: 0x04000B7C RID: 2940
  public UILabel RequiredLabel;

  // Token: 0x04000B7D RID: 2941
  public UILabel CurrentLabel;

  // Token: 0x04000B7E RID: 2942
  public UILabel ButtonLabel;

  // Token: 0x04000B7F RID: 2943
  public Transform MangaParent;

  // Token: 0x04000B80 RID: 2944
  public bool DestinationReached;

  // Token: 0x04000B81 RID: 2945
  public float TargetRotation;

  // Token: 0x04000B82 RID: 2946
  public float Rotation;

  // Token: 0x04000B83 RID: 2947
  public int TotalManga;

  // Token: 0x04000B84 RID: 2948
  public int Selected;

  // Token: 0x04000B85 RID: 2949
  public string Title = string.Empty;

  // Token: 0x04000B86 RID: 2950
  public GameObject[] MangaModels;

  // Token: 0x04000B87 RID: 2951
  public string[] MangaNames;

  // Token: 0x04000B88 RID: 2952
  public string[] MangaDescs;

  // Token: 0x04000B89 RID: 2953
  public string[] MangaBuffs;
}