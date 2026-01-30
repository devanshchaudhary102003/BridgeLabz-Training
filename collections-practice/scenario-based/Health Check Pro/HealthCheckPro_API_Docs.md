# HealthCheckPro - API Documentation

## POST /api/labs/book
- Controller: LabTestsController
- Method: BookTest
- Public API: Book a lab test
- RequiresAuth Role: PATIENT
- Summary: Book a lab test for patient
- Response Example: {"status":"booked"}

## GET /api/labs/tests
- Controller: LabTestsController
- Method: GetAllTests
- Public API: Anyone can view available tests
- RequiresAuth Role: NOT SPECIFIED
- Summary: List all available lab tests
- Response Example: ["CBC","LFT","KFT"]

## GET /api/reports/{id}
- Controller: ReportsController
- Method: GetReportById
- Public API: Get report by reportId
- RequiresAuth Role: DOCTOR
- Summary: Fetch a lab report by id
- Response Example: {"id":101,"result":"Normal"}

## GET /api/reports/{id}/download
- Controller: ReportsController
- Method: DownloadReport
- Public API: Download report PDF
- RequiresAuth Role: PATIENT
- Summary: NO SUMMARY
- Response Example: NO EXAMPLE

