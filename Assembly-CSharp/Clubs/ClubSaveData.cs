using System;

// Token: 0x0200018E RID: 398
[Serializable]
public class ClubSaveData {

  // Token: 0x0600071D RID: 1821 RVA: 0x0006C8D8 File Offset: 0x0006ACD8
  public static ClubSaveData ReadFromGlobals() {
    ClubSaveData clubSaveData = new ClubSaveData();
    clubSaveData.club = ClubGlobals.Club;
    foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed()) {
      if (ClubGlobals.GetClubClosed(clubType)) {
        clubSaveData.clubClosed.Add(clubType);
      }
    }
    foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked()) {
      if (ClubGlobals.GetClubKicked(clubType2)) {
        clubSaveData.clubKicked.Add(clubType2);
      }
    }
    foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub()) {
      if (ClubGlobals.GetQuitClub(clubType3)) {
        clubSaveData.quitClub.Add(clubType3);
      }
    }
    return clubSaveData;
  }

  // Token: 0x0600071E RID: 1822 RVA: 0x0006C9B0 File Offset: 0x0006ADB0
  public static void WriteToGlobals(ClubSaveData data) {
    ClubGlobals.Club = data.club;
    foreach (ClubType clubID in data.clubClosed) {
      ClubGlobals.SetClubClosed(clubID, true);
    }
    foreach (ClubType clubID2 in data.clubKicked) {
      ClubGlobals.SetClubKicked(clubID2, true);
    }
    foreach (ClubType clubID3 in data.quitClub) {
      ClubGlobals.SetQuitClub(clubID3, true);
    }
  }

  // Token: 0x0400120D RID: 4621
  public ClubType club;

  // Token: 0x0400120E RID: 4622
  public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

  // Token: 0x0400120F RID: 4623
  public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

  // Token: 0x04001210 RID: 4624
  public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}