using UnityEngine;

// Token: 0x0200016A RID: 362
public class PromptScript : MonoBehaviour {

  // Token: 0x060006AC RID: 1708 RVA: 0x00064DBC File Offset: 0x000631BC
  private void Awake() {
    this.DistanceSqr = float.PositiveInfinity;
    this.OwnerType = this.DecideOwnerType();
    if (this.RaycastTarget == null) {
      this.RaycastTarget = base.transform;
    }
    if (this.OffsetZ.Length == 0) {
      this.OffsetZ = new float[4];
    }
    if (this.Yandere == null) {
      this.YandereObject = GameObject.Find("YandereChan");
      if (this.YandereObject != null) {
        this.Yandere = this.YandereObject.GetComponent<YandereScript>();
      }
    }
    if (this.Yandere != null) {
      this.PauseScreen = GameObject.Find("PauseScreen").GetComponent<PauseScreenScript>();
      this.PromptParent = GameObject.Find("PromptParent").GetComponent<PromptParentScript>();
      this.UICamera = GameObject.Find("UI Camera").GetComponent<Camera>();
      if (this.Noisy) {
        this.Speaker = UnityEngine.Object.Instantiate<GameObject>(this.SpeakerObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
        this.Speaker.transform.parent = this.PromptParent.transform;
        this.Speaker.transform.localScale = new Vector3(1f, 1f, 1f);
        this.Speaker.transform.localEulerAngles = Vector3.zero;
        this.Speaker.enabled = false;
      }
      this.Square = UnityEngine.Object.Instantiate<GameObject>(this.PromptParent.SquareObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
      this.Square.transform.parent = this.PromptParent.transform;
      this.Square.transform.localScale = new Vector3(1f, 1f, 1f);
      this.Square.transform.localEulerAngles = Vector3.zero;
      Color color = this.Square.color;
      color.a = 0f;
      this.Square.color = color;
      this.Square.enabled = false;
      this.ID = 0;
      while (this.ID < 4) {
        if (this.ButtonActive[this.ID]) {
          this.Button[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.ButtonObject[this.ID], base.transform.position, Quaternion.identity).GetComponent<UISprite>();
          UISprite uisprite = this.Button[this.ID];
          uisprite.transform.parent = this.PromptParent.transform;
          uisprite.transform.localScale = new Vector3(1f, 1f, 1f);
          uisprite.transform.localEulerAngles = Vector3.zero;
          uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
          uisprite.enabled = false;
          this.Circle[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.CircleObject, base.transform.position, Quaternion.identity).GetComponent<UISprite>();
          UISprite uisprite2 = this.Circle[this.ID];
          uisprite2.transform.parent = this.PromptParent.transform;
          uisprite2.transform.localScale = new Vector3(1f, 1f, 1f);
          uisprite2.transform.localEulerAngles = Vector3.zero;
          uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
          uisprite2.enabled = false;
          this.Label[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.LabelObject, base.transform.position, Quaternion.identity).GetComponent<UILabel>();
          UILabel uilabel = this.Label[this.ID];
          uilabel.transform.parent = this.PromptParent.transform;
          uilabel.transform.localScale = new Vector3(1f, 1f, 1f);
          uilabel.transform.localEulerAngles = Vector3.zero;
          uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
          uilabel.enabled = false;
          if (this.Suspicious) {
            uilabel.color = new Color(1f, 0f, 0f, 0f);
          }
          uilabel.text = "     " + this.Text[this.ID];
        }
        this.AcceptingInput[this.ID] = true;
        this.ID++;
      }
      this.BloodMask = 2;
      this.BloodMask |= 512;
      this.BloodMask |= 8192;
      this.BloodMask |= 16384;
      this.BloodMask |= 65536;
      this.BloodMask |= 2097152;
      this.BloodMask = ~this.BloodMask;
    }
  }

  // Token: 0x060006AD RID: 1709 RVA: 0x00065349 File Offset: 0x00063749
  private void Start() {
    if (this.DisableAtStart) {
      this.Hide();
      base.enabled = false;
    }
  }

  // Token: 0x170000DF RID: 223
  // (get) Token: 0x060006AE RID: 1710 RVA: 0x00065363 File Offset: 0x00063763
  private float MinimumDistanceSqr {
    get {
      return this.MinimumDistance * this.MinimumDistance;
    }
  }

  // Token: 0x170000E0 RID: 224
  // (get) Token: 0x060006AF RID: 1711 RVA: 0x00065372 File Offset: 0x00063772
  private float MaximumDistanceSqr {
    get {
      return this.MaximumDistance * this.MaximumDistance;
    }
  }

  // Token: 0x060006B0 RID: 1712 RVA: 0x00065381 File Offset: 0x00063781
  private PromptOwnerType DecideOwnerType() {
    if (base.GetComponent<DoorScript>() != null) {
      return PromptOwnerType.Door;
    }
    return PromptOwnerType.Unknown;
  }

  // Token: 0x060006B1 RID: 1713 RVA: 0x00065397 File Offset: 0x00063797
  private bool AllowedWhenCrouching(PromptOwnerType ownerType) {
    return ownerType == PromptOwnerType.Door;
  }

  // Token: 0x060006B2 RID: 1714 RVA: 0x0006539D File Offset: 0x0006379D
  private bool AllowedWhenCrawling(PromptOwnerType ownerType) {
    return false;
  }

  // Token: 0x060006B3 RID: 1715 RVA: 0x000653A0 File Offset: 0x000637A0
  private void Update() {
    if (!this.PauseScreen.Show) {
      if (this.InView) {
        Vector3 position = this.Yandere.transform.position;
        Vector3 a = new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z);
        this.DistanceSqr = (a - position).sqrMagnitude;
        if (this.DistanceSqr < this.MaximumDistanceSqr) {
          bool flag = this.Yandere.Stance.Current == StanceType.Crouching;
          bool flag2 = this.Yandere.Stance.Current == StanceType.Crawling;
          if (this.Yandere.CanMove && (!flag || this.AllowedWhenCrouching(this.OwnerType)) && (!flag2 || this.AllowedWhenCrawling(this.OwnerType)) && !this.Yandere.Aiming && !this.Yandere.Mopping && !this.Yandere.NearSenpai) {
            Debug.DrawLine(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, Color.green);
            RaycastHit raycastHit;
            if (Physics.Linecast(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, out raycastHit, this.BloodMask)) {
              if (this.Debugging) {
                Debug.Log("We hit a collider named " + raycastHit.collider.name);
              }
              this.InSight = (raycastHit.collider == this.MyCollider);
            }
            if (this.Carried || this.InSight) {
              this.SquareSet = false;
              this.Hidden = false;
              Vector2 vector = Vector2.zero;
              this.ID = 0;
              while (this.ID < 4) {
                if (this.ButtonActive[this.ID]) {
                  if (this.Local) {
                    Vector2 vector2 = Camera.main.WorldToScreenPoint(base.transform.position + base.transform.right * this.OffsetX[this.ID] + base.transform.up * this.OffsetY[this.ID] + base.transform.forward * this.OffsetZ[this.ID]);
                    this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
                    this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
                    if (!this.SquareSet) {
                      this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
                      this.SquareSet = true;
                    }
                    Vector2 vector3 = Camera.main.WorldToScreenPoint(base.transform.position + base.transform.right * this.OffsetX[this.ID] + base.transform.up * this.OffsetY[this.ID] + base.transform.forward * this.OffsetZ[this.ID]);
                    this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector3.x + this.OffsetX[this.ID], vector3.y, 1f));
                    this.RelativePosition = vector2.x;
                  } else {
                    vector = Camera.main.WorldToScreenPoint(base.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
                    this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
                    this.Circle[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
                    if (!this.SquareSet) {
                      this.Square.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
                      this.SquareSet = true;
                    }
                    Vector2 vector4 = Camera.main.WorldToScreenPoint(base.transform.position + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
                    this.Label[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector4.x + this.OffsetX[this.ID], vector4.y, 1f));
                    this.RelativePosition = vector.x;
                  }
                  if (!this.HideButton[this.ID]) {
                    this.Square.enabled = true;
                    this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                  }
                }
                this.ID++;
              }
              if (this.Noisy) {
                this.Speaker.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y + 40f, 1f));
              }
              if (this.DistanceSqr < this.MinimumDistanceSqr) {
                if (this.Yandere.NearestPrompt == null) {
                  this.Yandere.NearestPrompt = this;
                } else if (Mathf.Abs(this.RelativePosition - (float)Screen.width * 0.5f) < Mathf.Abs(this.Yandere.NearestPrompt.RelativePosition - (float)Screen.width * 0.5f)) {
                  this.Yandere.NearestPrompt = this;
                }
                if (this.Yandere.NearestPrompt == this) {
                  this.Square.enabled = false;
                  this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
                  this.ID = 0;
                  while (this.ID < 4) {
                    if (this.ButtonActive[this.ID]) {
                      if (!this.Button[this.ID].enabled) {
                        this.Button[this.ID].enabled = true;
                        this.Circle[this.ID].enabled = true;
                        this.Label[this.ID].enabled = true;
                      }
                      this.Button[this.ID].color = new Color(1f, 1f, 1f, 1f);
                      this.Circle[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                      Color color = this.Label[this.ID].color;
                      color.a = 1f;
                      this.Label[this.ID].color = color;
                      if (this.Speaker != null) {
                        this.Speaker.enabled = true;
                        Color color2 = this.Speaker.color;
                        color2.a = 1f;
                        this.Speaker.color = color2;
                      }
                    }
                    this.ID++;
                  }
                  if (Input.GetButton("A")) {
                    this.ButtonHeld = 1;
                  } else if (Input.GetButton("B")) {
                    this.ButtonHeld = 2;
                  } else if (Input.GetButton("X")) {
                    this.ButtonHeld = 3;
                  } else if (Input.GetButton("Y")) {
                    this.ButtonHeld = 4;
                  } else {
                    this.ButtonHeld = 0;
                  }
                  if (this.ButtonHeld > 0) {
                    this.ID = 0;
                    while (this.ID < 4) {
                      if (((this.ButtonActive[this.ID] && this.ID != this.ButtonHeld - 1) || this.HideButton[this.ID]) && this.Circle[this.ID] != null) {
                        this.Circle[this.ID].fillAmount = 1f;
                      }
                      this.ID++;
                    }
                    if (this.ButtonActive[this.ButtonHeld - 1] && !this.HideButton[this.ButtonHeld - 1] && this.AcceptingInput[this.ButtonHeld - 1] && !this.Yandere.Attacking) {
                      this.Circle[this.ButtonHeld - 1].color = new Color(1f, 1f, 1f, 1f);
                      if (!this.Attack) {
                        this.Circle[this.ButtonHeld - 1].fillAmount -= Time.deltaTime * 2f;
                      } else {
                        this.Circle[this.ButtonHeld - 1].fillAmount = 0f;
                      }
                      this.ID = 0;
                    }
                  } else {
                    this.ID = 0;
                    while (this.ID < 4) {
                      if (this.ButtonActive[this.ID]) {
                        this.Circle[this.ID].fillAmount = 1f;
                      }
                      this.ID++;
                    }
                  }
                } else {
                  this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                  this.ID = 0;
                  while (this.ID < 4) {
                    if (this.ButtonActive[this.ID]) {
                      UISprite uisprite = this.Button[this.ID];
                      UISprite uisprite2 = this.Circle[this.ID];
                      UILabel uilabel = this.Label[this.ID];
                      uisprite.enabled = false;
                      uisprite2.enabled = false;
                      uilabel.enabled = false;
                      Color color3 = uisprite.color;
                      Color color4 = uisprite2.color;
                      Color color5 = uilabel.color;
                      color3.a = 0f;
                      color4.a = 0f;
                      color5.a = 0f;
                      uisprite.color = color3;
                      uisprite2.color = color4;
                      uilabel.color = color5;
                    }
                    this.ID++;
                  }
                  if (this.Speaker != null) {
                    this.Speaker.enabled = false;
                    Color color6 = this.Speaker.color;
                    color6.a = 0f;
                    this.Speaker.color = color6;
                  }
                }
              } else {
                if (this.Yandere.NearestPrompt == this) {
                  this.Yandere.NearestPrompt = null;
                }
                this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                this.ID = 0;
                while (this.ID < 4) {
                  if (this.ButtonActive[this.ID]) {
                    UISprite uisprite3 = this.Button[this.ID];
                    UISprite uisprite4 = this.Circle[this.ID];
                    UILabel uilabel2 = this.Label[this.ID];
                    uisprite4.fillAmount = 1f;
                    uisprite3.enabled = false;
                    uisprite4.enabled = false;
                    uilabel2.enabled = false;
                    Color color7 = uisprite3.color;
                    Color color8 = uisprite4.color;
                    Color color9 = uilabel2.color;
                    color7.a = 0f;
                    color8.a = 0f;
                    color9.a = 0f;
                    uisprite3.color = color7;
                    uisprite4.color = color8;
                    uilabel2.color = color9;
                  }
                  this.ID++;
                }
                if (this.Speaker != null) {
                  this.Speaker.enabled = false;
                  Color color10 = this.Speaker.color;
                  color10.a = 0f;
                  this.Speaker.color = color10;
                }
              }
              Color color11 = this.Square.color;
              color11.a = 1f;
              this.Square.color = color11;
              this.ID = 0;
              while (this.ID < 4) {
                if (this.ButtonActive[this.ID] && this.HideButton[this.ID]) {
                  UISprite uisprite5 = this.Button[this.ID];
                  UISprite uisprite6 = this.Circle[this.ID];
                  UILabel uilabel3 = this.Label[this.ID];
                  uisprite5.enabled = false;
                  uisprite6.enabled = false;
                  uilabel3.enabled = false;
                  Color color12 = uisprite5.color;
                  Color color13 = uisprite6.color;
                  Color color14 = uilabel3.color;
                  color12.a = 0f;
                  color13.a = 0f;
                  color14.a = 0f;
                  uisprite5.color = color12;
                  uisprite6.color = color13;
                  uilabel3.color = color14;
                  if (this.Speaker != null) {
                    this.Speaker.enabled = false;
                    Color color15 = this.Speaker.color;
                    color15.a = 0f;
                    this.Speaker.color = color15;
                  }
                }
                this.ID++;
              }
            } else {
              if (this.Debugging) {
                Debug.Log("1.");
              }
              this.Hide();
            }
          } else {
            if (this.Debugging) {
              Debug.Log("2.");
            }
            this.Hide();
          }
        } else {
          if (this.Debugging) {
            Debug.Log("3.");
          }
          this.Hide();
        }
      } else {
        if (this.Debugging) {
          Debug.Log("4.");
        }
        this.DistanceSqr = float.PositiveInfinity;
        this.Hide();
      }
    } else {
      if (this.Debugging) {
        Debug.Log("4.");
      }
      this.Hide();
    }
  }

