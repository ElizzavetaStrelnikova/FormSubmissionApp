# TASK 2

I haven't had an opportunity yet to work with such large files in an app but I have reseached and figured out that there are some popular ways to hadle this situation are:
1. Chunking - splitting the data to smaller types. For example, in JS we can use the method *Blob.slice* to split the data to the smaller parts of 10 MB in size. This will minimize memory usage.
2. We can create an ability for a user to pause an uploading of the file and start it later from the point it ended with.
3. Streaming - stream it directly to its destination (avoid caching locally), this reduce memory consumption.
-  As for the architecture, we have Frontend and Backend as usual. 
+ Frontend has Vue.js form with file input that splits large files into smaller chunks (10 MB). 
+ Backend has two main services:

1. Submission service (handles form data)
2. Attachment service (handles file storage)

- In the database we have a table for submissions and attachments:

+ ID (unique identifier)
+ FormType (text)
+ SubmissionDate (datetime)

+ ID (unique identifier)
+ SubmissionID (links to submission)
+ FileName (text)
+ FileSize (number)
+ StoragePath (text - where file is saved)
+ ContentType (text - file type)

- API:

1. Client submits form without files first.

+ POST /api/submissions

2. Returns submission ID.

3. Client uploads files in chunks.

+ POST /api/submissions/{id}/attachments

4. Shows upload progress.

5. Client can later:

+ List files: GET /api/submissions/{id}/attachments

+ Download files: GET /api/attachments/{id}

- For production the best way is to add cloud storage integration.

# Form Submission Application

## Overview
A full-stack application for submitting web forms with storage, listing, and search capabilities. Built with Vue.js frontend and ASP.NET Core backend.

## Features
- Dynamic form submission with validation

- Form data storage with flexible schema

- Submission listing and search UI

- Single-page application architecture

- Production-ready build process

## Technologies
### Frontend
+ Vue 3 - Reactive JavaScript framework

+ Vite - Next-generation frontend tooling

+ Axios - HTTP client for API communication

+ CSS3 - Modern styling with Flexbox

### Backend
+ ASP.NET Core - Web API framework

+ In-Memory Database - Lightweight data storage

+ RESTful API - JSON-based endpoints
 
+ CORS - Cross-origin resource sharing

## Setup Instructions
### Prerequisites
- Node.js (v16+ recommended)

- .NET 9 SDK

- Code editor (VS Code or Visual Studio recommended)

## Installation
1. Clone the repository.
2. Install frontend dependencies: 

+ cd FormSubmissionApp/ClientApp
+ npm install

3. Restore backend packages:

+ cd FormSubmissionApp
+ dotnet restore

## Development
### Running Locally
1. Start the backend API:

+ cd FormSubmissionApp
+ dotnet run
+ (API available at http://localhost:5182)

2. Start the frontend development server:

+ cd FormSubmissionApp/ClientApp
+ npm run dev
+ (App available at http://localhost:5173)

## Building for Production
1. Build the frontend:

+ cd FormSubmissionApp/ClientApp
+ npm run build
+ This creates optimized assets in /frontend/dist

2. Deploy to backend wwwroot:

+ copy the folder *dist* from ClientApp to *wwwroot* in backend

## API Endpoints
- POST /api/submissions - Submit new form data

- GET /api/submissions - List all submissions

- GET /api/submissions/search?query={searchTerm} - Search submissions
