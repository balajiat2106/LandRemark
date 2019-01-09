# Landmark Remark

This application allows users to save remarks for current loaction on a map. 

Note: Once the application is running, the database will be seeded with minimal set of data
 
# Technology Stack

	- IDE	    ---> Visual Studio 2017
	- Front end ---> .Net core 2.1 with Angular 5
	- Back end  ---> .Net core web api, EF Core (Code first approach) 
	- Database  ---> SQL Express
	- Pattern   ---> CQRS

# Requirements

    - As a User, I can see their current location on the map
    - As a User, I can save a short note at their current location
    . As a User, I can see notes that they have saved at the location they were saved on the map
    - As a User, I can see the location, text, and user-name of notes other users have saved
    - As a User, I have the ability to search for a note based on contained text or user-name
    
# Implicit Requirements

    - By clicking a notes on the list, User should be able to navigate to the location of the notes on the map.
    - User should be able to identify notes saved by him and others by a distinguished marker.
    - The current location may be shown with a home like marker.
    - When the user navigates away from the current location they should be able to reach the current location by a single click.
    - Since the requirements involve multiple users, a screen to provide their username (or login credentials) should be given.
    - All the notes are persisted in the backend.
    - Since this is a browser based application and a demo, to avoid negative scenarios like the user doesn't grant location access, or browser fails to detect current location, a static location is provided as a failproof.
    - By default, all the notes of the current user and other users are loaded. If search feature used, then only the notes are filtered. This is reflected in the list view as well.
    
 
# Effort

- KickStart (40 minutes):
	--->Requirement analysis - 30 minutes
	--->Model design and work breakdown structure - 10 minutes

- Backend (5 hrs):
	--->Test driven development - 3 hours
	--->CQRS application repository- 30 minutes (Approx)
	--->CQRS business layer - 30 minutes (Approx)
	--->Code refactor - 1 hour

- Frontend (4 hrs):
 	--->Google map work - 2 hours
	--->Integration - 30 minutes
	--->Page design - 1 hour
	--->Internal service layer for front end - 30 minutes

- Testing (2 hrs):
	--->Functional testing - 30 minutes
	--->Smoke testing - 30 minutes
	--->Cross browser testing - 1 hour

> Total - 11 hours 40 minutes approximately

# Known issues - Limitations

- Application first load is slow
- Alert messages has to be improved

#Future enhancements

- Self-submitted notes shall be editable
- Star rating can be added for a location
- Click on a remark from the list to navigate to the respective map location
- Search box UI shall be improved
