import { ILocation } from "./Location.interface";

export class Location implements ILocation {
  public Id: number;
  public Label: string;
  public Latitude: number;
  public Longitude: number;
  public Remark: string;
}


