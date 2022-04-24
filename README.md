# Weather Forecast Report API

This API provides allows a weatherman to store weater forecasts (temperature)per day and a user can retrieve that forecast in a feel like format (e.g.:  "Freezing", 
"Bracing", "Chilly", "Cool", "Mild", 
"Warm", "Balmy", "Hot", "Sweltering", 
"Scorching")).

Conversion bettween numeral value range and feel like text form is done using the next table.

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

Note: Reported values bellow -60 or above 60 are not allowed


## Assumptions

1. Weather report will return on GET the temperature feel (human readable) for a 7 day's week starting from current day (not including).
2. If a forecast is subimet for a day already in the database it will update the existing forecast.