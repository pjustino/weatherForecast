# Weather Forecast Report API

This API allows a weatherman to store weather forecasts (temperature) per day that any user can retrieve in a week (7 days) forecast report in a "feel like" format (e.g.:  "Freezing", 
"Bracing", "Chilly", "Cool", "Mild", 
"Warm", "Balmy", "Hot", "Sweltering", 
"Scorching").

Conversion between temperature numeral value range (Celsius) and feel like text form follows the table below.

| Temperature interval (Celsius) | Feels Like |
|:------------------------------:|:----------:|
|          \] -60 , 0 \]         | Freezing   |
|          \] 0 , 5 \]           | Bracing    |
|          \] 5 , 10 \]          | Chilly     |
|          \] 10 , 15 \]         | Cool       |
|          \] 15 , 20 \]         | Mild       |
|          \] 20 , 25 \]         | Warm       |
|          \] 25 , 30 \]         | Balmy      |
|          \] 30 , 35 \]         | Hot        |
|          \] 35 , 40 \]         | Sweltering |
|          \] 40 , 60 \]         | Scorching  |

> :warning: Reported values bellow -60 or above 60 are not allowed


## Forecast input data rules

1. Reported data cannot be in the past
2. Temperature max value is 60 (Celsius)
3. Temperature min value is -60 (Celsius)

## Assumptions

1. Weather report will return on GET the temperature feel (human readable) for a 7 day's week starting from current day (not including).
2. If a forecast is submited for a day already in the database it will update the existing forecast.
3. Inputs can be done in Celsius or Fahrenheit units but values stored in database are always in Celsius.
    

## Run the API
The API was build in .NET 6.0 using Visual Studio. To run with Visual Studio just run the docker-compose start option for project weather.web

To run from the console go to the repository root and run:
```
> docker-compose up
```

## API Swagger

API swagger looks like

![Demo-Api](swagger-ui.png)