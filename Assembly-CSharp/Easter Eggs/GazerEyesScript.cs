using UnityEngine;

// Token: 0x020000C9 RID: 201
public class GazerEyesScript : MonoBehaviour {

  // Token: 0x060002FE RID: 766 RVA: 0x00038FCC File Offset: 0x000373CC
  private void Start() {
    base.GetComponent<Animation>()["Eyeballs_Run"].speed = 0f;
    base.GetComponent<Animation>()["Eyeballs_Walk"].speed = 0f;
    base.GetComponent<Animation>()["Eyeballs_Idle"].speed = 0f;
  }

  // Token: 0x060002FF RID: 767 RVA: 0x00039028 File Offset: 0x00037428
  private void Update() {
    this.StudentManager.UpdateStudents();
    if (!this.Attacking) {
      this.AnimTime += Time.deltaTime;
      if (this.AnimTime > 144f) {
        this.AnimTime = 0f;
      }
    } else if (this.AnimTime < 72f) {
      this.AnimTime = Mathf.Lerp(this.AnimTime, 0f, Time.deltaTime * 1.44f * 5f);
    } else {
      this.AnimTime = Mathf.Lerp(this.AnimTime, 144f, Time.deltaTime * 1.44f * 5f);
    }
    base.GetComponent<Animation>()["Eyeballs_Run"].time = this.AnimTime;
    base.GetComponent<Animation>()["Eyeballs_Walk"].time = this.AnimTime;
    base.GetComponent<Animation>()["Eyeballs_Idle"].time = this.AnimTime;
    this.ID = 0;
    while (this.ID < this.Eyes.Length) {
      if (this.BlinkStrength[this.ID] == 0f) {
        this.RandomNumber = (float)UnityEngine.Random.Range(1, 101);
      }
      if (this.RandomNumber == 1f) {
        this.Blink[this.ID] = true;
      }
      if (this.Blink[this.ID]) {
        this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 100f, Time.deltaTime * 1000f);
        this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
        if (this.BlinkStrength[this.ID] == 100f) {
          this.Blink[this.ID] = false;
        }
      } else if (this.BlinkStrength[this.ID] > 0f) {
        this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 0f, Time.deltaTime * 1000f);
        this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
      }
      this.ID++;
    }
    float axis = Input.GetAxis("Vertical");
    float axis2 = Input.GetAxis("Horizontal");
    if (this.Yandere.CanMove) {
      if (axis != 0f || axis2 != 0f) {
        if (Input.GetButton("LB")) {
          base.GetComponent<Animation>().CrossFade("Eyeballs_Run", 1f);
        } else {
          base.GetComponent<Animation>().CrossFade("Eyeballs_Walk", 1f);
        }
      } else {
        base.GetComponent<Animation>().CrossFade("Eyeballs_Idle", 1f);
      }
    }
  }

  // Token: 0x06000300 RID: 768 RVA: 0x00039328 File Offset: 0x00037728
  public void ChangeEffect() {
    this.Effect++;
    if (this.Effect == this.EyeTextures.Length) {
      this.Effect = 0;
    }
    this.ID = 0;
    while (this.ID < this.Eyes.Length) {
      UnityEngine.Object.Instantiate<GameObject>(this.ParticleEffect, this.Eyes[this.ID].transform.position, Quaternion.identity);
      this.Eyes[this.ID].material.mainTexture = this.EyeTextures[this.Effect];
      this.ID++;
    }
  }

  // Token: 0x06000301 RID: 769 RVA: 0x000393D8 File Offset: 0x000377D8
  public void Attack() {
    this.ID = 0;
    while (this.ID < this.Eyes.Length) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Laser, this.Eyes[this.ID].transform.position, Quaternion.identity);
      gameObject.transform.LookAt(this.Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f));
      gameObject.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(this.Eyes[this.ID].transform.position, this.Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f)) * 0.5f);
      this.ID++;
    }
    if (this.Effect == 0) {
      this.Yandere.TargetStudent.Combust();
    } else if (this.Effect == 1) {
      StudentScript targetStudent = this.Yandere.TargetStudent;
      targetStudent.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
      targetStudent.CharacterAnimation["f02_electrocution_00"].time = 2f;
      targetStudent.CharacterAnimation.CrossFade("f02_electrocution_00");
      targetStudent.Pathfinding.canSearch = false;
      targetStudent.Pathfinding.canMove = false;
      targetStudent.Electrified = true;
      targetStudent.Fleeing = false;
      targetStudent.Routine = false;
      targetStudent.Dying = true;
      GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject2.transform.parent = targetStudent.BoneSets.RightArm;
      gameObject2.transform.localPosition = Vector3.zero;
      GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject3.transform.parent = targetStudent.BoneSets.LeftArm;
      gameObject3.transform.localPosition = Vector3.zero;
      GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject4.transform.parent = targetStudent.BoneSets.RightLeg;
      gameObject4.transform.localPosition = Vector3.zero;
      GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject5.transform.parent = targetStudent.BoneSets.LeftLeg;
      gameObject5.transform.localPosition = Vector3.zero;
      GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject6.transform.parent = targetStudent.BoneSets.Head;
      gameObject6.transform.localPosition = Vector3.zero;
      GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, targetStudent.transform.position, Quaternion.identity);
      gameObject7.transform.parent = targetStudent.Hips;
      gameObject7.transform.localPosition = Vector3.zero;
      AudioSource.PlayClipAtPoint(this.StudentManager.LightSwitch.Flick[2], targetStudent.transform.position + Vector3.up);
    } else if (this.Effect == 2) {
      UnityEngine.Object.Instantiate<GameObject>(this.Yandere.FalconPunch, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 0.5f, 0f) - this.Yandere.transform.forward * 0.5f, Quaternion.identity);
    } else if (this.Effect == 3) {
      UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, this.Yandere.TargetStudent.transform.position + Vector3.up, Quaternion.identity);
      this.Yandere.TargetStudent.SpawnAlarmDisc();
      this.Yandere.TargetStudent.BecomeRagdoll();
    } else if (this.Effect == 4) {
      if (this.Yandere.TargetStudent.Male) {
        UnityEngine.Object.Instantiate<GameObject>(this.MaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
      } else {
        UnityEngine.Object.Instantiate<GameObject>(this.FemaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
      }
      this.Yandere.TargetStudent.BecomeRagdoll();
      this.Yandere.TargetStudent.Ragdoll.Dismember();
    } else if (this.Effect == 5) {
      this.Yandere.TargetStudent.TurnToStone();
    }
    this.Yandere.TargetStudent.Prompt.Hide();
    this.Yandere.TargetStudent.Prompt.enabled = false;
  }

  // Token: 0x0400098D RID: 2445
  public StudentManagerScript StudentManager;

  // Token: 0x0400098E RID: 2446
  public YandereScript Yandere;

  // Token: 0x0400098F RID: 2447
  public GameObject FemaleBloodyScream;

  // Token: 0x04000990 RID: 2448
  public GameObject MaleBloodyScream;

  // Token: 0x04000991 RID: 2449
  public GameObject ParticleEffect;

  // Token: 0x04000992 RID: 2450
  public GameObject Laser;

  // Token: 0x04000993 RID: 2451
  public SkinnedMeshRenderer[] Eyes;

  // Token: 0x04000994 RID: 2452
  public float[] BlinkStrength;

  // Token: 0x04000995 RID: 2453
  public Texture[] EyeTextures;

  // Token: 0x04000996 RID: 2454
  public bool[] Blink;

  // Token: 0x04000997 RID: 2455
  public float RandomNumber;

  // Token: 0x04000998 RID: 2456
  public float AnimTime;

  // Token: 0x04000999 RID: 2457
  public bool Attacking;

  // Token: 0x0400099A RID: 2458
  public int Effect;

  // Token: 0x0400099B RID: 2459
  public int ID;
}