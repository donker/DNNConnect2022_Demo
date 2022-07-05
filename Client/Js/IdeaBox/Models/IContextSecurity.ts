export interface IContextSecurity {
  UserId: number;
  CanView: boolean;
  CanEdit: boolean;
  IsAdmin: boolean;
  CanSubmit: boolean;
  CanVote: boolean;
}
