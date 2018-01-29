using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000042 RID: 66
public class BloodPoolSpawnerScript : MonoBehaviour {

  // Token: 0x060000F0 RID: 240 RVA: 0x000111AC File Offset: 0x0000F5AC
  public void Start() {
    if (SceneManager.GetActiveScene().name == "SchoolScene") {
      this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
      this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
      this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
      this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
      this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
    }
    this.BloodParent = GameObject.Find("BloodParent").transform;
    this.Positions = new Vector3[5];
    this.Positions[0] = Vector3.zero;
    this.Positions[1] = new Vector3(0.5f, 0.012f, 0f);
    this.Positions[2] = new Vector3(-0.5f, 0.012f, 0f);
    this.Positions[3] = new Vector3(0f, 0.012f, 0.5f);
    this.Positions[4] = new Vector3(0f, 0.012f, -0.5f);
  }

  // Token: 0x060000F1 RID: 241 RVA: 0x00011309 File Offset: 0x0000F709
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "BloodPool(Clone)") {
      this.LastBloodPool = other.gameObject;
      this.NearbyBlood++;
    }
  }

  // Token: 0x060000F2 RID: 242 RVA: 0x0001133F File Offset: 0x0000F73F
  private void OnTriggerExit(Collider other) {
    if (other.gameObject.name == "BloodPool(Clone)") {
      this.NearbyBlood--;
    }
  }

  // Token: 0x060000F3 RID: 243 RVA: 0x0001136C File Offset: 0x0000F76C
  private void Update() {
    if (this.MyCollider.enabled) {
      if (this.Timer > 0f) {
        this.Timer -= Time.deltaTime;
      }
      this.SetHeight();
      Vector3 position = base.transform.position;
      if (SceneManager.GetActiveScene().name == "SchoolScene") {
        this.CanSpawn = (!this.GardenArea.bounds.Contains(position) && !this.NEStairs.bounds.Contains(position) && !this.NWStairs.bounds.Contains(position) && !this.SEStairs.bounds.Contains(position) && !this.SWStairs.bounds.Contains(position));
      } else {
        this.CanSpawn = true;
      }
      if (this.CanSpawn && position.y < this.Height + 0.333333343f) {
        if (this.NearbyBlood > 0 && this.LastBloodPool == null) {
          this.NearbyBlood--;
        }
        if (this.NearbyBlood < 1 && this.Timer <= 0f) {
          this.Timer = 0.1f;
          if (this.PoolsSpawned < 10) {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
            gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
            gameObject.transform.parent = this.BloodParent;
            this.PoolsSpawned++;
          } else if (this.PoolsSpawned < 20) {
            GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
            gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
            gameObject2.transform.parent = this.BloodParent;
            this.PoolsSpawned++;
            gameObject2.GetComponent<BloodPoolScript>().TargetSize = 1f - (float)(this.PoolsSpawned - 10) * 0.1f;
            if (this.PoolsSpawned == 20) {
              base.gameObject.SetActive(false);
            }
          }
        }
      }
    }
  }

  // Token: 0x060000F4 RID: 244 RVA: 0x00011634 File Offset: 0x0000FA34
  public void SpawnBigPool() {
    this.SetHeight();
    Vector3 a = new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z);
    for (int i = 0; i < 5; i++) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, a + this.Positions[i], Quaternion.identity);
      gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
      gameObject.transform.parent = this.BloodParent;
    }
  }

  // Token: 0x060000F5 RID: 245 RVA: 0x000116F8 File Offset: 0x0000FAF8
  private void SpawnRow(Transform Location) {
    Vector3 position = Location.position;
    Vector3 forward = Location.forward;
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2f, Quaternion.identity);
    gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
    gameObject.transform.parent = this.BloodParent;
    gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2.5f, Quaternion.identity);
    gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
    gameObject.transform.parent = this.BloodParent;
    gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 3f, Quaternion.identity);
    gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
    gameObject.transform.parent = this.BloodParent;
  }

  // Token: 0x060000F6 RID: 246 RVA: 0x00011828 File Offset: 0x0000FC28
  public void SpawnPool(Transform Location) {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, Location.position + Location.forward, Quaternion.identity);
    gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
    gameObject.transform.parent = this.BloodParent;
  }

  // Token: 0x060000F7 RID: 247 RVA: 0x00011894 File Offset: 0x0000FC94
  private void SetHeight() {
    float y = base.transform.position.y;
    if (y < 4f) {
      this.Height = 0f;
    } else if (y < 8f) {
      this.Height = 4f;
    } else if (y < 12f) {
      this.Height = 8f;
    } else {
      this.Height = 12f;
    }
  }

  // Token: 0x0400033C RID: 828
  public RagdollScript Ragdoll;

  // Token: 0x0400033D RID: 829
  public GameObject LastBloodPool;

  // Token: 0x0400033E RID: 830
  public GameObject BloodPool;

  // Token: 0x0400033F RID: 831
  public Transform BloodParent;

  // Token: 0x04000340 RID: 832
  public Transform Hips;

  // Token: 0x04000341 RID: 833
  public Collider MyCollider;

  // Token: 0x04000342 RID: 834
  public Collider GardenArea;

  // Token: 0x04000343 RID: 835
  public Collider NEStairs;

  // Token: 0x04000344 RID: 836
  public Collider NWStairs;

  // Token: 0x04000345 RID: 837
  public Collider SEStairs;

  // Token: 0x04000346 RID: 838
  public Collider SWStairs;

  // Token: 0x04000347 RID: 839
  public Vector3[] Positions;

  // Token: 0x04000348 RID: 840
  public bool CanSpawn;

  // Token: 0x04000349 RID: 841
  public int PoolsSpawned;

  // Token: 0x0400034A RID: 842
  public int NearbyBlood;

  // Token: 0x0400034B RID: 843
  public float Height;

  // Token: 0x0400034C RID: 844
  public float Timer;
}