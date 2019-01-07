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
  LocationMarkers: Location[] = [];
  LocationMarkersCount: number = this.LocationMarkers.length;
  coordinates;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder, private alertService: AlertService) {    
    this.currentId = +localStorage.getItem('currentId');
  }

  // convenience getter for easy access to form fields
  get f() { return this.locationForm.controls; }

  //ADDITIONAL FEATURE:
  //step 1: click on a location
  //step 2: fill the label and remark for the location
  //step 3: click on submit button will trigger this event
  OnChoseLocation(event) {
    this.currentClickLatitude = event.coords.lat;
    this.currentClickLongitude = event.coords.lng;
    this.locationChosen = true;

    this.LocationMarkers.push({ Label: this.f.locationLabel.value, Latitude: event.coords.lat, Longitude: event.coords.lng, Remark: this.f.locationRemark.value });
  }

  //This method will get records by comparing the input text with remarks field(contains search criteria)
  SearchLocationBasedOnText() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/text');
  }

  //This method will get records by comparing the input text with username field(exact match criteria)
  SearchLocationBasedOnUserName() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/user');
  }

  //This method will get records for a specific user id
  GetLocationsForUser() {
    this.GetLocation(this.baseUrl + 'api/location/' + this.currentId);
  }

  //generic get location method that operates based on the url
  GetLocation(url: string) {
    this.http.get<Location[]>(url).subscribe(result => {
      if (result) {
        this.LocationMarkers = result;
      } else {
        this.alertService.error("No record found");
      }
    }, error => console.error(error));
  }

  //Creates a new location remark for a user
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

  //When a user clicks on a location pin, the label and remark of the respective location pin will be shown on info bar
  //NOTE: Manual closure of info bar is required
  //TODO: Automatic closure of info bar, when another location pin is clicked
  ClickedMarker(remark: string, label:string) {
    console.log(`clicked the marker: ${remark}`)
    this.currentClickRemark = label+": "+remark;
  }

  //Resets user to the current location. Sometimes works, sometimes not.
  //TODO: Not working as expected. To be fixed.
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


