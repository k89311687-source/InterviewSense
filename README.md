# InterviewSense AI

## Overview

InterviewSense AI is a full-stack resume analysis and interview preparation platform developed using React.js, ASP.NET Core Web API, and MongoDB. The application allows users to upload PDF resumes, analyze their skills, calculate an ATS score, identify missing skills, and generate interview questions based on the detected skill set.

## Features

* Upload PDF resumes
* Extract text from resumes
* ATS score calculation
* Skill identification and analysis
* Missing skill detection
* Interview question generation
* REST API integration
* MongoDB database connectivity

## Technology Stack

### Frontend

* React.js
* JavaScript
* HTML
* CSS

### Backend

* ASP.NET Core Web API
* C#

### Database

* MongoDB

### Libraries

* PdfPig
* MongoDB.Driver

### Concepts

* REST APIs
* Client-Server Architecture
* File Upload Handling
* PDF Processing
* JSON Serialization

## Project Architecture

React Frontend

↓

ASP.NET Core Web API

↓

Resume Analysis Engine

↓

MongoDB Database

## How to Run

### Backend

```bash
cd InterviewSenseAPI
dotnet restore
dotnet run
```

### Frontend

```bash
cd interviewsense-ui
npm install
npm start
```

## Future Enhancements

* JWT Authentication
* Cloud Storage Integration
* AI-based Skill Recommendations
* Resume History Dashboard
* Deployment using Cloud Platforms

## Author

Aishwarya K
