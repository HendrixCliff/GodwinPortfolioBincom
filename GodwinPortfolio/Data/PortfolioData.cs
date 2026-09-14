using GodwinPortfolio.Models;

namespace GodwinPortfolio.Data;

public static class PortfolioData
{
    public static PortfolioProfile BuildProfile()
    {
        return new PortfolioProfile
        {
            Name = "Godwin Chukwuebuka Igwegbe",
            Title = "Backend Developer & DevOps Engineer",
            Summary =
                "Results-driven Backend & DevOps Engineer specializing in ASP.NET Core, C#, scalable microservices, containerization, CI/CD automation and application observability.",
            Location = "Ajah, Lagos, Nigeria",
            Email = "godwincliff10@gmail.com",
            Phone = "09075948313",
            GitHub = "https://github.com/HendrixCliff",
            PortfolioUrl =
                "https://godwin-portfolio-ivory.vercel.app/",
            Education =
                "Bachelor of Engineering: Civil Engineering — Chukwuemeka Odumegwu Ojukwu University, Uli, Anambra State."
        };
    }

    public static List<Experience> BuildExperience()
    {
        return
        [
            new Experience
            {
                Company = "Independent Backend Developer",
                Role = "Backend Developer & DevOps Engineer",
                Period = "July 2024 - Present",
                Description =
                    "Developing scalable backend systems and cloud-native applications with modern .NET and DevOps practices.",
                Highlights =
                [
                    "Architected applications using Clean Architecture.",
                    "Implemented CQRS with MediatR.",
                    "Built JWT authentication and role-based authorization.",
                    "Designed PostgreSQL databases using Entity Framework Core.",
                    "Integrated Paystack payment workflows.",
                    "Integrated Cloudinary for media storage.",
                    "Implemented SMTP email notifications.",
                    "Built RESTful APIs with validation and pagination.",
                    "Integrated Google Gemini AI features.",
                    "Containerized applications using Docker and Docker Compose.",
                    "Configured GitHub Actions CI/CD pipelines.",
                    "Implemented monitoring using Prometheus, Grafana and Seq.",
                    "Deployed applications to AWS EC2.",
                    "Configured Linux systemd services.",
                    "Implemented Redis caching."
                ],
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Redis",
                    "Docker",
                    "GitHub Actions",
                    "AWS EC2",
                    "Prometheus",
                    "Grafana",
                    "Seq"
                ]
            }
        ];
    }

    public static List<Project> BuildProjects()
    {
        return
        [
            new Project
            {
                Name = "WorkServices",
                Description =
                    "A service marketplace backend connecting customers with skilled artisans. The platform provides secure authentication, payments, media management, AI-powered recommendations and scalable RESTful APIs.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Clean Architecture",
                    "CQRS",
                    "MediatR",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Redis",
                    "JWT",
                    "Paystack",
                    "Cloudinary",
                    "Docker",
                    "Docker Compose",
                    "GitHub Actions",
                    "AWS EC2",
                    "Google Gemini AI",
                    "Prometheus",
                    "Grafana",
                    "Seq"
                ]
            },

            new Project
            {
                Name = "PayVault",
                Description =
                    "A financial application designed to support savings and loan-dispensing workflows, with a backend architecture focused on secure financial transactions, data integrity and maintainability.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL"
                ]
            },

            new Project
            {
                Name = "GrowthPilot",
                Description =
                    "An intelligent business growth platform that analyzes uploaded business reports, extracts financial and customer metrics, identifies business trends and generates actionable growth insights and tasks.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Clean Architecture",
                    "CQRS",
                    "MediatR",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Cloudflare R2",
                    "AWS S3 SDK",
                    "Redis",
                    "Docker",
                    "GitHub Actions",
                    "Prometheus",
                    "Grafana",
                    "Seq",
                    "Swagger/OpenAPI"
                ]
            },

            new Project
            {
                Name = "MooreHotelAndSuites",
                Description =
                    "Hotel management backend supporting reservations, customer management, authentication and administrative operations.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "JWT",
                    "Cloudinary",
                    "SMTP"
                ]
            }
        ];
    }

    public static List<SkillGroup> BuildSkills()
    {
        return
        [
            new SkillGroup
            {
                Category = "Backend Engineering",
                Skills =
                [
                    "C#",
                    "ASP.NET Core",
                    "Node.js",
                    "NestJS",
                    "RESTful APIs",
                    "GraphQL",
                    "Dependency Injection",
                    "JWT Authentication"
                ]
            },

            new SkillGroup
            {
                Category = "Databases",
                Skills =
                [
                    "PostgreSQL",
                    "MongoDB",
                    "Entity Framework Core",
                    "TypeORM",
                    "Redis"
                ]
            },

            new SkillGroup
            {
                Category = "DevOps & Cloud",
                Skills =
                [
                    "Docker",
                    "Docker Compose",
                    "GitHub Actions",
                    "AWS EC2",
                    "Cloudflare R2",
                    "Linux",
                    "systemd",
                    "Cloud Deployment"
                ]
            },

            new SkillGroup
            {
                Category = "Monitoring",
                Skills =
                [
                    "Prometheus",
                    "Grafana",
                    "Seq",
                    "Application Metrics",
                    "Centralized Logging"
                ]
            },

            new SkillGroup
            {
                Category = "Tools",
                Skills =
                [
                    "Git",
                    "GitHub",
                    "Swagger/OpenAPI",
                    "Postman",
                    "Visual Studio"
                ]
            }
        ];
    }
}