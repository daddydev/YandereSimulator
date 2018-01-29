using UnityEngine;

// Token: 0x020000C6 RID: 198
public class GardeningClubMemberScript : MonoBehaviour {

  // Token: 0x060002F5 RID: 757 RVA: 0x00038188 File Offset: 0x00036588
  private void Start() {
    Animation component = base.GetComponent<Animation>();
    component["f02_angryFace_00"].layer = 2;
    component.Play("f02_angryFace_00");
    component["f02_angryFace_00"].weight = 0f;
    if (!this.Leader && GameObject.Find("DetectionCamera") != null) {
      this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
      this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
      this.DetectionMarker.Target = base.transform;
    }
  }

  // Token: 0x060002F6 RID: 758 RVA: 0x00038250 File Offset: 0x00036650
  private void Update() {
    if (!this.Angry) {
      if (this.Phase == 1) {
        while (Vector3.Distance(base.transform.position, this.Destination.position) < 1f) {
          if (this.ID == 1) {
            this.Destination.position = new Vector3(UnityEngine.Random.Range(-61f, -71f), this.Destination.position.y, UnityEngine.Random.Range(-14f, 14f));
          } else {
            this.Destination.position = new Vector3(UnityEngine.Random.Range(-28f, -23f), this.Destination.position.y, UnityEngine.Random.Range(-15f, -7f));
          }
        }
        base.GetComponent<Animation>().CrossFade(this.WalkAnim);
        this.Moving = true;
        if (this.Leader) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.PickpocketPanel.enabled = false;
        }
        this.Phase++;
      } else if (this.Moving) {
        if (Vector3.Distance(base.transform.position, this.Destination.position) >= 1f) {
          Quaternion b = Quaternion.LookRotation(this.Destination.transform.position - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 1f * Time.deltaTime);
          this.MyController.Move(base.transform.forward * Time.deltaTime);
        } else {
          base.GetComponent<Animation>().CrossFade(this.IdleAnim);
          this.Moving = false;
          if (this.Leader) {
            this.PickpocketPanel.enabled = true;
          }
        }
      } else {
        this.Timer += Time.deltaTime;
        if (this.Leader) {
          this.TimeBar.fillAmount = 1f - this.Timer / base.GetComponent<Animation>()[this.IdleAnim].length;
        }
        if (this.Timer > base.GetComponent<Animation>()[this.IdleAnim].length) {
          if (this.Leader && this.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID) {
            this.PickpocketMinigame.Failure = true;
            this.PickpocketMinigame.End();
            this.Punish();
          }
          this.Timer = 0f;
          this.Phase = 1;
        }
      }
      if (this.Leader) {
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
          this.PickpocketMinigame.Show = true;
          this.PickpocketMinigame.ID = this.ID;
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_pickpocketing_00");
          this.Yandere.Pickpocketing = true;
          this.Yandere.EmptyHands();
          this.Yandere.CanMove = false;
        }
        if (this.PickpocketMinigame.ID == this.ID) {
          if (this.PickpocketMinigame.Success) {
            this.PickpocketMinigame.Success = false;
            this.PickpocketMinigame.ID = 0;
            if (this.ID == 1) {
              this.ShedDoor.Prompt.Label[0].text = "     Open";
              this.Padlock.SetActive(false);
              this.ShedDoor.Locked = false;
              this.Yandere.Inventory.ShedKey = true;
            } else {
              this.CabinetDoor.Prompt.Label[0].text = "     Open";
              this.CabinetDoor.Locked = false;
              this.Yandere.Inventory.CabinetKey = true;
            }
            this.Prompt.gameObject.SetActive(false);
            this.Key.SetActive(false);
          }
          if (this.PickpocketMinigame.Failure) {
            this.PickpocketMinigame.Failure = false;
            this.PickpocketMinigame.ID = 0;
            this.Punish();
          }
        }
      } else {
        this.LookForYandere();
      }
    } else {
      Quaternion b2 = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, 10f * Time.deltaTime);
      this.Timer += Time.deltaTime;
      if (this.Timer > 10f) {
        base.GetComponent<Animation>()["f02_angryFace_00"].weight = 0f;
        this.Angry = false;
        this.Timer = 0f;
      } else if (this.Timer > 1f && this.Phase == 0) {
        this.Subtitle.UpdateLabel(SubtitleType.PickpocketReaction, 0, 8f);
        this.Phase++;
      }
    }
    if (this.Leader && this.PickpocketPanel.enabled) {
      if (this.Yandere.PickUp == null && this.Yandere.Pursuer == null) {
        this.Prompt.enabled = true;
      } else {
        this.Prompt.enabled = false;
        this.Prompt.Hide();
      }
    }
  }

  // Token: 0x060002F7 RID: 759 RVA: 0x00038834 File Offset: 0x00036C34
  private void Punish() {
    Animation component = base.GetComponent<Animation>();
    component["f02_angryFace_00"].weight = 1f;
    component.CrossFade(this.AngryAnim);
    this.Reputation.PendingRep -= 10f;
    this.CameraEffects.Alarm();
    this.Angry = true;
    this.Phase = 0;
    this.Timer = 0f;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.PickpocketPanel.enabled = false;
  }

  // Token: 0x060002F8 RID: 760 RVA: 0x000388C8 File Offset: 0x00036CC8
  private void LookForYandere() {
    float num = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
    if (num < this.VisionCone.farClipPlane) {
      Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
      if (GeometryUtility.TestPlanesAABB(planes, this.Yandere.GetComponent<Collider>().bounds)) {
        Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
        Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
        RaycastHit raycastHit;
        if (Physics.Linecast(this.Eyes.transform.position, end, out raycastHit)) {
          if (raycastHit.collider.gameObject == this.Yandere.gameObject) {
            if (this.Yandere.Pickpocketing) {
              if (!this.ClubLeader.Angry) {
                this.Alarm = Mathf.MoveTowards(this.Alarm, 100f, Time.deltaTime * (100f / num));
                if (this.Alarm == 100f) {
                  this.PickpocketMinigame.NotNurse = true;
                  this.PickpocketMinigame.End();
                  this.ClubLeader.Punish();
                }
              } else {
                this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
              }
            } else {
              this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
            }
          } else {
            this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
          }
        } else {
          this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
        }
      } else {
        this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
      }
    }
    this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, this.Alarm / 100f, this.DetectionMarker.Tex.transform.localScale.z);
    if (this.Alarm > 0f) {
      if (!this.DetectionMarker.Tex.enabled) {
        this.DetectionMarker.Tex.enabled = true;
      }
      this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
    } else if (this.DetectionMarker.Tex.color.a != 0f) {
      this.DetectionMarker.Tex.enabled = false;
      this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
    }
  }

  // Token: 0x04000966 RID: 2406
  public PickpocketMinigameScript PickpocketMinigame;

  // Token: 0x04000967 RID: 2407
  public DetectionMarkerScript DetectionMarker;

  // Token: 0x04000968 RID: 2408
  public CameraEffectsScript CameraEffects;

  // Token: 0x04000969 RID: 2409
  public CharacterController MyController;

  // Token: 0x0400096A RID: 2410
  public CabinetDoorScript CabinetDoor;

  // Token: 0x0400096B RID: 2411
  public ReputationScript Reputation;

  // Token: 0x0400096C RID: 2412
  public SubtitleScript Subtitle;

  // Token: 0x0400096D RID: 2413
  public YandereScript Yandere;

  // Token: 0x0400096E RID: 2414
  public PromptScript Prompt;

  // Token: 0x0400096F RID: 2415
  public DoorScript ShedDoor;

  // Token: 0x04000970 RID: 2416
  public AIPath Pathfinding;

  // Token: 0x04000971 RID: 2417
  public UIPanel PickpocketPanel;

  // Token: 0x04000972 RID: 2418
  public UISprite TimeBar;

  // Token: 0x04000973 RID: 2419
  public Transform PickpocketSpot;

  // Token: 0x04000974 RID: 2420
  public Transform Destination;

  // Token: 0x04000975 RID: 2421
  public GameObject Padlock;

  // Token: 0x04000976 RID: 2422
  public GameObject Marker;

  // Token: 0x04000977 RID: 2423
  public GameObject Key;

  // Token: 0x04000978 RID: 2424
  public bool Moving;

  // Token: 0x04000979 RID: 2425
  public bool Leader;

  // Token: 0x0400097A RID: 2426
  public bool Angry;

  // Token: 0x0400097B RID: 2427
  public string AngryAnim = "idle_01";

  // Token: 0x0400097C RID: 2428
  public string IdleAnim = string.Empty;

  // Token: 0x0400097D RID: 2429
  public string WalkAnim = string.Empty;

  // Token: 0x0400097E RID: 2430
  public float Timer;

  // Token: 0x0400097F RID: 2431
  public int Phase = 1;

  // Token: 0x04000980 RID: 2432
  public int ID = 1;

  // Token: 0x04000981 RID: 2433
  public GardeningClubMemberScript ClubLeader;

  // Token: 0x04000982 RID: 2434
  public Camera VisionCone;

  // Token: 0x04000983 RID: 2435
  public Transform Eyes;

  // Token: 0x04000984 RID: 2436
  public float Alarm;
}