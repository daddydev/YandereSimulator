using UnityEngine;

// Token: 0x020001D0 RID: 464
public class SubtitleScript : MonoBehaviour {

  // Token: 0x0600085E RID: 2142 RVA: 0x00091924 File Offset: 0x0008FD24
  private void Awake() {
    this.SubtitleClipArrays = new SubtitleTypeAndAudioClipArrayDictionary
    {
      {
        SubtitleType.ClubAccept,
        new AudioClipArrayWrapper(this.ClubAcceptClips)
      },
      {
        SubtitleType.ClubActivity,
        new AudioClipArrayWrapper(this.ClubActivityClips)
      },
      {
        SubtitleType.ClubConfirm,
        new AudioClipArrayWrapper(this.ClubConfirmClips)
      },
      {
        SubtitleType.ClubDeny,
        new AudioClipArrayWrapper(this.ClubDenyClips)
      },
      {
        SubtitleType.ClubEarly,
        new AudioClipArrayWrapper(this.ClubEarlyClips)
      },
      {
        SubtitleType.ClubExclusive,
        new AudioClipArrayWrapper(this.ClubExclusiveClips)
      },
      {
        SubtitleType.ClubFarewell,
        new AudioClipArrayWrapper(this.ClubFarewellClips)
      },
      {
        SubtitleType.ClubGreeting,
        new AudioClipArrayWrapper(this.ClubGreetingClips)
      },
      {
        SubtitleType.ClubGrudge,
        new AudioClipArrayWrapper(this.ClubGrudgeClips)
      },
      {
        SubtitleType.ClubJoin,
        new AudioClipArrayWrapper(this.ClubJoinClips)
      },
      {
        SubtitleType.ClubKick,
        new AudioClipArrayWrapper(this.ClubKickClips)
      },
      {
        SubtitleType.ClubLate,
        new AudioClipArrayWrapper(this.ClubLateClips)
      },
      {
        SubtitleType.ClubMartialArtsInfo,
        new AudioClipArrayWrapper(this.Club6Clips)
      },
      {
        SubtitleType.ClubNo,
        new AudioClipArrayWrapper(this.ClubNoClips)
      },
      {
        SubtitleType.ClubOccultInfo,
        new AudioClipArrayWrapper(this.Club3Clips)
      },
      {
        SubtitleType.ClubPlaceholderInfo,
        new AudioClipArrayWrapper(this.Club0Clips)
      },
      {
        SubtitleType.ClubQuit,
        new AudioClipArrayWrapper(this.ClubQuitClips)
      },
      {
        SubtitleType.ClubRefuse,
        new AudioClipArrayWrapper(this.ClubRefuseClips)
      },
      {
        SubtitleType.ClubRejoin,
        new AudioClipArrayWrapper(this.ClubRejoinClips)
      },
      {
        SubtitleType.ClubUnwelcome,
        new AudioClipArrayWrapper(this.ClubUnwelcomeClips)
      },
      {
        SubtitleType.ClubYes,
        new AudioClipArrayWrapper(this.ClubYesClips)
      },
      {
        SubtitleType.DrownReaction,
        new AudioClipArrayWrapper(this.DrownReactionClips)
      },
      {
        SubtitleType.EavesdropReaction,
        new AudioClipArrayWrapper(this.RivalEavesdropClips)
      },
      {
        SubtitleType.GrudgeWarning,
        new AudioClipArrayWrapper(this.GrudgeWarningClips)
      },
      {
        SubtitleType.LightSwitchReaction,
        new AudioClipArrayWrapper(this.LightSwitchClips)
      },
      {
        SubtitleType.LostPhone,
        new AudioClipArrayWrapper(this.LostPhoneClips)
      },
      {
        SubtitleType.NoteReaction,
        new AudioClipArrayWrapper(this.NoteReactionClips)
      },
      {
        SubtitleType.PickpocketReaction,
        new AudioClipArrayWrapper(this.PickpocketReactionClips)
      },
      {
        SubtitleType.RivalLostPhone,
        new AudioClipArrayWrapper(this.RivalLostPhoneClips)
      },
      {
        SubtitleType.RivalPickpocketReaction,
        new AudioClipArrayWrapper(this.RivalPickpocketReactionClips)
      },
      {
        SubtitleType.RivalSplashReaction,
        new AudioClipArrayWrapper(this.RivalSplashReactionClips)
      },
      {
        SubtitleType.SenpaiBloodReaction,
        new AudioClipArrayWrapper(this.SenpaiBloodReactionClips)
      },
      {
        SubtitleType.SenpaiInsanityReaction,
        new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips)
      },
      {
        SubtitleType.SenpaiLewdReaction,
        new AudioClipArrayWrapper(this.SenpaiLewdReactionClips)
      },
      {
        SubtitleType.SenpaiMurderReaction,
        new AudioClipArrayWrapper(this.SenpaiMurderReactionClips)
      },
      {
        SubtitleType.SenpaiStalkingReaction,
        new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips)
      },
      {
        SubtitleType.SenpaiWeaponReaction,
        new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips)
      },
      {
        SubtitleType.SplashReaction,
        new AudioClipArrayWrapper(this.SplashReactionClips)
      },
      {
        SubtitleType.Task6Line,
        new AudioClipArrayWrapper(this.Task6Clips)
      },
      {
        SubtitleType.Task7Line,
        new AudioClipArrayWrapper(this.Task7Clips)
      },
      {
        SubtitleType.Task13Line,
        new AudioClipArrayWrapper(this.Task13Clips)
      },
      {
        SubtitleType.Task14Line,
        new AudioClipArrayWrapper(this.Task14Clips)
      },
      {
        SubtitleType.Task15Line,
        new AudioClipArrayWrapper(this.Task15Clips)
      },
      {
        SubtitleType.Task32Line,
        new AudioClipArrayWrapper(this.Task32Clips)
      },
      {
        SubtitleType.Task33Line,
        new AudioClipArrayWrapper(this.Task33Clips)
      },
      {
        SubtitleType.Task34Line,
        new AudioClipArrayWrapper(this.Task34Clips)
      },
      {
        SubtitleType.TeacherAttackReaction,
        new AudioClipArrayWrapper(this.TeacherAttackClips)
      },
      {
        SubtitleType.TeacherBloodHostile,
        new AudioClipArrayWrapper(this.TeacherBloodHostileClips)
      },
      {
        SubtitleType.TeacherBloodReaction,
        new AudioClipArrayWrapper(this.TeacherBloodClips)
      },
      {
        SubtitleType.TeacherCorpseInspection,
        new AudioClipArrayWrapper(this.TeacherInspectClips)
      },
      {
        SubtitleType.TeacherCorpseReaction,
        new AudioClipArrayWrapper(this.TeacherCorpseClips)
      },
      {
        SubtitleType.TeacherInsanityHostile,
        new AudioClipArrayWrapper(this.TeacherInsanityHostileClips)
      },
      {
        SubtitleType.TeacherInsanityReaction,
        new AudioClipArrayWrapper(this.TeacherInsanityClips)
      },
      {
        SubtitleType.TeacherLateReaction,
        new AudioClipArrayWrapper(this.TeacherLateClips)
      },
      {
        SubtitleType.TeacherLewdReaction,
        new AudioClipArrayWrapper(this.TeacherLewdClips)
      },
      {
        SubtitleType.TeacherMurderReaction,
        new AudioClipArrayWrapper(this.TeacherMurderClips)
      },
      {
        SubtitleType.TeacherPoliceReport,
        new AudioClipArrayWrapper(this.TeacherPoliceClips)
      },
      {
        SubtitleType.TeacherPrankReaction,
        new AudioClipArrayWrapper(this.TeacherPrankClips)
      },
      {
        SubtitleType.TeacherReportReaction,
        new AudioClipArrayWrapper(this.TeacherReportClips)
      },
      {
        SubtitleType.TeacherTheftReaction,
        new AudioClipArrayWrapper(this.TeacherTheftClips)
      },
      {
        SubtitleType.TeacherTrespassingReaction,
        new AudioClipArrayWrapper(this.TeacherTrespassClips)
      },
      {
        SubtitleType.TeacherWeaponHostile,
        new AudioClipArrayWrapper(this.TeacherWeaponHostileClips)
      },
      {
        SubtitleType.TeacherWeaponReaction,
        new AudioClipArrayWrapper(this.TeacherWeaponClips)
      },
      {
        SubtitleType.YandereWhimper,
        new AudioClipArrayWrapper(this.YandereWhimperClips)
      }
    };
  }

  // Token: 0x0600085F RID: 2143 RVA: 0x00091E0D File Offset: 0x0009020D
  private void Start() {
    this.Label.text = string.Empty;
  }

  // Token: 0x06000860 RID: 2144 RVA: 0x00091E1F File Offset: 0x0009021F
  private string GetRandomString(string[] strings) {
    return strings[UnityEngine.Random.Range(0, strings.Length)];
  }

  // Token: 0x06000861 RID: 2145 RVA: 0x00091E2C File Offset: 0x0009022C
  public void UpdateLabel(SubtitleType subtitleType, int ID, float Duration) {
    if (subtitleType == SubtitleType.WeaponAndBloodAndInsanityReaction) {
      this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
    } else if (subtitleType == SubtitleType.WeaponAndBloodReaction) {
      this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
    } else if (subtitleType == SubtitleType.WeaponAndInsanityReaction) {
      this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
    } else if (subtitleType == SubtitleType.BloodAndInsanityReaction) {
      this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
    } else if (subtitleType == SubtitleType.WeaponReaction) {
      if (ID == 1) {
        this.Label.text = this.GetRandomString(this.KnifeReactions);
      } else if (ID == 2) {
        this.Label.text = this.GetRandomString(this.KatanaReactions);
      } else if (ID == 3) {
        this.Label.text = this.GetRandomString(this.SyringeReactions);
      } else if (ID == 7) {
        this.Label.text = this.GetRandomString(this.SawReactions);
      } else if (ID == 8) {
        this.Label.text = this.GetRandomString(this.RitualReactions);
      } else if (ID == 9) {
        this.Label.text = this.GetRandomString(this.BatReactions);
      } else if (ID == 10) {
        this.Label.text = this.GetRandomString(this.ShovelReactions);
      } else if (ID == 12) {
        this.Label.text = this.GetRandomString(this.DumbbellReactions);
      } else if (ID == 13) {
        this.Label.text = this.GetRandomString(this.AxeReactions);
      }
    } else if (subtitleType == SubtitleType.BloodReaction) {
      this.Label.text = this.GetRandomString(this.BloodReactions);
    } else if (subtitleType == SubtitleType.WetBloodReaction) {
      this.Label.text = this.GetRandomString(this.WetBloodReactions);
    } else if (subtitleType == SubtitleType.InsanityReaction) {
      this.Label.text = this.GetRandomString(this.InsanityReactions);
    } else if (subtitleType == SubtitleType.LewdReaction) {
      this.Label.text = this.GetRandomString(this.LewdReactions);
    } else if (subtitleType == SubtitleType.SuspiciousReaction) {
      this.Label.text = this.GetRandomString(this.SuspiciousReactions);
    } else if (subtitleType == SubtitleType.PrankReaction) {
      this.Label.text = this.GetRandomString(this.PrankReactions);
    } else if (subtitleType == SubtitleType.InterruptionReaction) {
      this.Label.text = this.GetRandomString(this.InterruptReactions);
    } else if (subtitleType == SubtitleType.NoteReaction) {
      this.Label.text = this.NoteReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.AcceptFood) {
      this.Label.text = this.GetRandomString(this.FoodAccepts);
    } else if (subtitleType == SubtitleType.RejectFood) {
      this.Label.text = this.GetRandomString(this.FoodRejects);
    } else if (subtitleType == SubtitleType.EavesdropReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
      this.Label.text = this.EavesdropReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.PickpocketReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.PickpocketReactions.Length);
      this.Label.text = this.PickpocketReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.RivalPickpocketReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.RivalPickpocketReactions.Length);
      this.Label.text = this.RivalPickpocketReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.DrownReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.DrownReactions.Length);
      this.Label.text = this.DrownReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.HmmReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.HmmReactions.Length);
      this.Label.text = this.HmmReactions[this.RandomID];
    } else if (subtitleType == SubtitleType.TeacherWeaponReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponReactions.Length);
      this.Label.text = this.TeacherWeaponReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherBloodReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodReactions.Length);
      this.Label.text = this.TeacherBloodReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherInsanityReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityReactions.Length);
      this.Label.text = this.TeacherInsanityReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherWeaponHostile) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponHostiles.Length);
      this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherBloodHostile) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodHostiles.Length);
      this.Label.text = this.TeacherBloodHostiles[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherInsanityHostile) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityHostiles.Length);
      this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherLewdReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherLewdReactions.Length);
      this.Label.text = this.TeacherLewdReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherTrespassingReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherTrespassReactions.Length);
      this.Label.text = this.TeacherTrespassReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.TeacherLateReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherLateReactions.Length);
      this.Label.text = this.TeacherLateReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.TeacherReportReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherReportReactions.Length);
      this.Label.text = this.TeacherReportReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherCorpseReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherCorpseReactions.Length);
      this.Label.text = this.TeacherCorpseReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherCorpseInspection) {
      this.Label.text = this.TeacherCorpseInspections[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.TeacherPoliceReport) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherPoliceReports.Length);
      this.Label.text = this.TeacherPoliceReports[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherAttackReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherAttackReactions.Length);
      this.Label.text = this.TeacherAttackReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherMurderReaction) {
      this.Label.text = this.TeacherMurderReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.TeacherPrankReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherPrankReactions.Length);
      this.Label.text = this.TeacherPrankReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.TeacherTheftReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.TeacherTheftReactions.Length);
      this.Label.text = this.TeacherTheftReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.LostPhone) {
      this.Label.text = this.LostPhones[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.RivalLostPhone) {
      this.Label.text = this.RivalLostPhones[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.MurderReaction) {
      this.Label.text = this.GetRandomString(this.MurderReactions);
    } else if (subtitleType == SubtitleType.CorpseReaction) {
      this.Label.text = this.GetRandomString(this.CorpseReactions);
    } else if (subtitleType == SubtitleType.CouncilCorpseReaction) {
      this.Label.text = this.CouncilCorpseReactions[ID];
    } else if (subtitleType == SubtitleType.LonerMurderReaction) {
      this.Label.text = this.GetRandomString(this.LonerMurderReactions);
    } else if (subtitleType == SubtitleType.LonerCorpseReaction) {
      this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
    } else if (subtitleType == SubtitleType.PetMurderReport) {
      this.Label.text = this.PetMurderReports[ID];
    } else if (subtitleType == SubtitleType.PetMurderReaction) {
      this.Label.text = this.GetRandomString(this.PetMurderReactions);
    } else if (subtitleType == SubtitleType.PetCorpseReport) {
      this.Label.text = this.PetCorpseReports[ID];
    } else if (subtitleType == SubtitleType.PetCorpseReaction) {
      this.Label.text = this.GetRandomString(this.PetCorpseReactions);
    } else if (subtitleType == SubtitleType.EvilCorpseReaction) {
      this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
    } else if (subtitleType == SubtitleType.HeroMurderReaction) {
      this.Label.text = this.GetRandomString(this.HeroMurderReactions);
    } else if (subtitleType == SubtitleType.CowardMurderReaction) {
      this.Label.text = this.GetRandomString(this.CowardMurderReactions);
    } else if (subtitleType == SubtitleType.EvilMurderReaction) {
      this.Label.text = this.GetRandomString(this.EvilMurderReactions);
    } else if (subtitleType == SubtitleType.SocialDeathReaction) {
      this.Label.text = this.GetRandomString(this.SocialDeathReactions);
    } else if (subtitleType == SubtitleType.LovestruckDeathReaction) {
      this.Label.text = this.GetRandomString(this.LovestruckDeathReactions);
    } else if (subtitleType == SubtitleType.LovestruckMurderReport) {
      this.Label.text = this.GetRandomString(this.LovestruckMurderReports);
    } else if (subtitleType == SubtitleType.LovestruckCorpseReport) {
      this.Label.text = this.GetRandomString(this.LovestruckCorpseReports);
    } else if (subtitleType == SubtitleType.SocialReport) {
      this.Label.text = this.GetRandomString(this.SocialReports);
    } else if (subtitleType == SubtitleType.SocialFear) {
      this.Label.text = this.GetRandomString(this.SocialFears);
    } else if (subtitleType == SubtitleType.SocialTerror) {
      this.Label.text = this.GetRandomString(this.SocialTerrors);
    } else if (subtitleType == SubtitleType.RepeatReaction) {
      this.Label.text = this.GetRandomString(this.RepeatReactions);
    } else if (subtitleType == SubtitleType.Greeting) {
      this.Label.text = this.GetRandomString(this.Greetings);
    } else if (subtitleType == SubtitleType.PlayerFarewell) {
      this.Label.text = this.GetRandomString(this.PlayerFarewells);
    } else if (subtitleType == SubtitleType.StudentFarewell) {
      this.Label.text = this.GetRandomString(this.StudentFarewells);
    } else if (subtitleType == SubtitleType.InsanityApology) {
      this.Label.text = this.GetRandomString(this.InsanityApologies);
    } else if (subtitleType == SubtitleType.WeaponAndBloodApology) {
      this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
    } else if (subtitleType == SubtitleType.WeaponApology) {
      this.Label.text = this.GetRandomString(this.WeaponApologies);
    } else if (subtitleType == SubtitleType.BloodApology) {
      this.Label.text = this.GetRandomString(this.BloodApologies);
    } else if (subtitleType == SubtitleType.LewdApology) {
      this.Label.text = this.GetRandomString(this.LewdApologies);
    } else if (subtitleType == SubtitleType.SuspiciousApology) {
      this.Label.text = this.GetRandomString(this.SuspiciousApologies);
    } else if (subtitleType == SubtitleType.EventApology) {
      this.Label.text = this.GetRandomString(this.EventApologies);
    } else if (subtitleType == SubtitleType.ClassApology) {
      this.Label.text = this.GetRandomString(this.ClassApologies);
    } else if (subtitleType == SubtitleType.AccidentApology) {
      this.Label.text = this.GetRandomString(this.AccidentApologies);
    } else if (subtitleType == SubtitleType.Forgiving) {
      this.Label.text = this.GetRandomString(this.Forgivings);
    } else if (subtitleType == SubtitleType.ForgivingAccident) {
      this.Label.text = this.GetRandomString(this.AccidentForgivings);
    } else if (subtitleType == SubtitleType.ForgivingInsanity) {
      this.Label.text = this.GetRandomString(this.InsanityForgivings);
    } else if (subtitleType == SubtitleType.Impatience) {
      this.Label.text = this.Impatiences[ID];
    } else if (subtitleType == SubtitleType.PlayerCompliment) {
      this.Label.text = this.GetRandomString(this.PlayerCompliments);
    } else if (subtitleType == SubtitleType.StudentHighCompliment) {
      this.Label.text = this.GetRandomString(this.StudentHighCompliments);
    } else if (subtitleType == SubtitleType.StudentMidCompliment) {
      this.Label.text = this.GetRandomString(this.StudentMidCompliments);
    } else if (subtitleType == SubtitleType.StudentLowCompliment) {
      this.Label.text = this.GetRandomString(this.StudentLowCompliments);
    } else if (subtitleType == SubtitleType.PlayerGossip) {
      this.Label.text = this.GetRandomString(this.PlayerGossip);
    } else if (subtitleType == SubtitleType.StudentGossip) {
      this.Label.text = this.GetRandomString(this.StudentGossip);
    } else if (subtitleType == SubtitleType.PlayerFollow) {
      this.Label.text = this.GetRandomString(this.PlayerFollows);
    } else if (subtitleType == SubtitleType.StudentFollow) {
      this.Label.text = this.GetRandomString(this.StudentFollows);
    } else if (subtitleType == SubtitleType.PlayerLeave) {
      this.Label.text = this.GetRandomString(this.PlayerLeaves);
    } else if (subtitleType == SubtitleType.StudentLeave) {
      this.Label.text = this.GetRandomString(this.StudentLeaves);
    } else if (subtitleType == SubtitleType.StudentStay) {
      this.Label.text = this.GetRandomString(this.StudentStays);
    } else if (subtitleType == SubtitleType.PlayerDistract) {
      this.Label.text = this.GetRandomString(this.PlayerDistracts);
    } else if (subtitleType == SubtitleType.StudentDistract) {
      this.Label.text = this.GetRandomString(this.StudentDistracts);
    } else if (subtitleType == SubtitleType.StudentDistractRefuse) {
      this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
    } else if (subtitleType == SubtitleType.StopFollowApology) {
      this.Label.text = this.GetRandomString(this.StopFollowApologies);
    } else if (subtitleType == SubtitleType.GrudgeWarning) {
      this.Label.text = this.GetRandomString(this.GrudgeWarnings);
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.GrudgeRefusal) {
      this.Label.text = this.GetRandomString(this.GrudgeRefusals);
    } else if (subtitleType == SubtitleType.CowardGrudge) {
      this.Label.text = this.GetRandomString(this.CowardGrudges);
    } else if (subtitleType == SubtitleType.EvilGrudge) {
      this.Label.text = this.GetRandomString(this.EvilGrudges);
    } else if (subtitleType == SubtitleType.PlayerLove) {
      this.Label.text = this.PlayerLove[ID];
    } else if (subtitleType == SubtitleType.SuitorLove) {
      this.Label.text = this.SuitorLove[ID];
    } else if (subtitleType == SubtitleType.RivalLove) {
      this.Label.text = this.RivalLove[ID];
    } else if (subtitleType == SubtitleType.Dying) {
      this.Label.text = this.GetRandomString(this.Deaths);
    } else if (subtitleType == SubtitleType.SenpaiInsanityReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.SenpaiInsanityReactions.Length);
      this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.SenpaiWeaponReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.SenpaiWeaponReactions.Length);
      this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.SenpaiBloodReaction) {
      this.RandomID = UnityEngine.Random.Range(0, this.SenpaiBloodReactions.Length);
      this.Label.text = this.SenpaiBloodReactions[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.SenpaiLewdReaction) {
      this.Label.text = this.GetRandomString(this.SenpaiLewdReactions);
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.SenpaiStalkingReaction) {
      this.Label.text = this.SenpaiStalkingReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.SenpaiMurderReaction) {
      this.Label.text = this.SenpaiMurderReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.SenpaiCorpseReaction) {
      this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
    } else if (subtitleType == SubtitleType.YandereWhimper) {
      this.RandomID = UnityEngine.Random.Range(0, this.YandereWhimpers.Length);
      this.Label.text = this.YandereWhimpers[this.RandomID];
      this.PlayVoice(subtitleType, this.RandomID);
    } else if (subtitleType == SubtitleType.StudentMurderReport) {
      this.Label.text = this.StudentMurderReports[ID];
    } else if (subtitleType == SubtitleType.SplashReaction) {
      this.Label.text = this.SplashReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.RivalSplashReaction) {
      this.Label.text = this.RivalSplashReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.LightSwitchReaction) {
      this.Label.text = this.LightSwitchReactions[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.PhotoAnnoyance) {
      this.RandomID = UnityEngine.Random.Range(0, this.PhotoAnnoyances.Length);
      this.Label.text = this.PhotoAnnoyances[this.RandomID];
    } else if (subtitleType == SubtitleType.Task6Line) {
      this.Label.text = this.Task6Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task7Line) {
      this.Label.text = this.Task7Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task13Line) {
      this.Label.text = this.Task13Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task14Line) {
      this.Label.text = this.Task14Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task15Line) {
      this.Label.text = this.Task15Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task32Line) {
      this.Label.text = this.Task32Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task33Line) {
      this.Label.text = this.Task33Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.Task34Line) {
      this.Label.text = this.Task34Lines[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubGreeting) {
      this.Label.text = this.ClubGreetings[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubUnwelcome) {
      this.Label.text = this.ClubUnwelcomes[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubKick) {
      this.Label.text = this.ClubKicks[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubPlaceholderInfo) {
      this.Label.text = this.Club0Info[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubOccultInfo) {
      this.Label.text = this.Club3Info[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubMartialArtsInfo) {
      this.Label.text = this.Club6Info[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubJoin) {
      this.Label.text = this.ClubJoins[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubAccept) {
      this.Label.text = this.ClubAccepts[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubRefuse) {
      this.Label.text = this.ClubRefuses[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubRejoin) {
      this.Label.text = this.ClubRejoins[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubExclusive) {
      this.Label.text = this.ClubExclusives[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubGrudge) {
      this.Label.text = this.ClubGrudges[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubQuit) {
      this.Label.text = this.ClubQuits[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubConfirm) {
      this.Label.text = this.ClubConfirms[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubDeny) {
      this.Label.text = this.ClubDenies[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubFarewell) {
      this.Label.text = this.ClubFarewells[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubActivity) {
      this.Label.text = this.ClubActivities[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubEarly) {
      this.Label.text = this.ClubEarlies[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubLate) {
      this.Label.text = this.ClubLates[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubYes) {
      this.Label.text = this.ClubYeses[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.ClubNo) {
      this.Label.text = this.ClubNoes[ID];
      this.PlayVoice(subtitleType, ID);
    } else if (subtitleType == SubtitleType.InfoNotice) {
      this.Label.text = this.InfoNotice;
    } else if (subtitleType == SubtitleType.StrictReaction) {
      this.Label.text = this.StrictReaction[ID];
    } else if (subtitleType == SubtitleType.CasualReaction) {
      this.Label.text = this.CasualReaction[ID];
    } else if (subtitleType == SubtitleType.GraceReaction) {
      this.Label.text = this.GraceReaction[ID];
    } else if (subtitleType == SubtitleType.EdgyReaction) {
      this.Label.text = this.EdgyReaction[ID];
    } else if (subtitleType == SubtitleType.Shoving) {
      this.Label.text = this.Shoving[ID];
    } else if (subtitleType == SubtitleType.Spraying) {
      this.Label.text = this.Spraying[ID];
    } else if (subtitleType == SubtitleType.Chasing) {
      this.Label.text = this.Chasing[ID];
    }
    this.Timer = Duration;
  }

  // Token: 0x06000862 RID: 2146 RVA: 0x0009381C File Offset: 0x00091C1C
  private void Update() {
    if (this.Timer > 0f) {
      this.Timer -= Time.deltaTime;
      if (this.Timer <= 0f) {
        this.Jukebox.Dip = 1f;
        this.Label.text = string.Empty;
        this.Timer = 0f;
      }
    }
  }

  // Token: 0x06000863 RID: 2147 RVA: 0x00093888 File Offset: 0x00091C88
  private void PlayVoice(SubtitleType subtitleType, int ID) {
    if (this.CurrentClip != null) {
      UnityEngine.Object.Destroy(this.CurrentClip);
    }
    this.Jukebox.Dip = 0.5f;
    AudioClipArrayWrapper audioClipArrayWrapper;
    bool flag = this.SubtitleClipArrays.TryGetValue(subtitleType, out audioClipArrayWrapper);
    this.PlayClip(audioClipArrayWrapper[ID], base.transform.position);
  }

  // Token: 0x06000864 RID: 2148 RVA: 0x000938E8 File Offset: 0x00091CE8
  public float GetClipLength(int StudentID, int TaskPhase) {
    if (StudentID == 6) {
      return this.Task6Clips[TaskPhase].length;
    }
    if (StudentID == 7) {
      return this.Task7Clips[TaskPhase].length;
    }
    if (StudentID == 13) {
      return this.Task13Clips[TaskPhase].length;
    }
    if (StudentID == 14) {
      return this.Task14Clips[TaskPhase].length;
    }
    if (StudentID == 15) {
      return this.Task15Clips[TaskPhase].length;
    }
    if (StudentID == 32) {
      return this.Task32Clips[TaskPhase].length;
    }
    if (StudentID == 33) {
      return this.Task33Clips[TaskPhase].length;
    }
    if (StudentID == 34) {
      return this.Task34Clips[TaskPhase].length;
    }
    return 0f;
  }

  // Token: 0x06000865 RID: 2149 RVA: 0x000939A8 File Offset: 0x00091DA8
  public float GetClubClipLength(ClubType Club, int ClubPhase) {
    if (Club == ClubType.Occult) {
      return this.Club3Clips[ClubPhase].length;
    }
    if (Club == ClubType.MartialArts) {
      return this.Club6Clips[ClubPhase].length;
    }
    return 0f;
  }

  // Token: 0x06000866 RID: 2150 RVA: 0x000939DC File Offset: 0x00091DDC
  private void PlayClip(AudioClip clip, Vector3 pos) {
    if (clip != null) {
      GameObject gameObject = new GameObject("TempAudio");
      gameObject.transform.position = this.Yandere.transform.position + base.transform.up;
      gameObject.transform.parent = this.Yandere.transform;
      AudioSource audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.clip = clip;
      audioSource.Play();
      UnityEngine.Object.Destroy(gameObject, clip.length);
      audioSource.rolloffMode = AudioRolloffMode.Linear;
      audioSource.minDistance = 5f;
      audioSource.maxDistance = 10f;
      this.CurrentClip = gameObject;
      audioSource.volume = ((this.Yandere.position.y >= gameObject.transform.position.y - 2f) ? 1f : 0f);
    }
  }

  // Token: 0x040017CA RID: 6090
  public JukeboxScript Jukebox;

  // Token: 0x040017CB RID: 6091
  public Transform Yandere;

  // Token: 0x040017CC RID: 6092
  public UILabel Label;

  // Token: 0x040017CD RID: 6093
  public string[] WeaponBloodInsanityReactions;

  // Token: 0x040017CE RID: 6094
  public string[] WeaponBloodReactions;

  // Token: 0x040017CF RID: 6095
  public string[] WeaponInsanityReactions;

  // Token: 0x040017D0 RID: 6096
  public string[] BloodInsanityReactions;

  // Token: 0x040017D1 RID: 6097
  public string[] BloodReactions;

  // Token: 0x040017D2 RID: 6098
  public string[] WetBloodReactions;

  // Token: 0x040017D3 RID: 6099
  public string[] InsanityReactions;

  // Token: 0x040017D4 RID: 6100
  public string[] LewdReactions;

  // Token: 0x040017D5 RID: 6101
  public string[] SuspiciousReactions;

  // Token: 0x040017D6 RID: 6102
  public string[] MurderReactions;

  // Token: 0x040017D7 RID: 6103
  public string[] CowardMurderReactions;

  // Token: 0x040017D8 RID: 6104
  public string[] EvilMurderReactions;

  // Token: 0x040017D9 RID: 6105
  public string[] PetMurderReports;

  // Token: 0x040017DA RID: 6106
  public string[] PetMurderReactions;

  // Token: 0x040017DB RID: 6107
  public string[] PetCorpseReports;

  // Token: 0x040017DC RID: 6108
  public string[] PetCorpseReactions;

  // Token: 0x040017DD RID: 6109
  public string[] HeroMurderReactions;

  // Token: 0x040017DE RID: 6110
  public string[] LonerMurderReactions;

  // Token: 0x040017DF RID: 6111
  public string[] LonerCorpseReactions;

  // Token: 0x040017E0 RID: 6112
  public string[] EvilCorpseReactions;

  // Token: 0x040017E1 RID: 6113
  public string[] SocialDeathReactions;

  // Token: 0x040017E2 RID: 6114
  public string[] LovestruckDeathReactions;

  // Token: 0x040017E3 RID: 6115
  public string[] LovestruckMurderReports;

  // Token: 0x040017E4 RID: 6116
  public string[] LovestruckCorpseReports;

  // Token: 0x040017E5 RID: 6117
  public string[] SocialReports;

  // Token: 0x040017E6 RID: 6118
  public string[] SocialFears;

  // Token: 0x040017E7 RID: 6119
  public string[] SocialTerrors;

  // Token: 0x040017E8 RID: 6120
  public string[] RepeatReactions;

  // Token: 0x040017E9 RID: 6121
  public string[] CorpseReactions;

  // Token: 0x040017EA RID: 6122
  public string[] PrankReactions;

  // Token: 0x040017EB RID: 6123
  public string[] InterruptReactions;

  // Token: 0x040017EC RID: 6124
  public string[] NoteReactions;

  // Token: 0x040017ED RID: 6125
  public string[] FoodAccepts;

  // Token: 0x040017EE RID: 6126
  public string[] FoodRejects;

  // Token: 0x040017EF RID: 6127
  public string[] EavesdropReactions;

  // Token: 0x040017F0 RID: 6128
  public string[] PickpocketReactions;

  // Token: 0x040017F1 RID: 6129
  public string[] RivalPickpocketReactions;

  // Token: 0x040017F2 RID: 6130
  public string[] DrownReactions;

  // Token: 0x040017F3 RID: 6131
  public string[] KnifeReactions;

  // Token: 0x040017F4 RID: 6132
  public string[] SyringeReactions;

  // Token: 0x040017F5 RID: 6133
  public string[] KatanaReactions;

  // Token: 0x040017F6 RID: 6134
  public string[] SawReactions;

  // Token: 0x040017F7 RID: 6135
  public string[] RitualReactions;

  // Token: 0x040017F8 RID: 6136
  public string[] BatReactions;

  // Token: 0x040017F9 RID: 6137
  public string[] ShovelReactions;

  // Token: 0x040017FA RID: 6138
  public string[] DumbbellReactions;

  // Token: 0x040017FB RID: 6139
  public string[] AxeReactions;

  // Token: 0x040017FC RID: 6140
  public string[] WeaponBloodApologies;

  // Token: 0x040017FD RID: 6141
  public string[] WeaponApologies;

  // Token: 0x040017FE RID: 6142
  public string[] BloodApologies;

  // Token: 0x040017FF RID: 6143
  public string[] InsanityApologies;

  // Token: 0x04001800 RID: 6144
  public string[] LewdApologies;

  // Token: 0x04001801 RID: 6145
  public string[] SuspiciousApologies;

  // Token: 0x04001802 RID: 6146
  public string[] EventApologies;

  // Token: 0x04001803 RID: 6147
  public string[] ClassApologies;

  // Token: 0x04001804 RID: 6148
  public string[] AccidentApologies;

  // Token: 0x04001805 RID: 6149
  public string[] Greetings;

  // Token: 0x04001806 RID: 6150
  public string[] PlayerFarewells;

  // Token: 0x04001807 RID: 6151
  public string[] StudentFarewells;

  // Token: 0x04001808 RID: 6152
  public string[] Forgivings;

  // Token: 0x04001809 RID: 6153
  public string[] AccidentForgivings;

  // Token: 0x0400180A RID: 6154
  public string[] InsanityForgivings;

  // Token: 0x0400180B RID: 6155
  public string[] PlayerCompliments;

  // Token: 0x0400180C RID: 6156
  public string[] StudentHighCompliments;

  // Token: 0x0400180D RID: 6157
  public string[] StudentMidCompliments;

  // Token: 0x0400180E RID: 6158
  public string[] StudentLowCompliments;

  // Token: 0x0400180F RID: 6159
  public string[] PlayerGossip;

  // Token: 0x04001810 RID: 6160
  public string[] StudentGossip;

  // Token: 0x04001811 RID: 6161
  public string[] PlayerFollows;

  // Token: 0x04001812 RID: 6162
  public string[] StudentFollows;

  // Token: 0x04001813 RID: 6163
  public string[] PlayerLeaves;

  // Token: 0x04001814 RID: 6164
  public string[] StudentLeaves;

  // Token: 0x04001815 RID: 6165
  public string[] StudentStays;

  // Token: 0x04001816 RID: 6166
  public string[] PlayerDistracts;

  // Token: 0x04001817 RID: 6167
  public string[] StudentDistracts;

  // Token: 0x04001818 RID: 6168
  public string[] StudentDistractRefuses;

  // Token: 0x04001819 RID: 6169
  public string[] StopFollowApologies;

  // Token: 0x0400181A RID: 6170
  public string[] GrudgeWarnings;

  // Token: 0x0400181B RID: 6171
  public string[] GrudgeRefusals;

  // Token: 0x0400181C RID: 6172
  public string[] CowardGrudges;

  // Token: 0x0400181D RID: 6173
  public string[] EvilGrudges;

  // Token: 0x0400181E RID: 6174
  public string[] PlayerLove;

  // Token: 0x0400181F RID: 6175
  public string[] SuitorLove;

  // Token: 0x04001820 RID: 6176
  public string[] RivalLove;

  // Token: 0x04001821 RID: 6177
  public string[] Impatiences;

  // Token: 0x04001822 RID: 6178
  public string[] ImpatientFarewells;

  // Token: 0x04001823 RID: 6179
  public string[] Deaths;

  // Token: 0x04001824 RID: 6180
  public string[] SenpaiInsanityReactions;

  // Token: 0x04001825 RID: 6181
  public string[] SenpaiWeaponReactions;

  // Token: 0x04001826 RID: 6182
  public string[] SenpaiBloodReactions;

  // Token: 0x04001827 RID: 6183
  public string[] SenpaiLewdReactions;

  // Token: 0x04001828 RID: 6184
  public string[] SenpaiStalkingReactions;

  // Token: 0x04001829 RID: 6185
  public string[] SenpaiMurderReactions;

  // Token: 0x0400182A RID: 6186
  public string[] SenpaiCorpseReactions;

  // Token: 0x0400182B RID: 6187
  public string[] TeacherInsanityReactions;

  // Token: 0x0400182C RID: 6188
  public string[] TeacherWeaponReactions;

  // Token: 0x0400182D RID: 6189
  public string[] TeacherBloodReactions;

  // Token: 0x0400182E RID: 6190
  public string[] TeacherInsanityHostiles;

  // Token: 0x0400182F RID: 6191
  public string[] TeacherWeaponHostiles;

  // Token: 0x04001830 RID: 6192
  public string[] TeacherBloodHostiles;

  // Token: 0x04001831 RID: 6193
  public string[] TeacherLewdReactions;

  // Token: 0x04001832 RID: 6194
  public string[] TeacherTrespassReactions;

  // Token: 0x04001833 RID: 6195
  public string[] TeacherLateReactions;

  // Token: 0x04001834 RID: 6196
  public string[] TeacherReportReactions;

  // Token: 0x04001835 RID: 6197
  public string[] TeacherCorpseReactions;

  // Token: 0x04001836 RID: 6198
  public string[] TeacherCorpseInspections;

  // Token: 0x04001837 RID: 6199
  public string[] TeacherPoliceReports;

  // Token: 0x04001838 RID: 6200
  public string[] TeacherAttackReactions;

  // Token: 0x04001839 RID: 6201
  public string[] TeacherMurderReactions;

  // Token: 0x0400183A RID: 6202
  public string[] TeacherPrankReactions;

  // Token: 0x0400183B RID: 6203
  public string[] TeacherTheftReactions;

  // Token: 0x0400183C RID: 6204
  public string[] LostPhones;

  // Token: 0x0400183D RID: 6205
  public string[] RivalLostPhones;

  // Token: 0x0400183E RID: 6206
  public string[] StudentMurderReports;

  // Token: 0x0400183F RID: 6207
  public string[] YandereWhimpers;

  // Token: 0x04001840 RID: 6208
  public string[] SplashReactions;

  // Token: 0x04001841 RID: 6209
  public string[] RivalSplashReactions;

  // Token: 0x04001842 RID: 6210
  public string[] LightSwitchReactions;

  // Token: 0x04001843 RID: 6211
  public string[] PhotoAnnoyances;

  // Token: 0x04001844 RID: 6212
  public string[] Task6Lines;

  // Token: 0x04001845 RID: 6213
  public string[] Task7Lines;

  // Token: 0x04001846 RID: 6214
  public string[] Task13Lines;

  // Token: 0x04001847 RID: 6215
  public string[] Task14Lines;

  // Token: 0x04001848 RID: 6216
  public string[] Task15Lines;

  // Token: 0x04001849 RID: 6217
  public string[] Task32Lines;

  // Token: 0x0400184A RID: 6218
  public string[] Task33Lines;

  // Token: 0x0400184B RID: 6219
  public string[] Task34Lines;

  // Token: 0x0400184C RID: 6220
  public string[] Club0Info;

  // Token: 0x0400184D RID: 6221
  public string[] Club3Info;

  // Token: 0x0400184E RID: 6222
  public string[] Club6Info;

  // Token: 0x0400184F RID: 6223
  public string[] ClubGreetings;

  // Token: 0x04001850 RID: 6224
  public string[] ClubUnwelcomes;

  // Token: 0x04001851 RID: 6225
  public string[] ClubKicks;

  // Token: 0x04001852 RID: 6226
  public string[] ClubJoins;

  // Token: 0x04001853 RID: 6227
  public string[] ClubAccepts;

  // Token: 0x04001854 RID: 6228
  public string[] ClubRefuses;

  // Token: 0x04001855 RID: 6229
  public string[] ClubRejoins;

  // Token: 0x04001856 RID: 6230
  public string[] ClubExclusives;

  // Token: 0x04001857 RID: 6231
  public string[] ClubGrudges;

  // Token: 0x04001858 RID: 6232
  public string[] ClubQuits;

  // Token: 0x04001859 RID: 6233
  public string[] ClubConfirms;

  // Token: 0x0400185A RID: 6234
  public string[] ClubDenies;

  // Token: 0x0400185B RID: 6235
  public string[] ClubFarewells;

  // Token: 0x0400185C RID: 6236
  public string[] ClubActivities;

  // Token: 0x0400185D RID: 6237
  public string[] ClubEarlies;

  // Token: 0x0400185E RID: 6238
  public string[] ClubLates;

  // Token: 0x0400185F RID: 6239
  public string[] ClubYeses;

  // Token: 0x04001860 RID: 6240
  public string[] ClubNoes;

  // Token: 0x04001861 RID: 6241
  public string[] StrictReaction;

  // Token: 0x04001862 RID: 6242
  public string[] CasualReaction;

  // Token: 0x04001863 RID: 6243
  public string[] GraceReaction;

  // Token: 0x04001864 RID: 6244
  public string[] EdgyReaction;

  // Token: 0x04001865 RID: 6245
  public string[] Spraying;

  // Token: 0x04001866 RID: 6246
  public string[] Shoving;

  // Token: 0x04001867 RID: 6247
  public string[] Chasing;

  // Token: 0x04001868 RID: 6248
  public string[] CouncilCorpseReactions;

  // Token: 0x04001869 RID: 6249
  public string[] HmmReactions;

  // Token: 0x0400186A RID: 6250
  public string InfoNotice;

  // Token: 0x0400186B RID: 6251
  public int RandomID;

  // Token: 0x0400186C RID: 6252
  public float Timer;

  // Token: 0x0400186D RID: 6253
  public AudioClip[] NoteReactionClips;

  // Token: 0x0400186E RID: 6254
  public AudioClip[] GrudgeWarningClips;

  // Token: 0x0400186F RID: 6255
  public AudioClip[] SenpaiInsanityReactionClips;

  // Token: 0x04001870 RID: 6256
  public AudioClip[] SenpaiWeaponReactionClips;

  // Token: 0x04001871 RID: 6257
  public AudioClip[] SenpaiBloodReactionClips;

  // Token: 0x04001872 RID: 6258
  public AudioClip[] SenpaiLewdReactionClips;

  // Token: 0x04001873 RID: 6259
  public AudioClip[] SenpaiStalkingReactionClips;

  // Token: 0x04001874 RID: 6260
  public AudioClip[] SenpaiMurderReactionClips;

  // Token: 0x04001875 RID: 6261
  public AudioClip[] YandereWhimperClips;

  // Token: 0x04001876 RID: 6262
  public AudioClip[] TeacherWeaponClips;

  // Token: 0x04001877 RID: 6263
  public AudioClip[] TeacherBloodClips;

  // Token: 0x04001878 RID: 6264
  public AudioClip[] TeacherInsanityClips;

  // Token: 0x04001879 RID: 6265
  public AudioClip[] TeacherWeaponHostileClips;

  // Token: 0x0400187A RID: 6266
  public AudioClip[] TeacherBloodHostileClips;

  // Token: 0x0400187B RID: 6267
  public AudioClip[] TeacherInsanityHostileClips;

  // Token: 0x0400187C RID: 6268
  public AudioClip[] TeacherLewdClips;

  // Token: 0x0400187D RID: 6269
  public AudioClip[] TeacherTrespassClips;

  // Token: 0x0400187E RID: 6270
  public AudioClip[] TeacherLateClips;

  // Token: 0x0400187F RID: 6271
  public AudioClip[] TeacherReportClips;

  // Token: 0x04001880 RID: 6272
  public AudioClip[] TeacherCorpseClips;

  // Token: 0x04001881 RID: 6273
  public AudioClip[] TeacherInspectClips;

  // Token: 0x04001882 RID: 6274
  public AudioClip[] TeacherPoliceClips;

  // Token: 0x04001883 RID: 6275
  public AudioClip[] TeacherAttackClips;

  // Token: 0x04001884 RID: 6276
  public AudioClip[] TeacherMurderClips;

  // Token: 0x04001885 RID: 6277
  public AudioClip[] TeacherPrankClips;

  // Token: 0x04001886 RID: 6278
  public AudioClip[] TeacherTheftClips;

  // Token: 0x04001887 RID: 6279
  public AudioClip[] LostPhoneClips;

  // Token: 0x04001888 RID: 6280
  public AudioClip[] RivalLostPhoneClips;

  // Token: 0x04001889 RID: 6281
  public AudioClip[] PickpocketReactionClips;

  // Token: 0x0400188A RID: 6282
  public AudioClip[] RivalPickpocketReactionClips;

  // Token: 0x0400188B RID: 6283
  public AudioClip[] SplashReactionClips;

  // Token: 0x0400188C RID: 6284
  public AudioClip[] RivalSplashReactionClips;

  // Token: 0x0400188D RID: 6285
  public AudioClip[] DrownReactionClips;

  // Token: 0x0400188E RID: 6286
  public AudioClip[] LightSwitchClips;

  // Token: 0x0400188F RID: 6287
  public AudioClip[] Task6Clips;

  // Token: 0x04001890 RID: 6288
  public AudioClip[] Task7Clips;

  // Token: 0x04001891 RID: 6289
  public AudioClip[] Task13Clips;

  // Token: 0x04001892 RID: 6290
  public AudioClip[] Task14Clips;

  // Token: 0x04001893 RID: 6291
  public AudioClip[] Task15Clips;

  // Token: 0x04001894 RID: 6292
  public AudioClip[] Task32Clips;

  // Token: 0x04001895 RID: 6293
  public AudioClip[] Task33Clips;

  // Token: 0x04001896 RID: 6294
  public AudioClip[] Task34Clips;

  // Token: 0x04001897 RID: 6295
  public AudioClip[] Club0Clips;

  // Token: 0x04001898 RID: 6296
  public AudioClip[] Club3Clips;

  // Token: 0x04001899 RID: 6297
  public AudioClip[] Club6Clips;

  // Token: 0x0400189A RID: 6298
  public AudioClip[] ClubGreetingClips;

  // Token: 0x0400189B RID: 6299
  public AudioClip[] ClubUnwelcomeClips;

  // Token: 0x0400189C RID: 6300
  public AudioClip[] ClubKickClips;

  // Token: 0x0400189D RID: 6301
  public AudioClip[] ClubJoinClips;

  // Token: 0x0400189E RID: 6302
  public AudioClip[] ClubAcceptClips;

  // Token: 0x0400189F RID: 6303
  public AudioClip[] ClubRefuseClips;

  // Token: 0x040018A0 RID: 6304
  public AudioClip[] ClubRejoinClips;

  // Token: 0x040018A1 RID: 6305
  public AudioClip[] ClubExclusiveClips;

  // Token: 0x040018A2 RID: 6306
  public AudioClip[] ClubGrudgeClips;

  // Token: 0x040018A3 RID: 6307
  public AudioClip[] ClubQuitClips;

  // Token: 0x040018A4 RID: 6308
  public AudioClip[] ClubConfirmClips;

  // Token: 0x040018A5 RID: 6309
  public AudioClip[] ClubDenyClips;

  // Token: 0x040018A6 RID: 6310
  public AudioClip[] ClubFarewellClips;

  // Token: 0x040018A7 RID: 6311
  public AudioClip[] ClubActivityClips;

  // Token: 0x040018A8 RID: 6312
  public AudioClip[] ClubEarlyClips;

  // Token: 0x040018A9 RID: 6313
  public AudioClip[] ClubLateClips;

  // Token: 0x040018AA RID: 6314
  public AudioClip[] ClubYesClips;

  // Token: 0x040018AB RID: 6315
  public AudioClip[] ClubNoClips;

  // Token: 0x040018AC RID: 6316
  public AudioClip[] RivalEavesdropClips;

  // Token: 0x040018AD RID: 6317
  private SubtitleTypeAndAudioClipArrayDictionary SubtitleClipArrays;

  // Token: 0x040018AE RID: 6318
  public GameObject CurrentClip;
}