# ExcelParser
ASP.NET Web.Api application for working with excel document

## Requirements
- Use Book1.xlsx for testing
- Created database 'Spreadsheet'
- Specified connection string in \ExcelParser.Core\ExcelParser.Core\appsettings.json
- Software for API testing like Postman

## URI's:
- Create excel file from database
  - HTTP GET
  - https://localhost:44348/api/v1/excel/get
- Save file to database
  - HTTP POST
  - Body: form-data; key=file, value=excel file
  - https://localhost:44348/api/v1/excel/add
- Update records in database
  - HTTP PUT
  - Body: form-data; key=file, value=excel file
  - https://localhost:44348/api/v1/excel/update
- Delete record by id
  - HTTP DELETE
  - https://localhost:44348/api/v1/excel/delete/record id
- Validate excel file 
  - HTTP POST
  - Body: form-data; key=file, value=excel file
  - https://localhost:44348/api/v1/excel/validation/validate

### P.S.
- Some Method column values will be marked red on validate request because formula isn't supported
- Validate method require improvements 
