using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
[Serializable]
public class Club {

  // Token: 0x06000291 RID: 657 RVA: 0x000341FA File Offset: 0x000325FA
  public Club(ClubType type) {
    this.type = type;
  }

  // Token: 0x17000047 RID: 71
  // (get) Token: 0x06000292 RID: 658 RVA: 0x00034209 File Offset: 0x00032609
  // (set) Token: 0x06000293 RID: 659 RVA: 0x00034211 File Offset: 0x00032611
  public ClubType Type {
    get {
      return this.type;
    }
    set {
      this.type = value;
    }
  }

  // Token: 0x0400086F RID: 2159
  [SerializeField]
  private ClubType type;

  // Token: 0x04000870 RID: 2160
  public static readonly ClubTypeAndStringDictionary ClubNames = new ClubTypeAndStringDictionary
  {
    {
      ClubType.None,
      "No Club"
    },
    {
      ClubType.Cooking,
      "Cooking"
    },
    {
      ClubType.Drama,
      "Drama"
    },
    {
      ClubType.Occult,
      "Occult"
    },
    {
      ClubType.Art,
      "Art"
    },
    {
      ClubType.LightMusic,
      "Light Music"
    },
    {
      ClubType.MartialArts,
      "Martial Arts"
    },
    {
      ClubType.Photography,
      "Photography"
    },
    {
      ClubType.Science,
      "Science"
    },
    {
      ClubType.Sports,
      "Sports"
    },
    {
      ClubType.Gardening,
      "Gardening"
    },
    {
      ClubType.Gaming,
      "Gaming"
    },
    {
      ClubType.Council,
      "Student Council"
    },
    {
      ClubType.Nemesis,
      "?????"
    }
  };

  // Token: 0x04000871 RID: 2161
  public static readonly IntAndStringDictionary TeacherClubNames = new IntAndStringDictionary
  {
    {
      0,
      "Gym Teacher"
    },
    {
      1,
      "School Nurse"
    },
    {
      2,
      "Guidance Counselor"
    },
    {
      3,
      "Headmaster"
    },
    {
      4,
      "?????"
    },
    {
      11,
      "Teacher of Class 1-1"
    },
    {
      12,
      "Teacher of Class 1-2"
    },
    {
      21,
      "Teacher of Class 2-1"
    },
    {
      22,
      "Teacher of Class 2-2"
    },
    {
      31,
      "Teacher of Class 3-1"
    },
    {
      32,
      "Teacher of Class 3-2"
    }
  };
}