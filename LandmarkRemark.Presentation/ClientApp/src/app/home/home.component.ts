import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Location } from '../SharedModels/Location';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../services/alert.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['./home.component.css']
})

export class HomeComponent {

  currentId: number;
  currentClickLatitude: number;
  currentClickLongitude: number;
  currentClickRemark: string;
  locationChosen: boolean = false;
  locationForm: FormGroup;
  newLocation: Location;
  LocationMarkers: Location[]=[];
  coordinates;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder, private alertService: AlertService) {    
    this.currentId = +localStorage.getItem('currentId');
  }

  // convenience getter for easy access to form fields
  get f() { return this.locationForm.controls; }

  OnChoseLocation(event) {
    this.currentClickLatitude = event.coords.lat;
    this.currentClickLongitude = event.coords.lng;
    this.locationChosen = true;

    this.LocationMarkers.push({ Label: this.f.locationLabel.value, Latitude: event.coords.lat, Longitude: event.coords.lng, Remark: this.f.locationRemark.value });
  }

  SearchLocationBasedOnText() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/text');
  }

  SearchLocationBasedOnUserName() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/user');
  }

  GetLocationsForUser() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.currentId);
  }

  GetLocation(url: string) {
    this.http.get<Location[]>(url).subscribe(result => {
      if (result) {
        this.LocationMarkers = result;
      } else {
        this.alertService.error("No record found");
      }
    }, error => console.error(error));
  }
   
  AddLocationsForUser() {
    this.newLocation = new Location();
    this.newLocation.Label = this.f.locationLabel.value;
    this.newLocation.Latitude = this.currentClickLatitude;
    this.newLocation.Longitude = this.currentClickLongitude;
    this.newLocation.Remark = this.f.locationRemark.value;
    this.http.post(this.baseUrl + 'api/location/' + this.currentId, this.newLocation).subscribe(result => {
      if (result)
        this.alertService.success('User remark saved', true);
    }, error => this.alertService.error(error));
  }

  ClickedMarker(remark: string, label:string) {
    console.log(`clicked the marker: ${remark}`)
    this.currentClickRemark = label+": "+remark;
  }

  ResetToCurrentLocation() {
    navigator.geolocation.getCurrentPosition(
      (pos: Position) => {
        this.coordinates = {
          longitude: +(pos.coords.longitude),
          latitude: +(pos.coords.latitude)
        };
      });
  }

  ngOnInit() {
    this.ResetToCurrentLocation();
    this.locationForm = this.formBuilder.group({
      locationLabel: [''],
      locationRemark: [''],
      searchTextControl: ['']
    });
  }
}


