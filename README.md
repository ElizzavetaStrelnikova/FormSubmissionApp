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

## Project Structure
form-submission-app/
├── backend/                  # ASP.NET Core Web API
│   ├── Controllers/          # API endpoints
│   ├── Services/             # Business logic
│   ├── Models/               # 
│   ├── Program.cs            # Application entry point
│   └── appsettings.json      # Configuration
├── frontend/                 # Vue.js application
│   ├── public/               # Static assets
│   ├── src/                  # Application code
│   │   ├── components/       # Vue components
│   │   ├── App.vue           # Root component
│   │   └── main.js           # Application entry
│   ├── package.json          # Frontend dependencies
│   └── vite.config.js        # Build configuration
└── README.md                 # Project documentation

## Setup Instructions
### Prerequisites
- Node.js (v16+ recommended)

- .NET 9 SDK

- Code editor (VS Code or Visual Studio recommended)

## Installation
1. Clone the repository.
2. Install frontend dependencies: 

cd FormSubmissionApp/ClientApp
npm install

3. Restore backend packages:

cd FormSubmissionApp
dotnet restore

## Development
### Running Locally
1. Start the backend API:

cd FormSubmissionApp
dotnet run
(API available at http://localhost:5182)

2. Start the frontend development server:

cd FormSubmissionApp/ClientApp
npm run dev
(App available at http://localhost:5173)

## Building for Production
1. Build the frontend:

cd FormSubmissionApp/ClientApp
npm run build
This creates optimized assets in /frontend/dist

2. Deploy to backend wwwroot:

copy the folder *dist* from ClientApp to *wwwroot* in backend

## API Endpoints
- POST /api/submissions - Submit new form data

- GET /api/submissions - List all submissions

- GET /api/submissions/search?query={searchTerm} - Search submissions
