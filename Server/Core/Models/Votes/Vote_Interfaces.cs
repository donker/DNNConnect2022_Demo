using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.IdeaBox.Models.Votes
{
  public partial class Vote : IHydratable, IPropertyAccess
  {

    #region IHydratable

    public virtual void Fill(IDataReader dr)
    {
      IdeaId = Convert.ToInt32(Null.SetNull(dr["IdeaId"], IdeaId));
      UserId = Convert.ToInt32(Null.SetNull(dr["UserId"], UserId));
      Karma = Convert.ToInt16(Null.SetNull(dr["Karma"], Karma));
      VotedOn = (DateTime)(Null.SetNull(dr["VotedOn"], VotedOn));
    }

    [IgnoreColumn()]
    public int KeyID
    {
      get { return Null.NullInteger; }
      set { }
    }
    #endregion

    #region IPropertyAccess
    public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
    {
      switch (strPropertyName.ToLower())
      {
        case "ideaid": // Int
          return IdeaId.ToString(strFormat, formatProvider);
        case "userid": // Int
          return UserId.ToString(strFormat, formatProvider);
        case "karma": // TinyInt
          return Karma.ToString(strFormat, formatProvider);
        case "votedon": // DateTime
          return VotedOn.ToString(strFormat, formatProvider);
        default:
          propertyNotFound = true;
          break;
      }

      return Null.NullString;
    }

    [IgnoreColumn()]
    public CacheLevel Cacheability
    {
      get { return CacheLevel.fullyCacheable; }
    }
    #endregion

  }
}

