using UnityEngine;

// Token: 0x020000C1 RID: 193
public class FootprintSpawnerScript : MonoBehaviour {

  // Token: 0x060002E3 RID: 739 RVA: 0x00037004 File Offset: 0x00035404
  private void Start() {
    this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
    this.PoolStairs = GameObject.Find("PoolStairs").GetComponent<Collider>();
    this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
    this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
    this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
    this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
  }

  // Token: 0x060002E4 RID: 740 RVA: 0x00037090 File Offset: 0x00035490
  private void Update() {
    if (this.Debugging) {
      Debug.Log(string.Concat(new string[]
      {
        "UpThreshold: ",
        (this.Yandere.transform.position.y + this.UpThreshold).ToString(),
        " | DownThreshold: ",
        (this.Yandere.transform.position.y + this.DownThreshold).ToString(),
        " | CurrentHeight: ",
        base.transform.position.y.ToString()
      }));
    }
    this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.PoolStairs.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
    if (!this.FootUp) {
      if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold) {
        this.FootUp = true;
      }
    } else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold) {
      if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp) {
        AudioSource component = base.GetComponent<AudioSource>();
        if (Input.GetButton("LB")) {
          component.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
          component.volume = 0.5f;
          component.Play();
        } else {
          component.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
          component.volume = 0.25f;
          component.Play();
        }
      }
      this.FootUp = false;
      if (this.CanSpawn && this.Bloodiness > 0) {
        if (base.transform.position.y > -1f && base.transform.position.y < 1f) {
          this.Height = 0f;
        } else if (base.transform.position.y > 3f && base.transform.position.y < 5f) {
          this.Height = 4f;
        } else if (base.transform.position.y > 7f && base.transform.position.y < 9f) {
          this.Height = 8f;
        } else if (base.transform.position.y > 11f && base.transform.position.y < 13f) {
          this.Height = 12f;
        }
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
        gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
        gameObject.transform.parent = this.BloodParent;
        this.Bloodiness--;
      }
    }
  }

  // Token: 0x0400092C RID: 2348
  public YandereScript Yandere;

  // Token: 0x0400092D RID: 2349
  public GameObject BloodyFootprint;

  // Token: 0x0400092E RID: 2350
  public AudioClip[] WalkFootsteps;

  // Token: 0x0400092F RID: 2351
  public AudioClip[] RunFootsteps;

  // Token: 0x04000930 RID: 2352
  public Transform BloodParent;

  // Token: 0x04000931 RID: 2353
  public Collider GardenArea;

  // Token: 0x04000932 RID: 2354
  public Collider PoolStairs;

  // Token: 0x04000933 RID: 2355
  public Collider NEStairs;

  // Token: 0x04000934 RID: 2356
  public Collider NWStairs;

  // Token: 0x04000935 RID: 2357
  public Collider SEStairs;

  // Token: 0x04000936 RID: 2358
  public Collider SWStairs;

  // Token: 0x04000937 RID: 2359
  public bool Debugging;

  // Token: 0x04000938 RID: 2360
  public bool CanSpawn;

  // Token: 0x04000939 RID: 2361
  public bool FootUp;

  // Token: 0x0400093A RID: 2362
  public float DownThreshold;

  // Token: 0x0400093B RID: 2363
  public float UpThreshold;

  // Token: 0x0400093C RID: 2364
  public float Height;

  // Token: 0x0400093D RID: 2365
  public int Bloodiness;

  // Token: 0x0400093E RID: 2366
  public int Collisions;
}