  // Token: 0x060006B4 RID: 1716 RVA: 0x000663FE File Offset: 0x000647FE
  private void OnBecameVisible() {
    this.InView = true;
  }

  // Token: 0x060006B5 RID: 1717 RVA: 0x00066407 File Offset: 0x00064807
  private void OnBecameInvisible() {
    this.InView = false;
    if (this.Debugging) {
      Debug.Log("5.");
    }
    this.Hide();
  }

  // Token: 0x060006B6 RID: 1718 RVA: 0x0006642C File Offset: 0x0006482C
  public void Hide() {
    if (!this.Hidden) {
      this.Hidden = true;
      if (this.YandereObject != null) {
        if (this.Yandere.NearestPrompt == this) {
          this.Yandere.NearestPrompt = null;
        }
        if (this.Square.enabled) {
          this.Square.enabled = false;
          this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
        }
        this.ID = 0;
        while (this.ID < 4) {
          if (this.ButtonActive[this.ID]) {
            UISprite uisprite = this.Button[this.ID];
            if (uisprite.enabled) {
              UISprite uisprite2 = this.Circle[this.ID];
              UILabel uilabel = this.Label[this.ID];
              uisprite2.fillAmount = 1f;
              uisprite.enabled = false;
              uisprite2.enabled = false;
              uilabel.enabled = false;
              uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
              uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
              uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
            }
          }
          this.ID++;
        }
        if (this.Speaker != null) {
          this.Speaker.enabled = false;
          this.Speaker.color = new Color(this.Speaker.color.r, this.Speaker.color.g, this.Speaker.color.b, 0f);
        }
      }
    }
  }

