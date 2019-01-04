import { IUser } from "./user.interface";

export class User implements IUser {
  public FirstName: string;
  public LastName: string;
  public UserName: string;
  public Password: string;
  public Email: string;
  public IsActive: boolean;
  public CreationDate: Date;
}


