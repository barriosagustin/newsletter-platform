# newsletter-platform

A modern full-stack newsletter SaaS platform built with **.NET, PostgreSQL, React/Next.js, Docker, and cloud-native architecture principles**.

The idea behind this project came from a personal frustration with endless social media scrolling and information overload.

Instead of consuming fragmented content through algorithms, notifications, and infinite feeds, I wanted a cleaner and more intentional way to stay informed.

The goal of this platform is simple:

> Receive a personalized weekly newsletter containing only the most relevant news about topics you actually care about.

No doomscrolling.
No distractions.
No wasted time.

Users can choose their favorite topics (AI, technology, finance, startups, etc.), and the platform automatically collects, processes, and delivers curated news directly to their inbox.

---

# Architecture Overview

```txt id="arch1"
Frontend (Next.js + TypeScript)
        ↓
.NET 8 REST API
        ↓
PostgreSQL
        ↓
Hangfire Background Jobs
        ↓
RSS News Ingestion
        ↓
Newsletter Generation
        ↓
Email Delivery System
```

---

# Tech Stack

## Frontend

* React
* Next.js
* TypeScript
* TailwindCSS

## Backend

* .NET 8 Web API
* Entity Framework Core
* JWT Authentication
* Hangfire Scheduler

## Database

* PostgreSQL

## Infrastructure

* Docker
* Docker Compose

## Email System

* Mailtrap (development/testing)
* Future production providers:

  * SendGrid
  * AWS SES
  * Resend

## Future Integrations

* Stripe subscriptions
* AI-generated summaries
* Cloud deployment
* CI/CD pipelines

---

# Features

## Authentication & Authorization

* JWT-based authentication
* Secure login/register flow
* Protected API endpoints
* Role-based architecture ready

---

## Personalized Topics System

Users can:

* choose topics they care about
* subscribe/unsubscribe dynamically
* receive customized newsletters

Implemented using a many-to-many relationship between:

* Users
* Topics

---

## Automated News Ingestion

The platform periodically fetches news from external RSS feeds and stores them in PostgreSQL.

Current ingestion includes:

* AI news
* technology news

This architecture allows adding:

* financial news
* crypto
* startups
* sports
* custom categories

with minimal changes.

---

## Background Job Processing

The application uses Hangfire for production-grade recurring jobs.

This includes:

* scheduled RSS ingestion
* automated newsletter delivery
* retry mechanisms
* persistent jobs stored in PostgreSQL
* monitoring dashboard

---

## Newsletter Delivery System

The backend dynamically generates personalized HTML newsletters and sends them through an SMTP provider.

Current implementation:

* Mailtrap sandbox environment

Production-ready providers planned:

* SendGrid
* AWS SES
* Resend

---

# Why .NET?

I decided to use .NET for this project because I wanted to expand beyond frontend development and gain hands-on experience with backend and cloud-oriented architecture.

.NET provides:

* strong typing
* excellent performance
* enterprise-level tooling
* scalable APIs
* dependency injection
* background processing
* mature ecosystem

This project helped me understand how real-world backend systems are structured and deployed.

---

# What I Learned Through This Project

## Backend Development

* REST API architecture
* Entity Framework Core
* relational database modeling
* dependency injection
* authentication flows
* DTO patterns
* service architecture

---

## Infrastructure & DevOps

* Docker containers
* PostgreSQL setup
* environment configuration
* background workers
* recurring jobs
* SMTP integrations

---

## Full-Stack Architecture

* frontend/backend separation
* API communication
* authentication flow between client and server
* scalable SaaS architecture concepts

---

# Current Status

## Implemented

* .NET backend
* PostgreSQL integration
* Dockerized local environment
* JWT authentication
* Topic subscription system
* RSS ingestion
* Hangfire jobs
* Email delivery sandbox
* Personalized newsletter generation

---

## In Progress

* Next.js frontend
* dashboard UI
* topic management UI
* newsletter preferences

---

## Planned

* CI/CD with GitHub Actions
* Cloud deployment
* Stripe subscriptions
* AI-generated summaries
* monitoring/logging
* production email infrastructure
* environment secrets management
* rate limiting
* analytics

---

# Local Development

## Requirements

* Docker Desktop
* .NET 8 SDK
* Node.js
* PostgreSQL (via Docker)

---

## Run PostgreSQL

```bash id="runpg1"
docker compose up -d
```

---

## Run Backend

```bash id="runbe1"
cd backend
dotnet run
```

Swagger:

```txt id="swagger1"
http://localhost:5265/swagger
```

Hangfire Dashboard:

```txt id="hangfire1"
http://localhost:5265/hangfire
```

---

## Run Frontend

```bash id="runfe1"
cd frontend
npm install
npm run dev
```

---

# Future Vision

The long-term vision for this project is to evolve into a fully production-ready SaaS platform capable of delivering highly personalized, low-noise information experiences.

Potential future ideas:

* AI-generated summaries
* semantic topic clustering
* recommendation systems
* mobile app
* browser extension
* premium subscriptions
* multilingual newsletters

---

# Author

Built by [Agustín Barrios](https://www.agustinbarriosweb.com?utm_source=chatgpt.com)

* [LinkedIn](https://www.linkedin.com/in/agustin-barrios-/?skipRedirect=true)
* [GitHub](https://github.com/barriosagustin))