  // Token: 0x04001099 RID: 4249
  public PauseScreenScript PauseScreen;

  // Token: 0x0400109A RID: 4250
  public YandereScript Yandere;

  // Token: 0x0400109B RID: 4251
  [SerializeField]
  private GameObject[] ButtonObject;

  // Token: 0x0400109C RID: 4252
  [SerializeField]
  private GameObject SpeakerObject;

  // Token: 0x0400109D RID: 4253
  [SerializeField]
  private GameObject CircleObject;

  // Token: 0x0400109E RID: 4254
  [SerializeField]
  private GameObject LabelObject;

  // Token: 0x0400109F RID: 4255
  [SerializeField]
  private PromptParentScript PromptParent;

  // Token: 0x040010A0 RID: 4256
  public Collider MyCollider;

  // Token: 0x040010A1 RID: 4257
  [SerializeField]
  private Camera UICamera;

  // Token: 0x040010A2 RID: 4258
  public bool[] AcceptingInput;

  // Token: 0x040010A3 RID: 4259
  public bool[] ButtonActive;

  // Token: 0x040010A4 RID: 4260
  public bool[] HideButton;

  // Token: 0x040010A5 RID: 4261
  public UISprite[] Button;

  // Token: 0x040010A6 RID: 4262
  public UISprite[] Circle;

