using UnityEngine;

// Token: 0x020001D3 RID: 467
public class TallLockerScript : MonoBehaviour {

  // Token: 0x0600086D RID: 2157 RVA: 0x0009757F File Offset: 0x0009597F
  private void Awake() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x0600086E RID: 2158 RVA: 0x00097596 File Offset: 0x00095996
  private void Start() {
    this.Prompt.HideButton[1] = true;
    this.Prompt.HideButton[2] = true;
    this.Prompt.HideButton[3] = true;
  }

  // Token: 0x0600086F RID: 2159 RVA: 0x000975C4 File Offset: 0x000959C4
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Open) {
        this.Open = true;
        if (this.YandereLocker) {
          if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > 0f)) {
            if (this.Yandere.Bloodiness == 0f) {
              if (!this.Bloody[1]) {
                this.Prompt.HideButton[1] = false;
              }
              if (!this.Bloody[2]) {
                this.Prompt.HideButton[2] = false;
              }
              if (!this.Bloody[3]) {
                this.Prompt.HideButton[3] = false;
              }
            } else if (this.Yandere.Schoolwear > 0) {
              if (!this.Yandere.ClubAttire) {
                this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
              } else {
                this.Prompt.HideButton[1] = false;
              }
            }
          } else {
            this.Prompt.HideButton[1] = true;
            this.Prompt.HideButton[2] = true;
            this.Prompt.HideButton[3] = true;
          }
        }
        this.UpdateSchoolwear();
        this.Prompt.Label[0].text = "     Close";
      } else {
        this.Open = false;
        this.Prompt.HideButton[1] = true;
        this.Prompt.HideButton[2] = true;
        this.Prompt.HideButton[3] = true;
        this.Prompt.Label[0].text = "     Open";
      }
    }
    if (!this.Open) {
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[2] = true;
      this.Prompt.HideButton[3] = true;
    } else {
      this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
      if (this.Prompt.Circle[1].fillAmount == 0f) {
        this.Yandere.EmptyHands();
        if (this.Yandere.ClubAttire) {
          this.RemovingClubAttire = true;
        }
        this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
        if (this.Yandere.Schoolwear == 1) {
          this.Yandere.Schoolwear = 0;
          if (!this.Removed[1]) {
            if (this.Yandere.Bloodiness == 0f) {
              this.DropCleanUniform = true;
            }
          } else {
            this.Removed[1] = false;
          }
        } else {
          this.Yandere.Schoolwear = 1;
          this.Removed[1] = true;
        }
        this.SpawnSteam();
      } else if (this.Prompt.Circle[2].fillAmount == 0f) {
        this.Yandere.EmptyHands();
        if (this.Yandere.ClubAttire) {
          this.RemovingClubAttire = true;
        }
        this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
        if (this.Yandere.Schoolwear == 1 && !this.Removed[1]) {
          this.DropCleanUniform = true;
        }
        if (this.Yandere.Schoolwear == 2) {
          this.Yandere.Schoolwear = 0;
          this.Removed[2] = false;
        } else {
          this.Yandere.Schoolwear = 2;
          this.Removed[2] = true;
        }
        this.SpawnSteam();
      } else if (this.Prompt.Circle[3].fillAmount == 0f) {
        this.Yandere.EmptyHands();
        if (this.Yandere.ClubAttire) {
          this.RemovingClubAttire = true;
        }
        this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
        if (this.Yandere.Schoolwear == 1 && !this.Removed[1]) {
          this.DropCleanUniform = true;
        }
        if (this.Yandere.Schoolwear == 3) {
          this.Yandere.Schoolwear = 0;
          this.Removed[3] = false;
        } else {
          this.Yandere.Schoolwear = 3;
          this.Removed[3] = true;
        }
        this.SpawnSteam();
      }
    }
    this.Hinge.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
    if (this.SteamCountdown) {
      this.Timer += Time.deltaTime;
      if (this.Phase == 1) {
        if (this.Timer > 1.5f) {
          if (this.YandereLocker) {
            if (this.Yandere.Gloved) {
              this.Yandere.Gloves.transform.localPosition = new Vector3(0f, 1f, -1f);
              this.Yandere.Gloves.transform.parent = null;
              this.Yandere.Gloves.gameObject.SetActive(true);
              this.Yandere.Gloved = false;
              this.Yandere.Gloves = null;
            }
            this.Yandere.ChangeSchoolwear();
            if (this.Yandere.Bloodiness > 0f) {
              if (this.RemovingClubAttire) {
                UnityEngine.Object.Instantiate<GameObject>(this.BloodyClubUniform[(int)ClubGlobals.Club], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity);
                this.StudentManager.ChangingBooths[(int)ClubGlobals.Club].CannotChange = true;
                this.StudentManager.ChangingBooths[(int)ClubGlobals.Club].CheckYandereClub();
                this.Prompt.HideButton[1] = true;
                this.Prompt.HideButton[2] = true;
                this.Prompt.HideButton[3] = true;
                this.RemovingClubAttire = false;
              } else {
                UnityEngine.Object.Instantiate<GameObject>(this.BloodyUniform[this.Yandere.PreviousSchoolwear], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity);
                this.Prompt.HideButton[this.Yandere.PreviousSchoolwear] = true;
                this.Bloody[this.Yandere.PreviousSchoolwear] = true;
              }
            }
          } else {
            if (this.Student.Schoolwear == 0 && this.Student.StudentID == this.StudentManager.RivalID) {
              this.RivalPhone.gameObject.SetActive(true);
              this.RivalPhone.MyRenderer.material.mainTexture = this.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture;
            }
            this.Student.ChangeSchoolwear();
          }
          this.UpdateSchoolwear();
          this.Phase++;
        }
      } else if (this.Timer > 3f) {
        if (!this.YandereLocker) {
          this.Student.BathePhase++;
        }
        this.SteamCountdown = false;
        this.Phase = 1;
        this.Timer = 0f;
      }
    }
  }

  // Token: 0x06000870 RID: 2160 RVA: 0x00097D7C File Offset: 0x0009617C
  public void SpawnSteam() {
    this.SteamCountdown = true;
    if (this.YandereLocker) {
      UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_stripping_00");
      this.Yandere.Stripping = true;
      this.Yandere.CanMove = false;
    } else {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Student.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      gameObject.transform.parent = this.Student.transform;
      this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.StripAnim);
      this.Student.Pathfinding.canSearch = false;
      this.Student.Pathfinding.canMove = false;
    }
  }

  // Token: 0x06000871 RID: 2161 RVA: 0x00097E94 File Offset: 0x00096294
  public void UpdateSchoolwear() {
    if (this.DropCleanUniform) {
      UnityEngine.Object.Instantiate<GameObject>(this.CleanUniform, this.Yandere.transform.position + Vector3.forward * -0.5f + Vector3.up, Quaternion.identity);
      this.DropCleanUniform = false;
    }
    if (!this.Bloody[1]) {
      this.Schoolwear[1].SetActive(true);
    }
    if (!this.Bloody[2]) {
      this.Schoolwear[2].SetActive(true);
    }
    if (!this.Bloody[3]) {
      this.Schoolwear[3].SetActive(true);
    }
    this.Prompt.Label[1].text = "     School Uniform";
    this.Prompt.Label[2].text = "     School Swimsuit";
    this.Prompt.Label[3].text = "     Gym Uniform";
    if (this.YandereLocker) {
      if (!this.Yandere.ClubAttire) {
        if (this.Yandere.Schoolwear > 0) {
          this.Prompt.Label[this.Yandere.Schoolwear].text = "     Nude";
          if (this.Removed[this.Yandere.Schoolwear]) {
            this.Schoolwear[this.Yandere.Schoolwear].SetActive(false);
          }
        }
      } else {
        this.Prompt.Label[1].text = "     Nude";
      }
    } else if (this.Student != null && this.Student.Schoolwear > 0) {
      this.Prompt.HideButton[this.Student.Schoolwear] = true;
      this.Schoolwear[this.Student.Schoolwear].SetActive(false);
      this.Student.Indoors = true;
    }
  }

  // Token: 0x06000872 RID: 2162 RVA: 0x00098084 File Offset: 0x00096484
  public void UpdateButtons() {
    if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > 0f)) {
      if (this.Open) {
        if (this.Yandere.Bloodiness > 0f) {
          this.Prompt.HideButton[1] = true;
          this.Prompt.HideButton[2] = true;
          this.Prompt.HideButton[3] = true;
          if (this.Yandere.Schoolwear > 0 && !this.Yandere.ClubAttire) {
            this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
          }
          if (this.Yandere.ClubAttire) {
            Debug.Log("Don't hide Prompt 1!");
            this.Prompt.HideButton[1] = false;
          }
        } else {
          if (!this.Bloody[1]) {
            this.Prompt.HideButton[1] = false;
          }
          if (!this.Bloody[2]) {
            this.Prompt.HideButton[2] = false;
          }
          if (!this.Bloody[3]) {
            this.Prompt.HideButton[3] = false;
          }
        }
      }
    } else {
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[2] = true;
      this.Prompt.HideButton[3] = true;
    }
  }

  // Token: 0x040018C7 RID: 6343
  public GameObject[] BloodyClubUniform;

  // Token: 0x040018C8 RID: 6344
  public GameObject[] BloodyUniform;

  // Token: 0x040018C9 RID: 6345
  public GameObject[] Schoolwear;

  // Token: 0x040018CA RID: 6346
  public bool[] Removed;

  // Token: 0x040018CB RID: 6347
  public bool[] Bloody;

  // Token: 0x040018CC RID: 6348
  public GameObject CleanUniform;

  // Token: 0x040018CD RID: 6349
  public GameObject SteamCloud;

  // Token: 0x040018CE RID: 6350
  public StudentManagerScript StudentManager;

  // Token: 0x040018CF RID: 6351
  public RivalPhoneScript RivalPhone;

  // Token: 0x040018D0 RID: 6352
  public StudentScript Student;

  // Token: 0x040018D1 RID: 6353
  public YandereScript Yandere;

  // Token: 0x040018D2 RID: 6354
  public PromptScript Prompt;

  // Token: 0x040018D3 RID: 6355
  public Transform Hinge;

  // Token: 0x040018D4 RID: 6356
  public bool RemovingClubAttire;

  // Token: 0x040018D5 RID: 6357
  public bool DropCleanUniform;

  // Token: 0x040018D6 RID: 6358
  public bool SteamCountdown;

  // Token: 0x040018D7 RID: 6359
  public bool YandereLocker;

  // Token: 0x040018D8 RID: 6360
  public bool Swapping;

  // Token: 0x040018D9 RID: 6361
  public bool Open;

  // Token: 0x040018DA RID: 6362
  public float Rotation;

  // Token: 0x040018DB RID: 6363
  public float Timer;

  // Token: 0x040018DC RID: 6364
  public int Phase = 1;
}