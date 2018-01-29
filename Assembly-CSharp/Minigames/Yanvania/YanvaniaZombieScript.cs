using UnityEngine;

// Token: 0x0200023A RID: 570
public class YanvaniaZombieScript : MonoBehaviour {

  // Token: 0x06000A0C RID: 2572 RVA: 0x000B8C78 File Offset: 0x000B7078
  private void Start() {
    base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, (this.Yanmont.transform.position.x <= base.transform.position.x) ? -90f : 90f, base.transform.eulerAngles.z);
    UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
    base.transform.position = new Vector3(base.transform.position.x, -0.63f, base.transform.position.z);
    Animation component = this.Character.GetComponent<Animation>();
    component["getup1"].speed = 2f;
    component.Play("getup1");
    base.GetComponent<AudioSource>().PlayOneShot(this.RisingSound);
    this.MyRenderer.material.mainTexture = this.Textures[UnityEngine.Random.Range(0, 22)];
    this.MyCollider.enabled = false;
  }

  // Token: 0x06000A0D RID: 2573 RVA: 0x000B8DC0 File Offset: 0x000B71C0
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Dying) {
      this.DeathTimer += Time.deltaTime;
      if (this.DeathTimer > 1f) {
        if (!this.EffectSpawned) {
          UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
          component.PlayOneShot(this.SinkingSound);
          this.EffectSpawned = true;
        }
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime, base.transform.position.z);
        if (base.transform.position.y < -0.4f) {
          UnityEngine.Object.Destroy(base.gameObject);
        }
      }
    } else {
      Animation component2 = this.Character.GetComponent<Animation>();
      if (this.Sink) {
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime * 0.74f, base.transform.position.z);
        if (base.transform.position.y < -0.63f) {
          UnityEngine.Object.Destroy(base.gameObject);
        }
      } else if (this.Walk) {
        this.WalkTimer += Time.deltaTime;
        if (this.WalkType == 1) {
          base.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed1);
          component2.CrossFade("walk1");
        } else {
          base.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed2);
          component2.CrossFade("walk2");
        }
        if (this.WalkTimer > 10f) {
          this.SinkNow();
        }
      } else {
        this.Timer += Time.deltaTime;
        if (base.transform.position.y < 0f) {
          base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.74f, base.transform.position.z);
          if (base.transform.position.y > 0f) {
            base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
          }
        }
        if (this.Timer > 0.85f) {
          this.Walk = true;
          this.MyCollider.enabled = true;
          this.WalkType = UnityEngine.Random.Range(1, 3);
        }
      }
      if (base.transform.position.x < this.LeftBoundary) {
        base.transform.position = new Vector3(this.LeftBoundary, base.transform.position.y, base.transform.position.z);
        this.SinkNow();
      }
      if (base.transform.position.x > this.RightBoundary) {
        base.transform.position = new Vector3(this.RightBoundary, base.transform.position.y, base.transform.position.z);
        this.SinkNow();
      }
      if (this.HP <= 0) {
        UnityEngine.Object.Instantiate<GameObject>(this.DeathEffect, new Vector3(base.transform.position.x, base.transform.position.y + 1f, base.transform.position.z), Quaternion.identity);
        component2.Play("die");
        component.PlayOneShot(this.DeathSound);
        this.MyCollider.enabled = false;
        this.Yanmont.EXP += 10f;
        this.Dying = true;
      }
    }
    if (this.HitReactTimer < 1f) {
      this.MyRenderer.material.color = new Color(1f, this.HitReactTimer, this.HitReactTimer, 1f);
      this.HitReactTimer += Time.deltaTime * 10f;
      if (this.HitReactTimer >= 1f) {
        this.MyRenderer.material.color = new Color(1f, 1f, 1f, 1f);
      }
    }
  }

  // Token: 0x06000A0E RID: 2574 RVA: 0x000B9310 File Offset: 0x000B7710
  private void SinkNow() {
    Animation component = this.Character.GetComponent<Animation>();
    component["getup1"].time = component["getup1"].length;
    component["getup1"].speed = -2f;
    component.Play("getup1");
    AudioSource component2 = base.GetComponent<AudioSource>();
    component2.PlayOneShot(this.SinkingSound);
    UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
    this.MyCollider.enabled = false;
    this.Sink = true;
  }

  // Token: 0x06000A0F RID: 2575 RVA: 0x000B93AC File Offset: 0x000B77AC
  private void OnTriggerEnter(Collider other) {
    if (!this.Dying) {
      if (other.gameObject.tag == "Player") {
        this.Yanmont.TakeDamage(5);
      }
      if (other.gameObject.name == "Heart" && this.HitReactTimer >= 1f) {
        UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
        AudioSource component = base.GetComponent<AudioSource>();
        component.PlayOneShot(this.HitSound);
        this.HitReactTimer = 0f;
        this.HP -= 20 + (this.Yanmont.Level * 5 - 5);
      }
    }
  }

  // Token: 0x04001E80 RID: 7808
  public GameObject ZombieEffect;

  // Token: 0x04001E81 RID: 7809
  public GameObject BloodEffect;

  // Token: 0x04001E82 RID: 7810
  public GameObject DeathEffect;

  // Token: 0x04001E83 RID: 7811
  public GameObject HitEffect;

  // Token: 0x04001E84 RID: 7812
  public GameObject Character;

  // Token: 0x04001E85 RID: 7813
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001E86 RID: 7814
  public int HP;

  // Token: 0x04001E87 RID: 7815
  public float WalkSpeed1;

  // Token: 0x04001E88 RID: 7816
  public float WalkSpeed2;

  // Token: 0x04001E89 RID: 7817
  public float Damage;

  // Token: 0x04001E8A RID: 7818
  public float HitReactTimer;

  // Token: 0x04001E8B RID: 7819
  public float DeathTimer;

  // Token: 0x04001E8C RID: 7820
  public float WalkTimer;

  // Token: 0x04001E8D RID: 7821
  public float Timer;

  // Token: 0x04001E8E RID: 7822
  public int HitReactState;

  // Token: 0x04001E8F RID: 7823
  public int WalkType;

  // Token: 0x04001E90 RID: 7824
  public float LeftBoundary;

  // Token: 0x04001E91 RID: 7825
  public float RightBoundary;

  // Token: 0x04001E92 RID: 7826
  public bool EffectSpawned;

  // Token: 0x04001E93 RID: 7827
  public bool Dying;

  // Token: 0x04001E94 RID: 7828
  public bool Sink;

  // Token: 0x04001E95 RID: 7829
  public bool Walk;

  // Token: 0x04001E96 RID: 7830
  public Texture[] Textures;

  // Token: 0x04001E97 RID: 7831
  public Renderer MyRenderer;

  // Token: 0x04001E98 RID: 7832
  public Collider MyCollider;

  // Token: 0x04001E99 RID: 7833
  public AudioClip DeathSound;

  // Token: 0x04001E9A RID: 7834
  public AudioClip HitSound;

  // Token: 0x04001E9B RID: 7835
  public AudioClip RisingSound;

  // Token: 0x04001E9C RID: 7836
  public AudioClip SinkingSound;
}