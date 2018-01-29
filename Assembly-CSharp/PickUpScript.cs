using UnityEngine;

// Token: 0x02000158 RID: 344
public class PickUpScript : MonoBehaviour {

  // Token: 0x0600065A RID: 1626 RVA: 0x0005B664 File Offset: 0x00059A64
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
    if (!this.CanCollide) {
      Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    }
    this.OriginalColor = this.Outline[0].color;
    this.OriginalScale = base.transform.localScale;
    this.MyRigidbody = base.GetComponent<Rigidbody>();
  }

  // Token: 0x0600065B RID: 1627 RVA: 0x0005B6EC File Offset: 0x00059AEC
  private void LateUpdate() {
    if (this.CleaningProduct) {
      if (this.Clock.Period == 5) {
        this.Suspicious = false;
      } else {
        this.Suspicious = true;
      }
    }
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      if (this.Weight) {
        if (this.Yandere.PickUp != null) {
          this.Yandere.CharacterAnimation[this.Yandere.CarryAnims[this.Yandere.PickUp.CarryAnimID]].weight = 0f;
        }
        if (this.Yandere.Armed) {
          this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[this.Yandere.EquippedWeapon.AnimID]].weight = 0f;
        }
        this.Yandere.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
        this.Yandere.transform.rotation = this.Yandere.targetRotation;
        this.Yandere.EmptyHands();
        base.transform.parent = this.Yandere.transform;
        base.transform.localPosition = new Vector3(0f, 0f, 0.75f);
        base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        base.transform.parent = null;
        this.Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
        this.Yandere.HeavyWeight = true;
        this.Yandere.CanMove = false;
        this.Yandere.Lifting = true;
        this.MyRigidbody.isKinematic = true;
        this.BeingLifted = true;
      } else {
        this.BePickedUp();
      }
    }
    if (this.Yandere.PickUp == this) {
      base.transform.localPosition = this.HoldPosition;
      base.transform.localEulerAngles = this.HoldRotation;
    }
    if (this.Dumped) {
      this.DumpTimer += Time.deltaTime;
      if (this.DumpTimer > 1f) {
        if (this.Clothing) {
          this.Yandere.Incinerator.BloodyClothing++;
        } else if (this.BodyPart) {
          this.Yandere.Incinerator.BodyParts++;
        }
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
    if (this.MyRigidbody != null && !this.MyRigidbody.isKinematic) {
      this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
      if (this.KinematicTimer == 5f) {
        this.MyRigidbody.isKinematic = true;
        this.KinematicTimer = 0f;
      }
    }
    if (this.Weight && this.BeingLifted) {
      if (this.Yandere.Lifting) {
        if (this.Yandere.CharacterAnimation["f02_heavyWeightLift_00"].time >= 2f) {
          base.transform.parent = this.Yandere.LeftItemParent;
          base.transform.localPosition = this.HoldPosition;
          base.transform.localEulerAngles = this.HoldRotation;
        }
      } else {
        this.BePickedUp();
        this.BeingLifted = false;
      }
    }
  }

  // Token: 0x0600065C RID: 1628 RVA: 0x0005BAE4 File Offset: 0x00059EE4
  private void BePickedUp() {
    this.Prompt.Circle[3].fillAmount = 1f;
    if (this.Yandere.PickUp != null) {
      this.Yandere.PickUp.Drop();
    }
    if (this.Yandere.Equipped == 3) {
      this.Yandere.Weapon[3].Drop();
    } else if (this.Yandere.Equipped > 0) {
      this.Yandere.Unequip();
    }
    if (this.Yandere.Dragging) {
      this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    }
    if (this.Yandere.Carrying) {
      this.Yandere.StopCarrying();
    }
    if (!this.LeftHand) {
      base.transform.parent = this.Yandere.ItemParent;
    } else {
      base.transform.parent = this.Yandere.LeftItemParent;
    }
    if (base.GetComponent<RadioScript>() != null && base.GetComponent<RadioScript>().On) {
      base.GetComponent<RadioScript>().TurnOff();
    }
    base.transform.localPosition = new Vector3(0f, 0f, 0f);
    base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    this.MyCollider.enabled = false;
    if (this.MyRigidbody != null) {
      this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    if (!this.Usable) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.NearestPrompt = null;
    } else {
      this.Prompt.Carried = true;
    }
    this.Yandere.PickUp = this;
    this.Yandere.CarryAnimID = this.CarryAnimID;
    foreach (OutlineScript outlineScript in this.Outline) {
      outlineScript.color = new Color(0f, 0f, 0f, 1f);
    }
    if (this.BodyPart) {
      this.Yandere.NearBodies++;
    }
    this.Yandere.StudentManager.UpdateStudents();
    this.KinematicTimer = 0f;
  }

  // Token: 0x0600065D RID: 1629 RVA: 0x0005BD5C File Offset: 0x0005A15C
  public void Drop() {
    if (this.Weight) {
      this.Yandere.IdleAnim = this.Yandere.OriginalIdleAnim;
      this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
      this.Yandere.RunAnim = this.Yandere.OriginalRunAnim;
    }
    if (this.BloodCleaner != null) {
      this.BloodCleaner.enabled = true;
      this.BloodCleaner.Pathfinding.enabled = true;
    }
    this.Yandere.PickUp = null;
    base.transform.parent = null;
    if (this.LockRotation) {
      base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, 0f);
    }
    if (this.MyRigidbody != null) {
      this.MyRigidbody.constraints = this.OriginalConstraints;
      this.MyRigidbody.isKinematic = false;
      this.MyRigidbody.useGravity = true;
    }
    if (this.Dumped) {
      base.transform.position = this.Incinerator.DumpPoint.position;
    } else {
      this.Prompt.enabled = true;
      this.MyCollider.enabled = true;
      this.MyCollider.isTrigger = false;
      if (!this.CanCollide) {
        Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
      }
    }
    this.Prompt.Carried = false;
    foreach (OutlineScript outlineScript in this.Outline) {
      outlineScript.color = ((!this.Evidence) ? this.OriginalColor : this.EvidenceColor);
    }
    base.transform.localScale = this.OriginalScale;
    if (this.BodyPart) {
      this.Yandere.NearBodies--;
    }
    this.Yandere.StudentManager.UpdateStudents();
  }

  // Token: 0x04000F57 RID: 3927
  public RigidbodyConstraints OriginalConstraints;

  // Token: 0x04000F58 RID: 3928
  public BloodCleanerScript BloodCleaner;

  // Token: 0x04000F59 RID: 3929
  public IncineratorScript Incinerator;

  // Token: 0x04000F5A RID: 3930
  public BodyPartScript BodyPart;

  // Token: 0x04000F5B RID: 3931
  public TrashCanScript TrashCan;

  // Token: 0x04000F5C RID: 3932
  public OutlineScript[] Outline;

  // Token: 0x04000F5D RID: 3933
  public YandereScript Yandere;

  // Token: 0x04000F5E RID: 3934
  public BucketScript Bucket;

  // Token: 0x04000F5F RID: 3935
  public PromptScript Prompt;

  // Token: 0x04000F60 RID: 3936
  public ClockScript Clock;

  // Token: 0x04000F61 RID: 3937
  public Rigidbody MyRigidbody;

  // Token: 0x04000F62 RID: 3938
  public Collider MyCollider;

  // Token: 0x04000F63 RID: 3939
  public Vector3 TrashPosition;

  // Token: 0x04000F64 RID: 3940
  public Vector3 TrashRotation;

  // Token: 0x04000F65 RID: 3941
  public Vector3 OriginalScale;

  // Token: 0x04000F66 RID: 3942
  public Vector3 HoldPosition;

  // Token: 0x04000F67 RID: 3943
  public Vector3 HoldRotation;

  // Token: 0x04000F68 RID: 3944
  public Color EvidenceColor;

  // Token: 0x04000F69 RID: 3945
  public Color OriginalColor;

  // Token: 0x04000F6A RID: 3946
  public bool CleaningProduct;

  // Token: 0x04000F6B RID: 3947
  public bool LockRotation;

  // Token: 0x04000F6C RID: 3948
  public bool BeingLifted;

  // Token: 0x04000F6D RID: 3949
  public bool CanCollide;

  // Token: 0x04000F6E RID: 3950
  public bool Suspicious;

  // Token: 0x04000F6F RID: 3951
  public bool Blowtorch;

  // Token: 0x04000F70 RID: 3952
  public bool Clothing;

  // Token: 0x04000F71 RID: 3953
  public bool Evidence;

  // Token: 0x04000F72 RID: 3954
  public bool JerryCan;

  // Token: 0x04000F73 RID: 3955
  public bool LeftHand;

  // Token: 0x04000F74 RID: 3956
  public bool Garbage;

  // Token: 0x04000F75 RID: 3957
  public bool Bleach;

  // Token: 0x04000F76 RID: 3958
  public bool Dumped;

  // Token: 0x04000F77 RID: 3959
  public bool Usable;

  // Token: 0x04000F78 RID: 3960
  public bool Weight;

  // Token: 0x04000F79 RID: 3961
  public int CarryAnimID;

  // Token: 0x04000F7A RID: 3962
  public int Food;

  // Token: 0x04000F7B RID: 3963
  public float KinematicTimer;

  // Token: 0x04000F7C RID: 3964
  public float DumpTimer;

  // Token: 0x04000F7D RID: 3965
  public bool Empty = true;

  // Token: 0x04000F7E RID: 3966
  public GameObject[] FoodPieces;
}