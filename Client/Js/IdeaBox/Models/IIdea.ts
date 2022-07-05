export interface IIdea {
  IdeaId: number;
  ModuleId: number;
  Title: string;
  Description: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  TotalKarma?: number;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
}

export class Idea implements IIdea {
  IdeaId: number;
  ModuleId: number;
  Title: string;
  Description: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  TotalKarma?: number;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
    constructor() {
  this.IdeaId = -1;
  this.ModuleId = -1;
  this.Title = "";
  this.CreatedByUserID = -1;
  this.CreatedOnDate = new Date();
  this.LastModifiedByUserID = -1;
  this.LastModifiedOnDate = new Date();
   }
}

