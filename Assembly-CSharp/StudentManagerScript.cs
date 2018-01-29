using UnityEngine;

// Token: 0x020001C8 RID: 456
public class StudentManagerScript : MonoBehaviour {

  // Token: 0x060007EB RID: 2027 RVA: 0x0007A950 File Offset: 0x00078D50
  private void Start() {
    this.SeatsTaken32[3] = true;
    this.SeatsTaken31[3] = true;
    this.SeatsTaken22[3] = true;
    this.SeatsTaken21[3] = true;
    this.ID = 1;
    while (this.ID < this.JSON.Students.Length) {
      if (!this.JSON.Students[this.ID].Success) {
        this.ProblemID = this.ID;
        break;
      }
      this.ID++;
    }
    bool flag = this.ProblemID != -1;
    if (flag) {
      if (this.ErrorLabel != null) {
        this.ErrorLabel.text = string.Empty;
      }
      this.SetAtmosphere();
      GameGlobals.Paranormal = false;
      if (MissionModeGlobals.MissionMode) {
        StudentGlobals.FemaleUniform = 5;
        StudentGlobals.MaleUniform = 5;
      }
      if (StudentGlobals.GetStudentSlave(SchoolGlobals.KidnapVictim)) {
        this.ForceSpawn = true;
        this.SpawnPositions[SchoolGlobals.KidnapVictim] = this.SlaveSpot;
        this.SpawnID = SchoolGlobals.KidnapVictim;
        StudentGlobals.SetStudentDead(SchoolGlobals.KidnapVictim, false);
        this.SpawnStudent(this.SpawnID);
        this.Students[SchoolGlobals.KidnapVictim].Slave = true;
        this.SpawnID = 0;
        StudentGlobals.SetStudentSlave(SchoolGlobals.KidnapVictim, false);
        SchoolGlobals.KidnapVictim = 0;
      }
      this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
      this.SpawnID = 1;
      if (StudentGlobals.MaleUniform == 0) {
        StudentGlobals.MaleUniform = 1;
      }
      this.ID = 1;
      while (this.ID < this.NPCsTotal + 1) {
        if (!StudentGlobals.GetStudentDead(this.ID)) {
          StudentGlobals.SetStudentDying(this.ID, false);
        }
        this.ID++;
      }
      if (!this.TakingPortraits) {
        this.ID = 1;
        while (this.ID < this.Lockers.List.Length) {
          Transform transform = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f, this.Lockers.List[this.ID].rotation).transform;
          transform.parent = this.Lockers.transform;
          transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
          this.LockerPositions[this.ID] = transform;
          this.ID++;
        }
        this.ID = 1;
        while (this.ID < this.HidingSpots.List.Length) {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
          while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f) {
            gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
          }
          gameObject.transform.parent = this.HidingSpots.transform;
          this.HidingSpots.List[this.ID] = gameObject.transform;
          this.ID++;
        }
      }
      if (HomeGlobals.LateForSchool) {
        HomeGlobals.LateForSchool = false;
        this.YandereLate = true;
        this.Clock.PresentTime = 480f;
        this.Clock.HourTime = 8f;
        this.SkipTo8();
      }
      if (!this.TakingPortraits) {
        while (this.SpawnID < this.NPCsTotal + 1) {
          this.SpawnStudent(this.SpawnID);
          this.SpawnID++;
        }
      }
    } else {
      string str = string.Empty;
      if (this.ProblemID > 1) {
        str = "The problem may be caused by Student " + this.ProblemID.ToString() + ".";
      }
      if (this.ErrorLabel != null) {
        this.ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + str;
      }
    }
  }

  // Token: 0x060007EC RID: 2028 RVA: 0x0007AE5C File Offset: 0x0007925C
  public void SetAtmosphere() {
    if (GameGlobals.LoveSick) {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 0f;
    }
    if (!SchoolGlobals.SchoolAtmosphereSet) {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 1f;
    }
    Vignetting[] components = Camera.main.GetComponents<Vignetting>();
    float num = 1f - SchoolGlobals.SchoolAtmosphere;
    if (!this.TakingPortraits) {
      this.SmartphoneSelectiveGreyscale.desaturation = num;
      this.SelectiveGreyscale.desaturation = num;
      components[2].intensity = num * 5f;
      components[2].blur = num;
      components[2].chromaticAberration = num * 5f;
      float num2 = 1f - num;
      RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
      Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
      RenderSettings.fogDensity = num * 0.1f;
    }
  }

  // Token: 0x060007ED RID: 2029 RVA: 0x0007AF3C File Offset: 0x0007933C
  private void Update() {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if (!this.TakingPortraits) {
      this.Frame++;
      if (!this.FirstUpdate) {
        this.QualityManager.UpdateOutlines();
        this.FirstUpdate = true;
        this.AssignTeachers();
      }
      if (this.Frame == 3) {
        this.LoveManager.CoupleCheck();
        this.UpdateStudents();
      }
    } else if (this.NPCsSpawned < this.StudentsTotal + this.TeachersTotal) {
      this.Frame++;
      if (this.Frame == 1) {
        if (this.NewStudent != null) {
          UnityEngine.Object.Destroy(this.NewStudent);
        }
        if (this.Randomize) {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((UnityEngine.Random.Range(0, 2) != 0) ? this.PortraitKun : this.PortraitChan, Vector3.zero, Quaternion.identity);
        } else {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((this.JSON.Students[this.NPCsSpawned + 1].Gender != 0) ? this.PortraitKun : this.PortraitChan, Vector3.zero, Quaternion.identity);
        }
        this.NewStudent.GetComponent<CosmeticScript>().StudentID = this.NPCsSpawned + 1;
        this.NewStudent.GetComponent<CosmeticScript>().StudentManager = this;
        this.NewStudent.GetComponent<CosmeticScript>().TakingPortrait = true;
        this.NewStudent.GetComponent<CosmeticScript>().Randomize = this.Randomize;
        this.NewStudent.GetComponent<CosmeticScript>().JSON = this.JSON;
        this.NewPortraitChan = this.NewStudent.GetComponent<PortraitChanScript>();
        this.NewPortraitChan.StudentID = this.NPCsSpawned + 1;
        this.NewPortraitChan.StudentManager = this;
        this.NewPortraitChan.JSON = this.JSON;
        if (!this.Randomize) {
          this.NPCsSpawned++;
        }
      }
      if (this.Frame == 2) {
        Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
        this.Frame = 0;
      }
    } else {
      Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
      base.gameObject.SetActive(false);
    }
    if (this.Witnesses > 0) {
      this.ID = 1;
      while (this.ID < this.WitnessList.Length) {
        StudentScript studentScript = this.WitnessList[this.ID];
        if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || (studentScript.Fleeing && !studentScript.PinningDown))) {
          studentScript.PinDownWitness = false;
          if (this.ID != this.WitnessList.Length - 1) {
            this.Shuffle(this.ID);
          }
          this.Witnesses--;
        }
        this.ID++;
      }
      if (this.PinningDown && this.Witnesses < 4) {
        this.PinningDown = false;
        this.PinPhase = 0;
      }
    }
    if (this.PinningDown) {
      if (!this.Yandere.Attacking && this.Yandere.CanMove) {
        this.Yandere.CharacterAnimation.CrossFade("f02_pinDownPanic_00");
        this.Yandere.EmptyHands();
        this.Yandere.CanMove = false;
      }
      if (this.PinPhase == 1) {
        if (!this.Yandere.Attacking && !this.Yandere.Struggling) {
          this.PinTimer += Time.deltaTime;
        }
        if (this.PinTimer > 1f) {
          this.ID = 1;
          while (this.ID < 5) {
            StudentScript studentScript2 = this.WitnessList[this.ID];
            if (studentScript2 != null) {
              studentScript2.transform.position = new Vector3(studentScript2.transform.position.x, studentScript2.transform.position.y + 0.1f, studentScript2.transform.position.z);
              studentScript2.CurrentDestination = this.PinDownSpots[this.ID];
              studentScript2.Pathfinding.target = this.PinDownSpots[this.ID];
              studentScript2.DistanceToDestination = 100f;
              studentScript2.Pathfinding.speed = 5f;
              studentScript2.MyController.radius = 0f;
              studentScript2.PinningDown = true;
              studentScript2.Alarmed = false;
              studentScript2.Routine = false;
              studentScript2.Fleeing = true;
              studentScript2.AlarmTimer = 0f;
              studentScript2.Safe = true;
              studentScript2.Prompt.Hide();
              studentScript2.Prompt.enabled = false;
              Debug.Log(studentScript2 + "'s current destination is " + studentScript2.CurrentDestination);
            }
            this.ID++;
          }
          this.PinPhase++;
        }
      } else if (this.WitnessList[1].PinPhase == 0) {
        if (this.WitnessList[1].DistanceToDestination < 1f && this.WitnessList[2].DistanceToDestination < 1f && this.WitnessList[3].DistanceToDestination < 1f && this.WitnessList[4].DistanceToDestination < 1f) {
          this.Clock.StopTime = true;
          if (this.Yandere.Aiming) {
            this.Yandere.StopAiming();
            this.Yandere.enabled = false;
          }
          this.Yandere.Mopping = false;
          this.Yandere.EmptyHands();
          AudioSource component = base.GetComponent<AudioSource>();
          component.PlayOneShot(this.PinDownSFX);
          component.PlayOneShot(this.YanderePinDown);
          this.Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
          this.Yandere.CanMove = false;
          this.Yandere.ShoulderCamera.LookDown = true;
          this.Yandere.RPGCamera.enabled = false;
          this.StopMoving();
          this.ID = 1;
          while (this.ID < 5) {
            StudentScript studentScript3 = this.WitnessList[this.ID];
            GameObjectUtils.SetLayerRecursively(studentScript3.gameObject, 13);
            studentScript3.CharacterAnimation.CrossFade((((!studentScript3.Male) ? "f02_pinDown_0" : "pinDown_0") + this.ID).ToString());
            studentScript3.PinPhase++;
            this.ID++;
          }
        }
      } else {
        bool flag = false;
        if (!this.WitnessList[1].Male) {
          if (this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].length) {
            flag = true;
          }
        } else if (this.WitnessList[1].CharacterAnimation["pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["pinDown_01"].length) {
          flag = true;
        }
        if (flag) {
          this.Yandere.CharacterAnimation.CrossFade("f02_pinDownLoop_00");
          this.ID = 1;
          while (this.ID < 5) {
            StudentScript studentScript4 = this.WitnessList[this.ID];
            studentScript4.CharacterAnimation.CrossFade((((!studentScript4.Male) ? "f02_pinDownLoop_0" : "pinDownLoop_0") + this.ID).ToString());
            this.ID++;
          }
          this.PinningDown = false;
        }
      }
    }
  }

  // Token: 0x060007EE RID: 2030 RVA: 0x0007B77C File Offset: 0x00079B7C
  public void SpawnStudent(int spawnID) {
    if (this.Students[spawnID] == null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID) && this.JSON.Students[spawnID].Name != "Unknown" && this.JSON.Students[spawnID].Name != "Reserved" && StudentGlobals.GetStudentReputation(spawnID) > -100) {
      int num;
      if (this.JSON.Students[spawnID].Name == "Random") {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
        while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f) {
          gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
        }
        gameObject.transform.parent = this.HidingSpots.transform;
        this.HidingSpots.List[spawnID] = gameObject.transform;
        GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
        gameObject2.transform.parent = this.Patrols.transform;
        this.Patrols.List[spawnID] = gameObject2.transform;
        GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
        gameObject3.transform.parent = this.CleaningSpots.transform;
        this.CleaningSpots.List[spawnID] = gameObject3.transform;
        num = ((!MissionModeGlobals.MissionMode || MissionModeGlobals.MissionTarget != spawnID) ? UnityEngine.Random.Range(0, 2) : 0);
        this.FindUnoccupiedSeat();
      } else {
        num = this.JSON.Students[spawnID].Gender;
      }
      this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((num != 0) ? this.StudentKun : this.StudentChan, this.SpawnPositions[spawnID].position, Quaternion.identity);
      this.NewStudent.GetComponent<CosmeticScript>().LoveManager = this.LoveManager;
      this.NewStudent.GetComponent<CosmeticScript>().StudentManager = this;
      this.NewStudent.GetComponent<CosmeticScript>().Randomize = this.Randomize;
      this.NewStudent.GetComponent<CosmeticScript>().StudentID = spawnID;
      this.NewStudent.GetComponent<CosmeticScript>().JSON = this.JSON;
      if (this.JSON.Students[spawnID].Name == "Random") {
        this.NewStudent.GetComponent<StudentScript>().CleaningSpot = this.CleaningSpots.List[spawnID];
        this.NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
      }
      this.Students[spawnID] = this.NewStudent.GetComponent<StudentScript>();
      StudentScript studentScript = this.Students[spawnID];
      studentScript.Cosmetic.TextureManager = this.TextureManager;
      studentScript.WitnessCamera = this.WitnessCamera;
      studentScript.StudentManager = this;
      studentScript.StudentID = spawnID;
      studentScript.JSON = this.JSON;
      if (this.AoT) {
        studentScript.AoT = true;
      }
      if (this.DK) {
        studentScript.DK = true;
      }
      if (this.Spooky) {
        studentScript.Spooky = true;
      }
      if (this.Sans) {
        studentScript.BadTime = true;
      }
      if (spawnID == this.RivalID) {
        studentScript.Rival = true;
      }
      this.OccupySeat();
    }
    this.NPCsSpawned++;
    this.TaskManager.UpdateTaskStatus();
    this.ForceSpawn = false;
  }

  // Token: 0x060007EF RID: 2031 RVA: 0x0007BBD8 File Offset: 0x00079FD8
  public void UpdateStudents() {
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        if (studentScript.gameObject.activeInHierarchy) {
          if (!studentScript.Safe) {
            if (!studentScript.Slave) {
              if (studentScript.Pushable) {
                studentScript.Prompt.Label[0].text = "     Push";
              } else if (!studentScript.Following) {
                studentScript.Prompt.Label[0].text = "     Talk";
              } else {
                studentScript.Prompt.Label[0].text = "     Stop";
              }
              studentScript.Prompt.HideButton[0] = false;
              studentScript.Prompt.HideButton[2] = false;
              studentScript.Prompt.Attack = false;
              if (this.Yandere.Mask != null) {
                studentScript.Prompt.HideButton[0] = true;
              }
              if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased) {
                studentScript.Prompt.HideButton[0] = true;
                studentScript.Prompt.HideButton[2] = true;
                if (this.Yandere.PickUp != null && this.Yandere.PickUp.Food > 0) {
                  studentScript.Prompt.Label[0].text = "     Feed";
                  studentScript.Prompt.HideButton[0] = false;
                  studentScript.Prompt.HideButton[2] = true;
                }
              }
              if (this.Yandere.Armed) {
                studentScript.Prompt.HideButton[0] = true;
                studentScript.Prompt.MinimumDistance = 1f;
                studentScript.Prompt.Attack = true;
              } else {
                studentScript.Prompt.HideButton[2] = true;
                studentScript.Prompt.MinimumDistance = 2f;
                if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private) {
                  studentScript.Prompt.HideButton[0] = true;
                }
              }
              if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f) {
                studentScript.Prompt.HideButton[0] = true;
              }
              if (studentScript.Teacher) {
                studentScript.Prompt.HideButton[0] = true;
              }
            } else if (this.Yandere.Armed) {
              if (this.Yandere.EquippedWeapon.Concealable) {
                studentScript.Prompt.HideButton[0] = false;
                studentScript.Prompt.Label[0].text = "     Give Weapon";
              } else {
                studentScript.Prompt.HideButton[0] = true;
                studentScript.Prompt.Label[0].text = string.Empty;
              }
            } else {
              studentScript.Prompt.HideButton[0] = true;
              studentScript.Prompt.Label[0].text = string.Empty;
            }
          }
          if (this.NoSpeech && !studentScript.Armband.activeInHierarchy) {
            studentScript.Prompt.HideButton[0] = true;
          }
        }
        if (studentScript.Prompt.Label[0] != null) {
          if (this.Sans) {
            studentScript.Prompt.HideButton[0] = false;
            studentScript.Prompt.Label[0].text = "     Psychokinesis";
          }
          if (this.Pose) {
            studentScript.Prompt.HideButton[0] = false;
            studentScript.Prompt.Label[0].text = "     Pose";
          }
          if (this.Six) {
            studentScript.Prompt.MinimumDistance = 0.75f;
            studentScript.Prompt.HideButton[0] = false;
            studentScript.Prompt.Label[0].text = "     Eat";
          }
          if (this.Gaze) {
            studentScript.Prompt.MinimumDistance = 5f;
            studentScript.Prompt.HideButton[0] = false;
            studentScript.Prompt.Label[0].text = "     Gaze";
          }
        }
      }
      this.ID++;
    }
    this.Container.UpdatePrompts();
    this.TrashCan.UpdatePrompt();
  }

  // Token: 0x060007F0 RID: 2032 RVA: 0x0007C068 File Offset: 0x0007A468
  public void UpdateMe(int ID) {
    if (ID > 1) {
      StudentScript studentScript = this.Students[ID];
      if (!studentScript.Safe) {
        studentScript.Prompt.Label[0].text = "     Talk";
        studentScript.Prompt.HideButton[0] = false;
        studentScript.Prompt.HideButton[2] = false;
        studentScript.Prompt.Attack = false;
        if (this.Yandere.Armed) {
          studentScript.Prompt.HideButton[0] = true;
          studentScript.Prompt.MinimumDistance = 1f;
          studentScript.Prompt.Attack = true;
        } else {
          studentScript.Prompt.HideButton[2] = true;
          studentScript.Prompt.MinimumDistance = 2f;
          if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private) {
            studentScript.Prompt.HideButton[0] = true;
          }
        }
        if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased) {
          studentScript.Prompt.HideButton[0] = true;
          studentScript.Prompt.HideButton[2] = true;
        }
        if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f) {
          studentScript.Prompt.HideButton[0] = true;
        }
        if (studentScript.Teacher) {
          studentScript.Prompt.HideButton[0] = true;
        }
      }
      if (this.Sans) {
        studentScript.Prompt.HideButton[0] = false;
        studentScript.Prompt.Label[0].text = "     Psychokinesis";
      }
      if (this.Pose) {
        studentScript.Prompt.HideButton[0] = false;
        studentScript.Prompt.Label[0].text = "     Pose";
      }
      if (this.NoSpeech) {
        studentScript.Prompt.HideButton[0] = true;
      }
    }
  }

  // Token: 0x060007F1 RID: 2033 RVA: 0x0007C274 File Offset: 0x0007A674
  public void AttendClass() {
    if (this.RingEvent.EventActive) {
      this.RingEvent.ReturnRing();
    }
    while (this.NPCsSpawned < this.NPCsTotal) {
      this.SpawnStudent(this.SpawnID);
      this.SpawnID++;
    }
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil && studentScript.enabled) {
        if (!studentScript.Started) {
          studentScript.Start();
        }
        if (!studentScript.Teacher) {
          if (!studentScript.Indoors) {
            if (studentScript.ShoeRemoval.Locker == null) {
              studentScript.ShoeRemoval.Start();
            }
            studentScript.ShoeRemoval.PutOnShoes();
          }
          studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
          studentScript.transform.rotation = studentScript.Seat.rotation;
          studentScript.Character.GetComponent<Animation>().Play(studentScript.SitAnim);
          studentScript.Pathfinding.canSearch = false;
          studentScript.Pathfinding.canMove = false;
          studentScript.OccultBook.SetActive(false);
          studentScript.Pathfinding.speed = 0f;
          studentScript.Phone.SetActive(false);
          studentScript.Distracted = false;
          studentScript.Pushable = false;
          studentScript.OnPhone = false;
          studentScript.Routine = true;
          studentScript.Safe = false;
          if (studentScript.Wet) {
            studentScript.Schoolwear = 3;
            studentScript.ChangeSchoolwear();
            studentScript.LiquidProjector.enabled = false;
            studentScript.Splashed = false;
            studentScript.Bloody = false;
            studentScript.BathePhase = 1;
            studentScript.Wet = false;
            studentScript.UnWet();
            if (studentScript.Rival && this.CommunalLocker.RivalPhone.Stolen) {
              studentScript.RealizePhoneIsMissing();
            }
          }
          if (studentScript.ClubAttire) {
            studentScript.ChangeSchoolwear();
            studentScript.ClubAttire = false;
          }
          if (studentScript.Meeting && this.Clock.HourTime > studentScript.MeetTime) {
            studentScript.Meeting = false;
          }
        } else if (this.ID != this.GymTeacherID && this.ID != this.NurseID) {
          studentScript.transform.position = this.Podiums.List[studentScript.Class].position + Vector3.up * 0.01f;
          studentScript.transform.rotation = this.Podiums.List[studentScript.Class].rotation;
        } else {
          studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
          studentScript.transform.rotation = studentScript.Seat.rotation;
        }
      }
      this.ID++;
    }
    this.UpdateStudents();
  }

  // Token: 0x060007F2 RID: 2034 RVA: 0x0007C5C4 File Offset: 0x0007A9C4
  public void SkipTo8() {
    while (this.NPCsSpawned < this.NPCsTotal) {
      this.SpawnStudent(this.SpawnID);
      this.SpawnID++;
    }
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil) {
        if (!studentScript.Started) {
          studentScript.Start();
        }
        if (!studentScript.Teacher) {
          if (!studentScript.Indoors) {
            if (studentScript.ShoeRemoval.Locker == null) {
              studentScript.ShoeRemoval.Start();
            }
            studentScript.ShoeRemoval.PutOnShoes();
          }
          studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
          studentScript.transform.rotation = studentScript.Seat.rotation;
          studentScript.Pathfinding.canSearch = true;
          studentScript.Pathfinding.canMove = true;
          studentScript.OccultBook.SetActive(false);
          studentScript.Pathfinding.speed = 1f;
          studentScript.Phone.SetActive(false);
          studentScript.Distracted = false;
          studentScript.OnPhone = false;
          studentScript.Routine = true;
          studentScript.Safe = false;
          if (studentScript.ClubAttire) {
            studentScript.ChangeSchoolwear();
            studentScript.ClubAttire = true;
          }
          studentScript.TeleportToDestination();
          studentScript.TeleportToDestination();
        } else {
          studentScript.TeleportToDestination();
          studentScript.TeleportToDestination();
        }
      }
      this.ID++;
    }
  }

  // Token: 0x060007F3 RID: 2035 RVA: 0x0007C790 File Offset: 0x0007AB90
  public void ResumeMovement() {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.Pathfinding.canSearch = true;
        studentScript.Pathfinding.canMove = true;
        studentScript.Pathfinding.speed = 1f;
        studentScript.Routine = true;
      }
      this.ID++;
    }
  }

  // Token: 0x060007F4 RID: 2036 RVA: 0x0007C814 File Offset: 0x0007AC14
  public void StopMoving() {
    this.Stop = true;
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        if (!studentScript.Dying && !studentScript.PinningDown && !studentScript.Spraying) {
          if (this.YandereDying && studentScript.Club != ClubType.Council) {
            studentScript.IdleAnim = studentScript.ScaredAnim;
          }
          if (this.Yandere.Attacking) {
            if (studentScript.MurderReaction == 0) {
              studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.ScaredAnim);
            }
          } else if (this.ID > 1) {
            studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.IdleAnim);
          }
          studentScript.Pathfinding.canSearch = false;
          studentScript.Pathfinding.canMove = false;
          studentScript.Pathfinding.speed = 0f;
          studentScript.Stop = true;
          if (studentScript.EventManager != null) {
            studentScript.EventManager.EndEvent();
          }
        }
        if (studentScript.Alive && studentScript.SawMask) {
          this.Police.MaskReported = true;
        }
        if (studentScript.Slave) {
          studentScript.Broken.Subtitle.text = string.Empty;
          studentScript.Broken.Done = true;
          UnityEngine.Object.Destroy(studentScript.Broken);
          studentScript.Slave = false;
          studentScript.Suicide = true;
          studentScript.BecomeRagdoll();
          studentScript.DeathType = DeathType.Mystery;
          StudentGlobals.SetStudentSlave(studentScript.StudentID, false);
        }
      }
      this.ID++;
    }
  }

  // Token: 0x060007F5 RID: 2037 RVA: 0x0007C9D8 File Offset: 0x0007ADD8
  public void StopFleeing() {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && !studentScript.Teacher) {
        studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
        studentScript.Pathfinding.speed = 1f;
        studentScript.WitnessedCorpse = false;
        studentScript.WitnessedMurder = false;
        studentScript.Alarmed = false;
        studentScript.Fleeing = false;
        studentScript.Reacted = false;
        studentScript.Witness = false;
        studentScript.Routine = true;
      }
      this.ID++;
    }
  }

  // Token: 0x060007F6 RID: 2038 RVA: 0x0007CA90 File Offset: 0x0007AE90
  public void EnablePrompts() {
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.Prompt.enabled = true;
      }
      this.ID++;
    }
  }

  // Token: 0x060007F7 RID: 2039 RVA: 0x0007CAF0 File Offset: 0x0007AEF0
  public void DisablePrompts() {
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.Prompt.Hide();
        studentScript.Prompt.enabled = false;
      }
      this.ID++;
    }
  }

  // Token: 0x060007F8 RID: 2040 RVA: 0x0007CB5C File Offset: 0x0007AF5C
  public void WipePendingRep() {
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.PendingRep = 0f;
      }
      this.ID++;
    }
  }

  // Token: 0x060007F9 RID: 2041 RVA: 0x0007CBBC File Offset: 0x0007AFBC
  public void AttackOnTitan() {
    this.AoT = true;
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && !studentScript.Teacher) {
        studentScript.AttackOnTitan();
      }
      this.ID++;
    }
  }

  // Token: 0x060007FA RID: 2042 RVA: 0x0007CC28 File Offset: 0x0007B028
  public void Kong() {
    this.DK = true;
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.DK = true;
      }
      this.ID++;
    }
  }

  // Token: 0x060007FB RID: 2043 RVA: 0x0007CC8C File Offset: 0x0007B08C
  public void Spook() {
    this.Spooky = true;
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && !studentScript.Male) {
        studentScript.Spook();
      }
      this.ID++;
    }
  }

  // Token: 0x060007FC RID: 2044 RVA: 0x0007CCF8 File Offset: 0x0007B0F8
  public void BadTime() {
    this.Sans = true;
    this.ID = 2;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.Prompt.HideButton[0] = false;
        studentScript.BadTime = true;
      }
      this.ID++;
    }
  }

  // Token: 0x060007FD RID: 2045 RVA: 0x0007CD68 File Offset: 0x0007B168
  public void UpdateBooths() {
    this.ID = 0;
    while (this.ID < this.ChangingBooths.Length) {
      ChangingBoothScript changingBoothScript = this.ChangingBooths[this.ID];
      if (changingBoothScript != null) {
        changingBoothScript.CheckYandereClub();
      }
      this.ID++;
    }
  }

  // Token: 0x060007FE RID: 2046 RVA: 0x0007CDC4 File Offset: 0x0007B1C4
  public void UpdatePerception() {
    this.ID = 0;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.UpdatePerception();
      }
      this.ID++;
    }
  }

  // Token: 0x060007FF RID: 2047 RVA: 0x0007CE20 File Offset: 0x0007B220
  public void StopHesitating() {
    this.ID = 0;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        if (studentScript.AlarmTimer > 0f) {
          studentScript.AlarmTimer = 1f;
        }
        studentScript.Hesitation = 0f;
      }
      this.ID++;
    }
  }

  // Token: 0x06000800 RID: 2048 RVA: 0x0007CE9C File Offset: 0x0007B29C
  private void Unstop() {
    this.ID = 0;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.Stop = false;
      }
      this.ID++;
    }
  }

  // Token: 0x06000801 RID: 2049 RVA: 0x0007CEF8 File Offset: 0x0007B2F8
  public void LowerCorpsePosition() {
    if (this.CorpseLocation.position.y < 4f) {
      this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 0f, this.CorpseLocation.position.z);
    } else if (this.CorpseLocation.position.y < 8f) {
      this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 4f, this.CorpseLocation.position.z);
    } else if (this.CorpseLocation.position.y < 12f) {
      this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 8f, this.CorpseLocation.position.z);
    } else {
      this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 12f, this.CorpseLocation.position.z);
    }
  }

  // Token: 0x06000802 RID: 2050 RVA: 0x0007D060 File Offset: 0x0007B460
  public void CensorStudents() {
    this.ID = 0;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && !studentScript.Male && !studentScript.Teacher) {
        if (this.Censor) {
          studentScript.Cosmetic.CensorPanties();
        } else {
          studentScript.Cosmetic.RemoveCensor();
        }
      }
      this.ID++;
    }
  }

  // Token: 0x06000803 RID: 2051 RVA: 0x0007D0F0 File Offset: 0x0007B4F0
  private void OccupySeat() {
    int @class = this.JSON.Students[this.SpawnID].Class;
    int seat = this.JSON.Students[this.SpawnID].Seat;
    if (@class == 11) {
      this.SeatsTaken11[seat] = true;
    } else if (@class == 12) {
      this.SeatsTaken12[seat] = true;
    } else if (@class == 21) {
      this.SeatsTaken21[seat] = true;
    } else if (@class == 22) {
      this.SeatsTaken22[seat] = true;
    } else if (@class == 31) {
      this.SeatsTaken31[seat] = true;
    } else if (@class == 32) {
      this.SeatsTaken32[seat] = true;
    }
  }

  // Token: 0x06000804 RID: 2052 RVA: 0x0007D1AC File Offset: 0x0007B5AC
  private void FindUnoccupiedSeat() {
    this.SeatOccupied = false;
    if (this.Class == 1) {
      this.JSON.Students[this.SpawnID].Class = 11;
      this.ID = 1;
      while (this.ID < this.SeatsTaken11.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken11[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken11[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    } else if (this.Class == 2) {
      this.JSON.Students[this.SpawnID].Class = 12;
      this.ID = 1;
      while (this.ID < this.SeatsTaken12.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken12[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken12[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    } else if (this.Class == 3) {
      this.JSON.Students[this.SpawnID].Class = 21;
      this.ID = 1;
      while (this.ID < this.SeatsTaken21.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken21[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken21[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    } else if (this.Class == 4) {
      this.JSON.Students[this.SpawnID].Class = 22;
      this.ID = 1;
      while (this.ID < this.SeatsTaken22.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken22[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken22[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    } else if (this.Class == 5) {
      this.JSON.Students[this.SpawnID].Class = 31;
      this.ID = 1;
      while (this.ID < this.SeatsTaken31.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken31[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken31[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    } else if (this.Class == 6) {
      this.JSON.Students[this.SpawnID].Class = 32;
      this.ID = 1;
      while (this.ID < this.SeatsTaken32.Length && !this.SeatOccupied) {
        if (!this.SeatsTaken32[this.ID]) {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken32[this.ID] = true;
          this.SeatOccupied = true;
        }
        this.ID++;
        if (this.ID > 15) {
          this.Class++;
        }
      }
    }
    if (!this.SeatOccupied) {
      this.FindUnoccupiedSeat();
    }
  }

  // Token: 0x06000805 RID: 2053 RVA: 0x0007D654 File Offset: 0x0007BA54
  public void PinDownCheck() {
    if (!this.PinningDown && this.Witnesses > 3) {
      this.ID = 1;
      while (this.ID < this.WitnessList.Length) {
        StudentScript studentScript = this.WitnessList[this.ID];
        if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Fleeing)) {
          if (this.ID != this.WitnessList.Length - 1) {
            this.Shuffle(this.ID);
          }
          this.Witnesses--;
        }
        this.ID++;
      }
      if (this.Witnesses > 3) {
        this.PinningDown = true;
        this.PinPhase = 1;
      }
    }
  }

  // Token: 0x06000806 RID: 2054 RVA: 0x0007D72C File Offset: 0x0007BB2C
  private void Shuffle(int Start) {
    for (int i = Start; i < this.WitnessList.Length - 1; i++) {
      this.WitnessList[i] = this.WitnessList[i + 1];
    }
  }

  // Token: 0x06000807 RID: 2055 RVA: 0x0007D768 File Offset: 0x0007BB68
  public void ChangeOka() {
    StudentScript studentScript = this.Students[26];
    if (studentScript != null) {
      studentScript.AttachRiggedAccessory();
    }
  }

  // Token: 0x06000808 RID: 2056 RVA: 0x0007D794 File Offset: 0x0007BB94
  public void RemovePapersFromDesks() {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null && studentScript.MyPaper != null) {
        studentScript.MyPaper.SetActive(false);
      }
      this.ID++;
    }
  }

  // Token: 0x06000809 RID: 2057 RVA: 0x0007D808 File Offset: 0x0007BC08
  public void SetStudentsActive(bool active) {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.gameObject.SetActive(active);
      }
      this.ID++;
    }
  }

  // Token: 0x0600080A RID: 2058 RVA: 0x0007D868 File Offset: 0x0007BC68
  public void AssignTeachers() {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.MyTeacher = this.Teachers[this.JSON.Students[studentScript.StudentID].Class];
      }
      this.ID++;
    }
  }

  // Token: 0x0600080B RID: 2059 RVA: 0x0007D8E0 File Offset: 0x0007BCE0
  public void ToggleBookBags() {
    this.ID = 1;
    while (this.ID < this.Students.Length) {
      StudentScript studentScript = this.Students[this.ID];
      if (studentScript != null) {
        studentScript.BookBag.SetActive(!studentScript.BookBag.activeInHierarchy);
      }
      this.ID++;
    }
  }

  // Token: 0x0400146E RID: 5230
  private PortraitChanScript NewPortraitChan;

  // Token: 0x0400146F RID: 5231
  private GameObject NewStudent;

  // Token: 0x04001470 RID: 5232
  public StudentScript[] Students;

  // Token: 0x04001471 RID: 5233
  public SelectiveGrayscale SmartphoneSelectiveGreyscale;

  // Token: 0x04001472 RID: 5234
  public PickpocketMinigameScript PickpocketMinigame;

  // Token: 0x04001473 RID: 5235
  public SelectiveGrayscale HandSelectiveGreyscale;

  // Token: 0x04001474 RID: 5236
  public CleaningManagerScript CleaningManager;

  // Token: 0x04001475 RID: 5237
  public StolenPhoneSpotScript StolenPhoneSpot;

  // Token: 0x04001476 RID: 5238
  public SelectiveGrayscale SelectiveGreyscale;

  // Token: 0x04001477 RID: 5239
  public DatingMinigameScript DatingMinigame;

  // Token: 0x04001478 RID: 5240
  public TextureManagerScript TextureManager;

  // Token: 0x04001479 RID: 5241
  public QualityManagerScript QualityManager;

  // Token: 0x0400147A RID: 5242
  public ParticleSystem FemaleDrownSplashes;

  // Token: 0x0400147B RID: 5243
  public ComputerGamesScript ComputerGames;

  // Token: 0x0400147C RID: 5244
  public EmergencyExitScript EmergencyExit;

  // Token: 0x0400147D RID: 5245
  public TranqDetectorScript TranqDetector;

  // Token: 0x0400147E RID: 5246
  public WitnessCameraScript WitnessCamera;

  // Token: 0x0400147F RID: 5247
  public ConvoManagerScript ConvoManager;

  // Token: 0x04001480 RID: 5248
  public TallLockerScript CommunalLocker;

  // Token: 0x04001481 RID: 5249
  public CabinetDoorScript CabinetDoor;

  // Token: 0x04001482 RID: 5250
  public LightSwitchScript LightSwitch;

  // Token: 0x04001483 RID: 5251
  public LoveManagerScript LoveManager;

  // Token: 0x04001484 RID: 5252
  public TaskManagerScript TaskManager;

  // Token: 0x04001485 RID: 5253
  public ReputationScript Reputation;

  // Token: 0x04001486 RID: 5254
  public DoorScript FemaleVomitDoor;

  // Token: 0x04001487 RID: 5255
  public ContainerScript Container;

  // Token: 0x04001488 RID: 5256
  public OfferHelpScript OfferHelp;

  // Token: 0x04001489 RID: 5257
  public RingEventScript RingEvent;

  // Token: 0x0400148A RID: 5258
  public FountainScript Fountain;

  // Token: 0x0400148B RID: 5259
  public PoseModeScript PoseMode;

  // Token: 0x0400148C RID: 5260
  public TrashCanScript TrashCan;

  // Token: 0x0400148D RID: 5261
  public StudentScript Reporter;

  // Token: 0x0400148E RID: 5262
  public GhostScript GhostChan;

  // Token: 0x0400148F RID: 5263
  public YandereScript Yandere;

  // Token: 0x04001490 RID: 5264
  public ListScript MeetSpots;

  // Token: 0x04001491 RID: 5265
  public PoliceScript Police;

  // Token: 0x04001492 RID: 5266
  public DoorScript ShedDoor;

  // Token: 0x04001493 RID: 5267
  public UILabel ErrorLabel;

  // Token: 0x04001494 RID: 5268
  public ListScript SearchPatrols;

  // Token: 0x04001495 RID: 5269
  public ListScript CleaningSpots;

  // Token: 0x04001496 RID: 5270
  public ListScript Patrols;

  // Token: 0x04001497 RID: 5271
  public ClockScript Clock;

  // Token: 0x04001498 RID: 5272
  public JsonScript JSON;

  // Token: 0x04001499 RID: 5273
  public GateScript Gate;

  // Token: 0x0400149A RID: 5274
  public ListScript EntranceVectors;

  // Token: 0x0400149B RID: 5275
  public ListScript GoAwaySpots;

  // Token: 0x0400149C RID: 5276
  public ListScript HidingSpots;

  // Token: 0x0400149D RID: 5277
  public ListScript LunchSpots;

  // Token: 0x0400149E RID: 5278
  public ListScript Hangouts;

  // Token: 0x0400149F RID: 5279
  public ListScript Lockers;

  // Token: 0x040014A0 RID: 5280
  public ListScript Podiums;

  // Token: 0x040014A1 RID: 5281
  public ListScript Clubs;

  // Token: 0x040014A2 RID: 5282
  public ChangingBoothScript[] ChangingBooths;

  // Token: 0x040014A3 RID: 5283
  public GradingPaperScript[] FacultyDesks;

  // Token: 0x040014A4 RID: 5284
  public Transform[] CorpseGuardLocation;

  // Token: 0x040014A5 RID: 5285
  public Transform[] LockerPositions;

  // Token: 0x040014A6 RID: 5286
  public StudentScript[] WitnessList;

  // Token: 0x040014A7 RID: 5287
  public Transform[] SpawnPositions;

  // Token: 0x040014A8 RID: 5288
  public Transform[] PinDownSpots;

  // Token: 0x040014A9 RID: 5289
  public StudentScript[] Teachers;

  // Token: 0x040014AA RID: 5290
  public ListScript[] Seats;

  // Token: 0x040014AB RID: 5291
  public bool[] SeatsTaken11;

  // Token: 0x040014AC RID: 5292
  public bool[] SeatsTaken12;

  // Token: 0x040014AD RID: 5293
  public bool[] SeatsTaken21;

  // Token: 0x040014AE RID: 5294
  public bool[] SeatsTaken22;

  // Token: 0x040014AF RID: 5295
  public bool[] SeatsTaken31;

  // Token: 0x040014B0 RID: 5296
  public bool[] SeatsTaken32;

  // Token: 0x040014B1 RID: 5297
  public Collider RivalDeskCollider;

  // Token: 0x040014B2 RID: 5298
  public Transform FollowerLookAtTarget;

  // Token: 0x040014B3 RID: 5299
  public Transform SuitorConfessionSpot;

  // Token: 0x040014B4 RID: 5300
  public Transform RivalConfessionSpot;

  // Token: 0x040014B5 RID: 5301
  public Transform ConfessionWaypoint;

  // Token: 0x040014B6 RID: 5302
  public Transform FemaleCoupleSpot;

  // Token: 0x040014B7 RID: 5303
  public Transform FemaleStalkSpot;

  // Token: 0x040014B8 RID: 5304
  public Transform FemaleVomitSpot;

  // Token: 0x040014B9 RID: 5305
  public Transform ConfessionSpot;

  // Token: 0x040014BA RID: 5306
  public Transform CorpseLocation;

  // Token: 0x040014BB RID: 5307
  public Transform FemaleWashSpot;

  // Token: 0x040014BC RID: 5308
  public Transform MaleCoupleSpot;

  // Token: 0x040014BD RID: 5309
  public Transform FastBatheSpot;

  // Token: 0x040014BE RID: 5310
  public Transform MaleStalkSpot;

  // Token: 0x040014BF RID: 5311
  public Transform MaleVomitSpot;

  // Token: 0x040014C0 RID: 5312
  public Transform SacrificeSpot;

  // Token: 0x040014C1 RID: 5313
  public Transform FountainSpot;

  // Token: 0x040014C2 RID: 5314
  public Transform MaleWashSpot;

  // Token: 0x040014C3 RID: 5315
  public Transform SenpaiLocker;

  // Token: 0x040014C4 RID: 5316
  public Transform SuitorLocker;

  // Token: 0x040014C5 RID: 5317
  public Transform RomanceSpot;

  // Token: 0x040014C6 RID: 5318
  public Transform BrokenSpot;

  // Token: 0x040014C7 RID: 5319
  public Transform EdgeOfGrid;

  // Token: 0x040014C8 RID: 5320
  public Transform GoAwaySpot;

  // Token: 0x040014C9 RID: 5321
  public Transform SuitorSpot;

  // Token: 0x040014CA RID: 5322
  public Transform BatheSpot;

  // Token: 0x040014CB RID: 5323
  public Transform MournSpot;

  // Token: 0x040014CC RID: 5324
  public Transform ShameSpot;

  // Token: 0x040014CD RID: 5325
  public Transform SlaveSpot;

  // Token: 0x040014CE RID: 5326
  public Transform StripSpot;

  // Token: 0x040014CF RID: 5327
  public Transform Papers;

  // Token: 0x040014D0 RID: 5328
  public Transform Exit;

  // Token: 0x040014D1 RID: 5329
  public GameObject LovestruckCamera;

  // Token: 0x040014D2 RID: 5330
  public GameObject PortraitChan;

  // Token: 0x040014D3 RID: 5331
  public GameObject RandomPatrol;

  // Token: 0x040014D4 RID: 5332
  public GameObject EmptyObject;

  // Token: 0x040014D5 RID: 5333
  public GameObject PortraitKun;

  // Token: 0x040014D6 RID: 5334
  public GameObject StudentChan;

  // Token: 0x040014D7 RID: 5335
  public GameObject StudentKun;

  // Token: 0x040014D8 RID: 5336
  public GameObject Portal;

  // Token: 0x040014D9 RID: 5337
  public float[] SpawnTimes;

  // Token: 0x040014DA RID: 5338
  public int LowDetailThreshold;

  // Token: 0x040014DB RID: 5339
  public int StudentsSpawned;

  // Token: 0x040014DC RID: 5340
  public int StudentsTotal = 13;

  // Token: 0x040014DD RID: 5341
  public int TeachersTotal = 6;

  // Token: 0x040014DE RID: 5342
  public int NPCsSpawned;

  // Token: 0x040014DF RID: 5343
  public int NPCsTotal;

  // Token: 0x040014E0 RID: 5344
  public int Witnesses;

  // Token: 0x040014E1 RID: 5345
  public int PinPhase;

  // Token: 0x040014E2 RID: 5346
  public int Frame;

  // Token: 0x040014E3 RID: 5347
  public int GymTeacherID = 100;

  // Token: 0x040014E4 RID: 5348
  public int SuitorID = 13;

  // Token: 0x040014E5 RID: 5349
  public int NurseID = 93;

  // Token: 0x040014E6 RID: 5350
  public int RivalID = 7;

  // Token: 0x040014E7 RID: 5351
  public int SpawnID;

  // Token: 0x040014E8 RID: 5352
  public int ID;

  // Token: 0x040014E9 RID: 5353
  public bool MurderTakingPlace;

  // Token: 0x040014EA RID: 5354
  public bool TakingPortraits;

  // Token: 0x040014EB RID: 5355
  public bool TeachersSpawned;

  // Token: 0x040014EC RID: 5356
  public bool DisableFarAnims;

  // Token: 0x040014ED RID: 5357
  public bool YandereDying;

  // Token: 0x040014EE RID: 5358
  public bool YandereLate;

  // Token: 0x040014EF RID: 5359
  public bool FirstUpdate;

  // Token: 0x040014F0 RID: 5360
  public bool MissionMode;

  // Token: 0x040014F1 RID: 5361
  public bool PinningDown;

  // Token: 0x040014F2 RID: 5362
  public bool ForceSpawn;

  // Token: 0x040014F3 RID: 5363
  public bool NoGravity;

  // Token: 0x040014F4 RID: 5364
  public bool Randomize;

  // Token: 0x040014F5 RID: 5365
  public bool NoSpeech;

  // Token: 0x040014F6 RID: 5366
  public bool Censor;

  // Token: 0x040014F7 RID: 5367
  public bool Spooky;

  // Token: 0x040014F8 RID: 5368
  public bool Gaze;

  // Token: 0x040014F9 RID: 5369
  public bool Pose;

  // Token: 0x040014FA RID: 5370
  public bool Sans;

  // Token: 0x040014FB RID: 5371
  public bool Stop;

  // Token: 0x040014FC RID: 5372
  public bool Six;

  // Token: 0x040014FD RID: 5373
  public bool AoT;

  // Token: 0x040014FE RID: 5374
  public bool DK;

  // Token: 0x040014FF RID: 5375
  public float ChangeTimer;

  // Token: 0x04001500 RID: 5376
  public float PinTimer;

  // Token: 0x04001501 RID: 5377
  public float Timer;

  // Token: 0x04001502 RID: 5378
  public string[] ColorNames;

  // Token: 0x04001503 RID: 5379
  public string[] MaleNames;

  // Token: 0x04001504 RID: 5380
  public string[] FirstNames;

  // Token: 0x04001505 RID: 5381
  public string[] LastNames;

  // Token: 0x04001506 RID: 5382
  public AudioClip YanderePinDown;

  // Token: 0x04001507 RID: 5383
  public AudioClip PinDownSFX;

  // Token: 0x04001508 RID: 5384
  [SerializeField]
  private int ProblemID = -1;

  // Token: 0x04001509 RID: 5385
  public bool SeatOccupied;

  // Token: 0x0400150A RID: 5386
  public int Class = 1;
}