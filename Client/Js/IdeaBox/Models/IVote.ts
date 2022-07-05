export interface IVote {
  IdeaId: number;
  UserId: number;
  Karma: number;
  VotedOn: Date;
}

export class Vote implements IVote {
  IdeaId: number;
  UserId: number;
  Karma: number;
  VotedOn: Date;
    constructor() {
  this.IdeaId = -1;
  this.UserId = -1;
  this.Karma = -1;
  this.VotedOn = new Date();
   }
}

