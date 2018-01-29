using UnityEngine;

// Token: 0x02000124 RID: 292
public class LiquidColliderScript : MonoBehaviour {

  // Token: 0x0600059D RID: 1437 RVA: 0x0004CF58 File Offset: 0x0004B358
  private void Start() {
    if (this.Bucket) {
      base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
    }
  }

  // Token: 0x0600059E RID: 1438 RVA: 0x0004CF80 File Offset: 0x0004B380
  private void Update() {
    if (!this.Static) {
      if (!this.Bucket) {
        if (base.transform.position.y < 0f) {
          UnityEngine.Object.Instantiate<GameObject>(this.GroundSplash, new Vector3(base.transform.position.x, 0f, base.transform.position.z), Quaternion.identity);
          this.NewPool = UnityEngine.Object.Instantiate<GameObject>(this.Pool, new Vector3(base.transform.position.x, 0.012f, base.transform.position.z), Quaternion.identity);
          this.NewPool.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
          if (this.Blood) {
            this.NewPool.transform.parent = GameObject.Find("BloodParent").transform;
          }
          UnityEngine.Object.Destroy(base.gameObject);
        }
      } else {
        base.transform.localScale = new Vector3(base.transform.localScale.x + Time.deltaTime * 2f, base.transform.localScale.y + Time.deltaTime * 2f, base.transform.localScale.z + Time.deltaTime * 2f);
      }
    }
  }

  // Token: 0x0600059F RID: 1439 RVA: 0x0004D120 File Offset: 0x0004B520
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null && (component.StudentID == 7 || component.StudentID == component.StudentManager.RivalID)) {
        AudioSource.PlayClipAtPoint(this.SplashSound, base.transform.position);
        UnityEngine.Object.Instantiate<GameObject>(this.Splash, new Vector3(base.transform.position.x, 1.5f, base.transform.position.z), Quaternion.identity);
        if (this.Blood) {
          component.Bloody = true;
        } else if (this.Gas) {
          component.Gas = true;
        }
        component.GetWet();
      }
    }
  }

  // Token: 0x04000D5D RID: 3421
  private GameObject NewPool;

  // Token: 0x04000D5E RID: 3422
  public AudioClip SplashSound;

  // Token: 0x04000D5F RID: 3423
  public GameObject GroundSplash;

  // Token: 0x04000D60 RID: 3424
  public GameObject Splash;

  // Token: 0x04000D61 RID: 3425
  public GameObject Pool;

  // Token: 0x04000D62 RID: 3426
  public bool Static;

  // Token: 0x04000D63 RID: 3427
  public bool Bucket;

  // Token: 0x04000D64 RID: 3428
  public bool Blood;

  // Token: 0x04000D65 RID: 3429
  public bool Gas;
}