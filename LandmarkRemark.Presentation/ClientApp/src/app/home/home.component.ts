import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Location } from '../SharedModels/Location';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService } from '../services/alert.service';
import { AgmMap } from '@agm/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  @ViewChild(AgmMap) CurrentMap: AgmMap;

  currentId: number;
  currentUser: string;
  currentClickLatitude: number;
  currentClickLongitude: number;
  currentClickRemark: string;
  locationChosen: boolean = false;
  locationForm: FormGroup;
  newLocation: Location;
  LocationMarkers: Location[] = [];
  coordinates;
  searched = false;
  submitted = false;
  currentLocationIcon: string;
  otherLocationIcon: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private formBuilder: FormBuilder,
              private alertService: AlertService) {    

    this.currentId = +localStorage.getItem('currentId');
    this.currentUser = localStorage.getItem('currentUser');
    this.currentLocationIcon = '/assets/current.png';
    this.otherLocationIcon = '/assets/other.png';
  }

  // convenience getter for easy access to form fields
  get f() { return this.locationForm.controls; }
  
  //This method will get records by comparing the input text with remarks field(contains criteria)
  SearchLocationBasedOnText() {
    this.searched = true;
    this.LocationMarkers = [];

    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/text');
  }

  //This method will get records by comparing the input text with username field(exact match criteria)
  SearchLocationBasedOnUserName() {
    this.searched = true;
    this.LocationMarkers = [];

    this.GetLocation(this.baseUrl + 'api/location/' + this.f.searchTextControl.value + '/user');
  }

  //This method will get records for a specific user id
  GetLocationsForUser() {
    if (this.currentId > 0) {
      this.GetLocation(this.baseUrl + 'api/location/' + this.currentId);
    } else {
      this.alertService.error("Please log-in");
    }
  }

  //generic get location method that operates based on the url
  GetLocation(url: string) {
    this.LocationMarkers = [];

    this.http.get<Location[]>(url).subscribe(result => {
      if (result.length > 0) {
        this.LocationMarkers = this.LocationMarkers.concat(result);
      }
    }, () => this.alertService.error("No record found"));
  }

  //Sets the current location
  SetCurrentLocation() {
    navigator.geolocation.getCurrentPosition(
      (pos: Position) => {
        this.coordinates = {
          longitude: +(pos.coords.longitude),
          latitude: +(pos.coords.latitude)
        };

        this.currentClickLatitude = +(pos.coords.latitude);
        this.currentClickLongitude = +(pos.coords.longitude);
      });
  }

  //Creates a new location remark for a user
  AddLocationsForUser() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.locationForm.invalid) {
      return;
    }

    if (this.currentId > 0) {
      this.newLocation = new Location();
      this.newLocation.Label = this.f.locationLabel.value;
      this.newLocation.Latitude = this.currentClickLatitude;
      this.newLocation.Longitude = this.currentClickLongitude;
      this.newLocation.Remark = this.f.locationRemark.value;
      this.http.post(this.baseUrl + 'api/location/' + this.currentId, this.newLocation).subscribe(result => {
        if (result)
          this.alertService.success('User remark saved', true);
      }, error => this.alertService.error(error));
    } else {
      this.alertService.error("Please log-in");
    }
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    localStorage.removeItem('currentId');
  }

  ReCenter() {
    this.CurrentMap.triggerResize()
      .then(() => (this.CurrentMap as any)._mapsWrapper.setCenter({ lat: this.currentClickLatitude, lng: this.currentClickLongitude }));
  }

  ngOnInit() {
    this.GetLocationsForUser();
    this.SetCurrentLocation();
    this.locationForm = this.formBuilder.group({
      locationLabel: ['', Validators.required],
      locationRemark: ['', Validators.required],
      searchTextControl: ['', Validators.required]
    });
  }
}


