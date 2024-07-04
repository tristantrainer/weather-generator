In listing assumptions under requirements I have implemented a solution assuming they are correct. However in reality this would be a list of items to check with the stakeholder or domain expert.

The realism comments under each requirement are possible nice to haves. These ideas may or may not be necessary (or need to be configurable) depending on the level of data cleaning/validation in the consumer. 

The consideration comments under requirements are possible ways to plan for the future (Open-Closed principle), things to bare in mind.

Requirements
1. Generated files must contain the next 7 days worth of weather predictions.
    - Assumption: 7 days means starting from today 7 * 24 hour records (last prediction is T-Hour - 1)
    - Consideration: This forecast length might be flexible/vary in the future.
    - Consideration: Alter start date, generate at configured time.
2. Generated files must be broken down into records with a record for each hour within forecast window
    - Assumption: There should not be any gaps of hours within this window. 
    - Consideration: This record "rate" might be flexible/vary in the future (every half hour instead).
3. Each record within the file must start with a timestamp in UTC according to format
    - Assumption: Timestamp is always UTC rather than localised UTC offset UTC+X even though we can find UTC from this.
3. Information within each record must be displayed in a tab delimited line following the format in the brief.
    - Assumption: We do not need information for every location (i.e. every Lat/Long combination) since that would be around 6.48e+16 combinations.
    - Realism: Information within a record is unique per location (Lat/Long combination).
4. Information Format: As per brief
    - Lat/Long values to 6 decimal places
        - Realism: Values are within real ranges for Latitude (-90 to 90) and Longitude (-180 to 180).
    - Temperature value to 1 decimal place
        - Realism: Could be restricted to within min/max recorded values (−89.2 °C, 56.7°C).
        - Realism: Include a correlation with location/time of year i.e. colder in arctic/winter, warmer at the equator/summer,
    - Temperature unit in C or F
        - Assumption: Temperature units within a file can vary as this is not specified in the brief (however example shows a single unit for all lines).
        - Consideration: Other units might be added in the future
    - Wind Speed value to 1 decimal place
        - Assumption: Wind Speed should not be less than zero as this impossible. 
        - Realism: Possibly could be within max recorded speed (408 km/h). 
        - Consideration: Other units may be added at some point.
    - Wind Speed value is measured in km/h and unit is always displayed as that.
    - Wind Direction: Cardinal or Ordinal (only: N, NE, E, SE, S, SW, W, NW)
    - Precipitation change percentage: Integer value only, max 100
        - Realism: Minimum 0 as negative percentage doesn't make logical sense here.
5. Number of lines of information must be configurable (or a configurable range).
    - Assumption: This requirement is based on the wording "pumps out as much test data as needed" but there might be a defined set of lat/long combinations or required number of lines per record.
6. Initial produced file must be a .WIS file
    - Consideration: File format might differ in the future. 
7. File name is arbitrary at this point
    - Consideration: File name might be important in the future

Stages
1. Create domain objects for each Weather Records, 