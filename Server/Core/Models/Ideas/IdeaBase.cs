using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.IdeaBox.Data;

namespace Connect.IdeaBox.Models.Ideas
{
    [TableName("IdeaBox_Ideas")]
    [PrimaryKey("IdeaId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class IdeaBase  : AuditableEntity 
    {

        #region .ctor
        public IdeaBase()
        {
            IdeaId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int IdeaId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        #endregion

        #region Methods
        public void ReadIdeaBase(IdeaBase idea)
        {
            if (idea.IdeaId > -1)
                IdeaId = idea.IdeaId;

            if (idea.ModuleId > -1)
                ModuleId = idea.ModuleId;

            if (!String.IsNullOrEmpty(idea.Title))
                Title = idea.Title;

            if (!String.IsNullOrEmpty(idea.Description))
                Description = idea.Description;

        }
        #endregion

    }
}



