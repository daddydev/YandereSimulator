using UnityEngine;

// Token: 0x02000129 RID: 297
public class LoveManagerScript : MonoBehaviour {

  // Token: 0x060005AB RID: 1451 RVA: 0x0004E59A File Offset: 0x0004C99A
  private void Start() {
    this.SuitorProgress = DatingGlobals.SuitorProgress;
  }

  // Token: 0x060005AC RID: 1452 RVA: 0x0004E5A8 File Offset: 0x0004C9A8
  private void LateUpdate() {
    if (this.Follower != null && this.Follower.Alive) {
      this.ID = 0;
      while (this.ID < this.TotalTargets) {
        Transform transform = this.Targets[this.ID];
        if (transform != null && this.Follower.transform.position.y > transform.position.y - 2f && this.Follower.transform.position.y < transform.position.y + 2f && Vector3.Distance(this.Follower.transform.position, new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z)) < 2.5f) {
          float f = Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z));
          if (Mathf.Abs(f) > this.AngleLimit) {
            if (!this.Follower.Gush) {
              this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
              this.Follower.GushTarget = transform;
              ParticleSystem.EmissionModule emission = this.Follower.Hearts.emission;
              emission.enabled = true;
              emission.rateOverTime = 5f;
              this.Follower.Hearts.Play();
              this.Follower.Gush = true;
            }
          } else {
            this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
            var emission = Follower.Hearts.emission;
            emission.enabled = false;
            this.Follower.Gush = false;
          }
        }
        this.ID++;
      }
    }
    if (this.LeftNote) {
      this.Rival = this.StudentManager.Students[7];
      this.Suitor = this.StudentManager.Students[13];
      if (this.StudentManager.Students[this.StudentManager.RivalID] != null) {
        this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
        this.Suitor = this.StudentManager.Students[1];
      }
      if (this.Rival != null && this.Suitor != null && this.Rival.Alive && this.Suitor.Alive && this.Rival.ConfessPhase == 5 && this.Suitor.ConfessPhase == 3) {
        float num = Vector3.Distance(this.Yandere.transform.position, this.MythHill.position);
        if (num > 10f && num < 25f) {
          this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
          this.Yandere.RPGCamera.enabled = false;
          this.Yandere.CanMove = false;
          this.Suitor.enabled = false;
          this.Rival.enabled = false;
          if (this.StudentManager.Students[this.StudentManager.RivalID] != null) {
            this.ConfessionManager.SetActive(true);
          } else {
            this.ConfessionScene.enabled = true;
          }
          this.Clock.StopTime = true;
          this.LeftNote = false;
        }
      }
    }
    if (this.HoldingHands) {
      if (this.Rival == null) {
        this.Rival = this.StudentManager.Students[7];
      }
      if (this.Suitor == null) {
        this.Suitor = this.StudentManager.Students[13];
      }
      this.Rival.MyController.Move(base.transform.forward * Time.deltaTime);
      this.Suitor.transform.position = new Vector3(this.Rival.transform.position.x - 0.5f, this.Rival.transform.position.y, this.Rival.transform.position.z);
      if (this.Rival.transform.position.z > -50f) {
        this.Suitor.MyController.radius = 0.12f;
        this.Suitor.enabled = true;
        this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
        var suitorEmission = Suitor.Hearts.emission;
        suitorEmission.enabled = false;
        this.Rival.MyController.radius = 0.12f;
        this.Rival.enabled = true;
        this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
        var rivalEmission = Rival.Hearts.emission;
        rivalEmission.enabled = false;
        this.Suitor.HoldingHands = false;
        this.Rival.HoldingHands = false;
        this.HoldingHands = false;
      }
    }
  }

  // Token: 0x060005AD RID: 1453 RVA: 0x0004EBEC File Offset: 0x0004CFEC
  public void CoupleCheck() {
    if (this.SuitorProgress == 2) {
      this.Rival = this.StudentManager.Students[7];
      this.Suitor = this.StudentManager.Students[13];
      if (this.Rival != null && this.Suitor != null) {
        this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Suitor.Character.GetComponent<Animation>().enabled = true;
        this.Rival.Character.GetComponent<Animation>().enabled = true;
        this.Suitor.Character.GetComponent<Animation>().Play("walkHands_00");
        this.Suitor.transform.eulerAngles = Vector3.zero;
        this.Suitor.transform.position = new Vector3(-0.25f, 0f, -100f);
        this.Suitor.Pathfinding.canSearch = false;
        this.Suitor.Pathfinding.canMove = false;
        this.Suitor.MyController.radius = 0f;
        this.Suitor.enabled = false;
        this.Rival.Character.GetComponent<Animation>().Play("f02_walkHands_00");
        this.Rival.transform.eulerAngles = Vector3.zero;
        this.Rival.transform.position = new Vector3(0.25f, 0f, -100f);
        this.Rival.Pathfinding.canSearch = false;
        this.Rival.Pathfinding.canMove = false;
        this.Rival.MyController.radius = 0f;
        this.Rival.enabled = false;
        this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
        ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
        emission.enabled = true;
        emission.rateOverTime = 5f;
        this.Suitor.Hearts.Play();
        this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
        ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
        emission2.enabled = true;
        emission2.rateOverTime = 5f;
        this.Rival.Hearts.Play();
        this.Suitor.HoldingHands = true;
        this.Rival.HoldingHands = true;
        this.Suitor.CoupleID = 7;
        this.Rival.CoupleID = 13;
        this.HoldingHands = true;
      }
    }
  }

  // Token: 0x04000D91 RID: 3473
  public ConfessionSceneScript ConfessionScene;

  // Token: 0x04000D92 RID: 3474
  public StudentManagerScript StudentManager;

  // Token: 0x04000D93 RID: 3475
  public GameObject ConfessionManager;

  // Token: 0x04000D94 RID: 3476
  public YandereScript Yandere;

  // Token: 0x04000D95 RID: 3477
  public ClockScript Clock;

  // Token: 0x04000D96 RID: 3478
  public StudentScript Follower;

  // Token: 0x04000D97 RID: 3479
  public StudentScript Suitor;

  // Token: 0x04000D98 RID: 3480
  public StudentScript Rival;

  // Token: 0x04000D99 RID: 3481
  public Transform[] Targets;

  // Token: 0x04000D9A RID: 3482
  public Transform MythHill;

  // Token: 0x04000D9B RID: 3483
  public int SuitorProgress;

  // Token: 0x04000D9C RID: 3484
  public int TotalTargets;

  // Token: 0x04000D9D RID: 3485
  public int Phase = 1;

  // Token: 0x04000D9E RID: 3486
  public int ID;

  // Token: 0x04000D9F RID: 3487
  public float AngleLimit;

  // Token: 0x04000DA0 RID: 3488
  public bool HoldingHands;

  // Token: 0x04000DA1 RID: 3489
  public bool RivalWaiting;

  // Token: 0x04000DA2 RID: 3490
  public bool LeftNote;

  // Token: 0x04000DA3 RID: 3491
  public bool Courted;
}