  // Token: 0x040010A7 RID: 4263
  public UILabel[] Label;

  // Token: 0x040010A8 RID: 4264
  [SerializeField]
  private UISprite Speaker;

  // Token: 0x040010A9 RID: 4265
  [SerializeField]
  private UISprite Square;

  // Token: 0x040010AA RID: 4266
  public float[] OffsetX;

  // Token: 0x040010AB RID: 4267
  public float[] OffsetY;

  // Token: 0x040010AC RID: 4268
  public float[] OffsetZ;

  // Token: 0x040010AD RID: 4269
  [SerializeField]
  private string[] Text;

  // Token: 0x040010AE RID: 4270
  public PromptOwnerType OwnerType;

  // Token: 0x040010AF RID: 4271
  [SerializeField]
  private bool DisableAtStart;

  // Token: 0x040010B0 RID: 4272
  public bool Suspicious;

  // Token: 0x040010B1 RID: 4273
  [SerializeField]
  private bool Debugging;

  // Token: 0x040010B2 RID: 4274
  [SerializeField]
  private bool SquareSet;

  // Token: 0x040010B3 RID: 4275
  public bool Carried;

  // Token: 0x040010B4 RID: 4276
  [SerializeField]
  private bool InSight;

  // Token: 0x040010B5 RID: 4277
  public bool Attack;

