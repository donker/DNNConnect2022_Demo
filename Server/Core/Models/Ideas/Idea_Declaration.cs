using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.IdeaBox.Models.Ideas
{

    [TableName("vw_IdeaBox_Ideas")]
    [PrimaryKey("IdeaId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]                
    public partial class Idea  : IdeaBase 
    {

        #region .ctor
        public Idea()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public int? TotalKarma { get; set; }
        [DataMember]
        public string CreatedByUserDisplayName { get; set; }
        [DataMember]
        public string LastModifiedByUserDisplayName { get; set; }
        #endregion

        #region Methods
        public IdeaBase GetIdeaBase()
        {
            IdeaBase res = new IdeaBase();
             res.IdeaId = IdeaId;
             res.ModuleId = ModuleId;
             res.Title = Title;
             res.Description = Description;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        public Idea Clone()
        {
            Idea res = new Idea();
            res.IdeaId = IdeaId;
            res.ModuleId = ModuleId;
            res.Title = Title;
            res.Description = Description;
            res.TotalKarma = TotalKarma;
            res.CreatedByUserDisplayName = CreatedByUserDisplayName;
            res.LastModifiedByUserDisplayName = LastModifiedByUserDisplayName;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}
