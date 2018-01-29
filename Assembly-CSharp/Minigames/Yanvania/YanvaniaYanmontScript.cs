using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000239 RID: 569
[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour {

  // Token: 0x060009FF RID: 2559 RVA: 0x000B6CF0 File Offset: 0x000B50F0
  private void Awake() {
    Animation component = this.Character.GetComponent<Animation>();
    component["f02_yanvaniaDeath_00"].speed = 0.25f;
    component["f02_yanvaniaAttack_00"].speed = 2f;
    component["f02_yanvaniaCrouchAttack_00"].speed = 2f;
    component["f02_yanvaniaWalk_00"].speed = 0.6666667f;
    component["f02_yanvaniaWhip_Neutral"].speed = 0f;
    component["f02_yanvaniaWhip_Up"].speed = 0f;
    component["f02_yanvaniaWhip_Right"].speed = 0f;
    component["f02_yanvaniaWhip_Down"].speed = 0f;
    component["f02_yanvaniaWhip_Left"].speed = 0f;
    component["f02_yanvaniaCrouchPose_00"].layer = 1;
    component.Play("f02_yanvaniaCrouchPose_00");
    component["f02_yanvaniaCrouchPose_00"].weight = 0f;
    Physics.IgnoreLayerCollision(19, 13, true);
    Physics.IgnoreLayerCollision(19, 19, true);
  }

  // Token: 0x06000A00 RID: 2560 RVA: 0x000B6E0C File Offset: 0x000B520C
  private void Start() {
    this.WhipChain[0].transform.localScale = Vector3.zero;
    this.Character.GetComponent<Animation>().Play("f02_yanvaniaIdle_00");
    this.controller = base.GetComponent<CharacterController>();
    this.myTransform = base.transform;
    this.speed = this.walkSpeed;
    this.rayDistance = this.controller.height * 0.5f + this.controller.radius;
    this.slideLimit = this.controller.slopeLimit - 0.1f;
    this.jumpTimer = this.antiBunnyHopFactor;
    this.originalThreshold = this.fallingDamageThreshold;
  }

  // Token: 0x06000A01 RID: 2561 RVA: 0x000B6EBC File Offset: 0x000B52BC
  private void FixedUpdate() {
    Animation component = this.Character.GetComponent<Animation>();
    if (this.CanMove) {
      if (!this.Injured) {
        if (!this.Cutscene) {
          if (this.grounded) {
            if (!this.Attacking) {
              if (!this.Crouching) {
                if (Input.GetAxis("VaniaHorizontal") > 0f) {
                  this.inputX = 1f;
                } else if (Input.GetAxis("VaniaHorizontal") < 0f) {
                  this.inputX = -1f;
                } else {
                  this.inputX = 0f;
                }
              }
            } else if (this.grounded) {
              this.fallingDamageThreshold = 100f;
              this.moveDirection.x = 0f;
              this.inputX = 0f;
              this.speed = 0f;
            }
          } else if (Input.GetAxis("VaniaHorizontal") != 0f) {
            if (Input.GetAxis("VaniaHorizontal") > 0f) {
              this.inputX = 1f;
            } else if (Input.GetAxis("VaniaHorizontal") < 0f) {
              this.inputX = -1f;
            } else {
              this.inputX = 0f;
            }
          } else {
            this.inputX = Mathf.MoveTowards(this.inputX, 0f, Time.deltaTime * 10f);
          }
          float num = 0f;
          float num2 = (this.inputX == 0f || num == 0f || !this.limitDiagonalSpeed) ? 1f : 0.707106769f;
          if (!this.Attacking) {
            if (Input.GetAxis("VaniaHorizontal") < 0f) {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
            } else if (Input.GetAxis("VaniaHorizontal") > 0f) {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
            }
          }
          if (this.grounded) {
            if (!this.Attacking && !this.Dangling) {
              if (Input.GetAxis("VaniaVertical") < -0.5f) {
                this.MyController.center = new Vector3(this.MyController.center.x, 0.5f, this.MyController.center.z);
                this.MyController.height = 1f;
                this.Crouching = true;
                this.IdleTimer = 10f;
                this.inputX = 0f;
              }
              if (this.Crouching) {
                component.CrossFade("f02_yanvaniaCrouch_00", 0.1f);
                if (!this.Attacking) {
                  if (!this.Dangling) {
                    if (Input.GetAxis("VaniaVertical") > -0.5f) {
                      component["f02_yanvaniaCrouchPose_00"].weight = 0f;
                      this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
                      this.MyController.height = 1.5f;
                      this.Crouching = false;
                    }
                  } else if (Input.GetAxis("VaniaVertical") > -0.5f && Input.GetButton("X")) {
                    component["f02_yanvaniaCrouchPose_00"].weight = 0f;
                    this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
                    this.MyController.height = 1.5f;
                    this.Crouching = false;
                  }
                }
              } else if (this.inputX == 0f) {
                if (this.IdleTimer > 0f) {
                  component.CrossFade("f02_yanvaniaIdle_00", 0.1f);
                  component["f02_yanvaniaIdle_00"].speed = this.IdleTimer / 10f;
                } else {
                  component.CrossFade("f02_yanvaniaDramaticIdle_00", 1f);
                }
                this.IdleTimer -= Time.deltaTime;
              } else {
                this.IdleTimer = 10f;
                component.CrossFade((this.speed != this.walkSpeed) ? "f02_yanvaniaRun_00" : "f02_yanvaniaWalk_00", 0.1f);
              }
            }
            bool flag = false;
            if (Physics.Raycast(this.myTransform.position, -Vector3.up, out this.hit, this.rayDistance)) {
              if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit) {
                flag = true;
              }
            } else {
              Physics.Raycast(this.contactPoint + Vector3.up, -Vector3.up, out this.hit);
              if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit) {
                flag = true;
              }
            }
            if (this.falling) {
              this.falling = false;
              if (this.myTransform.position.y < this.fallStartLevel - this.fallingDamageThreshold) {
                this.FallingDamageAlert(this.fallStartLevel - this.myTransform.position.y);
              }
              this.fallingDamageThreshold = this.originalThreshold;
            }
            if (!this.toggleRun) {
              this.speed = ((!Input.GetKey(KeyCode.LeftShift)) ? this.walkSpeed : this.runSpeed);
            }
            if ((flag && this.slideWhenOverSlopeLimit) || (this.slideOnTaggedObjects && this.hit.collider.tag == "Slide")) {
              Vector3 normal = this.hit.normal;
              this.moveDirection = new Vector3(normal.x, -normal.y, normal.z);
              Vector3.OrthoNormalize(ref normal, ref this.moveDirection);
              this.moveDirection *= this.slideSpeed;
              this.playerControl = false;
            } else {
              this.moveDirection = new Vector3(this.inputX * num2, -this.antiBumpFactor, num * num2);
              this.moveDirection = this.myTransform.TransformDirection(this.moveDirection) * this.speed;
              this.playerControl = true;
            }
            if (!Input.GetButton("VaniaJump")) {
              this.jumpTimer++;
            } else if (this.jumpTimer >= this.antiBunnyHopFactor && !this.Attacking) {
              this.Crouching = false;
              this.fallingDamageThreshold = 0f;
              this.moveDirection.y = this.jumpSpeed;
              this.IdleTimer = 10f;
              this.jumpTimer = 0;
              AudioSource component2 = base.GetComponent<AudioSource>();
              component2.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
              component2.Play();
            }
          } else {
            if (!this.Attacking) {
              component.CrossFade((base.transform.position.y <= this.PreviousY) ? "f02_yanvaniaFall_00" : "f02_yanvaniaJump_00", 0.4f);
            }
            this.PreviousY = base.transform.position.y;
            if (!this.falling) {
              this.falling = true;
              this.fallStartLevel = this.myTransform.position.y;
            }
            if (this.airControl && this.playerControl) {
              this.moveDirection.x = this.inputX * this.speed * num2;
              this.moveDirection.z = num * this.speed * num2;
              this.moveDirection = this.myTransform.TransformDirection(this.moveDirection);
            }
          }
        } else {
          this.moveDirection.x = 0f;
          if (this.grounded) {
            if (base.transform.position.x > -34f) {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
              component.CrossFade("f02_yanvaniaWalk_00");
            } else if (base.transform.position.x < -34f) {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
              component.CrossFade("f02_yanvaniaWalk_00");
            } else {
              component.CrossFade("f02_yanvaniaDramaticIdle_00", 1f);
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              this.WhipChain[0].transform.localScale = Vector3.zero;
              this.fallingDamageThreshold = 100f;
              this.TextBox.SetActive(true);
              this.Attacking = false;
              base.enabled = false;
            }
          }
        }
      } else {
        component.CrossFade("f02_damage_25");
        this.RecoveryTimer += Time.deltaTime;
        if (this.RecoveryTimer > 1f) {
          this.RecoveryTimer = 0f;
          this.Injured = false;
        }
      }
      this.moveDirection.y = this.moveDirection.y - this.gravity * Time.deltaTime;
      this.grounded = ((this.controller.Move(this.moveDirection * Time.deltaTime) & CollisionFlags.Below) != CollisionFlags.None);
      if (this.grounded && this.EnterCutscene) {
        this.YanvaniaCamera.Cutscene = true;
        this.Cutscene = true;
      }
      if ((this.controller.collisionFlags & CollisionFlags.Above) != CollisionFlags.None && this.moveDirection.y > 0f) {
        this.moveDirection.y = 0f;
      }
    } else if (this.Health == 0f) {
      this.DeathTimer += Time.deltaTime;
      if (this.DeathTimer > 5f) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 0.2f);
        if (this.Darkness.color.a >= 1f) {
          if (this.Darkness.gameObject.activeInHierarchy) {
            this.HealthBar.parent.gameObject.SetActive(false);
            this.EXPBar.parent.gameObject.SetActive(false);
            this.Darkness.gameObject.SetActive(false);
            this.BossHealthBar.SetActive(false);
            this.BlackBG.SetActive(true);
          }
          this.TryAgainWindow.transform.localScale = Vector3.Lerp(this.TryAgainWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
      }
    }
  }

  // Token: 0x06000A02 RID: 2562 RVA: 0x000B7DC0 File Offset: 0x000B61C0
  private void Update() {
    Animation component = this.Character.GetComponent<Animation>();
    if (!this.Injured && this.CanMove && !this.Cutscene) {
      if (this.grounded) {
        if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
          this.TapTimer = 0.25f;
          this.Taps++;
        }
        if (this.Taps > 1) {
          this.speed = this.runSpeed;
        }
      }
      if (this.inputX == 0f) {
        this.speed = this.walkSpeed;
      }
      this.TapTimer -= Time.deltaTime;
      if (this.TapTimer < 0f) {
        this.Taps = 0;
      }
      if (Input.GetButtonDown("VaniaAttack") && !this.Attacking) {
        AudioSource.PlayClipAtPoint(this.WhipSound, base.transform.position);
        AudioSource component2 = base.GetComponent<AudioSource>();
        component2.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
        component2.Play();
        this.WhipChain[0].transform.localScale = Vector3.zero;
        this.Attacking = true;
        this.IdleTimer = 10f;
        if (this.Crouching) {
          component["f02_yanvaniaCrouchAttack_00"].time = 0f;
          component.Play("f02_yanvaniaCrouchAttack_00");
        } else {
          component["f02_yanvaniaAttack_00"].time = 0f;
          component.Play("f02_yanvaniaAttack_00");
        }
        if (this.grounded) {
          this.moveDirection.x = 0f;
          this.inputX = 0f;
          this.speed = 0f;
        }
      }
      if (this.Attacking) {
        if (!this.Dangling) {
          this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
          this.StraightenWhip();
        } else {
          for (int i = 1; i < this.WhipChain.Length; i++) {
            this.WhipCollider[i].enabled = false;
          }
          if (Input.GetAxis("VaniaHorizontal") > -0.5f && Input.GetAxis("VaniaHorizontal") < 0.5f && Input.GetAxis("VaniaVertical") > -0.5f && Input.GetAxis("VaniaVertical") < 0.5f) {
            component.CrossFade("f02_yanvaniaWhip_Neutral");
            if (this.Crouching) {
              component["f02_yanvaniaCrouchPose_00"].weight = 1f;
            }
            this.SpunUp = false;
            this.SpunDown = false;
            this.SpunRight = false;
            this.SpunLeft = false;
          } else {
            if (Input.GetAxis("VaniaVertical") > 0.5f) {
              if (!this.SpunUp) {
                AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
                this.StraightenWhip();
                this.TargetRotation = -360f;
                this.Rotation = 0f;
                this.SpunUp = true;
              }
              component.CrossFade("f02_yanvaniaWhip_Up", 0.1f);
            } else {
              this.SpunUp = false;
            }
            if (Input.GetAxis("VaniaVertical") < -0.5f) {
              if (!this.SpunDown) {
                AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
                this.StraightenWhip();
                this.TargetRotation = 360f;
                this.Rotation = 0f;
                this.SpunDown = true;
              }
              component.CrossFade("f02_yanvaniaWhip_Down", 0.1f);
            } else {
              this.SpunDown = false;
            }
            if (Input.GetAxis("VaniaHorizontal") > 0.5f) {
              if (this.Character.transform.localScale.x == 1f) {
                this.SpinRight();
              } else {
                this.SpinLeft();
              }
            } else if (this.Character.transform.localScale.x == 1f) {
              this.SpunRight = false;
            } else {
              this.SpunLeft = false;
            }
            if (Input.GetAxis("VaniaHorizontal") < -0.5f) {
              if (this.Character.transform.localScale.x == 1f) {
                this.SpinLeft();
              } else {
                this.SpinRight();
              }
            } else if (this.Character.transform.localScale.x == 1f) {
              this.SpunLeft = false;
            } else {
              this.SpunRight = false;
            }
          }
          this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 3600f * 0.5f);
          this.WhipChain[1].transform.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
          if (!Input.GetButton("VaniaAttack")) {
            this.StopAttacking();
          }
        }
      } else {
        this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      if ((!this.Crouching && component["f02_yanvaniaAttack_00"].time >= component["f02_yanvaniaAttack_00"].length) || (this.Crouching && component["f02_yanvaniaCrouchAttack_00"].time >= component["f02_yanvaniaCrouchAttack_00"].length)) {
        if (Input.GetButton("VaniaAttack")) {
          if (this.Crouching) {
            component["f02_yanvaniaCrouchPose_00"].weight = 1f;
          }
          this.Dangling = true;
        } else {
          this.StopAttacking();
        }
      }
    }
    if (this.FlashTimer > 0f) {
      this.FlashTimer -= Time.deltaTime;
      if (!this.Red) {
        foreach (Material material in this.MyRenderer.materials) {
          material.color = new Color(1f, 0f, 0f, 1f);
        }
        this.Frames++;
        if (this.Frames == 5) {
          this.Frames = 0;
          this.Red = true;
        }
      } else {
        foreach (Material material2 in this.MyRenderer.materials) {
          material2.color = new Color(1f, 1f, 1f, 1f);
        }
        this.Frames++;
        if (this.Frames == 5) {
          this.Frames = 0;
          this.Red = false;
        }
      }
    } else {
      this.FlashTimer = 0f;
      if (this.MyRenderer.materials[0].color != new Color(1f, 1f, 1f, 1f)) {
        foreach (Material material3 in this.MyRenderer.materials) {
          material3.color = new Color(1f, 1f, 1f, 1f);
        }
      }
    }
    this.HealthBar.localScale = new Vector3(this.HealthBar.localScale.x, Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * 10f), this.HealthBar.localScale.z);
    if (this.Health > 0f) {
      if (this.EXP >= 100f) {
        this.Level++;
        if (this.Level >= 99) {
          this.Level = 99;
        } else {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LevelUpEffect, this.LevelLabel.transform.position, Quaternion.identity);
          gameObject.transform.parent = this.LevelLabel.transform;
          this.MaxHealth += 20f;
          this.Health = this.MaxHealth;
          this.EXP -= 100f;
        }
        this.LevelLabel.text = this.Level.ToString();
      }
      this.EXPBar.localScale = new Vector3(this.EXPBar.localScale.x, Mathf.Lerp(this.EXPBar.localScale.y, this.EXP / 100f, Time.deltaTime * 10f), this.EXPBar.localScale.z);
    }
    base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
    if (Input.GetKeyDown(KeyCode.BackQuote)) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      base.transform.position = new Vector3(-31.75f, 6.51f, 0f);
    }
    if (Input.GetKeyDown(KeyCode.Alpha5)) {
      this.Level = 5;
      this.LevelLabel.text = this.Level.ToString();
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      Time.timeScale += 10f;
    }
    if (Input.GetKeyDown(KeyCode.Minus)) {
      Time.timeScale -= 10f;
      if (Time.timeScale < 0f) {
        Time.timeScale = 1f;
      }
    }
  }

  // Token: 0x06000A03 RID: 2563 RVA: 0x000B886C File Offset: 0x000B6C6C
  private void LateUpdate() {
  }

  // Token: 0x06000A04 RID: 2564 RVA: 0x000B886E File Offset: 0x000B6C6E
  private void OnControllerColliderHit(ControllerColliderHit hit) {
    this.contactPoint = this.hit.point;
  }

  // Token: 0x06000A05 RID: 2565 RVA: 0x000B8884 File Offset: 0x000B6C84
  private void FallingDamageAlert(float fallDistance) {
    AudioClipPlayer.Play2D(this.LandSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
    this.Character.GetComponent<Animation>().Play("f02_yanvaniaCrouch_00");
    this.fallingDamageThreshold = this.originalThreshold;
  }

  // Token: 0x06000A06 RID: 2566 RVA: 0x000B88D8 File Offset: 0x000B6CD8
  private void SpinRight() {
    if (!this.SpunRight) {
      AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
      this.StraightenWhip();
      this.TargetRotation = 360f;
      this.Rotation = 0f;
      this.SpunRight = true;
    }
    this.Character.GetComponent<Animation>().CrossFade("f02_yanvaniaWhip_Right", 0.1f);
  }

  // Token: 0x06000A07 RID: 2567 RVA: 0x000B8954 File Offset: 0x000B6D54
  private void SpinLeft() {
    if (!this.SpunLeft) {
      AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
      this.StraightenWhip();
      this.TargetRotation = -360f;
      this.Rotation = 0f;
      this.SpunLeft = true;
    }
    this.Character.GetComponent<Animation>().CrossFade("f02_yanvaniaWhip_Left", 0.1f);
  }

  // Token: 0x06000A08 RID: 2568 RVA: 0x000B89D0 File Offset: 0x000B6DD0
  private void StraightenWhip() {
    for (int i = 1; i < this.WhipChain.Length; i++) {
      this.WhipCollider[i].enabled = true;
      Transform transform = this.WhipChain[i].transform;
      transform.localPosition = new Vector3(0f, -0.03f, 0f);
      transform.localEulerAngles = Vector3.zero;
    }
    this.WhipChain[1].transform.localPosition = new Vector3(0f, -0.1f, 0f);
  }

  // Token: 0x06000A09 RID: 2569 RVA: 0x000B8A60 File Offset: 0x000B6E60
  private void StopAttacking() {
    this.Character.GetComponent<Animation>()["f02_yanvaniaCrouchPose_00"].weight = 0f;
    this.TargetRotation = 0f;
    this.Rotation = 0f;
    this.Attacking = false;
    this.Dangling = false;
    this.SpunUp = false;
    this.SpunDown = false;
    this.SpunRight = false;
    this.SpunLeft = false;
  }

  // Token: 0x06000A0A RID: 2570 RVA: 0x000B8ACC File Offset: 0x000B6ECC
  public void TakeDamage(int Damage) {
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.Injuries[UnityEngine.Random.Range(0, this.Injuries.Length)];
    component.Play();
    this.WhipChain[0].transform.localScale = Vector3.zero;
    Animation component2 = this.Character.GetComponent<Animation>();
    component2["f02_damage_25"].time = 0f;
    this.fallingDamageThreshold = 100f;
    this.moveDirection.x = 0f;
    this.RecoveryTimer = 0f;
    this.FlashTimer = 2f;
    this.Injured = true;
    this.StopAttacking();
    this.Health -= (float)Damage;
    if (this.Dracula.Health <= 0f) {
      this.Health = 1f;
    }
    if (this.Dracula.Health > 0f && this.Health <= 0f) {
      if (this.NewBlood == null) {
        this.MyController.enabled = false;
        this.YanvaniaCamera.StopMusic = true;
        component.clip = this.DeathSound;
        component.Play();
        this.NewBlood = UnityEngine.Object.Instantiate<GameObject>(this.DeathBlood, base.transform.position, Quaternion.identity);
        this.NewBlood.transform.parent = this.Hips;
        this.NewBlood.transform.localPosition = Vector3.zero;
        component2.CrossFade("f02_yanvaniaDeath_00");
        this.CanMove = false;
      }
      this.Health = 0f;
    }
  }

  // Token: 0x04001E2E RID: 7726
  private GameObject NewBlood;

  // Token: 0x04001E2F RID: 7727
  public YanvaniaCameraScript YanvaniaCamera;

  // Token: 0x04001E30 RID: 7728
  public InputManagerScript InputManager;

  // Token: 0x04001E31 RID: 7729
  public YanvaniaDraculaScript Dracula;

  // Token: 0x04001E32 RID: 7730
  public CharacterController MyController;

  // Token: 0x04001E33 RID: 7731
  public GameObject BossHealthBar;

  // Token: 0x04001E34 RID: 7732
  public GameObject LevelUpEffect;

  // Token: 0x04001E35 RID: 7733
  public GameObject DeathBlood;

  // Token: 0x04001E36 RID: 7734
  public GameObject Character;

  // Token: 0x04001E37 RID: 7735
  public GameObject BlackBG;

  // Token: 0x04001E38 RID: 7736
  public GameObject TextBox;

  // Token: 0x04001E39 RID: 7737
  public Renderer MyRenderer;

  // Token: 0x04001E3A RID: 7738
  public Transform TryAgainWindow;

  // Token: 0x04001E3B RID: 7739
  public Transform HealthBar;

  // Token: 0x04001E3C RID: 7740
  public Transform EXPBar;

  // Token: 0x04001E3D RID: 7741
  public Transform Hips;

  // Token: 0x04001E3E RID: 7742
  public Transform TrailStart;

  // Token: 0x04001E3F RID: 7743
  public Transform TrailEnd;

  // Token: 0x04001E40 RID: 7744
  public UITexture Photograph;

  // Token: 0x04001E41 RID: 7745
  public UILabel LevelLabel;

  // Token: 0x04001E42 RID: 7746
  public UISprite Darkness;

  // Token: 0x04001E43 RID: 7747
  public Collider[] WhipCollider;

  // Token: 0x04001E44 RID: 7748
  public Transform[] WhipChain;

  // Token: 0x04001E45 RID: 7749
  public AudioClip[] Voices;

  // Token: 0x04001E46 RID: 7750
  public AudioClip[] Injuries;

  // Token: 0x04001E47 RID: 7751
  public AudioClip DeathSound;

  // Token: 0x04001E48 RID: 7752
  public AudioClip LandSound;

  // Token: 0x04001E49 RID: 7753
  public AudioClip WhipSound;

  // Token: 0x04001E4A RID: 7754
  public bool Attacking;

  // Token: 0x04001E4B RID: 7755
  public bool Crouching;

  // Token: 0x04001E4C RID: 7756
  public bool Dangling;

  // Token: 0x04001E4D RID: 7757
  public bool EnterCutscene;

  // Token: 0x04001E4E RID: 7758
  public bool Cutscene;

  // Token: 0x04001E4F RID: 7759
  public bool CanMove;

  // Token: 0x04001E50 RID: 7760
  public bool Injured;

  // Token: 0x04001E51 RID: 7761
  public bool Red;

  // Token: 0x04001E52 RID: 7762
  public bool SpunUp;

  // Token: 0x04001E53 RID: 7763
  public bool SpunDown;

  // Token: 0x04001E54 RID: 7764
  public bool SpunRight;

  // Token: 0x04001E55 RID: 7765
  public bool SpunLeft;

  // Token: 0x04001E56 RID: 7766
  public float TargetRotation;

  // Token: 0x04001E57 RID: 7767
  public float Rotation;

  // Token: 0x04001E58 RID: 7768
  public float RecoveryTimer;

  // Token: 0x04001E59 RID: 7769
  public float DeathTimer;

  // Token: 0x04001E5A RID: 7770
  public float FlashTimer;

  // Token: 0x04001E5B RID: 7771
  public float IdleTimer;

  // Token: 0x04001E5C RID: 7772
  public float TapTimer;

  // Token: 0x04001E5D RID: 7773
  public float PreviousY;

  // Token: 0x04001E5E RID: 7774
  public float MaxHealth = 100f;

  // Token: 0x04001E5F RID: 7775
  public float Health = 100f;

  // Token: 0x04001E60 RID: 7776
  public float EXP;

  // Token: 0x04001E61 RID: 7777
  public int Frames;

  // Token: 0x04001E62 RID: 7778
  public int Level;

  // Token: 0x04001E63 RID: 7779
  public int Taps;

  // Token: 0x04001E64 RID: 7780
  public float walkSpeed = 6f;

  // Token: 0x04001E65 RID: 7781
  public float runSpeed = 11f;

  // Token: 0x04001E66 RID: 7782
  public bool limitDiagonalSpeed = true;

  // Token: 0x04001E67 RID: 7783
  public bool toggleRun;

  // Token: 0x04001E68 RID: 7784
  public float jumpSpeed = 8f;

  // Token: 0x04001E69 RID: 7785
  public float gravity = 20f;

  // Token: 0x04001E6A RID: 7786
  public float fallingDamageThreshold = 10f;

  // Token: 0x04001E6B RID: 7787
  public bool slideWhenOverSlopeLimit;

  // Token: 0x04001E6C RID: 7788
  public bool slideOnTaggedObjects;

  // Token: 0x04001E6D RID: 7789
  public float slideSpeed = 12f;

  // Token: 0x04001E6E RID: 7790
  public bool airControl;

  // Token: 0x04001E6F RID: 7791
  public float antiBumpFactor = 0.75f;

  // Token: 0x04001E70 RID: 7792
  public int antiBunnyHopFactor = 1;

  // Token: 0x04001E71 RID: 7793
  private Vector3 moveDirection = Vector3.zero;

  // Token: 0x04001E72 RID: 7794
  public bool grounded;

  // Token: 0x04001E73 RID: 7795
  private CharacterController controller;

  // Token: 0x04001E74 RID: 7796
  private Transform myTransform;

  // Token: 0x04001E75 RID: 7797
  private float speed;

  // Token: 0x04001E76 RID: 7798
  private RaycastHit hit;

  // Token: 0x04001E77 RID: 7799
  private float fallStartLevel;

  // Token: 0x04001E78 RID: 7800
  private bool falling;

  // Token: 0x04001E79 RID: 7801
  private float slideLimit;

  // Token: 0x04001E7A RID: 7802
  private float rayDistance;

  // Token: 0x04001E7B RID: 7803
  private Vector3 contactPoint;

  // Token: 0x04001E7C RID: 7804
  private bool playerControl;

  // Token: 0x04001E7D RID: 7805
  private int jumpTimer;

  // Token: 0x04001E7E RID: 7806
  private float originalThreshold;

  // Token: 0x04001E7F RID: 7807
  public float inputX;
}