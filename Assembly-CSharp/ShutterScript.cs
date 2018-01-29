using UnityEngine;

// Token: 0x020001B4 RID: 436
public class ShutterScript : MonoBehaviour {

  // Token: 0x170000E4 RID: 228
  // (get) Token: 0x06000799 RID: 1945 RVA: 0x000741E3 File Offset: 0x000725E3
  public int OnlyPhotography {
    get {
      return 65537;
    }
  }

  // Token: 0x170000E5 RID: 229
  // (get) Token: 0x0600079A RID: 1946 RVA: 0x000741EA File Offset: 0x000725EA
  public int OnlyCharacters {
    get {
      return 513;
    }
  }

  // Token: 0x170000E6 RID: 230
  // (get) Token: 0x0600079B RID: 1947 RVA: 0x000741F1 File Offset: 0x000725F1
  public int OnlyRagdolls {
    get {
      return 2049;
    }
  }

  // Token: 0x170000E7 RID: 231
  // (get) Token: 0x0600079C RID: 1948 RVA: 0x000741F8 File Offset: 0x000725F8
  public int OnlyBlood {
    get {
      return 16385;
    }
  }

  // Token: 0x0600079D RID: 1949 RVA: 0x00074200 File Offset: 0x00072600
  private void Start() {
    if (MissionModeGlobals.MissionMode) {
      this.MissionMode = true;
    }
    this.ErrorWindow.transform.localScale = Vector3.zero;
    this.CameraButtons.SetActive(false);
    this.PhotoIcons.SetActive(false);
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
  }

