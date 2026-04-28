# 🎓 Umoja Learning Management System (ULMS) WinForms App

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![Windows Forms](https://img.shields.io/badge/WindowsForms-DesktopApp-blue)
![C#](https://img.shields.io/badge/C%23-Developer-green)
![Visual Studio](https://img.shields.io/badge/IDE-VisualStudio-orange)
![Status](https://img.shields.io/badge/Status-In%20Progress-blue)
![License](https://img.shields.io/badge/License-Portfolio-lightgrey)
# ULMS WinForms App Client

## Overview

**ULMS WinForms App Client** is a C# Windows Forms desktop application developed using **Visual Studio (.NET Desktop)**.
The application simulates a simple **User Learning Management System (ULMS)** that allows users to:

* Login securely
* Navigate through a dashboard
* Register students
* View reports
* Logout safely from the system

This project demonstrates practical skills in:

* Windows Forms GUI development
* Event-driven programming
* Form navigation
* Input validation
* Software structure organization
* GitHub version control integration


# Application Features

### Login Module

Allows users to authenticate before accessing the system dashboard.

Features:

* Username input
* Password input
* Login validation logic
* Error handling messages


### Dashboard Module

Acts as the system navigation center.

Users can:

* Open Student Registration form
* Open Reports form
* Logout safely


### Student Registration Module

Allows capturing student information.

Features include:

* Student name entry
* Data validation
* Registration confirmation messages
* Navigation back to dashboard


### Reports Module

Displays system-generated report information.

Example functionality:

* View stored data summary
* Display system activity
* Simulated reporting interface


### Logout Module

Safely returns the user to the login screen.

Improves usability and system control.


# Technologies Used

| Technology               | Purpose                          |
| ------------------------ | -------------------------------- |
| C#                       | Application programming language |
| .NET Windows Forms       | Desktop UI framework             |
| Visual Studio 2026       | Development environment          |
| GitHub                   | Version control & submission     |
| Event-driven programming | UI interaction handling          |



# Project Structure


<img width="486" height="1028" alt="image" src="https://github.com/user-attachments/assets/e22785bf-c392-4680-bb67-5c477d497b3d" />


# System Requirements

Before running the project, install:

* Windows OS
* Visual Studio 2022 or later (Visual Studio 2026 recommended)
* .NET Desktop Development workload enabled

To install workload:


Visual Studio Installer → Modify → Select .NET Desktop Development


# How to Run the Project

Follow these steps carefully.

## Step 1 — Clone the Repository

Open Command Prompt or Git Bash:

git clone https://github.com/lusuJR/ULMSWinFormsAppClient.git


## Step 2 — Open the Solution

Open Visual Studio

Select:

Open a project or solution

Then open:

ULMSWinFormsAppClient.sln

## Step 3 — Restore Dependencies

Visual Studio will automatically restore project dependencies.

Wait until the solution loads completely.

## Step 4 — Build the Solution

Click:


Build → Build Solution

or press:

CTRL + SHIFT + B


Ensure there are **no errors**.

## Step 5 — Run the Application

Click:


Start


or press:

F5

To run without debugging:


CTRL + F5


# Application Navigation Flow

Login Screen
     ↓
Dashboard
     ↓
Student Registration
     ↓
Reports
     ↓
Logout → Return to Login Screen

# Screenshots Example structure

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/d5a1058d-4a14-43b1-ba70-9cee13c3f859" />

# Learning Outcomes Demonstrated

This project demonstrates understanding of:

* Windows Forms UI controls
* Button click event handling
* Form navigation logic
* Input validation techniques
* Structured application design
* GitHub repository management
* Software testing scenario preparation

# Common Errors and Fixes

### Form does not open

Check button click event:

btnRegister_Click()

Ensure correct form name:

StudentRegistrationForm frm = new StudentRegistrationForm();
frm.Show();

### Project does not run

Verify:
.NET Desktop Development workload installed

### Build errors appear

Try:
Build → Clean Solution
Build → Rebuild Solution

# Author

Developed by

**Lusukama Selemani**

ICT Senior Lecturer

Microsoft Certified Trainer (MCT)

Software Development Instructor


# License

This project is developed for **educational and assessment purposes only**.
