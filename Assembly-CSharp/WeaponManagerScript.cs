using UnityEngine;

// Token: 0x02000213 RID: 531
public class WeaponManagerScript : MonoBehaviour {

  // Token: 0x06000940 RID: 2368 RVA: 0x000A03FC File Offset: 0x0009E7FC
  public void UpdateLabels() {
    foreach (WeaponScript weaponScript in this.Weapons) {
      weaponScript.UpdateLabel();
    }
  }

  // Token: 0x06000941 RID: 2369 RVA: 0x000A0430 File Offset: 0x0009E830
  public void CheckWeapons() {
    this.MurderWeapons = 0;
    this.Fingerprints = 0;
    for (int i = 0; i < this.Victims.Length; i++) {
      this.Victims[i] = 0;
    }
    foreach (WeaponScript weaponScript in this.Weapons) {
      if (weaponScript != null && weaponScript.Blood.enabled) {
        this.MurderWeapons++;
        if (weaponScript.FingerprintID > 0) {
          this.Fingerprints++;
          for (int k = 0; k < weaponScript.Victims.Length; k++) {
            if (weaponScript.Victims[k]) {
              this.Victims[k] = weaponScript.FingerprintID;
            }
          }
        }
      }
    }
  }

  // Token: 0x06000942 RID: 2370 RVA: 0x000A050C File Offset: 0x0009E90C
  public void CleanWeapons() {
    foreach (WeaponScript weaponScript in this.Weapons) {
      if (weaponScript != null) {
        weaponScript.Blood.enabled = false;
        weaponScript.FingerprintID = 0;
      }
    }
  }

  // Token: 0x06000943 RID: 2371 RVA: 0x000A0558 File Offset: 0x0009E958
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Z)) {
      this.CheckWeapons();
      for (int i = 0; i < this.Victims.Length; i++) {
        if (this.Victims[i] != 0) {
          if (this.Victims[i] == 100) {
            Debug.Log("The student named " + this.JSON.Students[i].Name + " was killed by Yandere-chan!");
          } else {
            Debug.Log(string.Concat(new string[]
            {
              "The student named ",
              this.JSON.Students[i].Name,
              " was killed by ",
              this.JSON.Students[this.Victims[i]].Name,
              "!"
            }));
          }
        }
      }
    }
  }

  // Token: 0x04001A62 RID: 6754
  public WeaponScript[] Weapons;

  // Token: 0x04001A63 RID: 6755
  public JsonScript JSON;

  // Token: 0x04001A64 RID: 6756
  public int[] Victims;

  // Token: 0x04001A65 RID: 6757
  public int MurderWeapons;

  // Token: 0x04001A66 RID: 6758
  public int Fingerprints;

  // Token: 0x04001A67 RID: 6759
  public bool YandereGuilty;
}