  // Token: 0x0600079E RID: 1950 RVA: 0x0007429C File Offset: 0x0007269C
  private void Update() {
    if (this.Snapping) {
      if (this.Close) {
        this.currentPercent += 40f * Time.unscaledDeltaTime;
        while (this.currentPercent >= 1f) {
          this.Frame = Mathf.Min(this.Frame + 1, 8);
          this.currentPercent -= 1f;
        }
        this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
        if (this.Frame == 8) {
          this.StudentManager.GhostChan.gameObject.SetActive(true);
          this.StudentManager.GhostChan.Look();
          this.CheckPhoto();
          this.SmartphoneCamera.targetTexture = null;
          this.Yandere.PhonePromptBar.Show = false;
          this.NotificationManager.SetActive(false);
          this.HeartbeatCamera.SetActive(false);
          this.MainCamera.enabled = false;
          this.PhotoIcons.SetActive(true);
          this.SubPanel.SetActive(false);
          this.Panel.SetActive(false);
          this.Close = false;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Save";
          this.PromptBar.Label[1].text = "Delete";
          if (!this.Yandere.RivalPhone) {
            this.PromptBar.Label[2].text = "Send";
          }
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          Time.timeScale = 0f;
        }
      } else {
        this.currentPercent += 40f * Time.unscaledDeltaTime;
        while (this.currentPercent >= 1f) {
          this.Frame = Mathf.Max(this.Frame - 1, 1);
          this.currentPercent -= 1f;
        }
        this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
        if (this.Frame == 1) {
          this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
          this.Snapping = false;
        }
      }
    } else if (this.Yandere.Aiming) {
      this.TargetStudent = 0;
      this.Timer += Time.deltaTime;
      if (this.Timer > 0.5f) {
        if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyPhotography)) {
          if (this.hit.collider.gameObject.name == "Face") {
            GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
            this.FaceStudent = gameObject.GetComponent<StudentScript>();
            if (this.FaceStudent != null) {
              this.TargetStudent = this.FaceStudent.StudentID;
              if (this.TargetStudent > 1) {
                this.ReactionDistance = 1.66666f;
              } else {
                this.ReactionDistance = this.FaceStudent.VisionDistance;
              }
              if (!this.FaceStudent.Alarmed && !this.FaceStudent.Distracted && !this.FaceStudent.InEvent && !this.FaceStudent.Wet && this.FaceStudent.Schoolwear > 0 && !this.FaceStudent.Fleeing && !this.FaceStudent.Following && !this.FaceStudent.ShoeRemoval.enabled && !this.FaceStudent.HoldingHands && this.FaceStudent.Actions[this.FaceStudent.Phase] != StudentActionType.Mourn && !this.FaceStudent.Guarding && Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < this.ReactionDistance && this.FaceStudent.CanSeeObject(this.Yandere.gameObject, this.Yandere.transform.position + Vector3.up)) {
                if (this.MissionMode) {
                  this.PenaltyTimer += Time.deltaTime;
                  if (this.PenaltyTimer > 1f) {
                    this.FaceStudent.Reputation.PendingRep -= -10f;
                    this.PenaltyTimer = 0f;
                  }
                }
                if (!this.FaceStudent.CameraReacting) {
                  if (this.FaceStudent.enabled && !this.FaceStudent.Stop) {
                    if (this.FaceStudent.PhotoPatience > 0f) {
                      if (this.FaceStudent.StudentID > 1) {
                        if (this.Yandere.Bloodiness > 0f || (double)this.Yandere.Sanity < 33.33333) {
                          this.FaceStudent.Alarm += 200f;
                        } else {
                          this.FaceStudent.CameraReact();
                        }
                      } else {
                        this.FaceStudent.Alarm += Time.deltaTime * (100f / this.FaceStudent.DistanceToPlayer) * this.FaceStudent.Paranoia * this.FaceStudent.Perception * this.FaceStudent.DistanceToPlayer * 2f;
                        this.FaceStudent.YandereVisible = true;
                      }
                    } else {
                      this.Penalize();
                    }
                  }
                } else {
                  this.FaceStudent.PhotoPatience = Mathf.MoveTowards(this.FaceStudent.PhotoPatience, 0f, Time.deltaTime);
                  if (this.FaceStudent.PhotoPatience > 0f) {
                    this.FaceStudent.CameraPoseTimer = 1f;
                  }
                }
              }
            }
          } else if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt") {
            GameObject gameObject2 = this.hit.collider.gameObject.transform.root.gameObject;
            if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyCharacters)) {
              if (Vector3.Distance(this.Yandere.transform.position, gameObject2.transform.position) < 5f) {
                if (this.hit.collider.gameObject == gameObject2) {
                  if (!this.Yandere.Lewd) {
                    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Lewd);
                  }
                  this.Yandere.Lewd = true;
                } else {
                  this.Yandere.Lewd = false;
                }
              } else {
                this.Yandere.Lewd = false;
              }
            }
          } else {
            this.Yandere.Lewd = false;
          }
        } else {
          this.Yandere.Lewd = false;
        }
      }
    } else {
      this.Timer = 0f;
    }
    if (this.TookPhoto) {
      this.ResumeGameplay();
    }
    if (!this.DisplayError) {
      if (this.PhotoIcons.activeInHierarchy && !this.Snapping && !this.TextMessages.gameObject.activeInHierarchy) {
        if (Input.GetButtonDown("A")) {
          if (!this.Yandere.RivalPhone) {
            bool flag = !this.SenpaiX.activeInHierarchy;
            this.PromptBar.transform.localPosition = new Vector3(this.PromptBar.transform.localPosition.x, -627f, this.PromptBar.transform.localPosition.z);
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.PhotoIcons.SetActive(false);
            this.ID = 0;
            this.FreeSpace = false;
            while (this.ID < 26) {
              this.ID++;
              if (!PlayerGlobals.GetPhoto(this.ID)) {
                this.FreeSpace = true;
                this.Slot = this.ID;
                this.ID = 26;
              }
            }
            if (this.FreeSpace) {
              Application.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/Photo_" + this.Slot.ToString() + ".png");
              this.TookPhoto = true;
              Debug.Log("Setting Photo " + this.Slot + " to ''true''.");
              PlayerGlobals.SetPhoto(this.Slot, true);
              if (flag) {
                PlayerGlobals.SetSenpaiPhoto(this.Slot, true);
              }
              if (this.KittenShot) {
                TaskGlobals.SetKittenPhoto(this.Slot, true);
                this.TaskManager.UpdateTaskStatus();
              }
            } else {
              this.DisplayError = true;
            }
          } else if (!this.PantiesX.activeInHierarchy) {
            this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos = true;
            SchemeGlobals.SetSchemeStage(4, 3);
            this.Schemes.UpdateInstructions();
            this.ResumeGameplay();
          }
        }
        if (!this.Yandere.RivalPhone && Input.GetButtonDown("X")) {
          this.Panel.SetActive(true);
          this.MainMenu.SetActive(false);
          this.PauseScreen.Show = true;
          this.PauseScreen.Panel.enabled = true;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[1].text = "Exit";
          this.PromptBar.Label[3].text = "Interests";
          this.PromptBar.UpdateButtons();
          if (!this.InfoX.activeInHierarchy) {
            this.PauseScreen.Sideways = true;
            StudentGlobals.SetStudentPhotographed(this.Student.StudentID, true);
            this.ID = 0;
            while (this.ID < this.Student.Outlines.Length) {
              this.Student.Outlines[this.ID].enabled = true;
              this.ID++;
            }
            this.StudentInfo.UpdateInfo(this.Student.StudentID);
            this.StudentInfo.gameObject.SetActive(true);
          } else if (!this.TextMessages.gameObject.activeInHierarchy) {
            this.PauseScreen.Sideways = false;
            this.TextMessages.gameObject.SetActive(true);
            this.SpawnMessage();
          }
        }
        if (Input.GetButtonDown("B")) {
          this.ResumeGameplay();
        }
      } else if (this.PhotoIcons.activeInHierarchy && Input.GetButtonDown("B")) {
        this.ResumeGameplay();
      }
    } else {
      float t = Time.unscaledDeltaTime * 10f;
      this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), t);
      if (Input.GetButtonDown("A")) {
        this.ResumeGameplay();
      }
    }
  }

  // Token: 0x0600079F RID: 1951 RVA: 0x00074EF4 File Offset: 0x000732F4
  public void Snap() {
    this.ErrorWindow.transform.localScale = Vector3.zero;
    this.Yandere.HandCamera.SetActive(false);
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
    this.Snapping = true;
    this.Close = true;
    this.Frame = 0;
  }

  // Token: 0x060007A0 RID: 1952 RVA: 0x00074F8C File Offset: 0x0007338C
  private void CheckPhoto() {
    this.InfoX.SetActive(true);
    this.PantiesX.SetActive(true);
    this.SenpaiX.SetActive(true);
    this.ViolenceX.SetActive(true);
    this.KittenShot = false;
    this.Nemesis = false;
    this.NotFace = false;
    this.Skirt = false;
    if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyPhotography)) {
      if (this.hit.collider.gameObject.name == "Panties") {
        this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
        this.PantiesX.SetActive(false);
      } else if (this.hit.collider.gameObject.name == "Face") {
        if (this.hit.collider.gameObject.tag == "Nemesis") {
          this.Nemesis = true;
          this.NemesisShots++;
        } else if (this.hit.collider.gameObject.tag == "Disguise") {
          this.Disguise = true;
        } else {
          this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
          if (this.Student.StudentID == 1) {
            this.SenpaiX.SetActive(false);
          } else {
            this.InfoX.SetActive(false);
          }
        }
      } else if (this.hit.collider.gameObject.name == "NotFace") {
        this.NotFace = true;
      } else if (this.hit.collider.gameObject.name == "Skirt") {
        this.Skirt = true;
      }
      if (this.hit.collider.gameObject.name == "Kitten") {
        this.KittenShot = true;
        if (!ConversationGlobals.GetTopicDiscovered(20)) {
          ConversationGlobals.SetTopicDiscovered(20, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
      }
    }
    if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11) {
      this.ViolenceX.SetActive(false);
    }
    if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.layer == 14) {
      this.ViolenceX.SetActive(false);
    }
  }

  // Token: 0x060007A1 RID: 1953 RVA: 0x000752F0 File Offset: 0x000736F0
  private void SpawnMessage() {
    if (this.NewMessage != null) {
      UnityEngine.Object.Destroy(this.NewMessage);
    }
    this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
    this.NewMessage.transform.parent = this.TextMessages;
    this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
    this.NewMessage.transform.localEulerAngles = Vector3.zero;
    this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
    bool flag = false;
    if (this.hit.collider != null && this.hit.collider.gameObject.name == "Kitten") {
      flag = true;
    }
    string text = string.Empty;
    int num;
    if (flag) {
      text = "Why are you showing me this? I don't care.";
      num = 2;
    } else if (!this.InfoX.activeInHierarchy) {
      text = "I recognize this person. Here's some information about them.";
      num = 3;
    } else if (!this.PantiesX.activeInHierarchy) {
      if (this.Student != null) {
        if (!PlayerGlobals.GetStudentPantyShot(this.Student.Name)) {
          PlayerGlobals.SetStudentPantyShot(this.Student.Name, true);
          if (this.Student.Nemesis) {
            text = "Wait...I recognize those panties! This person is extremely dangerous! Avoid her at all costs!";
          } else if (this.Student.StudentID == 32 || this.Student.Club == ClubType.Council) {
            text = "A high value target! " + this.Student.Name + "'s panties were in high demand. I owe you a big favor for this one.";
            PlayerGlobals.PantyShots += 5;
          } else {
            text = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. I owe you a favor for this one.";
            PlayerGlobals.PantyShots++;
          }
          num = 5;
        } else if (!this.Student.Nemesis) {
          text = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
          num = 4;
        } else {
          text = "You are in danger. Avoid her.";
          num = 2;
        }
      } else {
        text = "How peculiar. I don't recognize these panties.";
        num = 2;
      }
    } else if (!this.ViolenceX.activeInHierarchy) {
      text = "Good work, but don't send me this stuff. I have no use for it.";
      num = 3;
    } else if (!this.SenpaiX.activeInHierarchy) {
      if (PlayerGlobals.SenpaiShots == 0) {
        text = "I don't need any pictures of your Senpai.";
        num = 2;
      } else if (PlayerGlobals.SenpaiShots == 1) {
        text = "I know how you feel about this person, but I have no use for these pictures.";
        num = 4;
      } else if (PlayerGlobals.SenpaiShots == 2) {
        text = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
        num = 5;
      } else if (PlayerGlobals.SenpaiShots == 3) {
        text = "You're spamming my inbox. Cut it out.";
        num = 2;
      } else {
        text = "...";
        num = 1;
      }
      PlayerGlobals.SenpaiShots++;
    } else if (this.NotFace) {
      text = "Do you want me to identify this person? Please get me a clear shot of their face.";
      num = 4;
    } else if (this.Skirt) {
      text = "Is this supposed to be a panty shot? My clients are picky. The panties need to be in the EXACT center of the shot.";
      num = 5;
    } else if (this.Nemesis) {
      if (this.NemesisShots == 1) {
        text = "Strange. I have no profile for this student.";
        num = 2;
      } else if (this.NemesisShots == 2) {
        text = "...wait. I think I know who she is.";
        num = 2;
      } else if (this.NemesisShots == 3) {
        text = "You are in danger. Avoid her.";
        num = 2;
      } else if (this.NemesisShots == 4) {
        text = "Do not engage.";
        num = 1;
      } else {
        text = "I repeat: Do. Not. Engage.";
        num = 2;
      }
    } else if (this.Disguise) {
      text = "Something about that student seems...wrong.";
      num = 2;
    } else {
      text = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
      num = 5;
    }
    this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * num;
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = text;
  }

  // Token: 0x060007A2 RID: 1954 RVA: 0x000756E0 File Offset: 0x00073AE0
  private void ResumeGameplay() {
    this.ErrorWindow.transform.localScale = Vector3.zero;
    this.SmartphoneCamera.targetTexture = this.SmartphoneScreen;
    this.StudentManager.GhostChan.gameObject.SetActive(false);
    this.NotificationManager.SetActive(true);
    this.PauseScreen.CorrectingTime = true;
    this.Yandere.HandCamera.SetActive(true);
    this.HeartbeatCamera.SetActive(true);
    this.TextMessages.gameObject.SetActive(false);
    this.StudentInfo.gameObject.SetActive(false);
    this.MainCamera.enabled = true;
    this.PhotoIcons.SetActive(false);
    this.PauseScreen.Show = false;
    this.SubPanel.SetActive(true);
    this.MainMenu.SetActive(true);
    this.Yandere.CanMove = true;
    this.DisplayError = false;
    this.Panel.SetActive(true);
    Time.timeScale = 1f;
    this.TakePhoto = false;
    this.TookPhoto = false;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    if (this.NewMessage != null) {
      UnityEngine.Object.Destroy(this.NewMessage);
    }
    if (!this.Yandere.CameraEffects.OneCamera) {
      this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
      this.Yandere.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
    }
  }

  // Token: 0x060007A3 RID: 1955 RVA: 0x00075864 File Offset: 0x00073C64
  private void Penalize() {
    this.PenaltyTimer += Time.deltaTime;
    if (this.PenaltyTimer > 1f) {
      this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
      this.FaceStudent.RepDeduction = 0f;
      this.FaceStudent.RepLoss = 1f;
      this.FaceStudent.CalculateReputationPenalty();
      if (this.FaceStudent.RepDeduction >= 0f) {
        this.FaceStudent.RepLoss -= this.FaceStudent.RepDeduction;
      }
      this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
      this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
      this.PenaltyTimer = 0f;
    }
  }

  // Token: 0x04001379 RID: 4985
  public StudentManagerScript StudentManager;

  // Token: 0x0400137A RID: 4986
  public TaskManagerScript TaskManager;

  // Token: 0x0400137B RID: 4987
  public PauseScreenScript PauseScreen;

  // Token: 0x0400137C RID: 4988
  public StudentInfoScript StudentInfo;

  // Token: 0x0400137D RID: 4989
  public PromptBarScript PromptBar;

  // Token: 0x0400137E RID: 4990
  public SubtitleScript Subtitle;

  // Token: 0x0400137F RID: 4991
  public SchemesScript Schemes;

  // Token: 0x04001380 RID: 4992
  public StudentScript Student;

  // Token: 0x04001381 RID: 4993
  public YandereScript Yandere;

  // Token: 0x04001382 RID: 4994
  public StudentScript FaceStudent;

  // Token: 0x04001383 RID: 4995
  public RenderTexture SmartphoneScreen;

  // Token: 0x04001384 RID: 4996
  public Camera SmartphoneCamera;

  // Token: 0x04001385 RID: 4997
  public Transform TextMessages;

  // Token: 0x04001386 RID: 4998
  public Transform ErrorWindow;

  // Token: 0x04001387 RID: 4999
  public Camera MainCamera;

  // Token: 0x04001388 RID: 5000
  public UISprite Sprite;

  // Token: 0x04001389 RID: 5001
  public GameObject NotificationManager;

  // Token: 0x0400138A RID: 5002
  public GameObject HeartbeatCamera;

  // Token: 0x0400138B RID: 5003
  public GameObject CameraButtons;

  // Token: 0x0400138C RID: 5004
  public GameObject NewMessage;

  // Token: 0x0400138D RID: 5005
  public GameObject PhotoIcons;

  // Token: 0x0400138E RID: 5006
  public GameObject MainMenu;

  // Token: 0x0400138F RID: 5007
  public GameObject SubPanel;

  // Token: 0x04001390 RID: 5008
  public GameObject Message;

  // Token: 0x04001391 RID: 5009
  public GameObject Panel;

  // Token: 0x04001392 RID: 5010
  public GameObject ViolenceX;

  // Token: 0x04001393 RID: 5011
  public GameObject PantiesX;

  // Token: 0x04001394 RID: 5012
  public GameObject SenpaiX;

  // Token: 0x04001395 RID: 5013
  public GameObject InfoX;

  // Token: 0x04001396 RID: 5014
  public bool DisplayError;

  // Token: 0x04001397 RID: 5015
  public bool MissionMode;

  // Token: 0x04001398 RID: 5016
  public bool KittenShot;

  // Token: 0x04001399 RID: 5017
  public bool FreeSpace;

  // Token: 0x0400139A RID: 5018
  public bool TakePhoto;

  // Token: 0x0400139B RID: 5019
  public bool TookPhoto;

  // Token: 0x0400139C RID: 5020
  public bool Snapping;

  // Token: 0x0400139D RID: 5021
  public bool Close;

  // Token: 0x0400139E RID: 5022
  public bool Disguise;

  // Token: 0x0400139F RID: 5023
  public bool Nemesis;

  // Token: 0x040013A0 RID: 5024
  public bool NotFace;

  // Token: 0x040013A1 RID: 5025
  public bool Skirt;

  // Token: 0x040013A2 RID: 5026
  public RaycastHit hit;

  // Token: 0x040013A3 RID: 5027
  public float ReactionDistance;

  // Token: 0x040013A4 RID: 5028
  public float PenaltyTimer;

  // Token: 0x040013A5 RID: 5029
  public float Timer;

  // Token: 0x040013A6 RID: 5030
  private float currentPercent;

  // Token: 0x040013A7 RID: 5031
  public int TargetStudent;

  // Token: 0x040013A8 RID: 5032
  public int NemesisShots;

  // Token: 0x040013A9 RID: 5033
  public int Frame;

  // Token: 0x040013AA RID: 5034
  public int Slot;

  // Token: 0x040013AB RID: 5035
  public int ID;
}