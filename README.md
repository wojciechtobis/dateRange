# Date Range 

## Description

Simple console application which should:
* Accept input parameters
* Print date range in console

## Assumptions

Basic assumptions:
* Application accept exactly two input parameters
* Input parameters are dates
* Second date cannot be lower than first one
* Dates (both input and output) have user's culture specific format
* All outputs and errors' logs are displayed in console and written in log files

## Date patterns

Based on user's culture, short dates and ranges can have different patterns. Let's assume that: 

`D` - day

`M` - month

`Y` - year

`.` - date separator

Then all possible range's patterns are described in the table below:

ShortDatePattern | Different Years | Different Months | Different Days | Same Dates 
--- | ---:| ---:| ---:|---:
`D.M.Y` | `D.M.Y - D.M.Y` | `D.M - D.M.Y` | `D - D.M.Y` | `D.M.Y` 
`D.Y.M` | `D.Y.M - D.Y.M` | `D.Y.M - D.Y.M` | `D - D.Y.M` | `D.Y.M` 
`M.D.Y` | `M.D.Y - M.D.Y` | `M.D - M.D.Y` | `M.D - M.D.Y` | `M.D.Y` 
`M.Y.D` | `M.Y.D - M.Y.D` | `M.Y.D - M.Y.D` | `M.Y.D - D` | `M.Y.D`
`Y.D.M` | `Y.D.M - Y.D.M` | `Y.D.M - D.M` | `Y.D.M - D.M` | `Y.D.M`
`Y.M.D` | `Y.M.D - Y.M.D` | `Y.M.D - M.D` | `Y.M.D -D` | `Y.M.D`

