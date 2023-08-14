I have tried to fit in the desired timeframe. I've assumed I was allowed to take some shortcuts. In normal environment of course I would do some things differently.

The design:

I split GetOrganization method into few smaller ones to make it readable and testable. I used a constructor injection in OrganizationsController.
<br>LocationIds is an array when it's as json, but it's a string when it's in database. I made a Converter helper class for that.
<br>The method GetRemoteData returns Content or Throws exception which is turned into Content by the calling method to comfortably handle wrong input for a user.
<br>I used EF to map entities to databse.
<br>Anyone can easily run the solution locally without much configuration, as I used sqlite. I wanted to focus on code instead of database design, normally I would use an "actual database".
<br>Most methods are async even though often they are awaited. The reason for that is to have future extensibility, as a bigger system might have an advantage in calling some methods simultaneously eg. writing to database imported record and responding with it to a user.
<br>The organizations don't have a field "Inspection" in original so I assumed that's the "DateModified".
<br>It's available on http://localhost:7080/Organizations/1-1000388746 (make sure to use a US spelling for "Organization"). The remote server does not allow to send requests too often. For now in this case the default message "Wrong id" is shown. Just wait a little before sending another request.

<br>
Things I would do in a normal environment:

More exception handling that includes a wider range of user input with customized messages.
<br>I would analyze the datatypes more to make sure they fit the requirements and I would mock more elements in unit tests.
<br>Logging.
<br>I would have have data access layer in a separate class and I would analyze dependency resolution to make sure the code is loosely coupled and testable with a wide range of cases.