  // Token: 0x040010B6 RID: 4278
  [SerializeField]
  private bool InView;

  // Token: 0x040010B7 RID: 4279
  [SerializeField]
  private bool Weapon;

  // Token: 0x040010B8 RID: 4280
  [SerializeField]
  private bool Noisy;

  // Token: 0x040010B9 RID: 4281
  [SerializeField]
  private bool Local = true;

  // Token: 0x040010BA RID: 4282
  [SerializeField]
  private float RelativePosition;

  // Token: 0x040010BB RID: 4283
  [SerializeField]
  private float MaximumDistance = 5f;

  // Token: 0x040010BC RID: 4284
  public float MinimumDistance;

  // Token: 0x040010BD RID: 4285
  [SerializeField]
  private float DistanceSqr;

  // Token: 0x040010BE RID: 4286
  [SerializeField]
  private float Height;

  // Token: 0x040010BF RID: 4287
  [SerializeField]
  private int ButtonHeld;

  // Token: 0x040010C0 RID: 4288
  [SerializeField]
  private int BloodMask;

  // Token: 0x040010C1 RID: 4289
  [SerializeField]
  private int Priority;

  // Token: 0x040010C2 RID: 4290
  [SerializeField]
  private int ID;

  // Token: 0x040010C3 RID: 4291
  [SerializeField]
  private GameObject YandereObject;

  // Token: 0x040010C4 RID: 4292
  [SerializeField]
  private Transform RaycastTarget;

  // Token: 0x040010C5 RID: 4293
  public bool Hidden;
}