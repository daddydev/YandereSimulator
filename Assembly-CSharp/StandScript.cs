using UnityEngine;

// Token: 0x020001C0 RID: 448
public class StandScript : MonoBehaviour {

  // Token: 0x060007C7 RID: 1991 RVA: 0x000771B7 File Offset: 0x000755B7
  private void Start() {
    if (GameGlobals.LoveSick) {
      base.enabled = false;
    }
  }

  // Token: 0x060007C8 RID: 1992 RVA: 0x000771CC File Offset: 0x000755CC
  private void Update() {
    if (!this.Stand.activeInHierarchy) {
      if (this.Weapons == 8 && this.Yandere.transform.position.y > 11.9f && Input.GetButtonDown("RB") && !MissionModeGlobals.MissionMode && !this.Yandere.Laughing && this.Yandere.CanMove) {
        this.Yandere.Jojo();
      }
    } else if (this.Phase == 0) {
      if (this.Stand.GetComponent<Animation>()["StandSummon"].time >= 2f && this.Stand.GetComponent<Animation>()["StandSummon"].time <= 2.5f) {
        if (!this.SFX) {
          AudioSource.PlayClipAtPoint(this.SummonSFX, base.transform.position);
          this.SFX = true;
        }
        UnityEngine.Object.Instantiate<GameObject>(this.SummonEffect, this.SummonTransform.position, Quaternion.identity);
      }
      if (this.Stand.GetComponent<Animation>()["StandSummon"].time >= this.Stand.GetComponent<Animation>()["StandSummon"].length) {
        this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
        this.Phase++;
      }
    } else {
      float axis = Input.GetAxis("Vertical");
      float axis2 = Input.GetAxis("Horizontal");
      if (this.Yandere.CanMove) {
        this.Return();
        if (axis != 0f || axis2 != 0f) {
          if (Input.GetButton("LB")) {
            this.Stand.GetComponent<Animation>().CrossFade("StandRun");
          } else {
            this.Stand.GetComponent<Animation>().CrossFade("StandWalk");
          }
        } else {
          this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
        }
      } else if (this.Yandere.RPGCamera.enabled) {
        if (this.Yandere.Laughing) {
          if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0f, 0.2f, -0.4f)) > 0.01f) {
            this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0f, 0.2f, 0.1f), Time.deltaTime * 10f);
            this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
          }
          this.Stand.GetComponent<Animation>().CrossFade("StandAttack");
          this.StandPunch.MyCollider.enabled = true;
          this.ReadyForFinisher = true;
        } else if (this.ReadyForFinisher) {
          if (this.Phase == 1) {
            base.GetComponent<AudioSource>().Play();
            this.Finisher = UnityEngine.Random.Range(1, 3);
            this.Stand.GetComponent<Animation>().CrossFade("StandFinisher" + this.Finisher.ToString());
            this.Phase++;
          } else if (this.Phase == 2) {
            if (this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time >= 0.5f) {
              this.FalconPunch.MyCollider.enabled = true;
              this.StandPunch.MyCollider.enabled = false;
              this.Phase++;
            }
          } else if (this.Phase == 3 && (this.StandPunch.MyCollider.enabled || this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time >= this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].length)) {
            this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
            this.FalconPunch.MyCollider.enabled = false;
            this.ReadyForFinisher = false;
            this.Yandere.CanMove = true;
            this.Phase = 1;
          }
        }
      }
    }
  }

  // Token: 0x060007C9 RID: 1993 RVA: 0x000776E8 File Offset: 0x00075AE8
  public void Spawn() {
    this.FalconPunch.MyCollider.enabled = false;
    this.StandPunch.MyCollider.enabled = false;
    this.StandCamera.SetActive(true);
    this.MotionBlur.enabled = true;
    this.Stand.SetActive(true);
  }

  // Token: 0x060007CA RID: 1994 RVA: 0x0007773C File Offset: 0x00075B3C
  private void Return() {
    if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f)) > 0.01f) {
      this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f), Time.deltaTime * 10f);
      this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 0f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
    }
  }

  // Token: 0x040013F1 RID: 5105
  public AmplifyMotionEffect MotionBlur;

  // Token: 0x040013F2 RID: 5106
  public FalconPunchScript FalconPunch;

  // Token: 0x040013F3 RID: 5107
  public StandPunchScript StandPunch;

  // Token: 0x040013F4 RID: 5108
  public Transform SummonTransform;

  // Token: 0x040013F5 RID: 5109
  public GameObject SummonEffect;

  // Token: 0x040013F6 RID: 5110
  public GameObject StandCamera;

  // Token: 0x040013F7 RID: 5111
  public YandereScript Yandere;

  // Token: 0x040013F8 RID: 5112
  public GameObject Stand;

  // Token: 0x040013F9 RID: 5113
  public Transform[] Hands;

  // Token: 0x040013FA RID: 5114
  public int FinishPhase;

  // Token: 0x040013FB RID: 5115
  public int Finisher;

  // Token: 0x040013FC RID: 5116
  public int Weapons;

  // Token: 0x040013FD RID: 5117
  public int Phase;

  // Token: 0x040013FE RID: 5118
  public AudioClip SummonSFX;

  // Token: 0x040013FF RID: 5119
  public bool ReadyForFinisher;

  // Token: 0x04001400 RID: 5120
  public bool SFX;
}