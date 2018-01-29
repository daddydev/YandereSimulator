using UnityEngine;

// Token: 0x0200016F RID: 367
public class RagdollScript : MonoBehaviour {

  // Token: 0x060006CE RID: 1742 RVA: 0x00067A38 File Offset: 0x00065E38
  private void Start() {
    Physics.IgnoreLayerCollision(11, 13, true);
    this.Zs.SetActive(this.Tranquil);
    if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted && !this.Burning) {
      this.BloodPoolSpawner.gameObject.SetActive(true);
      if (this.Pushed) {
        this.BloodPoolSpawner.Timer = 5f;
      }
    }
    for (int i = 0; i < this.AllRigidbodies.Length; i++) {
      this.AllRigidbodies[i].isKinematic = false;
      this.AllColliders[i].enabled = true;
      if (this.Yandere.StudentManager.NoGravity) {
        this.AllRigidbodies[i].useGravity = false;
      }
    }
    this.Prompt.enabled = true;
    if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil) {
      this.Prompt.HideButton[3] = false;
    }
  }

  // Token: 0x060006CF RID: 1743 RVA: 0x00067B54 File Offset: 0x00065F54
  private void Update() {
    if (!this.Dragged && !this.Carried && !this.Settled && !this.Yandere.PK && !this.Yandere.StudentManager.NoGravity) {
      this.SettleTimer += Time.deltaTime;
      if (this.SettleTimer > 5f) {
        this.Settled = true;
        for (int i = 0; i < this.AllRigidbodies.Length; i++) {
          this.AllRigidbodies[i].isKinematic = true;
          this.AllColliders[i].enabled = false;
        }
      }
    }
    if (this.DetectionMarker != null) {
      if (this.DetectionMarker.Tex.color.a > 0.1f) {
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, 0f, Time.deltaTime * 10f));
      } else {
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
        this.DetectionMarker = null;
      }
    }
    if (!this.Dumped) {
      if (this.StopAnimation && this.Character.GetComponent<Animation>().isPlaying) {
        this.Character.GetComponent<Animation>().Stop();
      }
      if (!Input.GetButtonDown("LB")) {
        if (this.BloodPoolSpawner.gameObject.activeInHierarchy && !this.Cauterized) {
          if (this.Yandere.PickUp != null) {
            if (this.Yandere.PickUp.Blowtorch) {
              if (!this.Cauterizable) {
                this.Prompt.Label[0].text = "     Cauterize";
                this.Cauterizable = true;
              }
            } else if (this.Cauterizable) {
              this.Prompt.Label[0].text = "     Dismember";
              this.Cauterizable = false;
            }
          } else if (this.Cauterizable) {
            this.Prompt.Label[0].text = "     Dismember";
            this.Cauterizable = false;
          }
        }
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          if (this.Cauterizable) {
            this.Prompt.Label[0].text = "     Dismember";
            this.BloodPoolSpawner.enabled = false;
            this.Cauterizable = false;
            this.Cauterized = true;
            this.Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
            this.Yandere.Cauterizing = true;
            this.Yandere.CanMove = false;
            this.Yandere.PickUp.GetComponent<BlowtorchScript>().enabled = true;
            this.Yandere.PickUp.GetComponent<AudioSource>().Play();
          } else {
            this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_dismember_00");
            this.Yandere.transform.LookAt(base.transform);
            this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
            this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
            this.Yandere.EquippedWeapon.Dismember();
            this.Yandere.RPGCamera.enabled = false;
            this.Yandere.TargetStudent = this.Student;
            this.Yandere.Ragdoll = base.gameObject;
            this.Yandere.Dismembering = true;
            this.Yandere.CanMove = false;
          }
        }
        if (this.Prompt.Circle[1].fillAmount == 0f) {
          this.Prompt.Circle[1].fillAmount = 1f;
          if (!this.Dragged) {
            this.Yandere.EmptyHands();
            this.Prompt.AcceptingInput[1] = false;
            this.Prompt.Label[1].text = "     Drop";
            this.PickNearestLimb();
            this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
            this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
            this.Yandere.Dragging = true;
            this.Yandere.DragState = 0;
            this.Yandere.Ragdoll = base.gameObject;
            this.Dragged = true;
            this.Yandere.StudentManager.UpdateStudents();
            if (this.MurderSuicide) {
              this.Police.MurderSuicideScene = false;
              this.MurderSuicide = false;
            }
            if (this.Suicide) {
              this.Police.Suicide = false;
              this.Suicide = false;
            }
            for (int j = 0; j < this.Student.Ragdoll.AllRigidbodies.Length; j++) {
              this.Student.Ragdoll.AllRigidbodies[j].drag = 2f;
            }
            for (int k = 0; k < this.AllRigidbodies.Length; k++) {
              this.AllRigidbodies[k].isKinematic = false;
              this.AllColliders[k].enabled = true;
              if (this.Yandere.StudentManager.NoGravity) {
                this.AllRigidbodies[k].useGravity = false;
              }
            }
          } else {
            this.StopDragging();
          }
        }
        if (this.Prompt.Circle[3].fillAmount == 0f) {
          this.Yandere.EmptyHands();
          this.Prompt.Label[1].text = "     Drop";
          this.Prompt.HideButton[1] = true;
          this.Prompt.HideButton[3] = true;
          this.Prompt.enabled = false;
          this.Prompt.Hide();
          for (int l = 0; l < this.AllRigidbodies.Length; l++) {
            this.AllRigidbodies[l].isKinematic = true;
            this.AllColliders[l].enabled = false;
          }
          if (this.Male) {
            Rigidbody rigidbody = this.AllRigidbodies[0];
            rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
          }
          this.Yandere.Character.GetComponent<Animation>().Play("f02_carryLiftA_00");
          this.Character.GetComponent<Animation>().Play(this.LiftAnim);
          this.BloodSpawnerCollider.enabled = false;
          this.PelvisRoot.localEulerAngles = new Vector3(this.PelvisRoot.localEulerAngles.x, 0f, this.PelvisRoot.localEulerAngles.z);
          this.Prompt.MyCollider.enabled = false;
          this.PelvisRoot.localPosition = new Vector3(this.PelvisRoot.localPosition.x, this.PelvisRoot.localPosition.y, 0f);
          this.Yandere.Ragdoll = base.gameObject;
          this.Yandere.CanMove = false;
          this.Yandere.Lifting = true;
          this.StopAnimation = false;
          this.Carried = true;
          this.Falling = false;
          this.FallTimer = 0f;
        }
      } else if (this.Yandere.CanMove && this.Dragged) {
        this.StopDragging();
      }
      if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < 2f) {
        if (!this.Suicide && !this.AddingToCount) {
          this.Yandere.NearBodies++;
          this.AddingToCount = true;
        }
      } else if (this.AddingToCount) {
        this.Yandere.NearBodies--;
        this.AddingToCount = false;
      }
      if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B")) {
        this.Prompt.AcceptingInput[1] = true;
      }
      bool flag = false;
      if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 7) {
        flag = true;
      }
      if (!this.Cauterized && this.Yandere.PickUp != null && this.Yandere.PickUp.Blowtorch && this.BloodPoolSpawner.gameObject.activeInHierarchy) {
        flag = true;
      }
      this.Prompt.HideButton[0] = (this.Dragged || this.Carried || this.Tranquil || !flag || this.Nemesis);
    } else if (this.DumpType == RagdollDumpType.Incinerator) {
      if (this.DumpTimer == 0f && this.Yandere.Carrying) {
        this.Character.GetComponent<Animation>()[this.DumpedAnim].time = 2.5f;
      }
      this.Character.GetComponent<Animation>().CrossFade(this.DumpedAnim);
      this.DumpTimer += Time.deltaTime;
      if (this.Character.GetComponent<Animation>()[this.DumpedAnim].time >= this.Character.GetComponent<Animation>()[this.DumpedAnim].length) {
        this.Incinerator.Corpses++;
        this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
        this.Remove();
      }
    } else if (this.DumpType == RagdollDumpType.TranqCase) {
      if (this.DumpTimer == 0f && this.Yandere.Carrying) {
        this.Character.GetComponent<Animation>()[this.DumpedAnim].time = 2.5f;
      }
      this.Character.GetComponent<Animation>().CrossFade(this.DumpedAnim);
      this.DumpTimer += Time.deltaTime;
      if (this.Character.GetComponent<Animation>()[this.DumpedAnim].time >= this.Character.GetComponent<Animation>()[this.DumpedAnim].length) {
        this.TranqCase.Open = false;
        if (this.AddingToCount) {
          this.Yandere.NearBodies--;
        }
      }
    } else if (this.DumpType == RagdollDumpType.WoodChipper) {
      if (this.DumpTimer == 0f && this.Yandere.Carrying) {
        this.Character.GetComponent<Animation>()[this.DumpedAnim].time = 2.5f;
      }
      this.Character.GetComponent<Animation>().CrossFade(this.DumpedAnim);
      this.DumpTimer += Time.deltaTime;
      if (this.Character.GetComponent<Animation>()[this.DumpedAnim].time >= this.Character.GetComponent<Animation>()[this.DumpedAnim].length) {
        this.WoodChipper.VictimID = this.StudentID;
        this.Remove();
      }
    }
    if (this.Hidden && this.HideCollider == null) {
      this.Police.HiddenCorpses--;
      this.Hidden = false;
    }
    if (this.Falling) {
      this.FallTimer += Time.deltaTime;
      if (this.FallTimer > 2f) {
        this.BloodSpawnerCollider.enabled = true;
        this.FallTimer = 0f;
        this.Falling = false;
      }
    }
    if (this.Burning) {
      for (int m = 0; m < 3; m++) {
        Material material = this.MyRenderer.materials[m];
        material.color = Vector4.MoveTowards(material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
      }
      this.Student.Cosmetic.HairRenderer.material.color = Vector4.MoveTowards(this.Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
      if (this.MyRenderer.materials[0].color == new Color(0.1f, 0.1f, 0.1f, 1f)) {
        this.Burning = false;
        this.Burned = true;
      }
    }
    if (this.Burned) {
      this.Sacrifice = (Vector3.Distance(this.Prompt.transform.position, this.Yandere.StudentManager.SacrificeSpot.position) < 1.5f);
    }
  }

  // Token: 0x060006D0 RID: 1744 RVA: 0x000689F4 File Offset: 0x00066DF4
  private void LateUpdate() {
    if (!this.Male) {
      this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
      this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
      this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
      this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
      if (this.StudentID == 32) {
        for (int i = 0; i < 4; i++) {
          Transform transform = this.Student.Skirt[i];
          transform.transform.localScale = new Vector3(transform.transform.localScale.x, 0.6666667f, transform.transform.localScale.z);
        }
      }
    }
    if (this.Decapitated) {
      this.Head.localScale = Vector3.zero;
    }
    if (this.Yandere.Ragdoll == base.gameObject) {
      if (this.Yandere.DumpTimer < 1f) {
        if (this.Yandere.Lifting) {
          base.transform.position = this.Yandere.transform.position;
          base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
        } else if (this.Carried) {
          base.transform.position = this.Yandere.transform.position;
          base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
          float axis = Input.GetAxis("Vertical");
          float axis2 = Input.GetAxis("Horizontal");
          if (axis != 0f || axis2 != 0f) {
            this.Character.GetComponent<Animation>().CrossFade((!Input.GetButton("LB")) ? this.WalkAnim : this.RunAnim);
          } else {
            this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim);
          }
          this.Character.GetComponent<Animation>()[this.IdleAnim].time = this.Yandere.Character.GetComponent<Animation>()["f02_carryIdleA_00"].time;
          this.Character.GetComponent<Animation>()[this.WalkAnim].time = this.Yandere.Character.GetComponent<Animation>()["f02_carryWalkA_00"].time;
          this.Character.GetComponent<Animation>()[this.RunAnim].time = this.Yandere.Character.GetComponent<Animation>()["f02_carryRunA_00"].time;
        }
      }
      if (this.Carried && this.Male) {
        Rigidbody rigidbody = this.AllRigidbodies[0];
        rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
      }
    }
  }

  // Token: 0x060006D1 RID: 1745 RVA: 0x00068E2C File Offset: 0x0006722C
  public void StopDragging() {
    foreach (Rigidbody rigidbody in this.Student.Ragdoll.AllRigidbodies) {
      rigidbody.drag = 0f;
    }
    if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil) {
      this.Prompt.HideButton[3] = false;
    }
    this.Prompt.AcceptingInput[1] = false;
    this.Prompt.Circle[1].fillAmount = 1f;
    this.Prompt.Label[1].text = "     Drag";
    this.Yandere.RagdollDragger.connectedBody = null;
    this.Yandere.RagdollPK.connectedBody = null;
    this.Yandere.Dragging = false;
    this.Yandere.Ragdoll = null;
    this.Yandere.StudentManager.UpdateStudents();
    this.SettleTimer = 0f;
    this.Settled = false;
    this.Dragged = false;
  }

  // Token: 0x060006D2 RID: 1746 RVA: 0x00068F38 File Offset: 0x00067338
  private void PickNearestLimb() {
    this.NearestLimb = this.Limb[0];
    this.LimbID = 0;
    for (int i = 1; i < 4; i++) {
      Transform transform = this.Limb[i];
      if (Vector3.Distance(transform.position, this.Yandere.transform.position) < Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position)) {
        this.NearestLimb = transform;
        this.LimbID = i;
      }
    }
  }

  // Token: 0x060006D3 RID: 1747 RVA: 0x00068FC4 File Offset: 0x000673C4
  public void Dump() {
    if (this.DumpType == RagdollDumpType.Incinerator) {
      base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
      base.transform.position = this.Yandere.transform.position;
      this.Incinerator = this.Yandere.Incinerator;
      this.BloodPoolSpawner.enabled = false;
    } else if (this.DumpType == RagdollDumpType.TranqCase) {
      this.TranqCase = this.Yandere.TranqCase;
    } else if (this.DumpType == RagdollDumpType.WoodChipper) {
      this.WoodChipper = this.Yandere.WoodChipper;
    }
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Dumped = true;
    foreach (Rigidbody rigidbody in this.AllRigidbodies) {
      rigidbody.isKinematic = true;
    }
  }

  // Token: 0x060006D4 RID: 1748 RVA: 0x000690B8 File Offset: 0x000674B8
  public void Fall() {
    base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.0001f, base.transform.position.z);
    this.Prompt.Label[1].text = "     Drag";
    this.Prompt.HideButton[1] = false;
    this.Prompt.enabled = true;
    if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil) {
      this.Prompt.HideButton[3] = false;
    }
    if (this.Dragged) {
      this.Yandere.RagdollDragger.connectedBody = null;
      this.Yandere.RagdollPK.connectedBody = null;
      this.Yandere.Dragging = false;
      this.Dragged = false;
    }
    this.Yandere.Ragdoll = null;
    this.Prompt.MyCollider.enabled = true;
    this.BloodPoolSpawner.NearbyBlood = 0;
    this.StopAnimation = true;
    this.SettleTimer = 0f;
    this.Carried = false;
    this.Settled = false;
    this.Falling = true;
    for (int i = 0; i < this.AllRigidbodies.Length; i++) {
      this.AllRigidbodies[i].isKinematic = false;
      this.AllColliders[i].enabled = true;
    }
  }

  // Token: 0x060006D5 RID: 1749 RVA: 0x00069234 File Offset: 0x00067634
  public void Dismember() {
    if (!this.Dismembered) {
      this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
      for (int i = 0; i < this.BodyParts.Length; i++) {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
        gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
        gameObject.GetComponent<BodyPartScript>().StudentID = this.StudentID;
        gameObject.GetComponent<BodyPartScript>().Sacrifice = this.Sacrifice;
        if (this.Yandere.StudentManager.NoGravity) {
          gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (i == 0) {
          if (!this.Student.OriginallyTeacher) {
            if (!this.Male) {
              this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
              if (this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != null && this.Student.Cosmetic.Accessory != 3 && this.Student.Cosmetic.Accessory != 6) {
                this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
              }
            } else {
              Transform transform = this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform;
              transform.parent = gameObject.transform;
              transform.localScale *= 1.06382978f;
              if (transform.transform.localPosition.y < -1f) {
                transform.transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y - 0.1f, transform.transform.localPosition.z);
              }
              if (this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory] != null) {
                this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
              }
            }
          } else {
            this.Student.Cosmetic.TeacherHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
            if (this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory] != null) {
              this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
            }
          }
          if (this.Student.Club < ClubType.Gaming && this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club] != null) {
            this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.parent = gameObject.transform;
            if (this.Student.Club == ClubType.Occult) {
              if (!this.Male) {
                this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.5f, 0.01f);
                this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
              } else {
                this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.42f, 0.005f);
                this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
              }
            }
          }
          gameObject.GetComponent<Renderer>().materials[0].mainTexture = this.Student.Cosmetic.FaceTexture;
          if (i == 0) {
            gameObject.transform.position += new Vector3(0f, 1f, 0f);
          }
        } else if (i == 2 && this.Student.Cosmetic.Accessory == 6) {
          this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
        }
      }
      if (this.BloodPoolSpawner.BloodParent == null) {
        this.BloodPoolSpawner.Start();
      }
      this.BloodPoolSpawner.SpawnBigPool();
      this.Police.BodyParts += 6;
      this.Yandere.NearBodies--;
      this.Police.Corpses--;
      UnityEngine.Object.Destroy(base.gameObject);
      this.Dismembered = true;
    }
  }

  // Token: 0x060006D6 RID: 1750 RVA: 0x000697F4 File Offset: 0x00067BF4
  public void Remove() {
    if (this.AddingToCount) {
      this.Yandere.NearBodies--;
    }
    if (this.Poisoned) {
      this.Police.PoisonScene = false;
    }
    base.gameObject.SetActive(false);
  }

  // Token: 0x040010F4 RID: 4340
  public BloodPoolSpawnerScript BloodPoolSpawner;

  // Token: 0x040010F5 RID: 4341
  public DetectionMarkerScript DetectionMarker;

  // Token: 0x040010F6 RID: 4342
  public IncineratorScript Incinerator;

  // Token: 0x040010F7 RID: 4343
  public WoodChipperScript WoodChipper;

  // Token: 0x040010F8 RID: 4344
  public TranqCaseScript TranqCase;

  // Token: 0x040010F9 RID: 4345
  public StudentScript Student;

  // Token: 0x040010FA RID: 4346
  public YandereScript Yandere;

  // Token: 0x040010FB RID: 4347
  public PoliceScript Police;

  // Token: 0x040010FC RID: 4348
  public PromptScript Prompt;

  // Token: 0x040010FD RID: 4349
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x040010FE RID: 4350
  public Collider BloodSpawnerCollider;

  // Token: 0x040010FF RID: 4351
  public Animation CharacterAnimation;

  // Token: 0x04001100 RID: 4352
  public Collider HideCollider;

  // Token: 0x04001101 RID: 4353
  public Rigidbody[] AllRigidbodies;

  // Token: 0x04001102 RID: 4354
  public Collider[] AllColliders;

  // Token: 0x04001103 RID: 4355
  public Rigidbody[] Rigidbodies;

  // Token: 0x04001104 RID: 4356
  public Transform[] SpawnPoints;

  // Token: 0x04001105 RID: 4357
  public GameObject[] BodyParts;

  // Token: 0x04001106 RID: 4358
  public Transform NearestLimb;

  // Token: 0x04001107 RID: 4359
  public Transform RightBreast;

  // Token: 0x04001108 RID: 4360
  public Transform LeftBreast;

  // Token: 0x04001109 RID: 4361
  public Transform PelvisRoot;

  // Token: 0x0400110A RID: 4362
  public Transform Ponytail;

  // Token: 0x0400110B RID: 4363
  public Transform RightEye;

  // Token: 0x0400110C RID: 4364
  public Transform LeftEye;

  // Token: 0x0400110D RID: 4365
  public Transform HairR;

  // Token: 0x0400110E RID: 4366
  public Transform HairL;

  // Token: 0x0400110F RID: 4367
  public Transform[] Limb;

  // Token: 0x04001110 RID: 4368
  public Transform Head;

  // Token: 0x04001111 RID: 4369
  public Vector3 RightEyeOrigin;

  // Token: 0x04001112 RID: 4370
  public Vector3 LeftEyeOrigin;

  // Token: 0x04001113 RID: 4371
  public Vector3[] LimbAnchor;

  // Token: 0x04001114 RID: 4372
  public GameObject Character;

  // Token: 0x04001115 RID: 4373
  public GameObject Zs;

  // Token: 0x04001116 RID: 4374
  public bool AddingToCount;

  // Token: 0x04001117 RID: 4375
  public bool MurderSuicide;

  // Token: 0x04001118 RID: 4376
  public bool Cauterizable;

  // Token: 0x04001119 RID: 4377
  public bool Electrocuted;

  // Token: 0x0400111A RID: 4378
  public bool StopAnimation = true;

  // Token: 0x0400111B RID: 4379
  public bool Decapitated;

  // Token: 0x0400111C RID: 4380
  public bool Dismembered;

  // Token: 0x0400111D RID: 4381
  public bool Cauterized;

  // Token: 0x0400111E RID: 4382
  public bool Disturbing;

  // Token: 0x0400111F RID: 4383
  public bool Sacrifice;

  // Token: 0x04001120 RID: 4384
  public bool Poisoned;

  // Token: 0x04001121 RID: 4385
  public bool Tranquil;

  // Token: 0x04001122 RID: 4386
  public bool Burning;

  // Token: 0x04001123 RID: 4387
  public bool Carried;

  // Token: 0x04001124 RID: 4388
  public bool Dragged;

  // Token: 0x04001125 RID: 4389
  public bool Drowned;

  // Token: 0x04001126 RID: 4390
  public bool Falling;

  // Token: 0x04001127 RID: 4391
  public bool Nemesis;

  // Token: 0x04001128 RID: 4392
  public bool Settled;

  // Token: 0x04001129 RID: 4393
  public bool Suicide;

  // Token: 0x0400112A RID: 4394
  public bool Burned;

  // Token: 0x0400112B RID: 4395
  public bool Dumped;

  // Token: 0x0400112C RID: 4396
  public bool Hidden;

  // Token: 0x0400112D RID: 4397
  public bool Pushed;

  // Token: 0x0400112E RID: 4398
  public bool Male;

  // Token: 0x0400112F RID: 4399
  public float AnimStartTime;

  // Token: 0x04001130 RID: 4400
  public float SettleTimer;

  // Token: 0x04001131 RID: 4401
  public float BreastSize;

  // Token: 0x04001132 RID: 4402
  public float DumpTimer;

  // Token: 0x04001133 RID: 4403
  public float EyeShrink;

  // Token: 0x04001134 RID: 4404
  public float FallTimer;

  // Token: 0x04001135 RID: 4405
  public int StudentID;

  // Token: 0x04001136 RID: 4406
  public RagdollDumpType DumpType;

  // Token: 0x04001137 RID: 4407
  public int LimbID;

  // Token: 0x04001138 RID: 4408
  public int Frame;

  // Token: 0x04001139 RID: 4409
  public string DumpedAnim = string.Empty;

  // Token: 0x0400113A RID: 4410
  public string LiftAnim = string.Empty;

  // Token: 0x0400113B RID: 4411
  public string IdleAnim = string.Empty;

  // Token: 0x0400113C RID: 4412
  public string WalkAnim = string.Empty;

  // Token: 0x0400113D RID: 4413
  public string RunAnim = string.Empty;
}